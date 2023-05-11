using Legion_IX.DataFiles;
using Legion_IX.DB;
using Legion_IX.Helpers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Diagnostics;


namespace Legion_IX.User_Controls
{
    public partial class StudentDocuments : UserControl
    {
        #region Global vars

        // Variable that hold the chosen options from `comboBox_Subjects` as string (obviously)
        public string? ChosenSubject { get; set; }

        // This is necessary for Accessing the correct Atlas Data Base holding the collections containing the Subject documents (pdf files)
        public string SubjectsStudyYear = LoggedInStudent.theStudent.StudyYear.Replace(" ", "");

        // PDF file
        PDF_File? pdf;

        // RAR file
        RAR_File? rar;

        // Basically information describing the files stored on Atlas associated with Student
        List<AtlasFile> files;

        #endregion Global vars


        public StudentDocuments()
        {
            InitializeComponent();

            if (ParentForm != null)
                ParentForm.FormClosing += SignalCancellationToken;
        }


        // Signals `Cancel()` method of CancellationTokenSource if Parent Form is closing
        private void SignalCancellationToken(object? sender, FormClosingEventArgs e) =>
            RequestCancel.killProccess.Cancel();

        // UC `OnLoad` event
        private void StudentDocuments_Load(object sender, EventArgs e)
        {

            // Hiding from view on load
            this.Hide();

            // Calling the method for registering my own class to MongoDB (rules?) I must look into this further...
            RegisteringClassMap_PDF();
            RegisteringClassMap_RAR();

            // Basically method in which I assigned variables and it's values
            PreppingGlobalVarsForUse();

            // Adding available Databases to ComboBox
            AddSubjectsToComboBox();

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

            #region Remember This...might come in handy


            /*
            
            BsonClassMap.RegisterClassMap<PDF_File>(cm =>
            {
                cm.AutoMap();

                // !!!!! Used `BysonBinaryDataSerializer()` it is not the same as type `byte[]` pay more attention to method names and their functions !!!!!!
                // In other words, use your God Damn logic, Man. Get a five minute rest when you notice that all you look at is the same.
                cm.MapMember(p => p.BinData).SetSerializer(new ByteArraySerializer());
            });

            */


            /*            
             
            if (BsonClassMap.TryRegisterClassMap<PDF_File>(cm => cm.AutoMap()))
                return;
            //MessageBox.Show("Sucess!", "Class PDF_File Registered", MessageBoxButtons.OK);

            else
                MessageBox.Show("Failed!", "Class PDF_File NOT Registered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            */


            #endregion Remember This...might come in handy
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

            #region Remember This...might come in handy


            /*
            
            BsonClassMap.RegisterClassMap<PDF_File>(cm =>
            {
                cm.AutoMap();

                // !!!!! Used `BysonBinaryDataSerializer()` it is not the same as type `byte[]` pay more attention to method names and their functions !!!!!!
                // In other words, use your God Damn logic, Man. Get a five minute rest when you notice that all you look at is the same.
                cm.MapMember(p => p.BinData).SetSerializer(new ByteArraySerializer());
            });

            */

            /*            
             
            if (BsonClassMap.TryRegisterClassMap<RAR_File>(cm => cm.AutoMap()))
                return;
            //MessageBox.Show("Sucess!", "Class RAR_File Registered", MessageBoxButtons.OK);

            else
                MessageBox.Show("Failed!", "Class RAR_File NOT Registered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            */


            #endregion Remember This...might come in handy
        }


        // Assigning data/instances to Global Variables
        private void PreppingGlobalVarsForUse()
        {
            string DataBase_byStudyYear = LoggedInStudent.theStudent.StudyYear.Replace(" ", "");

            // Assigning the list of subjects to `theStudent` variable belonging to `frmStudentProfile`
            if (LoggedInStudent.theStudent != null)
                LoggedInStudent.theStudent.Subjects = LoggedInStudent.theStudent.StudentDBConnection.Client.GetDatabase(DataBase_byStudyYear).ListCollectionNames().ToList();

            // Creating instance
            pdf = new PDF_File();
            rar = new RAR_File();
            files = new List<AtlasFile>();

            // Disabling adding autoColumns from `DataSource()`
            dgv_Files.AutoGenerateColumns = false;
            dgv_Files.DataSource = null;
        }


        // Adding `Subject` collections from AtlasDB to comboBox
        public void AddSubjectsToComboBox()
        {
            foreach (string subject in LoggedInStudent.theStudent.Subjects)
                comboBox_Subjects.Items.Add(subject);
        }


