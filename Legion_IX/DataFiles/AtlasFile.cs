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

namespace Legion_IX.DataFiles
{
    public class AtlasFile
    {
        public ObjectId? _id { get; set; }
        public string NameOfFile { get; set; }
        public string FileType { get; set; }
        public DateTime TimeStamp_Creation { get; set; }


        [BsonIgnore]
        public string PathToFile { get; set; }


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

        
        // User Defined Constructor for AtlasFile received from `ProfessorDocuments` - `dgv_Files` - `DragDrop` event
        public AtlasFile(string nameOfFile, string fileType, DateTime timeStamp, string pathToFile)
        {
            NameOfFile = nameOfFile;
            FileType = fileType;
            TimeStamp_Creation = timeStamp;

            PathToFile = pathToFile;
        }


        public AtlasFile(AtlasFile file, bool fromAtlasFileDropped)
        {
            if(fromAtlasFileDropped)
            {
                NameOfFile = file.NameOfFile;
                FileType = file.FileType;
                TimeStamp_Creation = file.TimeStamp_Creation;

                PathToFile = file.PathToFile;
            }

            else
            {
                _id = file._id;
                NameOfFile = file.NameOfFile;
                FileType = file.FileType;
                TimeStamp_Creation = file.TimeStamp_Creation;
            }
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


        public static AtlasFile GetAtlasFileFrom_PDF(in PDF_File pdf)
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
            Thread filterAnd_Add_PDF_Files = new Thread(new ThreadStart(() => Add_PDFs_ToList(ChosenSubject)));
            Thread filterAnd_Add_RAR_Files = new Thread(new ThreadStart(() => Add_RARs_ToList(ChosenSubject)));

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
                lock (_lock)
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


        public ObjectId? GetID() => _id;
        public string GetNameOfFile() => NameOfFile;
        public string GetFileType() => FileType;
        public DateTime GetTimeStamp_Creation() => TimeStamp_Creation;


        public override string ToString()
        {
            return $"Type: {FileType}, ID: {_id}, Name: {NameOfFile}";
        }
    }
}