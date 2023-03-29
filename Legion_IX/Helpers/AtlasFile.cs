using Legion_IX.DB;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.Helpers
{
    public class AtlasFile
    {
        public ObjectId? _id { get; set; }
        public string NameOfFile { get; set; }
        public string FileType { get; set; }

        public AtlasFile()
        {
            //Id = null; // ===> Avoid this, because MongoDB already takes care of this by itself.
            //      However, if you send it as null, it will be stored on the server as such. Bad choice.
            NameOfFile = string.Empty;
            FileType = string.Empty;
        }

        public AtlasFile(ObjectId id, string nameOfFile, string fileType)
        {
            _id = id;
            NameOfFile = nameOfFile;
            FileType = fileType;
        }

        public AtlasFile(PDF_File document)
        {
            _id = document._id;
            NameOfFile = document.NameOfFile;
            FileType = document.FileType;
        }

        public AtlasFile(in BsonDocument document)
        {
            _id = (ObjectId)document.GetValue("_id");
            NameOfFile = (string)document.GetValue("NameOfFile");
            FileType = (string)document.GetValue("FileType");
        }

        public ObjectId? GetID() => this._id;
        public string GetNameOfFile() => this.NameOfFile;
        public string GetFileType() => this.FileType;

        public override string ToString()
        {
            return $"Type: {FileType}, ID: {_id}, Name: {NameOfFile}";
        }
    }
}
