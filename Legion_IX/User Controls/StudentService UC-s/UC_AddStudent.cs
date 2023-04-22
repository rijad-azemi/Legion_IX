using Legion_IX.Helpers;
using Legion_IX.Users;
using Microsoft.IdentityModel.Tokens;
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
    internal partial class UC_AddStudent : UserControl
    {
        public UC_AddStudent()
        {
            InitializeComponent();
        }


        private void UC_AddStudent_Load(object sender, EventArgs e)
        {
            txtBox_StudentEmail.Text = ".@edu.fit.ba";
            AddOptionsToComboBox();
        }


        // GENERATE Email Address
        private void GenerateStudentEmail()
        {
            // Generates email based on Name and Surname
            string generatedEmail = $"{txtBox_StudentName.Text.ToLower()}.{txtBox_StudentSurname.Text.ToLower()}@edu.fit.ba";

            // Gives it to TextBox Email
            txtBox_StudentEmail.Text = generatedEmail;
        }


        // Add Options to ComboBox
        private void AddOptionsToComboBox()
        {
            comboBox_StudyYear.Items.Add("First Year");
            comboBox_StudyYear.Items.Add("Second Year");
            comboBox_StudyYear.Items.Add("Third Year");

            comboBox_StudyYear.SelectedItem = comboBox_StudyYear.Items[0];
        }


        // Text Box Name Event
        private void txtBox_StudentName_TextChanged(object sender, EventArgs e)
        {
            GenerateStudentEmail();
        }


        //Text Box Surname Event
        private void txtBox_StudentSurname_TextChanged(object sender, EventArgs e)
        {
            GenerateStudentEmail();
        }


        // Check Box Custom Email
        private void checkBox_EnterCustomEmail_CheckedChanged(object sender, EventArgs e)
        {
            // If checked, allow custom email
            if (checkBox_EnterCustomEmail.Checked)
                txtBox_StudentEmail.ReadOnly = false;

            // If unchecked, set to read only and revert to original variant
            else
            {
                txtBox_StudentEmail.ReadOnly = true;
                GenerateStudentEmail();
            }
        }


        // Button Load Photo
        private void btn_LoadPhoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog_SetStudentPhoto.ShowDialog() == DialogResult.OK)
            {
                picBox_StudentPhoto.Image = Image.FromFile(openFileDialog_SetStudentPhoto.FileName);
            }
        }


        // Validate Inputs
        private bool InputValidation_Student(object sender, EventArgs e)
        {
            bool AllGood = false;

            // EMAIL VALIDATION
            if (!MyValidators.ValidateEmail(txtBox_StudentEmail.Text) || txtBox_StudentEmail.Text.IsNullOrEmpty())
                err_StudentEmailFormat.SetError(txtBox_StudentEmail, "Wrong Email Format!");

            else
            {
                err_StudentEmailFormat.SetError(txtBox_StudentEmail, "");
                AllGood = true;
            }

            // PASSWORD VALIDATION
            if (!MyValidators.ValidatePassword(txtBox_StudentPassword.Text) || txtBox_StudentPassword.Text.IsNullOrEmpty())
                err_StudentPasswordFormat.SetError(txtBox_StudentPassword, "Wrong Password Format!");

            else
            {
                err_StudentPasswordFormat.SetError(txtBox_StudentPassword, "");
                AllGood = true;
            }

            // Returning
            return AllGood;
        }


        // Create Student
        private void btn_CreateStudent_Click(object sender, EventArgs e)
        {
            if (InputValidation_Student(sender, e))
            {
                Student newStudent = new Student
                    (
                    txtBox_StudentName.Text,
                    txtBox_StudentSurname.Text,
                    picBox_StudentPhoto.Image,
                    dtTimePicker_Birthdate.Value,
                    comboBox_StudyYear.Text,
                    txtBox_Index.Text,
                    txtBox_StudentPassword.Text,
                    txtBox_StudentEmail.Text,
                    checkBox_Revised.Checked
                    );

                if (newStudent.CreateAndUpload())
                {
                    MessageBox.Show("Created and Added to ATLAS!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Resseting Input Fields
                    txtBox_StudentName.Text = "";
                    txtBox_StudentSurname.Text = "";
                    dtTimePicker_Birthdate.Value = DateTime.Now;
                    comboBox_StudyYear.Text = "- - - - - - - - - - - - - - - - - - - -";
                    txtBox_StudentEmail.Text = ".@edu.fit.ba";
                    checkBox_EnterCustomEmail.Checked = false;
                    txtBox_Index.Text = "";
                    txtBox_StudentPassword.Text = "";

                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_AddStudent));
                    picBox_StudentPhoto.Image = (Image)resources.GetObject("picBox_StudentPhoto.Image");
                }

                else
                    MessageBox.Show("Problem has occured: Check 'btn_CreateStudent_Click'!");
            }
        }
    }
}