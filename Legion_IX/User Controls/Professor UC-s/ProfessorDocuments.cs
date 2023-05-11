using Legion_IX.DataFiles;
using Legion_IX.Helpers;
using Microsoft.AspNet.SignalR.Messaging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legion_IX.User_Controls.Professor_UC_s
{
    public partial class ProfessorDocuments : UserControl
    {
        #region Global vars

        // Variable that hold the chosen options from `comboBox_Subjects` as string (obviously)
        public string? ChosenSubject { get; set; }

        // PDF file
        PDF_File? pdf;

        // RAR file
        RAR_File? rar;

        // Basically information describing the files stored on Atlas associated with Student
        List<AtlasFile> AtlasFiles = new List<AtlasFile>();

        // Reference Variable to the Dictionary of Faculty years and their respective List of Subjects
        Dictionary<string, List<string>> profSubjects = LoggedInProfessor.theProf.SubjectsTeaching;

        // This list holds indexes of faculty years in `comboBox_Subjects` and will be ingored in `comboBox_Subjects_SelectedIndexChanged` event handler
        List<int> comboBox_IgnoreOptionIndex = new List<int>();

        /*          Class properties for `dgv_Files_DragDrop` Event         */

        // List of `AtlasFile` objects that were dropped on `dgv_Files` in purpose of upload
        List<AtlasFile> AtlasFiles_Dropped = new List<AtlasFile>();

        // Indexes of `AtlasFile` objects inside `AtlasFiles_Dropped` that contain a supported extension
        List<int> IndexesOfValidDroppedFiles = new List<int>();

        #endregion Global vars


        internal ProfessorDocuments()
        {
            InitializeComponent();
        }


        // UC `OnLoad` event
        private void ProfessorDocuments_Load(object sender, EventArgs e)
        {
            this.Hide();

            this.ParentForm.FormClosing += SignalThe_CancellationToken;

            Hide_Or_Show_DragDropButtons(false);

            // Loading the list of subjects to comboBox
            LoadToComboBoxSubjects();

            RegisteringClassMap_PDF();
            RegisteringClassMap_RAR();

            dgv_Files.AutoGenerateColumns = false;
            dgv_Files.DataSource = null;
        }


        // Method that will signal a static, global `CancellationToken` that the form is closing and the `Task` should be cancelled
        private void SignalThe_CancellationToken(object? sender, FormClosingEventArgs e)
        {
            RequestCancel.killProccess.Cancel();
        }


        // Shows buttons if DragDrop event is triggered
        private void Hide_Or_Show_DragDropButtons(bool show)
        {
            btn_CancelDrop.Visible = show;
            btn_RemoveUnsupported.Visible = show;

            lbl_Info.Visible = show;
        }


        // Registering `PDF_File` to support MongoDB Bson serialisation
        private void RegisteringClassMap_PDF()
        {
            try
            {
                BsonClassMap.RegisterClassMap<PDF_File>(cm => cm.AutoMap());
            }

            catch (Exception ex)
            {
                string expectedMessageIfRegistered = "An item with the same key has already been added. Key: Legion_IX.DataFiles.PDF_File";

                if (ex is System.ArgumentException && (ex as System.ArgumentException).Message == expectedMessageIfRegistered)
                    return;

                MessageBox.Show("Failed!", "Class PDF_File NOT Registered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        // Registering `RAR_File` to support MongoDB Bson serialisation
        private void RegisteringClassMap_RAR()
        {
            try
            {
                BsonClassMap.RegisterClassMap<RAR_File>(cm => cm.AutoMap());
            }

            catch (Exception ex)
            {
                string expectedMessageIfRegistered = "An item with the same key has already been added. Key: Legion_IX.DataFiles.RAR_File";

                if (ex is System.ArgumentException && ex.Message == expectedMessageIfRegistered)
                    return;

                MessageBox.Show("Failed!", "Class RAR_File NOT Registered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        // Loading subjects to ComboBox
        private void LoadToComboBoxSubjects()
        {
            foreach (string key in profSubjects.Keys)
            {
                comboBox_Subjects.Items.Add(TidyFacultyYear(key));
                comboBox_IgnoreOptionIndex.Add(comboBox_Subjects.Items.Count - 1);

                for (int i = 0; i < profSubjects[key].Count; i++)
                    comboBox_Subjects.Items.Add(profSubjects[key][i]);

                comboBox_Subjects.Items.Add("");
                comboBox_IgnoreOptionIndex.Add(comboBox_Subjects.Items.Count - 1); /* Adding index of the previously added empty space which will be ignored*/
            }

            // This line is used to remove the last empty space added to `comboBox_Subjects`, I hardcoded because it's faster than checking with an `if` statement while iterating
            comboBox_Subjects.Items.RemoveAt(comboBox_Subjects.Items.Count - 1);
        }


        // Changes the faculty year to a more readable format
        private string TidyFacultyYear(string facultyYear)
        {
            switch (facultyYear)
            {
                case "FirstYear": return "--- First Year ---";
                case "SecondYear": return "--- Second Year ---";
                case "ThirdYear": return "--- Third Year ---";
                case "FourthYear": return "--- Fourth Year ---";

                default: return "";
            }
        }


        // Evenet handler for `comboBox_Subjects` in case an option has been changed
        private async void comboBox_Subjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox_IgnoreOptionIndex.Contains(comboBox_Subjects.SelectedIndex))
            {
                ChosenSubject = (string)comboBox_Subjects.SelectedItem;

                await GetAvailableDocuments(/* This method returns Documents based on the ChosenSubject */);

                btn_Refresh_Click(sender, e);
            }
        }


        // Loading documents to `dgv_Files` based on the chosen subject from `comboBox_Subjects`
        private void LoadDocumentsTo_dgv()
        {
            dgv_Files.DataSource = null;

            if (AtlasFiles.Count > 0)
                dgv_Files.DataSource = AtlasFiles;
        }


        // Getting documents from Atlas based on the chosen subject from `comboBox_Subjects`
        private async Task GetAvailableDocuments()
        {
            List<BsonDocument> pipeline = new List<BsonDocument>()
                {
                    new BsonDocument("$project", new BsonDocument
                    {
                        {"NameOfFile", 1},
                        {"FileType", 1},
                        {"TimeStamp_Creation", 1}
                    })
                };

            IAsyncCursor<BsonDocument> documents = await LoggedInProfessor.theProf.ProfessorAtlasAccess.Client.
                GetDatabase(Get_YearOfSubject()).GetCollection<BsonDocument>(ChosenSubject).AggregateAsync<BsonDocument>(pipeline);

            ExtractSubjectsFromBsonDocuments_To_AtlasFiles(in documents);

            LoadDocumentsTo_dgv();
        }


        // !!! OVERLOADED !!! Getting documents from Atlas based on the chosen subject from `comboBox_Subjects`
        private async Task GetAvailableDocuments(string Year)
        {
            List<BsonDocument> pipeline = new List<BsonDocument>()
                {
                    new BsonDocument("$project", new BsonDocument
                    {
                        {"NameOfFile", 1},
                        {"FileType", 1},
                        {"TimeStamp_Creation", 1}
                    })
                };

            IAsyncCursor<BsonDocument> documents = await LoggedInProfessor.theProf.ProfessorAtlasAccess.Client.
                GetDatabase(Year).GetCollection<BsonDocument>(ChosenSubject).AggregateAsync<BsonDocument>(pipeline);

            ExtractSubjectsFromBsonDocuments_To_AtlasFiles(in documents);

            LoadDocumentsTo_dgv();
        }


        // Gets the year of the `ChosenSubject` from the `profSubjects` Dictionary
        private string Get_YearOfSubject()
        {
            string Year_DB = "";
            foreach (string facultyYear in profSubjects.Keys)
            {
                if (profSubjects[facultyYear].Contains(ChosenSubject))
                {
                    Year_DB = facultyYear;
                    break;
                }
            }

            return Year_DB;
        }


        // Extracts from `BsonDocument` and adds the documents to `List<AtlasFile> AtlasFiles`
        private void ExtractSubjectsFromBsonDocuments_To_AtlasFiles(in IAsyncCursor<BsonDocument> documents)
        {
            if (AtlasFiles.Count > 0)
                AtlasFiles.Clear();

            foreach (BsonDocument document in documents.ToList())
            {
                if (document.GetValue("FileType") == ".pdf")
                    AtlasFiles.Add(new AtlasFile(in document));

                else if (document.GetValue("FileType") == ".rar")
                    AtlasFiles.Add(new AtlasFile(in document));
            }
        }


        // Event handler for `dgv_Files` in case a button belonging to DGV has been clicked
        private async void dgv_Files_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_Files.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // Getting the `_id` ; `NameOfFile` and `theExtension` properties from the object in the Cell Column
                AtlasFile FileInCell = GetAtlasFileDataFromCell(e);

                DataGridViewButtonColumn? dgv_button = dgv_Files.Columns[e.ColumnIndex] as DataGridViewButtonColumn;

                if (dgv_button?.Name == "View")
                    await dgv_ViewButtonClicked(FileInCell._id, FileInCell.NameOfFile, FileInCell.FileType);

                else if (dgv_button?.Name == "Delete")
                    await dgv_DeleteButtonClicked(FileInCell._id, FileInCell.NameOfFile, FileInCell.FileType);
            }
        }


        // Gets all properties of clicked cell and returns them as an `AtlasFile` object
        private AtlasFile GetAtlasFileDataFromCell(DataGridViewCellEventArgs e)
        {
            return new AtlasFile(

            (dgv_Files.Rows[e.RowIndex].DataBoundItem as AtlasFile)?.GetID() ?? ObjectId.Empty,
            (dgv_Files.Rows[e.RowIndex].DataBoundItem as AtlasFile)?.GetNameOfFile() ?? string.Empty,
            (dgv_Files.Rows[e.RowIndex].DataBoundItem as AtlasFile)?.GetFileType() ?? string.Empty,
            (dgv_Files.Rows[e.RowIndex].DataBoundItem as AtlasFile).GetTimeStamp_Creation()

                );
        }


        // Method called if the button clicked in `dgv_Files` is `View`
        private async Task dgv_ViewButtonClicked(ObjectId? theDocID, string theDocName, string theExtension)
        {
            if (theExtension == ".pdf")
            {
                await PDF_File_WriteToFileAndOpen(theDocID, theDocName, theExtension);
            }

            else if (theExtension == ".rar")
            {
                await RAR_File_WriteToFileAndOpen(theDocID, theDocName, theExtension);
            }
        }


        // Method called if the button clicked in `dgv_Files` is `Delete`
        private async Task dgv_DeleteButtonClicked(ObjectId? theDocID, string theDocName, string theExtension)
        {
            FilterDefinition<BsonDocument> filterToDoc = Builders<BsonDocument>.Filter.Eq("_id", theDocID);
            filterToDoc &= Builders<BsonDocument>.Filter.Eq("NameOfFile", theDocName);
            filterToDoc &= Builders<BsonDocument>.Filter.Eq("FileType", theExtension);

            string Year;

            await LoggedInProfessor.theProf.ProfessorAtlasAccess.Client.
                GetDatabase(Year = Get_YearOfSubject()).
                GetCollection<BsonDocument>(ChosenSubject).
                DeleteOneAsync(filterToDoc);

            await GetAvailableDocuments(Year);
        }


        // Writes PDF binary data to a temporary file and opens for viewing
        private async Task PDF_File_WriteToFileAndOpen(ObjectId? theDocID, string theDocName, string theExtension)
        {
            // Getting the PDF
            pdf = await GetFile_PDF(theDocID, theDocName, theExtension);

            // Check to see if `GetFile()` method has returned null
            if (pdf != null)
            {
                // Creating teporary filepath for the PDF to be stored for later viewing
                string tempFilePath = Path.GetTempFileName();

                // Writing the PDF to that file
                if (pdf.BinData != null && Default_BrowserDirectory.CheckIfDefaultBrowserSet())
                {

                    try
                    {

                        File.WriteAllBytes(tempFilePath, pdf.BinData);

                        // Creating a Process for starting the Browser
                        ProcessStartInfo psi = new ProcessStartInfo();
                        psi.FileName = Default_BrowserDirectory.DefaultBrowser;
                        psi.Arguments = tempFilePath;

                        // Starting the browser with PDF binary Data to read
                        Process.Start(psi);

                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Failed to open Preview! Make sure you assigned the correct directory to browser of your choice in settings.",
                                        "--- Failed to Open preview ---",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation
                                        );
                    }

                }

                else
                    MessageBox.Show("Problem encountered", "At `dgv_Files_CellContentClick()` `pdf.BinData` was null!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Writes RAR binary data to a temporary file and opens for viewing
        private async Task RAR_File_WriteToFileAndOpen(ObjectId? theDocID, string theDocName, string theExtension)
        {
            // Getting the RAR
            rar = await GetFile_RAR(theDocID, theDocName, theExtension);

            // Check to see if `GetFile()` method has returned null
            if (rar != null)
            {
                // Creating teporary filepath for the RAR to be stored for later viewing
                string tempFilePath = Path.GetTempFileName();

                // Writing the PDF to that file
                if (rar.BinData != null && CheckIfWinrarDirectoryAssigned())
                {

                    try
                    {

                        File.WriteAllBytes(tempFilePath, rar.BinData);

                        // Creating a Process for starting the Browser
                        ProcessStartInfo psi = new ProcessStartInfo();
                        psi.FileName = Default_WinRAR_Directory.WinRAR_Directory;
                        psi.Arguments = tempFilePath;

                        // Starting the browser with PDF binary Data to read
                        Process.Start(psi);

                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Failed to open Preview! Make sure you assigned the correct directory to `WinRAR.exe` in settings.",
                                        "--- Failed to Open preview ---",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation
                                        );

                    }

                }

                else
                    MessageBox.Show("Problem encountered", "At `dgv_Files_CellContentClick()` `rar.BinData` was null!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Getting the chosen PDF file via Server-Side filtering
        private async Task<PDF_File> GetFile_PDF(ObjectId? theDocID, string theDocName, string theExtension)
        {
            if (!ChosenSubject.IsNullOrEmpty() && theDocID != ObjectId.Empty && theDocName != null && theExtension != null)
            {

                // Creating the pipeline for Server-Side filtering
                List<BsonDocument> pipeline = new List<BsonDocument>()
                    {
                        new BsonDocument( "$match" , new BsonDocument("_id", theDocID)),
                        new BsonDocument( "$match" , new BsonDocument("NameOfFile", theDocName)),
                        new BsonDocument( "$match" , new BsonDocument("FileType", theExtension))
                    };

                // Getting the filtered document
                IAsyncCursor<BsonDocument> theDoc = await LoggedInProfessor.theProf.ProfessorAtlasAccess.Client.
                    GetDatabase(Get_YearOfSubject()).
                    GetCollection<BsonDocument>(ChosenSubject).
                    AggregateAsync<BsonDocument>(pipeline);

                BsonDocument extracted = theDoc.FirstOrDefault();
                PDF_File newFile = BsonSerializer.Deserialize<PDF_File>(extracted);

                // Returning Finished Proccessed document
                return new PDF_File(newFile);

            }

            return new PDF_File();
        }


        // Getting the chosen PDF file via Server-Side filtering
        private async Task<RAR_File> GetFile_RAR(ObjectId? theDocID, string theDocName, string theExtension)
        {
            if (!ChosenSubject.IsNullOrEmpty() && theDocID != ObjectId.Empty && theDocName != null && theExtension != null)
            {

                // Creating the pipeline for Server-Side filtering
                List<BsonDocument> pipeline = new List<BsonDocument>()
                    {
                        new BsonDocument( "$match" , new BsonDocument("_id", theDocID)),
                        new BsonDocument( "$match" , new BsonDocument("NameOfFile", theDocName)),
                        new BsonDocument( "$match" , new BsonDocument("FileType", theExtension))
                    };

                // Getting the filtered document
                IAsyncCursor<BsonDocument> theDoc = await LoggedInProfessor.theProf.ProfessorAtlasAccess.Client.
                    GetDatabase(Get_YearOfSubject()).
                    GetCollection<BsonDocument>(ChosenSubject).
                    AggregateAsync<BsonDocument>(pipeline);

                BsonDocument extracted = theDoc.FirstOrDefault();
                RAR_File newFile = BsonSerializer.Deserialize<RAR_File>(extracted);

                // Returning Finished Proccessed document
                return new RAR_File(newFile);

            }

            return new RAR_File();
        }


        // Accesses the SQL `.db` to see if WinRAR `.exe` directory exists
        private bool CheckIfWinrarDirectoryAssigned()
        {

            if (!Default_WinRAR_Directory.CheckIfWinRAR_dirSet())
            {
                opf_ChooseDocument.Filter = "Executable files (*.exe)|*.exe";

                if (opf_ChooseDocument.ShowDialog() == DialogResult.OK)
                {
                    Default_WinRAR_Directory.Update_or_Add_WinRAR_ToSQL(opf_ChooseDocument.FileName);

                    Default_WinRAR_Directory.WinRAR_Directory = Default_WinRAR_Directory.GetWinRAR_dir_From_SQL();

                    if (Default_WinRAR_Directory.CheckIfWinRAR_dirSet())
                        return false;

                    return true;
                }

                return false;
            }

            else
                return true;

        }


        // Button evenet for uploading a document to Atlas
        private async void btn_UploadDocument_Click(object sender, EventArgs e)
        {
            if (!ChosenSubject.IsNullOrEmpty())
            {

                // If `AtlasFiles_Dropped` is not empty means files were dropped on `dgv_Files` so different upload method occurs
                if(AtlasFiles_Dropped.Count > 0 && IndexesOfValidDroppedFiles.Count > 0)
                {
                    btn_RemoveUnsupported_Click(sender, e);

                    if (MessageBox.Show($"The following files will be uploaded to: '{ChosenSubject}'", "Files to be uploaded", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SignalUploading();

                        await UploadDroppedFiles();

                        _ = Task.Run(() => lblInfo_InformUser("Files uploaded successfully!", 5));

                        Hide_Or_Show_DragDropButtons(false);

                        await GetAvailableDocuments();
                    }
                }

                else
                {
                    //string opf_ChooseDocumentFilter = "PDF files (*.pdf)|*.pdf|RAR files (*.rar)|*.rar";
                    string opf_ChooseDocumentFilter = "PDF files (.pdf); RAR files (.rar)|*.pdf;*.rar";

                    await InsertFile(opf_ChooseDocumentFilter);
                }

            }
        }

        CancellationTokenSource kill_UploadingMessage = new CancellationTokenSource();
        private void SignalUploading()
        {
            Task.Run(() => lblInfo_Uploading(kill_UploadingMessage.Token));
        }


        // Method that creates a `BsonDocument` list of files to upload and inserts them all to Atlas at once
        private async Task UploadDroppedFiles()
        {
            BsonDocument[] docsToUpload = new BsonDocument[IndexesOfValidDroppedFiles.Count];

            for(int i = 0; i < IndexesOfValidDroppedFiles.Count; i++)
            {

                AtlasFile refOBJ = AtlasFiles_Dropped[i];

                switch(refOBJ.FileType)
                {
                    case ".pdf":
                        PDF_File pdf_Serialized = new PDF_File(in refOBJ, File.ReadAllBytes(refOBJ.PathToFile));
                        docsToUpload[i] = pdf_Serialized.ToBsonDocument();
                        break;

                    case ".rar":
                        RAR_File rar_Serialized = new RAR_File(in refOBJ, File.ReadAllBytes(refOBJ.PathToFile));
                        docsToUpload[i] = rar_Serialized.ToBsonDocument();
                        break;
                }
            }

            await LoggedInProfessor.theProf.ProfessorAtlasAccess.Client.
                GetDatabase(Get_YearOfSubject()).
                GetCollection<BsonDocument>(ChosenSubject).
                InsertManyAsync(docsToUpload);

            kill_UploadingMessage.Cancel();
        }


        // Inserts File into collection chosen from `comboBox Subjects`
        private async Task InsertFile(string filter)
        {
            // Creating a Filter for `OpenFileDialog`
            opf_ChooseDocument.Filter = filter;

            // Continue if chosen file
            if (opf_ChooseDocument.ShowDialog() == DialogResult.OK)
            {

                if (Path.GetExtension(opf_ChooseDocument.FileName) == ".pdf")
                {

                    await toInsert_PDF(
                        Path.GetFileName(opf_ChooseDocument.FileName),
                        Path.GetExtension(opf_ChooseDocument.FileName),
                        File.GetCreationTime(opf_ChooseDocument.FileName),
                        File.ReadAllBytes(opf_ChooseDocument.FileName)
                        );

                }

                else if (Path.GetExtension(opf_ChooseDocument.FileName) == ".rar")
                {

                    await toInsert_RAR(
                        Path.GetFileName(opf_ChooseDocument.FileName),
                        Path.GetExtension(opf_ChooseDocument.FileName),
                        File.GetCreationTime(opf_ChooseDocument.FileName),
                        File.ReadAllBytes(opf_ChooseDocument.FileName)
                        );

                }

                else
                {
                    MessageBox.Show("Unsuported File Selected!", "Supported Files: .pdf | .rar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Showing confirmation message
                MessageBox.Show("Uploaded", "All went fine!", MessageBoxButtons.OK);

                // Refreshing the `DataGridView`
                GetAvailableDocuments();

            }
        }


        // Method that inserts a `PDF_File` into Atlas based on information from `opf_ChooseDocument` in `btn_UploadPdf_Click` method event
        private async Task toInsert_PDF(string fileName, string extension, DateTime timeStamp, byte[] data)
        {
            PDF_File toInsert = new PDF_File(new ObjectId(), fileName, extension, timeStamp, data);

            // Serialising the `PDF_File` object as `BsonDocument`
            BsonDocument converted = toInsert.ToBsonDocument();

            // Inserting serialised document
            await LoggedInProfessor.theProf.ProfessorAtlasAccess.Client.
                GetDatabase(Get_YearOfSubject()).
                GetCollection<BsonDocument>(ChosenSubject).
                InsertOneAsync(converted);
        }


        // Method that inserts a `RAR_File` into Atlas based on information from `opf_ChooseDocument` in `btn_UploadPdf_Click` method event
        private async Task toInsert_RAR(string fileName, string extension, DateTime timeStamp, byte[] data)
        {
            RAR_File toInsert = new RAR_File(new ObjectId(), fileName, extension, timeStamp, data);

            // Serialising the `PDF_File` object as `BsonDocument`
            BsonDocument converted = toInsert.ToBsonDocument();

            // Inserting serialised document
            await LoggedInProfessor.theProf.ProfessorAtlasAccess.Client.GetDatabase(Get_YearOfSubject()).GetCollection<BsonDocument>(ChosenSubject).InsertOneAsync(converted);
        }


        // Event that occurs when files are dropped on the `dgv_Files`
        private void dgv_Files_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }


        // Event that occurs after the files are dropped on the `dgv_Files` and handles how the data is processed
        private void dgv_Files_DragDrop(object sender, DragEventArgs e)
        {
            CheckIf_FilesWereDroppedBefore();

            comboBox_Subjects.SelectedIndexChanged -= comboBox_Subjects_SelectedIndexChanged;

            string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
            string ext; /* reference var */

            foreach (string extension in fileNames)
            {
                ext = Path.GetExtension(extension);

                AtlasFiles_Dropped.Add(GetDropedFileAsAtlas(extension));

                if (ext == ".pdf" || ext == ".rar")
                    IndexesOfValidDroppedFiles.Add(AtlasFiles_Dropped.Count - 1);
            }

            Display_DragDropFilesTo_DGV();
        }


        // Checks the `AtlasFiles_Dropped` list and clears it if it contains any files from previous drop
        private void CheckIf_FilesWereDroppedBefore()
        {
            if (AtlasFiles_Dropped.Count > 0)
            {
                AtlasFiles_Dropped.Clear();
                IndexesOfValidDroppedFiles.Clear();

                dgv_Files.DataSource = null;
            }
        }


        // Returns a `AtlasFile` object based on the file dropped on the `dgv_Files`
        private AtlasFile GetDropedFileAsAtlas(string pathToFile)
        {
            // public AtlasFile(string nameOfFile, string fileType, DateTime timeStamp, string pathToFile)
            return new AtlasFile
                (
                Path.GetFileName(pathToFile),
                Path.GetExtension(pathToFile),
                File.GetCreationTime(pathToFile),
                pathToFile
                );
        }


        // Displays the dropped files on the `dgv_Files`
        private void Display_DragDropFilesTo_DGV()
        {
            if (AtlasFiles_Dropped.Count > 0)
            {
                dgv_Files.DataSource = null;
                dgv_Files.DataSource = AtlasFiles_Dropped;
            }

            PaintValidFiles(Color.Green);

            lblInfo_InformUser(true, "Files in Green are valid for upload!");
            dgv_Files.KeyDown += EscapeKey_Pressed;

            Hide_Or_Show_DragDropButtons(true);
        }


        // Paints the valid files in the `dgv_Files` with the specified color
        private void PaintValidFiles(Color color)
        {
            foreach (int index in IndexesOfValidDroppedFiles)
                dgv_Files.Rows[index].DefaultCellStyle.BackColor = Color.Green;
        }


        // Event that occurs when an `ESC` key is pressed while the `dgv_Files` is selected
        private void EscapeKey_Pressed(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && AtlasFiles_Dropped.Count > 0)
            {
                dgv_Files.DataSource = null;

                AtlasFiles_Dropped.Clear();
                IndexesOfValidDroppedFiles.Clear();

                if (AtlasFiles.Count > 0)
                    dgv_Files.DataSource = AtlasFiles;

                comboBox_Subjects.SelectedIndexChanged += comboBox_Subjects_SelectedIndexChanged;

                if (!ChosenSubject.IsNullOrEmpty())
                    comboBox_Subjects.SelectedItem = ChosenSubject;

                lblInfo_InformUser(false, "");
                Hide_Or_Show_DragDropButtons(false);

                dgv_Files.KeyDown -= EscapeKey_Pressed;
            }
        }


        // Button event for refreshing DGV datasource
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            // Resetting the `dgv_files` DataSource property to null
            dgv_Files.DataSource = null;

            // Loading fresh data based on choice from `comboBox_Subjects`
            LoadDocumentsTo_dgv();
        }


        // Calls method to remove invalid files from `AtlasFiles_Dropped` list and refreshes the `dgv_Files` datasource with valid files only
        private void btn_RemoveUnsupported_Click(object sender, EventArgs e)
        {
            if (AtlasFiles_Dropped.Count > 0)
            {
                FilterDroppedFiles();

                dgv_Files.DataSource = null;
                dgv_Files.DataSource = AtlasFiles_Dropped;

                PaintValidFiles(Color.Green);
            }
        }


        // Removes all files from `AtlasFiles_Dropped` that are not supported by the application for upload to Atlas
        private void FilterDroppedFiles()
        {
            List<AtlasFile> atlasFiles_Filtered = new List<AtlasFile>();
            List<int> indexes = new List<int>();

            foreach (int index in IndexesOfValidDroppedFiles)
            {
                atlasFiles_Filtered.Add(new AtlasFile(AtlasFiles_Dropped[index], true));
                indexes.Add(atlasFiles_Filtered.Count - 1);
            }

            AtlasFiles_Dropped.Clear();
            IndexesOfValidDroppedFiles.Clear();

            AtlasFiles_Dropped = new List<AtlasFile>(atlasFiles_Filtered);
            IndexesOfValidDroppedFiles = new List<int>(indexes);
        }


        // `btn_CancelDrop` event is the same as `EscapeKey_Pressed` event, so it calls it
        private void btn_CancelDrop_Click(object sender, EventArgs e) => EscapeKey_Pressed(sender, new KeyEventArgs(Keys.Escape));


        // Universal method for informing the user of current status
        private void lblInfo_InformUser(bool showLabel, string message)
        {
            lbl_Info.Visible = showLabel;
            lbl_Info.Text = message;
        }


        // Universal method for informing the user of current status
        /* What a fucking mess... */
        private async Task lblInfo_InformUser(string message, int blinkTimes)
        {
            RequestCancel.killProccess.Token.ThrowIfCancellationRequested();

            this.Invoke(() => { lbl_Info.Visible = true; });
            this.Invoke(() => { lbl_Info.Text = message; });

            RequestCancel.killProccess.Token.ThrowIfCancellationRequested();

            for (int i = 0; i < blinkTimes; i++)
            {
                RequestCancel.killProccess.Token.ThrowIfCancellationRequested();

                this.Invoke(() => { lbl_Info.ForeColor = Color.Green; });

                RequestCancel.killProccess.Token.ThrowIfCancellationRequested();

                await Task.Delay(500);

                RequestCancel.killProccess.Token.ThrowIfCancellationRequested();

                this.Invoke(() => { lbl_Info.ForeColor = Color.White; });

                RequestCancel.killProccess.Token.ThrowIfCancellationRequested();

                await Task.Delay(500);

                RequestCancel.killProccess.Token.ThrowIfCancellationRequested();
            }

            RequestCancel.killProccess.Token.ThrowIfCancellationRequested();

            this.Invoke(() => { lbl_Info.Visible = false; });
            this.Invoke(() => { lbl_Info.Text = ""; });
        }


        private async Task lblInfo_Uploading(CancellationToken killProcess)
        {
            this.Invoke(() => lbl_Info.Text = "Uploading");
            this.Invoke(() => lbl_Info.Visible = true);

            while(!killProcess.IsCancellationRequested)
            {

                this.Invoke(() => lbl_Info.Text += " .");
                await Task.Delay(500);

                if (lbl_Info.Text.EndsWith(" . . ."))
                    this.Invoke(() => lbl_Info.Text = "Uploading");

            }
        }
    }
}



/*
 * 
 * { Explanation to {"Index -1 does not have a value."}
I'm guessing that you have bound a List that is initially empty, (or other sort of collection that does not generate list changed events) to your DataGridView,
and then added items to this List.

The items you add will display correctly on your grid, but clicking on a row will cause this exception. This is because the underlying CurrencyManager
will be reporting its current row position as an offset of -1. It will stay this way because the List does not report changes to the grid.

You should only bind your list to the grid if it has some items in it to begin with, or rebind when you add them.

See also my answer to this question, which is essentially the same problem.
*/