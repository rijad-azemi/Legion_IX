﻿using MongoDB.Bson;
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
        public string FileType { get; set; }

        [BsonRepresentation(BsonType.Binary)]
        public byte[]? pdfData { get; set; }

        public PDF_File()
        {
            //Id = null; // ===> Avoid this, because MongoDB already takes care of this by itself.
                         //      However, if you send it as null, it will be stored on the server as such. Bad choice.
            NameOfFile = string.Empty;
            FileType = string.Empty;
            pdfData = null;
        }

        public PDF_File(ObjectId id, string nameOfFile, string fileType, byte[] PDFdata)
        {
            _id = id;
            NameOfFile = nameOfFile;
            FileType = fileType;
            pdfData = PDFdata;
        }

        public PDF_File(PDF_File document)
        {
            _id = document._id;
            NameOfFile = document.NameOfFile;
            FileType = document.FileType;
            pdfData = document.pdfData;
        }

        public PDF_File(in BsonDocument document)
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