using Legion_IX.DataFiles;
using Legion_IX.Helpers;
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

        #endregion Global vars


        internal ProfessorDocuments()
        {
            InitializeComponent();
        }


        private void ProfessorDocuments_Load(object sender, EventArgs e)
        {
            this.Hide();

            // Loading the list of subjects to comboBox
            LoadToComboBoxSubjects();

            RegisteringClassMap_PDF();
            RegisteringClassMap_RAR();

            dgv_Files.AutoGenerateColumns = false;
            dgv_Files.DataSource = null;
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
        private void btn_UploadDocument_Click(object sender, EventArgs e)
        {

        }


        // Button evenet for refreshing DGV datasource
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            // Resetting the `dgv_files` DataSource property to null
            dgv_Files.DataSource = null;

            // Loading fresh data based on choice from `comboBox_Subjects`
            LoadDocumentsTo_dgv();
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
