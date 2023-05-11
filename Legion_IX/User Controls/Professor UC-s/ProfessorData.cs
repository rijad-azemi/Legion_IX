using Legion_IX.Helpers;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legion_IX.User_Controls.Professor_UC_s
{
    public partial class ProfessorData : UserControl
    {
        public ProfessorData()
        {
            InitializeComponent();
        }


        private void UserControlProf_Load(object sender, EventArgs e)
        {
            // Hiding from view on load
            this.Hide();
        }


        // Assigning all data to UI of UserControl
        internal void GetDataFrom_frmProfessorProfile()
        {
            txtBox_uc_DisplayName.Text = LoggedInProfessor.theProf.Name;
            txtBox_uc_DisplaySurname.Text = LoggedInProfessor.theProf.Surname;
            txtBox_uc_DisplayBirthdate.Text = LoggedInProfessor.theProf.Birthdate.ToString();

            picBox_uc_ProfessorPhoto.Image = LoggedInProfessor.theProf._Image;

            txtBox_uc_Email.Text = LoggedInProfessor.theProf.Email;

            GiveSubjectsToListBox();
        }


        // Gives subjects by year to ListBox for display
        private void GiveSubjectsToListBox()
        {
            // Reference variable
            Dictionary<string, List<string>> subjects = LoggedInProfessor.theProf.SubjectsTeaching;

            foreach (string key in subjects.Keys)
            {
                listBox_ProfessorSubjects.Items.Add(TidyFacultyYear(key));

                foreach (string subject in subjects[key])
                    listBox_ProfessorSubjects.Items.Add(subject);

                listBox_ProfessorSubjects.Items.Add("");
            }
        }


        private string TidyFacultyYear(string facultyYear)
        {
            switch (facultyYear)
            {
                case "FirstYear": return "--- First Year ---";
                case "SecondYear": return "--- Second Year ---";
                case "ThirdYear": return "--- Third Year ---";
                case "FourthYear": return "--- Fourth Year ---";

                default: return "";
            }
        }
    }
}
