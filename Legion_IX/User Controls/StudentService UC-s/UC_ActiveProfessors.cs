using Legion_IX.DB;
using Legion_IX.Helpers;
using Legion_IX.Users;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace Legion_IX.User_Controls.StudentService_UC_s
{
    public partial class UC_ActiveProfessors : UserControl
    {

        AtlasDB AtlasConnection = new AtlasDB();

        List<DataForDGV> listOfProfs = new List<DataForDGV>();

        List<int> indexdDisabledAccounts = new List<int>();

        // Keep in mind that these are acctually a reference variables...
        int ActiveFieldIndex_inDGV;
        int ButtonFieldIndex_inDGV;


        public UC_ActiveProfessors()
        {
            InitializeComponent();
            
            ActiveFieldIndex_inDGV = dgv_ActiveProfessors.Columns.IndexOf(Active);
            ButtonFieldIndex_inDGV = dgv_ActiveProfessors.Columns.IndexOf(RevokePrivileges);

            this.Hide();
        }


        private async void UC_ActiveProfessors_Load(object sender, EventArgs e)
        {

            dgv_ActiveProfessors.AutoGenerateColumns = false;
            dgv_ActiveProfessors.RowHeadersVisible = false;
            dgv_ActiveProfessors.DataSource = null;

            await LoadProfsTo_dgv(); // Environment failed to warn me about `await` keyword missing. Still a valuable lesson, remember that.
            AssignTextToDataGridViewButtons();

        }


        internal void btn_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private async Task LoadProfsTo_dgv()
        {
            await GetProfessorsFromAtlas();

            dgv_ActiveProfessors.DataSource = listOfProfs;
        }


        private void AssignTextToDataGridViewButtons()
        {

            for (int i = 0; i < listOfProfs.Count; i++)
                AdjustButtonCellText(i, ButtonFieldIndex_inDGV, listOfProfs[i].Active);

            for (int i = 0; i < indexdDisabledAccounts.Count; i++)
                Paint_dgv_ActiveField(indexdDisabledAccounts[i], ActiveFieldIndex_inDGV, listOfProfs[indexdDisabledAccounts[i]].Active);
        }


        private async Task GetProfessorsFromAtlas()
        {
            IAsyncCursor<BsonDocument> theProfsCollection = await AtlasConnection.Client.
                GetDatabase(AtlasConnection.AtlasDB_FacultyPersonell).GetCollection<BsonDocument>(AtlasConnection.AtlasCollection_Professor).FindAsync(new BsonDocument());

            //                I was mad...              //
            List<BsonDocument> djhasjkh = theProfsCollection.ToList();

            foreach (BsonDocument prof in djhasjkh)
            {
                listOfProfs.Add(GetProfessorFromBson(prof));

                if ((bool)prof.GetValue("active") == false)
                    indexdDisabledAccounts.Add(listOfProfs.Count - 1);
            }
        }


        // Gets the data for Professor from BsonDocument
        internal DataForDGV GetProfessorFromBson(in BsonDocument theProfessor)
        {
            DataForDGV theProf = new DataForDGV();

            theProf._id = (ObjectId)theProfessor.GetValue("_id");
            theProf.FirstName = (string)theProfessor.GetValue("name");
            theProf.Surname = (string)theProfessor.GetValue("surname");
            theProf.Birthdate = (DateTime)theProfessor.GetValue("birthdate");
            theProf.Email = (string)theProfessor.GetValue("email");

            theProf.Active = (bool)theProfessor.GetValue("active");

            return theProf;
        }


        private async void dgv_ActiveProfessors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dgv_ActiveProfessors.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {

                await UpdateProfessorAccount_activeField(e.RowIndex, !listOfProfs[e.RowIndex].Active);

                if(await Check_if_ChangeReflectedOnAtlas_and_UpdateListofProfs(e.RowIndex))
                {

                    // Painting `Active` field belonging to DGV based on the value of the `Active` field of the account
                    Paint_dgv_ActiveField(e.RowIndex, ActiveFieldIndex_inDGV, listOfProfs[e.RowIndex].Active);

                    // Adjusting the text of the button based on the value of the `Active` field of the account
                    AdjustButtonCellText(e.RowIndex, ButtonFieldIndex_inDGV, listOfProfs[e.RowIndex].Active);

                }

                else
                    MessageBox.Show("Change was not reflected on Atlas, please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }


        private async Task UpdateProfessorAccount_activeField(int professorIndex, bool activeField)
        {
            FilterDefinition<BsonDocument> filterToProfessor = Builders<BsonDocument>.Filter.Eq("_id", listOfProfs[professorIndex]._id);
            UpdateDefinition<BsonDocument> updateProfActiveField = Builders<BsonDocument>.Update.Set("active", activeField);

            await AtlasConnection.Client.
                GetDatabase(AtlasConnection.AtlasDB_FacultyPersonell).
                GetCollection<BsonDocument>(AtlasConnection.AtlasCollection_Professor).
                UpdateOneAsync(filterToProfessor, updateProfActiveField);
        }


        private void Paint_dgv_ActiveField(int rowIndex, int fieldIndex, bool activeField)
        {
            // Meaning the account is activated
            if(activeField)
                dgv_ActiveProfessors.Rows[rowIndex].Cells[fieldIndex].Style.BackColor = Color.White;

            // Meaning the account is disabled
            else
                dgv_ActiveProfessors.Rows[rowIndex].Cells[fieldIndex].Style.BackColor = Color.Red;
        }


        private void AdjustButtonCellText(int rowIndex, int fieldIndex, bool activeField)
        {
            DataGridViewRow row = dgv_ActiveProfessors.Rows[rowIndex];

            if(activeField)
                row.Cells[fieldIndex].Value = "Revoke Account";

            else
                row.Cells[fieldIndex].Value = "Activate Account";
        }


        // Method which makes sure that the change was reflected and stored on Atlas accordingly
        private async Task<bool> Check_if_ChangeReflectedOnAtlas_and_UpdateListofProfs(int professorIndex)
        {
            PipelineDefinition<BsonDocument, BsonDocument> pipeline = new BsonDocument[]
            {
                new BsonDocument("$match", new BsonDocument("_id", listOfProfs[professorIndex]._id)),
                new BsonDocument("$project", new BsonDocument("active", 1))
            };

            IAsyncCursor<BsonDocument> theProfessorAccount = await AtlasConnection.Client.

                GetDatabase(AtlasConnection.AtlasDB_FacultyPersonell).
                GetCollection<BsonDocument>(AtlasConnection.AtlasCollection_Professor).
                AggregateAsync(pipeline);

            // Extracted `active` field of Professor's account from Atlas
            bool activeField = (bool)theProfessorAccount.FirstOrDefault().GetValue("active");

            // The following if statement mathes current local boolean value of the `Active` field against the one stored on Atlas, if they are the same, which
                    // should not be possible if the button was clicked, it warns the user that the change was not reflected on Atlas and therefore the Account was not 
                        // disabled/activated
            if ((bool)dgv_ActiveProfessors.Rows[professorIndex].Cells[ActiveFieldIndex_inDGV].Value == activeField)
                return false;

            // If previous condition is not met then the change was reflected on Atlas and the local boolean value of the `Active` field is updated to Professor in original list
            listOfProfs[professorIndex].Active = activeField;

            // Updating the `Active` field of the DataGridView
            dgv_ActiveProfessors.Rows[professorIndex].Cells[ActiveFieldIndex_inDGV].Value = activeField;

            // Returning `true` signifying that all went accordingly and giving the go ahead for futher UI changes in DataGridView Cell click event handler
            return true;
        }

    }

    // This class exists because the `Professor` class is classified as internal so their properties and it's values will not be visible
    // when to Data Grid View when a list of `Professor` object is given to it's `DataSource` property
    public class DataForDGV
    {
        public ObjectId _id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public DataForDGV()
        {
            FirstName = "";
            Surname = "";

            Email = "";
        }
    }
}