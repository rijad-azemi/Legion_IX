using Legion_IX.Helpers;
using Legion_IX.ProjectForms;
using Legion_IX.Users;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legion_IX.User_Controls.StudentService_UC_s
{
    public partial class ProfessorsSubjects : UserControl
    {

        internal List<string> ProfessorsForComboBox = new List<string>();

        public ProfessorsSubjects()
        {
            InitializeComponent();
        }


        private void ProfessorsSubjects_Load(object sender, EventArgs e)
        {
            this.Hide();

            LoadProfessorsToComboBox();
        }


        private async void LoadProfessorsToComboBox()
        {

            // The pipeline will only return the name and surname of the professors
            List<BsonDocument> pipeline = new List<BsonDocument>()
            {
                new BsonDocument("$project", new BsonDocument{
                    {"name", 1},
                    {"surname", 1}
                })
            };

            // The cursor will contain the professors from the database
            IAsyncCursor<BsonDocument> RegisteredProfessors = await LoggedInProfessor.theProf.
                ProfessorAtlasAccess.Client.GetDatabase(Professor.ProfessorAtlasDB).GetCollection<BsonDocument>(Professor.ProfessorCollection).AggregateAsync<BsonDocument>(pipeline);

            // Cursor will be converted to a list of BsonDocuments
            List<BsonDocument> ProfessorsList = RegisteredProfessors.ToList();

            // If there are no professors in the database, the combobox will display "NO PROFESSORS IN DATABASE"
            ComboBoxIfCollectionEmpty(in ProfessorsList);

            // Adding the professor names and surnames to list of strings for the combobox
            foreach (BsonDocument Professor in ProfessorsList)
                ProfessorsForComboBox.Add((string)Professor.GetValue("name") + " " + (string)Professor.GetValue("surname"));

            // Binding the list of strings to the combobox
            foreach (string ProfessorFromList in ProfessorsForComboBox)
                comboBox_ExistingProfessors.Items.Add(ProfessorFromList);

        }

        // Method to check if Professors from database converted to a list is empty
        private void ComboBoxIfCollectionEmpty(in List<BsonDocument> ProfessorsOnAtlas)
        {

            if (ProfessorsOnAtlas.IsNullOrEmpty())
            {
                comboBox_ExistingProfessors.Text = "NO PROFESSORS IN DATABASE";
            }

        }


        private void comboBox_ExistingProfessors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_CloseProfSubjects_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}