using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

/*
                ----- Information for MongoDB Atlas access -----

1)      API Link: mongodb+srv://rijadazemi:<password>@cluster0.m9qqpen.mongodb.net/?retryWrites=true&w=majority
2)      Filled in API: mongodb+srv://rijadazemi:<Karate1227>@cluster0.m9qqpen.mongodb.net/?retryWrites=true&w=majority


var settings = MongoClientSettings.FromConnectionString("mongodb+srv://rijadazemi:<password>@cluster0.m9qqpen.mongodb.net/?retryWrites=true&w=majority");
settings.ServerApi = new ServerApi(ServerApiVersion.V1);
var client = new MongoClient(settings);
var database = client.GetDatabase("test");

 */

namespace TesterProject.MongoDB_Atlas
{
    internal class AtlasDB
    {
        const string accessLink = "mongodb+srv://rijadazemi:Karate1227@cluster0.m9qqpen.mongodb.net/?retryWrites=true&w=majority";
        public MongoClient Client { get; set; }
        public List<string> Data { get; set; }

        public AtlasDB()
        {
            Client = new MongoClient(accessLink);
            Data = Client.ListDatabaseNames().ToList();
        }

        public void printData()
        {
            foreach(string dataPiece in this.Data)
                Console.WriteLine(dataPiece);
        }

        public override string ToString()
        {
            return $"--- I am Atlas Database ---";
        }

    }
}