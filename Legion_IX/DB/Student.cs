using Legion_IX.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.DB
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string StudyYear { get; set; }
        public Image _Image { get; set; }
        public string Index { get; set; }
        //public int IndexIncrementor { get; }
        public bool Revised { get; set; }

        // Default ctor
        public Student()
        {
            Name = "";
            Surname = "";
            Birthdate = null;
            StudyYear = "";
            _Image = null;
            Index = "IB";
            //IndexIncrementor = 190000;
            Revised = false;
        }

        // User defined ctor
        public Student(string name, string surname,Image image, DateTime birthdate, string studyYear, string index, bool revised)
        {
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            _Image = image;
            StudyYear = studyYear;
            //_Image = null;//
            Index = index;
            Revised = revised;
        }

        // Copy ctor
        public Student(Student studentToCopy)
        {
            Name = studentToCopy.Name;
            Surname = studentToCopy.Surname;
            Birthdate = studentToCopy.Birthdate;
            StudyYear = studentToCopy.StudyYear;
            _Image = studentToCopy._Image;
            Index = studentToCopy.Index;
            Revised = studentToCopy.Revised;
        }

        // Create and Insert/Upload
        public bool CreateAndUpload()
        {
            var document = new BsonDocument
            {
                {"name", Name},
                {"surname", Surname},
                {"birthdate", Birthdate},
                {"studyYear", StudyYear},
                {"image", new BsonBinaryData(ImageHelper.FromImageToByte(_Image))},
                {"index", Index},
                {"revised", Revised}
            };

            AtlasDB access = new AtlasDB("FacultyPersonell", "Student");
            access.Collection.InsertOne(document);

            return true;
        }

        // Insert Document into Atlas
        public void DocumentToInsert()
        {
            var document = new BsonDocument
            {
                {"name", Name},
                {"surname", Surname},
                {"birthdate", Birthdate},
                {"image", _Image.ToString()},
                {"index", Index},
                {"revised", Revised}
            };
        }
    }
}