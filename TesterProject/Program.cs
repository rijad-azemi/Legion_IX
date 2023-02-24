// See https://aka.ms/new-console-template for more information

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System.Collections;
using TesterProject.MongoDB_Atlas;

//MongoClient client = new MongoClient("mongodb+srv://rijadazemi:Karate1227@cluster0.m9qqpen.mongodb.net/?retryWrites=true&w=majority");
//List<string> database = client.ListDatabaseNames().ToList();
const string accessLink = "mongodb+srv://rijadazemi:Karate1227@cluster0.m9qqpen.mongodb.net/?retryWrites=true&w=majority";

async void Execute()
{

    AtlasDB connection = new AtlasDB();
    connection.printData();

    // Can also use var, but for learning purposes I leave it at this
    /*IMongoCollection<Coll_comments> chosenCollection = connection.Client.GetDatabase("sample_mflix").GetCollection<Coll_comments>("comments");
    FilterDefinition<Coll_comments> filter = Builders<Coll_comments>.Filter.*/

    Console.WriteLine("\n--- End of First Print ---");
    /*AtlasDB newDB = new AtlasDB();

    var collection = newDB.Client.GetDatabase("sample_mflix").GetCollection<BsonDocument>("comments");

    try
    {
        var documents = await collection.Find(new BsonDocument()).ToListAsync();

        if (documents.Any())
            Console.WriteLine("Jesus fucking Christ");

        foreach(var document in documents)
            Console.WriteLine(document.ToJson());
    }

    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }*/

    var database = connection.Client.GetDatabase("sample_mflix");
    var collection = database.GetCollection<BsonDocument>("comments");
    var documents = collection.Find(new BsonDocument()).ToList();

    //foreach(var document in documents) // Works but it's a fucking disaster
    //    Console.WriteLine(document.ToString());
    for (int i = 0; i < 5; i++)
        Console.WriteLine(documents[i].ToString() + "\n");

    //var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();


    //Console.WriteLine(firstDocument.ToString());
    //Console.WriteLine(documents.ToString());

}

Execute(); // Call function