using Legion_IX.DB;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legion_IX
{
    public partial class frmStudentProfile : Form
    {
        static Student? theStudent = new Student();

        public frmStudentProfile(ref BsonDocument loggedStudent)
        {
            BsonDocument studentBson = new BsonDocument(loggedStudent);

            // Gets student data from BsonDocument
            theStudent = theStudent.GetStudentFromBson(ref studentBson);

            InitializeComponent();
        }

        private void frmStudentProfile_Load(object sender, EventArgs e)
        {
            txtBox_DisplayName.Text = theStudent.Name;
            txtBox_DisplaySurname.Text = theStudent.Surname;
            txtBox_DisplayBirthdate.Text = theStudent.Birthdate.ToString();
            txtBox_DisplayStudyYear.Text = theStudent.StudyYear;
            picBox_StudentPhoto.Image = theStudent._Image;
            txtBox_DisplayIndex.Text = theStudent.Index;
            txtBox_Email.Text = theStudent.Email;
            txtBox_Revised.Text = (theStudent.Revised) ? "--- Yes ---" : "--- No ---";
        }

        private void button_LogOut_Click(object sender, EventArgs e)
        {
            // Creating again the instance of the login form
            frmLoginScreen backToTlogIn = new frmLoginScreen();

            // Hide current from view
            this.Hide();

            // Show the form
            backToTlogIn.ShowDialog();

            // This message will be displayed onto the 'lblAccNotFound'
            backToTlogIn.displayLogoutMessage("--- You have been logged out ---");

            // Closing current form
            this.Close();
        }
    }
}