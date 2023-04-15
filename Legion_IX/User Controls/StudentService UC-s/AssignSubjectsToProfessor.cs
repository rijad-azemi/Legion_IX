using Legion_IX.DB;
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

    public partial class AssignSubjectsToProfessor : UserControl
    {

        internal List<Subjects> SubjectsFor_dgv = new List<Subjects>();
        internal List<string> SubjectsToAssign = new List<string>();

        internal AtlasDB AtlasAccess = new AtlasDB();

        public AssignSubjectsToProfessor()
        {
            InitializeComponent();
        }


        private void ProfessorsSubjects_Load(object sender, EventArgs e)
        {
            this.Hide();

            LoadSubjectsComboBox();
        }


        private void LoadSubjectsComboBox()
        {
            comboBox_FacultyYear.Items.Add("First Year");
            comboBox_FacultyYear.Items.Add("Second Year");
            comboBox_FacultyYear.Items.Add("Third Year");
        }


        private async Task LoadSubjectsTo_dgvSubjects(string? chosenFacultyYear)
        {

            if (chosenFacultyYear != null)
            {
                dgv_Subjects.DataSource = null;

                IAsyncCursor<string> atlas_Subjects = await AtlasAccess.Client.GetDatabase(chosenFacultyYear).ListCollectionNamesAsync();

                foreach(string subject in atlas_Subjects.ToList())
                {
                    SubjectsFor_dgv.Add(new Subjects(subject));
                }

                dgv_Subjects.DataSource = SubjectsFor_dgv;
            }

        }


        private void dgv_Subjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dgv_Subjects.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                DataGridViewCheckBoxCell? clickedCell = dgv_Subjects?.Rows[e.RowIndex]?.Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                //clickedCell.ValueType = typeof(bool); // Useful trick, worth remembering
                /*
                                  *For some reason, the clickedCell.Value get's converted to a string despite it's type value being assigned to bool,
                                  *and it's value being assigned to true or false, it get's converted to a string and throws a `cast` exception
                */



                if (clickedCell.Value == null || clickedCell?.Value.ToString() == false.ToString()) //|| (bool)clickedCell.Value == false
                {
                    clickedCell.Value = true;

                }

                else if (clickedCell != null && clickedCell?.Value.ToString() == true.ToString())
                {
                    clickedCell.Value = false;

                }

            }

        }


        private async void comboBox_ExistingSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_Subjects.DataSource = null;

            await LoadSubjectsTo_dgvSubjects(comboBox_FacultyYear.SelectedItem?.ToString().Replace(" ", ""));
        }


        private void btn_CloseUC_Click(object sender, EventArgs e)
        {
            this.Hide();

            /*
             * comboBox_FacultyYear.SelectedItem = null;
             * dgv_Subjects.DataSource = null;
             */
        }


        private void btn_AssignSubjects_Click(object sender, EventArgs e)
        {

        }
    }


    internal class Subjects
    {

        internal string AtlasSubject { get; set; }

        internal Subjects()
        {
            AtlasSubject = string.Empty;
        }


        internal Subjects(string atlasSubject)
        {
            AtlasSubject = atlasSubject;
        }

    }
}