        // Getting the chosen PDF file via Server-Side filtering
        private async Task<PDF_File> GetFile_PDF(ObjectId? theDocID, string theDocName, string theExtension)
        {
            if (CheckForChosenSubject() && theDocID != ObjectId.Empty && theDocName != null && theExtension != null)
            {

                // Creating the pipeline for Server-Side filtering
                List<BsonDocument> pipeline = new List<BsonDocument>()
                    {
                        new BsonDocument( "$match" , new BsonDocument("_id", theDocID)),
                        new BsonDocument( "$match" , new BsonDocument("NameOfFile", theDocName)),
                        new BsonDocument( "$match" , new BsonDocument("FileType", theExtension))
                    };

                // Getting the filtered document
                IAsyncCursor<BsonDocument> theDoc = await
                    LoggedInStudent.theStudent.StudentDBConnection.Client.GetDatabase(SubjectsStudyYear).GetCollection<BsonDocument>(ChosenSubject).AggregateAsync<BsonDocument>(pipeline);

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
            if (CheckForChosenSubject() && theDocID != ObjectId.Empty && theDocName != null && theExtension != null)
            {

                // Creating the pipeline for Server-Side filtering
                List<BsonDocument> pipeline = new List<BsonDocument>()
                    {
                        new BsonDocument( "$match" , new BsonDocument("_id", theDocID)),
                        new BsonDocument( "$match" , new BsonDocument("NameOfFile", theDocName)),
                        new BsonDocument( "$match" , new BsonDocument("FileType", theExtension))
                    };

                // Getting the filtered document
                IAsyncCursor<BsonDocument> theDoc = await
                    LoggedInStudent.theStudent.StudentDBConnection.Client.GetDatabase(SubjectsStudyYear).GetCollection<BsonDocument>(ChosenSubject).AggregateAsync<BsonDocument>(pipeline);

                BsonDocument extracted = theDoc.FirstOrDefault();
                RAR_File newFile = BsonSerializer.Deserialize<RAR_File>(extracted);

                // Returning Finished Proccessed document
                return new RAR_File(newFile);

            }

            return new RAR_File();
        }


        // Refreshes DataGridView
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            GetAvailableDocuments();
        }


        // Retrieve available document names
        private async void GetAvailableDocuments()
        {
            // Only continues if something an option has been chosen from `comboBox_Subjects`
            if (CheckForChosenSubject())
            {
                // Pipileni for retreiving only `NameOfFile` field from Atlas
                //   ^^
                //   ||
                //   ||
                // hahahHAHAHAHA

                List<BsonDocument> pipeline = new List<BsonDocument>() // I just want you to remember that you spent more than 10 hours because of this code below. //
                {
                    new BsonDocument("$project", new BsonDocument
                    {
                        {"NameOfFile", 1},
                        {"FileType", 1},
                        {"TimeStamp_Creation", 1}
                    })
                };

                IAsyncCursor<BsonDocument> theAvailableDocs = await LoggedInStudent.theStudent.StudentDBConnection.Client.
                    GetDatabase(SubjectsStudyYear).
                    GetCollection<BsonDocument>(ChosenSubject).
                    AggregateAsync<BsonDocument>(pipeline);

                // Cleats the list holding the Existing collections to create a new one with fresh records
                if (files.Count > 0)
                    files.Clear();

                foreach (BsonDocument document in theAvailableDocs.ToList())
                {
                    if (document.GetValue("FileType") == ".pdf")
                        files.Add(new AtlasFile(in document));

                    else if (document.GetValue("FileType") == ".rar")
                        files.Add(new AtlasFile(in document));

                    #region reminder comment
                    // Check if the List already contains the `PDF_File` that you are trying to add
                    // No need, I learned that can be slower, just create new list if the previous one was filled
                    #endregion reminder comment
                }

                // Assigning the List of collections to `DataGridView` source
                LoadToDataGridView();
            }
        }


        // DataGridView `CellContent` click event
        private async void dgv_Files_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string? whatButtonAmI = OpenOrDownloadButton(e);

