using Legion_IX.DB;
using Legion_IX.Helpers;
using Legion_IX.Users;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        List<DataForDGV> listOfProfs = new List<DataForDGV>();

        public UC_ActiveProfessors()
        {
            InitializeComponent();

            this.Hide();
        }


        private void UC_ActiveProfessors_Load(object sender, EventArgs e)
        {

            dgv_ActiveProfessors.AutoGenerateColumns = false;
            dgv_ActiveProfessors.RowHeadersVisible = false;
            dgv_ActiveProfessors.DataSource = null;

            LoadProfsTo_dgv();

        }


        private async void LoadProfsTo_dgv()
        {
            await GetProfessorsFromAtlas();

            dgv_ActiveProfessors.DataSource = listOfProfs;
        }


        private async Task GetProfessorsFromAtlas()
        {
            AtlasDB AtlasConnection = new AtlasDB();

            IAsyncCursor<BsonDocument> theProfsCollection = await AtlasConnection.Client.
                GetDatabase(AtlasConnection.AtlasDB_FacultyPersonell).GetCollection<BsonDocument>(AtlasConnection.AtlasCollection_Professor).FindAsync(new BsonDocument());

            //                I was mad...              //
            List<BsonDocument> djhasjkh = theProfsCollection.ToList();

            foreach (BsonDocument prof in djhasjkh)
            {
                listOfProfs.Add(GetProfessorFromBson(prof));
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


        internal void btn_Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgv_ActiveProfessors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if(e.RowIndex >= 0 && dgv_ActiveProfessors.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {

            }

        }
    }

    // This class exists because the `Professor` class is classified as internal so their properties and it's values will not be visible //
    // when to Data Grid View when a list of `Professor` object is given to it's `DataSource` property                                   //
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