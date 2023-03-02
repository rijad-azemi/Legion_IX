using Legion_IX.DB;
using Legion_IX.Helpers;
using MongoDB.Driver.Core.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legion_IX
{
    public partial class frm_AddStudent : Form
    {
        Validators validationAccess = new Validators();

        public frm_AddStudent()
        {
            InitializeComponent();
        }

        private void frm_AddStudent_Load(object sender, EventArgs e)
        {
            txtBox_Email.Text = ".@edu.fit.ba";
            AddOptionsToComboBox();
        }

        // GENERATE Email Address
        private void GenerateEmail()
        {
            // Generates email based on Name and Surname
            string generatedEmail = $"{txtBox_Name.Text.ToLower()}.{txtBox_Surname.Text.ToLower()}@edu.fit.ba";

            // Gives it to TextBox Email
            txtBox_Email.Text = generatedEmail;
        }

        // Add Options to ComboBox
        private void AddOptionsToComboBox()
        {
            comboBox_StudyYear.Items.Add("First Year");
            comboBox_StudyYear.Items.Add("Second Year");
            comboBox_StudyYear.Items.Add("Third Year");
            comboBox_StudyYear.Items.Add("Fourth Year");
        }

        // Text Box Name Event
        private void txtBox_Name_TextChanged(object sender, EventArgs e)
        {
            GenerateEmail();
        }

        //Text Box Surname Event
        private void txtBox_Surname_TextChanged(object sender, EventArgs e)
        {
            GenerateEmail();
        }

        // Check Box Custom Email
        private void checkBox_EnterCustomEmail_CheckedChanged(object sender, EventArgs e)
        {
            // If checked, allow custom email
            if (checkBox_EnterCustomEmail.Checked)
                txtBox_Email.ReadOnly = false;

            // If unchecked, set to read only and revert to original variant
            else
            {
                txtBox_Email.ReadOnly = true;
                GenerateEmail();
            }
        }

        // Button Load Photo
        private void btn_LoadPhoto_Click(object sender, EventArgs e)
        {
            //openFileDialog_SetPhoto = new OpenFileDialog();
            //openFileDialog_SetPhoto.ShowDialog();
            if (openFileDialog_SetPhoto.ShowDialog() == DialogResult.OK)
            {
                pictureBox_StudentPhoto.Image = Image.FromFile(openFileDialog_SetPhoto.FileName);
            }
        }

        // Validate Inputs
        private bool InputValidation(object sender, EventArgs e)
        {
            bool AllGood = false;

            // EMAIL VALIDATION
            if (!validationAccess.ValidateEmail(txtBox_Email.Text))
                err_EmailFormat.SetError(txtBox_Email, "Wrong Email Format!");

            else
            {
                err_EmailFormat.SetError(txtBox_Email, "");
                AllGood = true;
            }

            // PASSWORD VALIDATION
            if (!validationAccess.ValidatePassword(txtBox_Email.Text))
                err_PasswordFormat.SetError(txtBox_Email, "Wrong Password Format!");

            else
            {
                err_PasswordFormat.SetError(txtBox_Email, "");
                AllGood = true;
            }

            // Returning
            return AllGood;
        }

        // Create Student
        private void btn_CreateStudent_Click(object sender, EventArgs e)
        {
            if (InputValidation(sender, e))
            {
                Student newStudent = new Student
                    (
                    txtBox_Name.Text,
                    txtBox_Surname.Text,
                    pictureBox_StudentPhoto.Image,
                    dtTimePicker_Birthdate.Value,
                    comboBox_StudyYear.Text,
                    txtBox_Index.Text,
                    txtBox_Password.Text,
                    txtBox_Email.Text,
                    checkBox_Revised.Checked
                    );

                if (newStudent.CreateAndUpload())
                {
                    MessageBox.Show("Created and Added to ATLAS!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Resseting Input Fields
                    txtBox_Name.Text = "";
                    txtBox_Surname.Text = "";
                    dtTimePicker_Birthdate.Value = DateTime.Now;
                    comboBox_StudyYear.Text = "- - - - - - - - - - - - - - - - - - - -";
                    txtBox_Email.Text = ".@edu.fit.ba";
                    checkBox_EnterCustomEmail.Checked = false;
                    txtBox_Index.Text = "";
                    txtBox_Password.Text = "";
                    pictureBox_StudentPhoto.Image = null;
                }

                else
                    MessageBox.Show("Problem has occured: Check 'btn_CreateStudent_Click'!");
            }
        }
    }
}