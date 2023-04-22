using Legion_IX.Helpers;
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

namespace Legion_IX.User_Controls.Professor_UC_s
{
    public partial class ProfessorDocuments : UserControl
    {

        public string ChosenSubject { get; set; }
        public List<AtlasFile> files { get; set; }

        internal ProfessorDocuments()
        {
            InitializeComponent();
        }


        private void ProfessorDocuments_Load(object sender, EventArgs e)
        {
            this.Hide();

            // Loading the list of subjects to comboBox
            LoadToComboBoxSubjects();
        }


        private void LoadToComboBoxSubjects()
        {
            comboBox_Subjects.DataSource = LoggedInProfessor.theProf.Subjects_Teaching;
            ChosenSubject = (string)comboBox_Subjects.SelectedItem;
        }


        private void comboBox_Subjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChosenSubject = (string)comboBox_Subjects.SelectedItem;

            btn_Refresh_Click(sender, e);
        }


        private void LoadDocumentsTo_dgv()
        {

        }


        private async Task GetAvailableDocuments()
        {
            List<BsonDocument> pipeline = new List<BsonDocument>()
            {
                new BsonDocument("$project", new BsonDocument()
                {
                    { "NameOfFile", 1 },
                    { "FileType", 1 },
                    { "TimeStamp_Creation", 1 }
                })
            };

            //IAsyncCursor<BsonDocument> aggregateResult = await
                //LoggedInProfessor.theProf.ProfessorAtlasAccess.Client.GetDatabase("")
        }


        private void dgv_Files_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btn_UploadDocument_Click(object sender, EventArgs e)
        {

        }


        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            // Resetting the `dgv_files` DataSource property to null
            dgv_Files.DataSource = null;

            // Loading fresh data based on choice from `comboBox_Subjects`
            LoadDocumentsTo_dgv();
        }
    }
}