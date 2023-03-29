using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.DB
{
    public class RAR_File
    {
        public ObjectId? _id { get; set; }
        public string NameOfFile { get; set; }
        public string FileType { get; set; }

        [BsonRepresentation(BsonType.Binary)]
        public byte[]? rarData { get; set; }

        public RAR_File()
        {
            NameOfFile = string.Empty;
            FileType = string.Empty;
            rarData = null;
        }

        public RAR_File(ObjectId id, string nameOfFile, string fileType, byte[] Rardata)
        {
            _id = id;
            NameOfFile = nameOfFile;
            FileType = fileType;
            rarData = Rardata;
        }

        public RAR_File(RAR_File document)
        {
            _id = document._id;
            NameOfFile = document.NameOfFile;
            FileType = document.FileType;
            rarData = document.rarData;
        }

        public RAR_File(in BsonDocument document)
        {
            _id = (ObjectId)document.GetValue("_id");
            NameOfFile = (string)document.GetValue("NameOfFile");
            FileType = (string)document.GetValue("FileType");
        }

        public override string ToString()
        {
            return $"Type: {FileType}, ID: {_id}, Name: {NameOfFile}";
        }
    }
}
