using Legion_IX.DataFiles;
using Legion_IX.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.Resources
{
    internal class Code_Notes
    {

        #region commentedCode
        //from FRM LOGIN


        /*TO hell with this
        //            var pipeline = new BsonArray
        //{
        //    BsonDocument.Parse("{ $match: { email: 'sead.azemi@edu.fit.ba', password: 'undp123' } }")
        //};


        //var pipeline = new BsonDocument[]
        //{
        //    new BsonDocument("$match",
        //    new BsonDocument
        //{
        //        {"email", "sead.azemi@edu.fit.ba"},
        //        {"password", "undp123"}
        //}
        //    )
        //};

        //var pipline2 = BsonArray

        //            new BsonArray
        //{
        //    new BsonDocument("$match",
        //    new BsonDocument("email", "sead.azemi@edu.fit.ba"))
        //};

        //var matchStage = BsonDocument.Parse
        //    (
        //    @"{ $match: { email: {$eq: 'sead.azemi@edu.fit.ba'}, password: {$eq: 'undp123' } } }"
        //    );
        //var pipeline = PipelineDefinitionBuilder<BsonDocument, BsonDocument>.Create(matchStage)

        //var foundAccount = await filterTest.Client.GetDatabase(database).GetCollection<BsonDocument>(collection).AggregateAsync<BsonDocument>(pipeline);

        //txtBox_DisplayDocument.Text = foundAccount.ToString();


        var pipeline = new BsonDocument[]
        {
        new BsonDocument("$match",
        new BsonDocument
        {
        {"email", "sead.azemi@edu.fit.ba"},
        {"password", "undp123"}
        })
        };
                    //if (firstDocument != null)
        //{
        //    foreach (var field in firstDocument.ToJson()) 
        //    {
        //        txtBox_DisplayDocument.Text += field.ToString();
        //    }
        //}

                    //var studyYear = firstDocument.GetValue("studyYear");
        //var revised = firstDocument.GetValue("revised");
        //var index = firstDocument.GetValue("index");
        //txtBox_DisplayDocument.Text = $"{studyYear+Environment.NewLine+revised+Environment.NewLine+index}";

                    //var firstDocument = await foundAccount.FirstOrDefaultAsync();

        //if (textBox_email.Text == firstDocument.GetValue("email")
        //    && textBox_password.Text == firstDocument.GetValue("password"))
        //{
        //    MessageBox.Show("Login Successful", "Success!", MessageBoxButtons.OK);
        //}
        //else
        //    MessageBox.Show("Account not found!", "Failed", MessageBoxButtons.OK);
        */
        #endregion commentedCode

        #region reserve

        /*            //BsonDocument newDoc = new BsonDocument("my2Darray", array_dim1);

                    List<BsonDocument> pipeline = new List<BsonDocument>
                    {
                        new BsonDocument("$match", new BsonDocument("_id", new ObjectId("643f1ea2b8658341d546e84b")))
                    };

                    AtlasDB newInstance = new AtlasDB();
                    //newInstance.Client.GetDatabase(newInstance.AtlasDB_FacultyPersonell).GetCollection<BsonDocument>(newInstance.AtlasCollection_Professor).InsertOne(newDoc);
                    IAsyncCursor<BsonDocument> theCursor = newInstance.Client.
                        GetDatabase(newInstance.AtlasDB_FacultyPersonell).GetCollection<BsonDocument>(newInstance.AtlasCollection_Professor).Aggregate<BsonDocument>(pipeline);

                    BsonDocument theFile = theCursor.FirstOrDefault();

                    BsonArray theExtractedArray = (BsonArray)theFile.GetValue("my2Darray");

                    string meIsDone = "fuck YOU";
        */

        #endregion reserve

        #region StudentDocuments_UC

/*

        // TestButton for Document Insertion
        private async void btn_UploadPdf_Click(object sender, EventArgs e)
        {
            if (CheckForChosenSubject())
            {
                //string opf_ChooseDocumentFilter = "PDF files (*.pdf)|*.pdf|RAR files (*.rar)|*.rar";
                string opf_ChooseDocumentFilter = "PDF files (.pdf); RAR files (.rar)|*.pdf;*.rar";

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
            await LoggedInStudent.theStudent.StudentDBConnection.Client.GetDatabase(SubjectsStudyYear).GetCollection<BsonDocument>(ChosenSubject).InsertOneAsync(converted);
        }


        // Method that inserts a `RAR_File` into Atlas based on information from `opf_ChooseDocument` in `btn_UploadPdf_Click` method event
        private async Task toInsert_RAR(string fileName, string extension, DateTime timeStamp, byte[] data)
        {
            RAR_File toInsert = new RAR_File(new ObjectId(), fileName, extension, timeStamp, data);

            // Serialising the `PDF_File` object as `BsonDocument`
            BsonDocument converted = toInsert.ToBsonDocument();

            // Inserting serialised document
            await LoggedInStudent.theStudent.StudentDBConnection.Client.GetDatabase(SubjectsStudyYear).GetCollection<BsonDocument>(ChosenSubject).InsertOneAsync(converted);
        }

*/
        #endregion StudentDocuments_UC


    }
}
