using Legion_IX.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MongoDB.Bson;
using MongoDB.Driver;
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
        public string? Password { get; set; }
        public string Email { get; set; }
        public bool Revised { get; set; }

        #region Data for Atlas connection

        // Connection to Atlas Database for this class
        AtlasDB StudentDBConnection { get; set; }

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

        // Server Side filtering
        public async Task<IAsyncCursor<BsonDocument>>? ServerSideFilter_EmailPassword(string email, string password)
        {
            StudentDBConnection = new AtlasDB();

            List<BsonDocument> pipeline = new List<BsonDocument>()
            {
                new BsonDocument("$match", new BsonDocument("email", email)),
                new BsonDocument("$match", new BsonDocument("password", password))
            };

            IAsyncCursor<BsonDocument>? foundAccounts = await
                StudentDBConnection.Client.GetDatabase(StudentAtlasDB).GetCollection<BsonDocument>(StudentAtlasCollection).AggregateAsync<BsonDocument>(pipeline);

            return foundAccounts;
        }

        // Gets the data for Student from BsonDocument
        public Student GetStudentFromBson(ref BsonDocument theStudent)
        {
            return new Student()
            {
                Name = theStudent.GetValue("name").ToString(),

                Surname = theStudent.GetValue("surname").ToString(),

                Birthdate = ((DateTime)theStudent.GetValue("birthdate")),

                StudyYear = theStudent.GetValue("studyYear").ToString(),

                _Image = ImageHelper.FromByteToImage((byte[])theStudent.GetValue("image")),

                Index = theStudent.GetValue("index").ToString(),

                Password = null,

                Email = theStudent.GetValue("email").ToString(),

                Revised = (bool)theStudent.GetValue("revised")
            };
        }
    }
}