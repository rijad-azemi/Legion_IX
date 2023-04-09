using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Legion_IX.DataFiles
{
    public class RAR_File
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
                    get { return Subject; }
                    set { Subject = value; }
                }*/

        #endregion Subject (only for SQL)


        [BsonRepresentation(BsonType.Binary)]
        public byte[]? BinData { get; set; }


        public RAR_File()
        {
            NameOfFile = string.Empty;
            FileType = string.Empty;

            //TimeStamp_Creation = null;

            BinData = null;
        }

        public RAR_File(ObjectId id, string nameOfFile, string fileType, DateTime timeStampCreation, byte[] Rardata)
        {
            _id = id;
            NameOfFile = nameOfFile;
            FileType = fileType;
            TimeStamp_Creation = timeStampCreation;
            BinData = Rardata;
        }

        public RAR_File(RAR_File document)
        {
            _id = document._id;
            NameOfFile = document.NameOfFile;
            FileType = document.FileType;
            TimeStamp_Creation = document.TimeStamp_Creation;
            BinData = document.BinData;
        }

        public RAR_File(in BsonDocument document)
        {
            _id = (ObjectId)document.GetValue("_id");
            NameOfFile = (string)document.GetValue("NameOfFile");
            TimeStamp_Creation = (DateTime)document.GetValue("TimeStamp_Creation");
            FileType = (string)document.GetValue("FileType");
        }

        public override string ToString()
        {
            return $"Type: {FileType}, ID: {_id}, Name: {NameOfFile}";
        }
    }
}
