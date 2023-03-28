using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Libmongocrypt;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.DB
{
    public class PDF_File
    {
        public ObjectId? _id { get; set; }
        public string NameOfFile { get; set; }

        [BsonRepresentation(BsonType.Binary)]
        public byte[]? pdfData { get; set; }

        public PDF_File()
        {
            //Id = null; // ===> Avoid this, because MongoDB already takes care of this by itself.
                         //      However, if you send it as null, it will be stored on the server as such. Bad choice.
            NameOfFile = string.Empty;
            pdfData = null;
        }

        public PDF_File(ObjectId id, string nameOfFile, byte[] PDFdata)
        {
            _id = id;
            NameOfFile = nameOfFile;
            pdfData = PDFdata;
        }

        public PDF_File(PDF_File document)
        {
            _id = document._id;
            NameOfFile = document.NameOfFile;
            pdfData = document.pdfData;
        }

        public PDF_File(in BsonDocument document)
        {
            _id = (ObjectId)document.GetValue("_id");
            NameOfFile = (string)document.GetValue("NameOfFile");
        }

        public override string ToString()
        {
            return $"ID: {_id}, Name: {NameOfFile}";
        }
    }
}