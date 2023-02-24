using Legion_IX.DB;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Legion_IX
{
    public partial class frmHeartBeat : Form
    {
        public frmHeartBeat()
        {
            InitializeComponent();
        }

        private AtlasDB dataConnection;
        private void frmHeartBeat_Load(object sender, EventArgs e)
        {
            dataConnection = new AtlasDB();

            ShowDatabases();
            AddDBsToComboBox();
        }

        private void ShowDatabases()
        {
            string display = "";

            for (int i = 0; i < dataConnection.DataBaseNames.Count; i++)
            {
                if (i != dataConnection.DataBaseNames.Count - 1)
                    display += $"{i + 1}) ";
                display += dataConnection.DataBaseNames[i] + Environment.NewLine;
            }

            lbl_ShowDatabaseNames.Text = display;
        }

        private void ShowCollection()
        {
            string display = "";

            foreach (string collectionName in dataConnection.DatabaseCollectionNames)
                display += collectionName + Environment.NewLine;

            txtBox_AvailableCollections.Text = display;
        }

        private void AddDBsToComboBox()
        {
            foreach (string DB in dataConnection.DataBaseNames)
            {
                cmBox_ChooseDB.Items.Add(DB);
            }
        }

        private void OriginalCode()
        {
            // Choose Database
            dataConnection.Database = dataConnection.Client.GetDatabase("sample_mflix");

            // Choose it's Collection
            dataConnection.Collection = dataConnection.Database.GetCollection<BsonDocument>("comments");

            // And getting that collection's document
            dataConnection.Document = dataConnection.Collection.Find(new BsonDocument()).FirstOrDefault();

            // Convert Collection to a List for LEARNING PURPOSES
            //var LEARNING = dataConnection.ChosenDocument.ToList();

            // Printing collections data to TextBox
            List<BsonElement> collectionDocument = dataConnection.Document.ToList();
            foreach (BsonElement element in collectionDocument)
            {
                //txtBox_Data.Text += element.ToString() + Environment.NewLine;
                txtBox_Data.Text += element.Name + Environment.NewLine;
            }

            //txtBox_Data.Text = dataConnection.ChosenDocument.ToString();

            // Getting ObjectId from collection's document of Atlas
            //dataConnection.ChosenDocumentId = dataConnection.ChosenDocument.GetValue("_id").AsObjectId;

            //txtBox_Data.Text += $"{Environment.NewLine}Index of Mercedes Tyler is : {dataConnection.ChosenDocumentId.ToString()}"; // Showing that ObjectId in TextBox
        }

        private void btn_ConfrimEmailChange_Click(object sender, EventArgs e)
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId("5a9427648b0beebeb69579e7"));
            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("email", txtBox_ChangeEmail.Text);

            // Must Update via UpdateOneAsync!
            dataConnection.Collection.UpdateOneAsync(filter, update).Wait();

            // Inform user of change
            txtBox_Data.Text += $"{Environment.NewLine}Changed email to: {txtBox_ChangeEmail.Text}";
        }

        private void cmBox_ChooseDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chosenDB = dataConnection.DataBaseNames[cmBox_ChooseDB.SelectedIndex];

            dataConnection.GetDatabase(chosenDB); // Gets the chosen DB
            dataConnection.GetDatabaseCollectionNames(); // Gets of collection belonging to the chosen database

            ShowCollection();
        }

        private void txtBox_TypeCollection_KeyDown(object sender, KeyEventArgs e)
        {
            string collection = txtBox_TypeCollection.Text;

            if(!collection.IsNullOrEmpty())
            {
                dataConnection.Document = dataConnection.Collection.Find(new BsonDocument()).FirstOrDefault();
                txtBox_Data.Text = dataConnection.Document.ToString();
            }
        }
    }
}

/*
 *          --- UPDATING THE EMAIL STORED ON MONGODB ATLAS ---
 
            // Update the fucking email below: 

            //var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId("5a9427648b0beebeb69579e7"));
            //var update = Builders<BsonDocument>.Update.Set("email", "<AUSLAUG>mercedes_tyler@fakegmail.com");
            //collection.UpdateOneAsync(filter, update);
 */

/*
 *          --- CHOOSING A DATABASE, GETTING IT'S COLLECTION AND ASSIGNING IT'S ID ---
 * 
            //IMongoDatabase database = dataConnection.Client.GetDatabase("sample_mflix"); // Chosen Database
            //IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("comments"); // It's Collection
            //BsonDocument firstDocument = collection.Find(new BsonDocument()).FirstOrDefault(); // And getting that collection's data
            //ObjectId theIndex = dataConnection.ChosenDocument.GetValue("_id").AsObjectId; // Receive it's ObjectId
 */

/*
 *          --- UPDATE AN OBJECT WITH USING IT'S ID ---
 *          
        var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId("your_object_id_here"));
        var update = Builders<BsonDocument>.Update.Set("email", "new_email_address_here");
        await collection.UpdateOneAsync(filter, update);
 */

/*
 *          --- GET A COLLECTION FROM DESIRED DATABASE AND PRINT CONETENTS ---
 *          
        var database = connection.Client.GetDatabase("sample_mflix");
        var collection = database.GetCollection<BsonDocument>("comments");
        var documents = collection.Find(new BsonDocument()).ToList();

        //foreach(var document in documents) // Works but it's a fucking disaster
        //Console.WriteLine(document.ToString());
        for (int i = 0; i < 5; i++)
            Console.WriteLine(documents[i].ToString() + "\n");
 */