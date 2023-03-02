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
        public string Password { get; set; }
        public string Email { get; set; }
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
            Password = "";
            Email = "";
            //IndexIncrementor = 190000;
            Revised = false;
        }

        // User defined ctor
        public Student(string name, string surname,Image image, DateTime birthdate, string studyYear, string index, string password, string email, bool revised)
        {
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            _Image = image;
            StudyYear = studyYear;
            //_Image = null;//
            Index = index;
            Password = password;
            Email = email;
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
            Password = studentToCopy.Password;
            Email = studentToCopy.Email;
            Revised = studentToCopy.Revised;
        }

        // Create and Insert/Upload
        public bool CreateAndUpload()
        {
            // TRY
            try
            {
                var document = new BsonDocument
                {
                    {"name", Name},
                    {"surname", Surname},
                    {"birthdate", Birthdate},
                    {"studyYear", StudyYear},
                    {"image", new BsonBinaryData(ImageHelper.FromImageToByte(_Image))},
                    {"index", Index},
                    {"password", Password},
                    {"email", Email},
                    {"revised", Revised}
                };

                AtlasDB access = new AtlasDB("FacultyPersonell", "Student");
                access.Collection.InsertOne(document);
            }

            // CATCH
            catch (Exception insertFAILED)
            {
                // Shows Message box displaying an error and it's description
                MessageBox.Show
                    (
                    $"Student upload/insertion failed:{insertFAILED.Message}; Source: {insertFAILED.Source + Environment.NewLine}",
                    "Problem Detected: FAILED Document insertion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                // Returns false to fucntion call source
                return false;
            }

            // Returns true to function call source
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