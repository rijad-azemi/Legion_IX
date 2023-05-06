using Legion_IX.DB;
using Legion_IX.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.Users
{
    public class Student
    {
        internal bool Active { get; set; } = true;
        internal bool LoggedIn { get; set; } = false;


        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string StudyYear { get; set; }
        public Image _Image { get; set; }
        public string Index { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public bool Revised { get; set; }

        public List<string> Subjects { get; set; }


        #region Data for Atlas connection

        // Connection to Atlas Database for this class
        public AtlasDB StudentDBConnection { get; set; }

        // Database Name where 'Student' account is stored
        public string StudentAtlasDB = "FacultyPersonell";

        //Collection Name where 'Student' account is stored
        public string StudentAtlasCollection = "Student";

        #endregion Data for Atlas connection


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

            StudentDBConnection = new AtlasDB();
        }


        // User defined ctor
        // YOU FORGOT StudentDBConnection
        public Student(string name, string surname, Image image, DateTime birthdate, string studyYear, string index, string password, string email, bool revised)
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
        // YOU FORGOT StudentDBConnection
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

                    {"email", Email},
                    {"password", Password},

                    {"studyYear", StudyYear},
                    {"index", Index},
                    {"revised", Revised},

                    {"image", new BsonBinaryData(ImageHelper.FromImageToByte(_Image))},
                    
                    {"active", Active },
                    {"loggedIn", LoggedIn }

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


        // Gets the data for Student from BsonDocument
        internal void GetStudentFromBson(in BsonDocument theStudent)
        {
            _id = (ObjectId)theStudent.GetValue("_id");

            Name = theStudent.GetValue("name").ToString() ?? "N/A";

            Surname = theStudent.GetValue("surname").ToString() ?? "N/A";

            Birthdate = (DateTime)theStudent.GetValue("birthdate");

            StudyYear = theStudent.GetValue("studyYear").ToString() ?? "N/A";

            _Image = ImageHelper.FromByteToImage((byte[])theStudent.GetValue("image"));

            Index = theStudent.GetValue("index").ToString() ?? "N/A";

            Password = null;

            Email = theStudent.GetValue("email").ToString() ?? "N/A";

            Revised = (bool)theStudent.GetValue("revised");

            Active = (bool)theStudent.GetValue("active");
        }


        internal void UpdateStudent_LoggedIn_Field_toLoggedIn()
        {
            FilterDefinition<BsonDocument> filterToStudent = Builders<BsonDocument>.Filter.Eq("_id", _id);

            UpdateDefinition<BsonDocument> update_LoggedIn = Builders<BsonDocument>.Update.Set("loggedIn", true);

            StudentDBConnection.Client.
                GetDatabase(StudentDBConnection.AtlasDB_FacultyPersonell).
                GetCollection<BsonDocument>(StudentDBConnection.AtlasCollection_Student).
                UpdateOne(filterToStudent, update_LoggedIn);

            LoggedIn = true;
        }


        internal void UpdateStudent_LoggedIn_Field_toLoggedOut()
        {
            FilterDefinition<BsonDocument> filterToStudent = Builders<BsonDocument>.Filter.Eq("_id", _id);

            UpdateDefinition<BsonDocument> update_LoggedIn = Builders<BsonDocument>.Update.Set("loggedIn", false);

            StudentDBConnection.Client.
                GetDatabase(StudentDBConnection.AtlasDB_FacultyPersonell).
                GetCollection<BsonDocument>(StudentDBConnection.AtlasCollection_Student).
                UpdateOne(filterToStudent, update_LoggedIn);

            LoggedIn = false;
        }
    }
}