using Legion_IX.DB;
using Legion_IX.Helpers;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using MongoDB.Libmongocrypt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Legion_IX.User_Controls
{
    public partial class StudentDocuments : UserControl
    {
        #region Global vars

        // Browser directory for opening PDF Files
        static string? ChromeLocation = frmLoginScreen.GetBrowserPathFromSQL();
        static string? WinRarLocation = GetWinrarPathFromSQL();

        // Variable that hold the chosen options from `comboBox_Subjects` as string (obviously)
        public string? ChosenSubject { get; set; }

        // This is necessary for Accessing the correct Atlas Data Base holding the collections containing the Subject documents (pdf files)
        public string SubjectsStudyYear = frmStudentProfile.theStudent.StudyYear.Replace(" ", "");

        // Reference variable to `Student` object belonging to `frmStudentProfile`
        Student? theStudent = frmStudentProfile.theStudent;

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
        }

        private void StudentDocuments_Load(object sender, EventArgs e)
        {
            btn_GetMe.Hide();

            // Hiding from view on load
            this.Hide();

            // Calling the method for registering my own class to MongoDB (rules?) I must look into this further...
            RegisteringClassMap_PDF();
            RegisteringClassMap_RAR();

            // Basically method in which I assigned variables and it's values
            PreppingGlobalVarsForUse();

            // Adding available Databases to ComboBox
            AddSubjectsToComboBox();

            #region Not needed now
            // Retrieving available documents from the Atlas and displaying it to `DataGridView`
            //GetAvailableDocuments();
            #endregion Not needed now
        }

        // Registering `PDF_File` to support MongoDB Bson serialisation
        private void RegisteringClassMap_PDF()
        {

            if (BsonClassMap.TryRegisterClassMap<PDF_File>(cm => cm.AutoMap()))
                return;
            //MessageBox.Show("Sucess!", "Class PDF_File Registered", MessageBoxButtons.OK);

            else
                MessageBox.Show("Failed!", "Class PDF_File NOT Registered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            #region SecondTry

            /*
            BsonClassMap.RegisterClassMap<PDF_File>(cm =>
            {
                cm.AutoMap();

                // !!!!! Used `BysonBinaryDataSerializer()` it is not the same as type `byte[]` pay more attention to method names and their functions !!!!!!
                // In other words, use your God Damn logic, Man. Get a five minute rest when you notice that all you look at is the same.
                cm.MapMember(p => p.pdfData).SetSerializer(new ByteArraySerializer());
            });
            */

            #endregion SecondTry
        }

        // Registering `RAR_File` to support MongoDB Bson serialisation
        private void RegisteringClassMap_RAR()
        {
            if (BsonClassMap.TryRegisterClassMap<RAR_File>(cm => cm.AutoMap()))
                return;

            else
                MessageBox.Show("Failed!", "Class RAR_File NOT Registered", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        // Assigning data/instances to Global Variables
        private void PreppingGlobalVarsForUse()
        {
            string DataBase_byStudyYear = theStudent.StudyYear.Replace(" ", "");

            // Assigning the list of subjects to `theStudent` variable belonging to `frmStudentProfile`
            if (theStudent != null)
                theStudent.Subjects = theStudent.StudentDBConnection.Client.GetDatabase(DataBase_byStudyYear).ListCollectionNames().ToList();

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
            foreach (string subject in theStudent.Subjects)
                comboBox_Subjects.Items.Add(subject);
        }

        // TestButton for Document Insertion
        private async void btn_UploadPdf_Click(object sender, EventArgs e)
        {
            if (CheckForChosenSubject())
            {
                string opf_ChooseDocumentFilter = "PDF files (*.pdf)|*.pdf|RAR files (*.rar)|*.rar";

                await InsertFile(opf_ChooseDocumentFilter);
            }
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
                        File.ReadAllBytes(opf_ChooseDocument.FileName)
                        );

                }

                else if (Path.GetExtension(opf_ChooseDocument.FileName) == ".rar")
                {

                    await toInsert_RAR(
                        Path.GetFileName(opf_ChooseDocument.FileName),
                        Path.GetExtension(opf_ChooseDocument.FileName),
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
        private async Task toInsert_PDF(string fileName, string extension, byte[] data)
        {
            PDF_File toInsert = new PDF_File(new ObjectId(), fileName, extension, data);


            // Serialising the `PDF_File` object as `BsonDocument`
            BsonDocument converted = toInsert.ToBsonDocument();

            // Inserting serialised document
            await theStudent.StudentDBConnection.Client.GetDatabase(SubjectsStudyYear).GetCollection<BsonDocument>(ChosenSubject).InsertOneAsync(converted);
        }

        // Method that inserts a `RAR_File` into Atlas based on information from `opf_ChooseDocument` in `btn_UploadPdf_Click` method event
        private async Task toInsert_RAR(string fileName, string extension, byte[] data)
        {
            RAR_File toInsert = new RAR_File(new ObjectId(), fileName, extension, data);

            // Serialising the `PDF_File` object as `BsonDocument`
            BsonDocument converted = toInsert.ToBsonDocument();

            // Inserting serialised document
            await theStudent.StudentDBConnection.Client.GetDatabase(SubjectsStudyYear).GetCollection<BsonDocument>(ChosenSubject).InsertOneAsync(converted);
        }

        #region Button used for testing
        // TestButton
        private void btn_GetMe_Click(object sender, EventArgs e)
        {
            //PDF_File retrievedPDF = new PDF_File();

            PDF_File gotYa = theStudent.StudentDBConnection.Client.GetDatabase("Subjects").GetCollection<PDF_File>("Baze Podataka I").Find(new BsonDocument()).FirstOrDefault();
            //BsonDocument gotYa = theStudent.StudentDBConnection.Client.GetDatabase("Subjects").GetCollection<BsonDocument>("Baze Podataka I").Find(new BsonDocument()).FirstOrDefault();


            //MessageBox.Show("Got Me!", "Success", MessageBoxButtons.YesNo);

            if (MessageBox.Show($"{gotYa.NameOfFile}", "Success", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string tempFilePath = Path.GetTempFileName();
                System.IO.File.WriteAllBytes(tempFilePath, gotYa.pdfData);

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = ChromeLocation;
                psi.Arguments = tempFilePath;

                Process.Start(psi).WaitForExit();

                //File.Delete(tempFilePath);
            }
        }
        #endregion Button used for testing

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
                List<BsonDocument> pipeline = new List<BsonDocument>() // I just want you to remember that you spent more than 10 hours because of this code below. //
                {
                    new BsonDocument("$project", new BsonDocument
                    {
                        {"NameOfFile", 1},
                        {"FileType", 1}
                    })
                };

                IAsyncCursor<BsonDocument> theAvailableDocs =
                    await theStudent.StudentDBConnection.Client.GetDatabase(SubjectsStudyYear).GetCollection<BsonDocument>(ChosenSubject).AggregateAsync<BsonDocument>(pipeline);

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
            // Checking to see if the clicked cell was a button
            if (dgv_Files.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Getting the `_id` and `NameOfFile` property from the object in the Cell
                ObjectId theDocID = (dgv_Files.Rows[e.RowIndex].DataBoundItem as AtlasFile)?.GetID() ?? ObjectId.Empty;
                string theDocName = (dgv_Files.Rows[e.RowIndex].DataBoundItem as AtlasFile)?.GetNameOfFile() ?? string.Empty;
                string theExtension = (dgv_Files.Rows[e.RowIndex].DataBoundItem as AtlasFile)?.GetFileType() ?? string.Empty;

                if (theExtension == ".pdf")
                {
                    await PDF_File_WriteToFileAndOpen(theDocID, theDocName, theExtension);
                }

                else if (theExtension == ".rar")
                {
                    await RAR_File_WriteToFileAndOpen(theDocID, theDocName, theExtension);
                }

            }
        }

        // Writes binary data to a temporary file and opens for viewing
        private async Task PDF_File_WriteToFileAndOpen(ObjectId theDocID, string theDocName, string theExtension)
        {
            // Getting the PDF
            pdf = await GetFile_PDF(theDocID, theDocName, theExtension);

            // Check to see if `GetFile()` method has returned null
            if (pdf != null)
            {
                // Creating teporary filepath for the PDF to be stored for later viewing
                string tempFilePath = Path.GetTempFileName();

                // Writing the PDF to that file
                if (pdf.pdfData != null && !ChromeLocation.IsNullOrEmpty())
                {

                    try
                    {

                        File.WriteAllBytes(tempFilePath, pdf.pdfData);

                        // Creating a Process for starting the Browser
                        ProcessStartInfo psi = new ProcessStartInfo();
                        psi.FileName = ChromeLocation;
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
                    MessageBox.Show("Problem encountered", "At `dgv_Files_CellContentClick()` `pdf.pdfData` was null!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task RAR_File_WriteToFileAndOpen(ObjectId theDocID, string theDocName, string theExtension)
        {
            // Getting the RAR
            rar = await GetFile_RAR(theDocID, theDocName, theExtension);

            // Check to see if `GetFile()` method has returned null
            if (rar != null)
            {
                // Creating teporary filepath for the RAR to be stored for later viewing
                string tempFilePath = Path.GetTempFileName();

                // Writing the PDF to that file
                if (rar.rarData != null && CheckIfWinrarDirectoryAssigned())
                {

                    try
                    {

                        File.WriteAllBytes(tempFilePath, rar.rarData);

                        // Creating a Process for starting the Browser
                        ProcessStartInfo psi = new ProcessStartInfo();
                        psi.FileName = WinRarLocation;
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
                    MessageBox.Show("Problem encountered", "At `dgv_Files_CellContentClick()` `rar.rarData` was null!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckIfWinrarDirectoryAssigned()
        {
            if (WinRarLocation.IsNullOrEmpty() || Path.GetFileName(WinRarLocation) != "WinRAR.exe") // You cannot check if it's null! It must be a directory! Spotted immediately...bravo Rijad!
            {
                opf_ChooseDocument.Filter = "Executable files (*.exe)|*.exe";

                if (opf_ChooseDocument.ShowDialog() == DialogResult.OK)
                {
                    Update_Add_BrowserToSQL(opf_ChooseDocument.FileName);

                    WinRarLocation = GetWinrarPathFromSQL();

                    if (Path.GetFileName(WinRarLocation) != "WinRAR.exe")
                        return false;

                    return true;
                }

                return false;
            }

            else
                return true;
        }

        // Getting the chosen PDF file via Server-Side filtering
        private async Task<PDF_File> GetFile_PDF(ObjectId theDocID, string theDocName, string theExtension)
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
                    theStudent.StudentDBConnection.Client.GetDatabase(SubjectsStudyYear).GetCollection<BsonDocument>(ChosenSubject).AggregateAsync<BsonDocument>(pipeline);

                BsonDocument extracted = theDoc.FirstOrDefault();
                PDF_File newFile = BsonSerializer.Deserialize<PDF_File>(extracted);

                // Returning Finished Proccessed document
                return new PDF_File(newFile);

            }

            return new PDF_File();
        }

        // Getting the chosen PDF file via Server-Side filtering
        private async Task<RAR_File> GetFile_RAR(ObjectId theDocID, string theDocName, string theExtension)
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
                    theStudent.StudentDBConnection.Client.GetDatabase(SubjectsStudyYear).GetCollection<BsonDocument>(ChosenSubject).AggregateAsync<BsonDocument>(pipeline);

                BsonDocument extracted = theDoc.FirstOrDefault();
                RAR_File newFile = BsonSerializer.Deserialize<RAR_File>(extracted);

                // Returning Finished Proccessed document
                return new RAR_File(newFile);

            }

            return new RAR_File();
        }

        // Load Data to `DataGridView`
        private void LoadToDataGridView()
        {
            dgv_Files.DataSource = null;
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
                    this.Invoke(() => lbl_StatusMessage.Text = "You Must Choose a Subject.");

                    for (int i = 0; i < 3; i++)
                    {
                        this.Invoke(() =>
                        {
                            comboBox_Subjects.ForeColor = Color.Red;
                            lbl_StatusMessage.ForeColor = Color.Red;
                        });

                        Thread.Sleep(300);

                        this.Invoke(() =>
                        {
                            lbl_StatusMessage.ForeColor = Color.White;
                            comboBox_Subjects.ForeColor = Color.Black;
                        });

                        Thread.Sleep(300);
                    }

                    this.Invoke(() => comboBox_Subjects.ForeColor = Color.Black);
                    this.Invoke(() => lbl_StatusMessage.Text = "");
                };
                #endregion I know the code is a mess, but I wanted to practise delegates and lambda functions

                Thread blinker = new Thread(new ThreadStart(Lambdi));
                blinker.Start();

                return false;
            }

            return true;
        }

        // Adds the Winrar Directory to SQL `table_WinrarDirectory`
        private static void Update_Add_BrowserToSQL(string path)
        {
            string updateQuery = "UPDATE table_WinrarDirectory SET WinrarDirectory = @NewPath";
            string access = MySQLcustomConnection.myConnection;

            using (SQLiteConnection line = new SQLiteConnection(access))
            {
                line.Open();

                using (SQLiteCommand execute = new SQLiteCommand(updateQuery, line))
                {
                    execute.Parameters.AddWithValue("@NewPath", path);
                    execute.ExecuteNonQuery();
                }

            }
        }

        // Get Winrar Directory from SQL
        private static string? GetWinrarPathFromSQL()
        {
            string SQLaccess = MySQLcustomConnection.myConnection;
            string command = "SELECT WinrarDirectory FROM table_WinrarDirectory LIMIT 1;";
            string? directoryFromSQL = null;

            using (SQLiteConnection line = new SQLiteConnection(SQLaccess))
            {
                line.Open();

                using (SQLiteCommand instruction = new SQLiteCommand(command, line))
                {

                    using (SQLiteDataReader reader = instruction.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            directoryFromSQL = reader.GetString(0);
                        }

                    }

                }

            }

            return directoryFromSQL;
        }

        #region FirstTesting Phases, not important

        // Shows UC in view
        public void ShowMe() => this.Visible = true;

        // Hides UC from view
        public void HideMe() => this.Visible = false;

        #endregion FirstTesting Phases, not important
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
                File.WriteAllBytes(tempFilePath, gotYa.pdfData);

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
                psi.Arguments = tempFilePath;

                Process.Start(psi).WaitForExit();

                //File.Delete(tempFilePath);
            }


            All hail Microsoft documentation, stack overflow, and engineers that expect everyone to have infinity level experience to figure their explanations out.
 */