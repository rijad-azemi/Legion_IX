using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Legion_IX.Users;
using Microsoft.IdentityModel.Tokens;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Legion_IX.DB
{
    public class AtlasDB
    {
        const string DBconnectionLink = "mongodb+srv://AppUser777:itsMarioo@cluster0.m9qqpen.mongodb.net/?retryWrites=true&w=majority";


        internal readonly string AtlasDB_FacultyPersonell = "FacultyPersonell";
        internal readonly string AtlasCollection_Student = "Student";
        internal readonly string AtlasCollection_Professor = "Professor";
        internal readonly string AtlasCollection_StudentService = "Students Service Staff";


        public MongoClient Client { get; set; } // Client for connection to the Cluster containing Databases
        public List<string> DataBaseNames { get; set; } // List of all existing Database names
        public IMongoDatabase Database { get; set; } // Interface representing one Database of a Cluster
        public IMongoCollection<BsonDocument> Collection { get; set; } // Holds documents of one Collection
        public string CollectionName { get; set; } // A Name of one CHOSEN Collection
        public List<string> CollectionNames { get; set; } // List of all Collection names inside one Database
        public BsonDocument Document { get; set; } // Holds one Document from the chosen Collection
        public ObjectId DocumentId { get; set; } // Holds the ID of the chosen document


        // Creating List of Students and created profiles to be stored and uploaded later
        public List<Student> Students { get; set; }

        public AtlasDB()
        {
            this.Client = new MongoClient(DBconnectionLink);
            this.DataBaseNames = Client.ListDatabaseNames().ToList();
        }

        //User defined constuctor for getting a Database
        public AtlasDB(string databaseName)
        {
            this.Database = Client.GetDatabase(databaseName);
        }

        //User defined constuctor for getting a Database Collection
        public AtlasDB(string databaseName, string databaseCollection)
        {
            this.Client = new MongoClient(DBconnectionLink);
            this.DataBaseNames = Client.ListDatabaseNames().ToList();

            this.Database = Client.GetDatabase(databaseName);
            this.Collection = Database.GetCollection<BsonDocument>(databaseCollection);
        }

        // Gets Database NAMES
        public void GetAtlasDatabase(string databaseName)
        {
            this.Database = Client.GetDatabase(databaseName);
        }

        // Gets Fresh database names
        public IMongoDatabase GetFreshDatabase(string databaseName)
        {
            return this.Client.GetDatabase(databaseName);
        }
        
        //Gets Fresh needed Collection
        public void GetAll(string collectionName)
        {
            //return this.
        }

        // Gets COLLECTION (all Documents from a chosen Collection => DOCUMENTS REPRESENTING COLLECTION)
        public void GetAtlasCollection(string databaseCollection) // !!! Collection is a List of DOCUMENTS !!!
        {
            this.Collection = Database.GetCollection<BsonDocument>(databaseCollection);
        }

        // Gets Names of all Collections
        public void GetAtlasDB_CollectionNameses()
        {
            this.CollectionNames = Database.ListCollectionNames().ToList();
        }

        // Gets a Name of chosen Document
        public void GetAtlasDocumentName()
        {
            //this.Document = Collection.Find()
        }

        // Shows all contents/elements held by a Document
        public string ShowAtlasDocumentContent()
        {
            List<BsonElement> documentContents = this.Document.ToList(); // Converts to List to get to it's contents
            string display = ""; // 'display' will receive content Names and Values
            var newLine = Environment.NewLine; // Shortcut variable for printing new lines

            foreach (BsonElement element in documentContents) // Iterates through Document's contents
                display += $"{element.Name}: {element.Value.ToString() + newLine + newLine}"; // Adds information to a string

            // Basically informs that Document holds no elements/information
            if(display.IsNullOrEmpty())
                display = $"!!! N/A !!!{newLine + newLine}      --- DOCUMENT HOLDS NO INFORMATION---        ";

            return display; // Returns full string
        }

        // Checks if the searched for Collections exists
        public bool CheckIfCollectionExists(string collectionName)
        {
            return this.CollectionNames.Contains(collectionName);
        }

        // Refreshes localy available Databases in case of Atlas Update
        public List<string> RefreshDatabaseNames()
        {
            return this.DataBaseNames = this.Client.ListDatabaseNames().ToList();
        }

        public override string ToString()
        {
            return $"DB_TheNEST";
        }
    }
}


                  //                    DELETED                      //

/*              ---MongoDB Atlas CONNECTION information---

CONNECTION STRING: mongodb+srv://6usu6rper:<password>@thebridge.4ltipfn.mongodb.net/?retryWrites=true&w=majority


var settings = MongoClientSettings.FromConnectionString("mongodb+srv://6usu6rper:<password>@thebridge.4ltipfn.mongodb.net/?retryWrites=true&w=majority");
settings.ServerApi = new ServerApi(ServerApiVersion.V1);
var client = new MongoClient(settings);
var database = client.GetAtlasDatabase("test");


MongoDB Project ID: 63f3883181ae1c1d70334ae5
MongoDB Project API keys: 
                         Public Key: dyqgwnym
                         Private Key: 38970b1b-8394-4347-9bb0-942d7d32dc78

 */