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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legion_IX.User_Controls
{
    public partial class StudentDocuments : UserControl
    {
        #region Global vars

        const string ChromeLocation = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";

        // Reference variable to `Student` object belonging to `frmStudentProfile`
        Student? theStudent = frmStudentProfile.theStudent;

        // PDF file
        PDF_File pdf;

        // Basically information describing the files stored on Atlas associated with Student
        List<PDF_File> files;

        #endregion Global vars

        public StudentDocuments()
        {
            InitializeComponent();
        }

        private void StudentDocuments_Load(object sender, EventArgs e)
        {
            // Hiding from view on load
            this.Hide();

            // Calling the method for registering my own class to MongoDB (rules?) I must look into this further...
            RegisteringClassMap();

            // Basically method in which I assigned variables and it's values
            PreppingGlobalVarsForUse();

            // Adding available Databases to ComboBox
            AddSubjectsToComboBox();

            // Retrieving available documents from the Atlas and displaying it to `DataGridView`
            GetAvailableDocuments();
        }

        // Registering 
        private void RegisteringClassMap()
        {

            if (BsonClassMap.TryRegisterClassMap<PDF_File>(cm => cm.AutoMap()))
                MessageBox.Show("Sucess!", "Class PDF_File Registered", MessageBoxButtons.OK);

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
            // Assigning the list of subjects to `theStudent` variable belonging to `frmStudentProfile`
            if (theStudent != null)
                theStudent.Subjects = theStudent.StudentDBConnection.Client.GetDatabase("Subjects").ListCollectionNames().ToList();

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
            opf_ChooseDocument.Filter = "PDF files (*.pdf)|*.pdf";

            if (opf_ChooseDocument.ShowDialog() == DialogResult.OK)
            {
                PDF_File toInsert = new PDF_File();

                toInsert._id = new ObjectId();
                toInsert.pdfData = File.ReadAllBytes(opf_ChooseDocument.FileName);
                toInsert.NameOfFile = Path.GetFileName(opf_ChooseDocument.FileName);

                BsonDocument converted = toInsert.ToBsonDocument();

                #region TesterCode
                /*
                 pdf.pdfData = System.IO.File.ReadAllBytes(opf_ChooseDocument.FileName);
                 pdf.NameOfFile = opf_ChooseDocument.FileName.ToString();
                 //Data = File.ReadAllBytes(opf_ChooseDocument.FileName);
                */
                #endregion TesterCode

                await theStudent.StudentDBConnection.Client.GetDatabase("Subjects").GetCollection<BsonDocument>("Baze Podataka I").InsertOneAsync(converted);

                MessageBox.Show("Uploaded", "All went fine!", MessageBoxButtons.OK);
            }
        }

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

        // Refreshes DataGridView
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            GetAvailableDocuments();
        }

        // Retrieve available document names
        private async void GetAvailableDocuments()
        {
            // I just want you to remember that you spent more than 10 hours because of this code below.
            List<BsonDocument> pipeline = new List<BsonDocument>()
            {
                new BsonDocument("$project", new BsonDocument("NameOfFile", 1))
            };

            IAsyncCursor<BsonDocument> theAvailableDocs =
                await theStudent.StudentDBConnection.Client.GetDatabase("Subjects").GetCollection<BsonDocument>("Baze Podataka I").AggregateAsync<BsonDocument>(pipeline);

            if (files.Count > 0)
                files.Clear();

            foreach (BsonDocument document in theAvailableDocs.ToList())
            {
                // Check if the List already contains the `PDF_File` that you are trying to add
                // No need, I learned that can be slower, just create new list
                files.Add(new PDF_File(in document));
            }

            LoadToDataGridView();
        }

        // DataGridView `CellContent` click event
        private async void dgv_Files_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Checking to see if the clicked cell was a button
            if (dgv_Files.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Getting the `Id` property from the object in the Cell
                ObjectId theDocID = (ObjectId)(dgv_Files.Rows[e.RowIndex].DataBoundItem as PDF_File)._id;
                string theDocName = (dgv_Files.Rows[e.RowIndex].DataBoundItem as PDF_File).NameOfFile;

                // Getting the PDF
                pdf = await GetFile(theDocID, theDocName);

                // Creating teporary filepath for the PDF to be stored for later viewing
                string tempFilePath = Path.GetTempFileName();

                // Writing the PDF to that file
                File.WriteAllBytes(tempFilePath, pdf.pdfData);

                // Creating a Process for starting the Browser
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = ChromeLocation;
                psi.Arguments = tempFilePath;

                // Starting the browser with PDF binary Data to read
                Process.Start(psi);
                #region testPart
                /*
                //MessageBox.Show("This worked", "I got in");
                AtlasFile chosenDoc = dgv_Files.Rows[e.RowIndex].DataBoundItem as AtlasFile;
                MessageBox.Show(chosenDoc.Name, "I got in");
                */
                #endregion testPart
            }
        }

        // Getting the chosen PDF file via Server-Side filtering
        private async Task<PDF_File> GetFile(ObjectId theDocID, string theDocName)
        {
            // Creating the pipeline for Server-Side filtering
            List<BsonDocument> pipeline = new List<BsonDocument>()
                {
                    new BsonDocument( "$match" , new BsonDocument("_id", theDocID)),
                    new BsonDocument( "$match" , new BsonDocument("NameOfFile", theDocName))
                };

            // Getting the filtered document
            IAsyncCursor<BsonDocument> theDoc = await
                theStudent.StudentDBConnection.Client.GetDatabase("Subjects").GetCollection<BsonDocument>("Baze Podataka I").AggregateAsync<BsonDocument>(pipeline);

            BsonDocument extracted = theDoc.FirstOrDefault();
            PDF_File newFile = BsonSerializer.Deserialize<PDF_File>(extracted);

            // Returning Finished Proccessed document
            return new PDF_File(newFile);
        }

        // DataGridView Button click event
        private void dgv_FilesClickEvent()
        {

        }

        // Load Data to `DataGridView`
        private void LoadToDataGridView()
        {
            dgv_Files.DataSource = null;
            dgv_Files.DataSource = files;
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