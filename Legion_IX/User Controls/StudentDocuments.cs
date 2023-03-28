using Legion_IX.DB;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Legion_IX.User_Controls
{
    public partial class StudentDocuments : UserControl
    {
        #region Global vars

        // Browser directory for opening PDF Files
        static string? ChromeLocation = frmLoginScreen.GetBrowserPathFromSQL();

        // Variable that hold the chosen options from `comboBox_Subjects` as string (obviously)
        public string? ChosenSubject { get; set; }

        // This is necessary for Accessing the correct Atlas Data Base holding the collections containing the Subject documents (pdf files)
        public string SubjectsStudyYear = frmStudentProfile.theStudent.StudyYear.Replace(" ", "");

        // Reference variable to `Student` object belonging to `frmStudentProfile`
        Student? theStudent = frmStudentProfile.theStudent;

        // PDF file
        PDF_File? pdf;

        // Basically information describing the files stored on Atlas associated with Student
        List<PDF_File> files;

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
            RegisteringClassMap();

            // Basically method in which I assigned variables and it's values
            PreppingGlobalVarsForUse();

            // Adding available Databases to ComboBox
            AddSubjectsToComboBox();

            #region Not needed now
            // Retrieving available documents from the Atlas and displaying it to `DataGridView`
            //GetAvailableDocuments();
            #endregion Not needed now
        }

        // Registering 
        private void RegisteringClassMap()
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

        private void PreppingGlobalVarsForUse()
        {
            string DataBase_byStudyYear = theStudent.StudyYear.Replace(" ", "");

            // Assigning the list of subjects to `theStudent` variable belonging to `frmStudentProfile`
            if (theStudent != null)
                theStudent.Subjects = theStudent.StudentDBConnection.Client.GetDatabase(DataBase_byStudyYear).ListCollectionNames().ToList();

            // Creating instance
            pdf = new PDF_File();
            files = new List<PDF_File>();

            // Disabling adding autoColumns from `DataSource()`
            dgv_Files.AutoGenerateColumns = false;
            dgv_Files.DataSource = null;
        }

        #region FirstTesting Phases, not important

        // Shows UC in view
        public void ShowMe() => this.Visible = true;

        // Hides UC from view
        public void HideMe() => this.Visible = false;

        #endregion FirstTesting Phases, not important

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

                // Creating a Filter for `OpenFileDialog`
                opf_ChooseDocument.Filter = "PDF files (*.pdf)|*.pdf";

                // Continue if chosen file
                if (opf_ChooseDocument.ShowDialog() == DialogResult.OK)
                {
                    // Creating an instance of the Object to insert
                    PDF_File toInsert = new PDF_File(

                        new ObjectId(),
                        Path.GetFileName(opf_ChooseDocument.FileName),
                        File.ReadAllBytes(opf_ChooseDocument.FileName)

                        );

                    // Serialising the `PDF_File` object as `BsonDocument`
                    BsonDocument converted = toInsert.ToBsonDocument();

                    // Inserting serialised document
                    await theStudent.StudentDBConnection.Client.GetDatabase(SubjectsStudyYear).GetCollection<BsonDocument>(ChosenSubject).InsertOneAsync(converted);

                    // Showing confirmation message
                    MessageBox.Show("Uploaded", "All went fine!", MessageBoxButtons.OK);

                    // Refreshing the `DataGridView`
                    GetAvailableDocuments();
                }

            }
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
                    new BsonDocument("$project", new BsonDocument("NameOfFile", 1))
                };

                IAsyncCursor<BsonDocument> theAvailableDocs =
                    await theStudent.StudentDBConnection.Client.GetDatabase(SubjectsStudyYear).GetCollection<BsonDocument>(ChosenSubject).AggregateAsync<BsonDocument>(pipeline);

                // Cleats the list holding the Existing collections to create a new one with fresh records
                if (files.Count > 0)
                    files.Clear();

                foreach (BsonDocument document in theAvailableDocs.ToList())
                {
                    // Check if the List already contains the `PDF_File` that you are trying to add
                    // No need, I learned that can be slower, just create new list if the previous one was filled
                    files.Add(new PDF_File(in document));
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
                ObjectId theDocID = ((dgv_Files.Rows[e.RowIndex].DataBoundItem as PDF_File)?._id) ?? ObjectId.Empty;
                string theDocName = (dgv_Files.Rows[e.RowIndex].DataBoundItem as PDF_File)?.NameOfFile ?? string.Empty;

                // Getting the PDF
                pdf = await GetFile(theDocID, theDocName);

                // Check to see if `GetFile()` method has returned null
                if (pdf != null)
                {
                    // Creating teporary filepath for the PDF to be stored for later viewing
                    string tempFilePath = Path.GetTempFileName();

                    // Writing the PDF to that file
                    if (pdf.pdfData != null)
                    {
                        File.WriteAllBytes(tempFilePath, pdf.pdfData);
                        // Creating a Process for starting the Browser
                        ProcessStartInfo psi = new ProcessStartInfo();
                        psi.FileName = ChromeLocation;
                        psi.Arguments = tempFilePath;

                        // Starting the browser with PDF binary Data to read
                        Process.Start(psi);
                    }

                    else
                        MessageBox.Show("Problem encountered", "At `dgv_Files_CellContentClick()` `pdf.pdfData` was null!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Getting the chosen PDF file via Server-Side filtering
        private async Task<PDF_File> GetFile(ObjectId theDocID, string theDocName)
        {
            if (CheckForChosenSubject() && theDocID != ObjectId.Empty && theDocName != null)
            {

                // Creating the pipeline for Server-Side filtering
                List<BsonDocument> pipeline = new List<BsonDocument>()
                    {
                        new BsonDocument( "$match" , new BsonDocument("_id", theDocID)),
                        new BsonDocument( "$match" , new BsonDocument("NameOfFile", theDocName))
                    };

                // Getting the filtered document
                IAsyncCursor<BsonDocument> theDoc = await
                    theStudent.StudentDBConnection.Client.GetDatabase("Subjects").GetCollection<BsonDocument>(ChosenSubject).AggregateAsync<BsonDocument>(pipeline);

                BsonDocument extracted = theDoc.FirstOrDefault();
                PDF_File newFile = BsonSerializer.Deserialize<PDF_File>(extracted);

                // Returning Finished Proccessed document
                return new PDF_File(newFile);

            }

            return new PDF_File();
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