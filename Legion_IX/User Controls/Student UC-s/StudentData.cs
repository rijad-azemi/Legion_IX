using Legion_IX.DB;
using Legion_IX.Helpers;
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
            // Hiding from view on load
            this.Hide();
        }

        public void GetDataFrom_frmStudentProfile()
        {
            txtBox_uc_DisplayName.Text = LoggedInStudent.theStudent.Name;
            txtBox_uc_DisplaySurname.Text = LoggedInStudent.theStudent.Surname;
            txtBox_uc_DisplayBirthdate.Text = LoggedInStudent.theStudent.Birthdate.ToString();
            txtBox_uc_DisplayStudyYear.Text = LoggedInStudent.theStudent.StudyYear;
            picBox_uc_StudentPhoto.Image = LoggedInStudent.theStudent._Image;
            txtBox_uc_DisplayIndex.Text = LoggedInStudent.theStudent.Index;
            txtBox_uc_Email.Text = LoggedInStudent.theStudent.Email;
            txtBox_uc_Revised.Text = (LoggedInStudent.theStudent.Revised) ? "--- Yes ---" : "--- No ---";
        }
    }
}