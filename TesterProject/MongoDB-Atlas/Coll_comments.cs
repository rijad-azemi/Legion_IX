using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace TesterProject.MongoDB_Atlas
{
    internal class Coll_comments
    {
        public ObjectId _id { get; set; }
        public string name{ get; set; }
        public string email{ get; set; }
        public ObjectId movie_id { get; set; }
        public string text { get; set; }
        public DateTime date { get; set; }

        public void showCollectionByFilter()
        {
            
        }
    }
}