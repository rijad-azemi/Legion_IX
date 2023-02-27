using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.DB
{
    internal class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public Image _Image { get; set; }
        public string Index { get; set; }
        public bool Revised { get; set; }

        // Default ctor
        public Student()
        {
            Name = "";
            Surname = "";
            Birthdate = null;
            _Image = null;
            Index = "IB";
            Revised = false;
        }

        // User defined ctor
        public Student(string name, string surname, DateTime birthdate, string index, bool revised)
        {
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
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
            _Image = studentToCopy._Image;
            Index = studentToCopy.Index;
            Revised = studentToCopy.Revised;
        }

        public void DocumentToInsert()
        {
            var document = new BsonDocument
            {
                {"name", Name},
                {"age", 30},
                {"email", "john.doe@example.com"}
            };
        }
    }
}
