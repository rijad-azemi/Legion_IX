using Legion_IX.DB;
using Legion_IX.Helpers;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.Users
{
    internal class Professor
    {
        internal const bool Admin = true;

        internal string Name { get; set; }
        internal string Surname { get; set; }
        internal DateTime? Birthdate { get; set; }
        internal Image? _Image { get; set; }
        internal string? Password { get; set; }
        internal string Email { get; set; }

        #region Data for Atlas connection

        internal AtlasDB ProfessorAtlasAccess = new AtlasDB();

        internal static string ProfessorAtlasDB = "FacultyPersonell";
        internal static string ProfessorCollection = "Professor";

        #endregion Data for Atlas connection


        internal Professor()
        {
            Name = "";
            Surname = "";
            Birthdate = null;

            Password = null;
            Email = "";
        }


        internal Professor(string name, string surname, DateTime? birthdate, Image image, string? password, string email)
        {
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            _Image = image;
            Password = password;
            Email = email;
        }


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

                    {"image", new BsonBinaryData(ImageHelper.FromImageToByte(_Image))}

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
            Name = theProfessor.GetValue("name").ToString() ?? "N/A";

            Surname = theProfessor.GetValue("surname").ToString() ?? "N/A";

            Birthdate = (DateTime)theProfessor.GetValue("birthdate");

            _Image = ImageHelper.FromByteToImage((byte[])theProfessor.GetValue("image"));

            Password = null;

            Email = theProfessor.GetValue("email").ToString() ?? "N/A";
        }
    }
}