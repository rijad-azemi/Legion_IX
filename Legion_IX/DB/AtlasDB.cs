using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Legion_IX.DB
{
    public class AtlasDB
    {
        const string DBconnectionLink = "mongodb+srv://rijadazemi:Karate1227@cluster0.m9qqpen.mongodb.net/?retryWrites=true&w=majority";
        public MongoClient Client { get; set; }
        public List<string> DataBaseNames { get; set; }
        public IMongoDatabase Database { get; set; }
        public List<string> DatabaseCollectionNames { get; set; }
        public IMongoCollection<BsonDocument> Collection { get; set; }
        public BsonDocument Document { get; set; }
        public ObjectId DocumentId { get; set; }

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
            this.Database = Client.GetDatabase(databaseName);
            this.Collection = Database.GetCollection<BsonDocument>(databaseCollection);
        }

        public void GetDatabase(string databaseName)
        {
            this.Database = Client.GetDatabase(databaseName);
        }

        public void GetCollection(string databaseCollection)
        {
            this.Collection = Database.GetCollection<BsonDocument>(databaseCollection);
        }

        public void GetDatabaseCollectionNames()
        {
            this.DatabaseCollectionNames = Database.ListCollectionNames().ToList();
        }

        public void GetDocumentByName()
        {
            //this.Document = Collection.Find()
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
var database = client.GetDatabase("test");


MongoDB Project ID: 63f3883181ae1c1d70334ae5
MongoDB Project API keys: 
                         Public Key: dyqgwnym
                         Private Key: 38970b1b-8394-4347-9bb0-942d7d32dc78

 */