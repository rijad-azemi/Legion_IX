using Legion_IX.DB;
using Legion_IX.Helpers;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.Users
{
    internal class Professor
    {
        internal const bool Admin = true;
        internal bool Active { get; set; } = true;
        internal bool LoggedIn { get; set; } = false;

        internal ObjectId _id { get; set; }
        internal string Name { get; set; }
        internal string Surname { get; set; }
        internal DateTime? Birthdate { get; set; }
        internal Image? _Image { get; set; }
        internal string? Password { get; set; }
        internal string Email { get; set; }
        public Dictionary<string, List<string>> SubjectsTeaching { get; set; }

        #region Data for Atlas connection

        internal AtlasDB ProfessorAtlasAccess = new AtlasDB();

        internal static string ProfessorAtlasDB = "FacultyPersonell";
        internal static string ProfessorCollection = "Professor";

        #endregion Data for Atlas connection


        // Default Constructor
        internal Professor()
        {
            Name = "";
            Surname = "";
            Birthdate = null;

            Password = null;
            Email = "";

            SubjectsTeaching = new Dictionary<string, List<string>>();
        }


        // UserDefined Constructor
        internal Professor(string name, string surname, DateTime? birthdate, Image image, string? password, string email, Dictionary<string, List<string>> subjectsTeaching)
        {
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            _Image = image;
            Password = password;
            Email = email;

            SubjectsTeaching = subjectsTeaching;
        }


        // Accessed by an instance of Professor class, creates a BsonDocument and uploads the said document to Atlas
        internal bool CreateAndUpload()
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

                    {"image", new BsonBinaryData(ImageHelper.FromImageToByte(_Image))},

                    {"active", Active },

                    {"loggedIn", LoggedIn },

                    {"subjects_teaching", Get_SubjectsAsBsonArray() /* Returns a BsonArray converted from a Dictionary<string, List<strin>> */ }

                };

                AtlasDB access = new AtlasDB("FacultyPersonell", "Professor");
                access.Collection.InsertOne(document);
            }

            // CATCH
            catch (Exception insertFAILED)
            {
                // Shows Message box displaying an error and it's description
                MessageBox.Show
                    (
                    $"Professor upload/insertion failed:{insertFAILED.Message}; Source: {insertFAILED.Source + Environment.NewLine}",
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


        // Gets the data for Professor from BsonDocument
        internal void GetProfessorFromBson(in BsonDocument theProfessor)
        {
            _id = (ObjectId)theProfessor.GetValue("_id");

            Name = theProfessor.GetValue("name").ToString() ?? "N/A";

            Surname = theProfessor.GetValue("surname").ToString() ?? "N/A";

            Birthdate = (DateTime)theProfessor.GetValue("birthdate");

            _Image = ImageHelper.FromByteToImage((byte[])theProfessor.GetValue("image"));

            Password = null;

            Email = theProfessor.GetValue("email").ToString() ?? "N/A";

            BsonArray _BsonArraySubjects= new BsonArray((BsonArray)theProfessor.GetValue("subjects_teaching"));
            SubjectsTeaching = Get_SubjectsFromBsonArray(_BsonArraySubjects);

            Active = (bool)theProfessor.GetValue("active");

            //  The line of code I wrote below is really cool in a way so I'll just keep it. `Subjects_Teaching` was `List<string>` once.
                            //  ?.AsQueryable().Select(element => element.ToString()).ToList() ?? new List<string?>();  //
        }


        internal Dictionary<string, List<string>> Get_SubjectsFromBsonArray(in BsonArray _BsonArraySubjects)
        {
            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < _BsonArraySubjects.Count; i++)
            {

                if (_BsonArraySubjects[i] is BsonString)
                    dictionary.Add((string)_BsonArraySubjects[i], new List<string>());

                else if (_BsonArraySubjects[i] is BsonArray)
                {

                    for (int j = 0; j < (_BsonArraySubjects[i] as BsonArray).Count; j++)
                        dictionary[dictionary.Last().Key].Add((string)_BsonArraySubjects[i][j]);

                }

            }

            return dictionary;
        }


        internal BsonArray Get_SubjectsAsBsonArray()
        {
            BsonArray bsonArray_Years = new BsonArray();

            foreach(string key in SubjectsTeaching.Keys)
            {
                bsonArray_Years.Add(key);

                BsonArray bsonArray_Subjects = new BsonArray();

                for (int j = 0; j < SubjectsTeaching[key].Count; j++)
                    bsonArray_Subjects.Add(SubjectsTeaching[key][j]);

                bsonArray_Years.Add(bsonArray_Subjects);

            }

            return bsonArray_Years;
        }


        // When Professors account get's logged in, the `loggedIn` field on Atlas is updated to `true`
        internal void UpdateProfessor_LoggedIn_Field_toLoggedIn()
        {
            FilterDefinition<BsonDocument> filterToProfessor = Builders<BsonDocument>.Filter.Eq("_id", _id);

            UpdateDefinition<BsonDocument> update_loggedIn = Builders<BsonDocument>.Update.Set("loggedIn", true);

            ProfessorAtlasAccess.Client.
                GetDatabase(ProfessorAtlasAccess.AtlasDB_FacultyPersonell).
                GetCollection<BsonDocument>(ProfessorAtlasAccess.AtlasCollection_Professor).
                UpdateOne(filterToProfessor, update_loggedIn);

            LoggedIn = true;
        }


        // When Professors account get's logged out, the `loggedIn` field on Atlas is updated to `false`
        internal void UpdateProfessor_LoggedIn_Field_toLoggedOut()
        {
            FilterDefinition<BsonDocument> filterToProfessor = Builders<BsonDocument>.Filter.Eq("_id", _id);

            UpdateDefinition<BsonDocument> update_loggedIn = Builders<BsonDocument>.Update.Set("loggedIn", false);

            ProfessorAtlasAccess.Client.
                GetDatabase(ProfessorAtlasAccess.AtlasDB_FacultyPersonell).
                GetCollection<BsonDocument>(ProfessorAtlasAccess.AtlasCollection_Professor).
                UpdateOne(filterToProfessor, update_loggedIn);
        }
    }
}