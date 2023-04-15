using Legion_IX.DataFiles;
using Legion_IX.DB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.Helpers
{
    public class AtlasFile
    {
        public ObjectId? _id { get; set; }
        public string NameOfFile { get; set; }
        public string FileType { get; set; }
        public DateTime TimeStamp_Creation { get; set; }

        [BsonIgnore] // This is not necessary since I will not be uploading `AtlasFile` object, but just in case I change my mind, I don't want this to be uploaded
        public string Subject { get; set; }

        public AtlasFile()
        {
            //Id = null; // ===> Avoid this, because MongoDB already takes care of this by itself.
                        //       However, if you send it as null, it will be stored on the server as such. Bad choice.
            NameOfFile = string.Empty;
            FileType = string.Empty;
            Subject = string.Empty;
        }


        public AtlasFile(ObjectId? id, string nameOfFile, string fileType, DateTime timeStamp)
        {
            _id = id;
            NameOfFile = nameOfFile;
            FileType = fileType;
            TimeStamp_Creation = timeStamp;
        }


        public AtlasFile(PDF_File document)
        {
            _id = document._id;
            NameOfFile = document.NameOfFile;
            FileType = document.FileType;
            TimeStamp_Creation = document.TimeStamp_Creation;
        }


        public AtlasFile(in BsonDocument document)
        {
            _id = (ObjectId)document.GetValue("_id");
            NameOfFile = (string)document.GetValue("NameOfFile");
            FileType = (string)document.GetValue("FileType");
            TimeStamp_Creation = DateTime.Parse((string)document.GetValue("TimeStamp_Creation"));
        }


        public static AtlasFile GetAtlasFileFrom_PDF (in PDF_File pdf)
        {
            return new AtlasFile
                (
                pdf._id,
                pdf.NameOfFile,
                pdf.FileType,
                pdf.TimeStamp_Creation
                );

        }


        public static AtlasFile GetAtlasFileFrom_RAR(in RAR_File rar)
        {
            return new AtlasFile
                (
                rar._id,
                rar.NameOfFile,
                rar.FileType,
                rar.TimeStamp_Creation
                );

        }

        [BsonIgnore]
        [NotMapped]
        private static readonly object _lock = new object();

        [BsonIgnore]
        [NotMapped]
        private static List<AtlasFile> PassThisOver { get; set; } = new List<AtlasFile>();

        public static void GetFilesFrom_SQL(out List<AtlasFile> listToFill, string ChosenSubject)
        {

            Thread filterAnd_Add_PDF_Files = new Thread(new ThreadStart( () => Add_PDFs_ToList(ChosenSubject) ));
            Thread filterAnd_Add_RAR_Files = new Thread(new ThreadStart( () => Add_RARs_ToList(ChosenSubject) ));

            filterAnd_Add_PDF_Files.Start();
            filterAnd_Add_RAR_Files.Start();

            filterAnd_Add_PDF_Files.Join();
            filterAnd_Add_RAR_Files.Join();

            listToFill = new List<AtlasFile>(PassThisOver);

            // Recycle the list
            PassThisOver.Clear();
        }


        public static void Add_PDFs_ToList(string ChosenSubject)
        {
            MySQLcustomConnection SQLdb = new MySQLcustomConnection();

            List<PDF_File> PDF_fromSQLdb = SQLdb.pdf_Files.Where(subject => subject.Subject == ChosenSubject).ToList();

            foreach (PDF_File pdf in PDF_fromSQLdb)
            {
                lock(_lock)
                {
                    PassThisOver.Add(GetAtlasFileFrom_PDF(pdf));
                }
            }

        }


        public static void Add_RARs_ToList(string ChosenSubject)
        {
            MySQLcustomConnection SQLdb = new MySQLcustomConnection();

            List<RAR_File> PDF_fromSQLdb = SQLdb.rar_Files.Where(subject => subject.Subject == ChosenSubject).ToList();

            foreach (RAR_File pdf in PDF_fromSQLdb)
            {
                lock (_lock)
                {
                    PassThisOver.Add(GetAtlasFileFrom_RAR(pdf));
                }
            }
        }


        public ObjectId? GetID() => this._id;
        public string GetNameOfFile() => this.NameOfFile;
        public string GetFileType() => this.FileType;
        public DateTime GetTimeStamp_Creation() => this.TimeStamp_Creation;


        public override string ToString()
        {
            return $"Type: {FileType}, ID: {_id}, Name: {NameOfFile}";
        }
    }
}
