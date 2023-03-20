using Legion_IX.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legion_IX.User_Controls
{
    public partial class StudentData : UserControl
    {
        public StudentData()
        {
            InitializeComponent();
        }

        private void StudentData_Load(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        public void GetDataFrom_frmStudentProfile(in Student theStudent)
        {
            txtBox_uc_DisplayName.Text = theStudent.Name;
            txtBox_uc_DisplaySurname.Text = theStudent.Surname;
            txtBox_uc_DisplayBirthdate.Text = theStudent.Birthdate.ToString();
            txtBox_uc_DisplayStudyYear.Text = theStudent.StudyYear;
            picBox_uc_StudentPhoto.Image = theStudent._Image;
            txtBox_uc_DisplayIndex.Text = theStudent.Index;
            txtBox_uc_Email.Text = theStudent.Email;
            txtBox_uc_Revised.Text = (theStudent.Revised) ? "--- Yes ---" : "--- No ---";
        }

        // Shows UC in view
        public void ShowMe() => this.Visible = true;

        // Hides UC from view
        public void HideMe() => this.Visible = false;
    }
}