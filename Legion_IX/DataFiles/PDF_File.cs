using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Libmongocrypt;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.DataFiles
{
    public class PDF_File
    {
        #region SQL_Representation Map

        [NotMapped]
        public ObjectId? _id { get; set; }

        [BsonIgnore]
        [Key, MaxLength(24)]
        public string AtlasObjectId
        {

            get { return _id.ToString(); }

            set { _id = ObjectId.Parse(value); }

        }

        #endregion SQL_Representation Map

        public string NameOfFile { get; set; }
        public string FileType { get; set; }

        #region TimeStamp_Creation property (for Atlas and SQL)

        [BsonRepresentation(BsonType.String)]
        [Column("TimeStamp", TypeName = "TEXT")]
        public DateTime TimeStamp_Creation { get; set; }

        [BsonIgnore]
        [NotMapped]
        public string TimeStamp
        {
            get { return TimeStamp_Creation.ToString(); }
            set { TimeStamp_Creation = DateTime.Parse(value); }
        }

        #endregion TimeStamp_Creation property (for Atlas and SQL)


        #region Subject (only for SQL)

        [BsonIgnore]
        [Column("SubjectName", TypeName = "TEXT")]
        public string Subject { get; set; }

        /*        [BsonIgnore]
                [NotMapped]
                public string SubjectName
                {
                    get { return  Subject; }
                    set { Subject = value; }
                }*/

        #endregion Subject (only for SQL)


        [BsonRepresentation(BsonType.Binary)]
        public byte[]? BinData { get; set; }


        public PDF_File()
        {
            //Id = null; // ===> Avoid this, because MongoDB already takes care of this by itself.
            //      However, if you send it as null, it will be stored on the server as such. Bad choice.
            NameOfFile = string.Empty;
            FileType = string.Empty;

            //TimeStamp_Creation = null;

            BinData = null;
        }


        public PDF_File(ObjectId id, string nameOfFile, string fileType, DateTime timeStamp_Creation, byte[] PDFdata)
        {
            _id = id;
            NameOfFile = nameOfFile;
            FileType = fileType;
            TimeStamp_Creation = timeStamp_Creation;
            BinData = PDFdata;
        }


        public PDF_File(PDF_File document)
        {
            _id = document._id;
            NameOfFile = document.NameOfFile;
            FileType = document.FileType;
            TimeStamp_Creation = document.TimeStamp_Creation;
            BinData = document.BinData;
        }


        public PDF_File(in BsonDocument document)
        {
            _id = (ObjectId)document.GetValue("_id");
            NameOfFile = (string)document.GetValue("NameOfFile");
            TimeStamp_Creation = (DateTime)document.GetValue("TimeStamp_Creation");
            FileType = (string)document.GetValue("FileType");
        }


        public PDF_File(in AtlasFile droppedAtlasFile, byte[] bin)
        {
            _id = ObjectId.GenerateNewId();
            NameOfFile = droppedAtlasFile.NameOfFile;
            FileType = droppedAtlasFile.FileType;
            TimeStamp_Creation = droppedAtlasFile.TimeStamp_Creation;
            BinData = bin;
        }


        public override string ToString()
        {
            return $"Type: {FileType}, ID: {_id}, Name: {NameOfFile}";
        }
    }
}