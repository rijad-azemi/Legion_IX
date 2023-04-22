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

    }
}
