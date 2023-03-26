using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.DB
{
    public class AtlasFile
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        //public string FileType { get; set; }

        public AtlasFile(ObjectId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}