            // Checking to see if the clicked cell was a button
            if (e.RowIndex >= 0 && dgv_Files?.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {

                // Getting the `_id` ; `NameOfFile` and `theExtension` properties from the object in the Cell Column
                AtlasFile FileInCell = GetAtlasFileDataFromCell(e);

                if (whatButtonAmI == "Open Preview")
                {
                    await DoIfButton_OpenPreview(e, FileInCell._id, FileInCell.NameOfFile, FileInCell.FileType);
                }

                else if (whatButtonAmI == "Download")
                {
                    await DoIfButton_Download(e, FileInCell._id, FileInCell.NameOfFile, FileInCell.FileType);
                }

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


        // Checks the type of document user wants to preview and calls the apprppriate method
        private async Task DoIfButton_OpenPreview(DataGridViewCellEventArgs e, ObjectId? theDocID, string theDocName, string theExtension)
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


        // Checks the type of document user wants to download, writes and saves it to SQLite database
        private async Task DoIfButton_Download(DataGridViewCellEventArgs e, ObjectId? theDocID, string theDocName, string theExtension)
        {
            MySQLcustomConnection SQL_db = new MySQLcustomConnection();

            if (theExtension == ".pdf")
            {
                PDF_File pdf_ToWrite = await GetFile_PDF(theDocID, theDocName, theExtension);
                pdf_ToWrite.Subject = ChosenSubject ?? "N/A";

                SQL_db.pdf_Files.Add(pdf_ToWrite);

                SQL_db.SaveChanges();
            }

            else if (theExtension == ".rar")
            {
                RAR_File rar_ToWrite = await GetFile_RAR(theDocID, theDocName, theExtension);
                rar_ToWrite.Subject = ChosenSubject ?? "N/A";

                SQL_db.rar_Files.Add(rar_ToWrite);
                SQL_db.SaveChanges();
            }
        }


        // Method that checks whether the clicked cell button was either `Open Preview` or `Download`
        private string? OpenOrDownloadButton(DataGridViewCellEventArgs e)
        {
            if (e?.RowIndex >= 0 && dgv_Files?.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {

                if ((dgv_Files?.Columns[e.ColumnIndex] as DataGridViewButtonColumn)?.Text == "Open Preview")
                    return "Open Preview";

                else if ((dgv_Files?.Columns[e.ColumnIndex] as DataGridViewButtonColumn)?.Text == "Download")
                    return "Download";

            }

            return null;
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


        // Load Data to `DataGridView`
        private void LoadToDataGridView()
        {
            dgv_Files.DataSource = null;

            if (files.Count > 0)
                dgv_Files.DataSource = files;
        }


        // `comboBox_Subjects` option changed event
        private void comboBox_Subjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChosenSubject = comboBox_Subjects.SelectedItem.ToString();

            // Calling the method For Refreshing
            btn_Refresh_Click(sender, e);
        }


        // If `comboBox_Subject` option has been selected
        private bool CheckForChosenSubject()
        {
            if (ChosenSubject == null)
            {

                #region I know the code is a mess, but I wanted to practise delegates and lambda functions

                Action Lambdi = () =>
                {

                    for (int i = 0; i < 3; i++)
                    {

                        this.Invoke(() =>
                        {
                            comboBox_Subjects.ForeColor = Color.Red;
                        });

                        Thread.Sleep(300);

                        this.Invoke(() =>
                        {
                            comboBox_Subjects.ForeColor = Color.Black;
                        });

                        Thread.Sleep(300);

                    }

                    this.Invoke(() => comboBox_Subjects.ForeColor = Color.Black);

                };

                #endregion I know the code is a mess, but I wanted to practise delegates and lambda functions

                Thread blinker = new Thread(new ThreadStart(Lambdi));
                blinker.Start();

                return false;

            }

            return true;
        }

    }
}

/*
                 After 50000000000000000000000000000000000000000000000000000000000000000 years of testing, I figured out how to use it


            PDF_File retrievedPDF = new PDF_File();

            PDF_File gotYa = theStudent.StudentDBConnection.Client.GetDatabase("Subjects").GetCollection<PDF_File>("Baze Podataka I").Find(new BsonDocument()).FirstOrDefault();

            //MessageBox.Show("Got Me!", "Success", MessageBoxButtons.YesNo);

            if(MessageBox.Show($"{gotYa.NameOfFile}", "Success", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string tempFilePath = Path.GetTempFileName();
                File.WriteAllBytes(tempFilePath, gotYa.BinData);

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
                psi.Arguments = tempFilePath;

                Process.Start(psi).WaitForExit();

                //File.Delete(tempFilePath);
            }


            All hail Microsoft documentation, stack overflow, and engineers that expect everyone to have infinity level experience to figure their explanations out.
 */