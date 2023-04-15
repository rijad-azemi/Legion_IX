using Legion_IX.DB;
using Legion_IX.Helpers;
using Legion_IX.Properties;
using Legion_IX.Users;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.User_Controls.StudentService_UC_s
{
    internal partial class UC_StudentService_ADMIN
    {
        private AtlasDB AtlasAccess = new AtlasDB();


        private void OnLoadPartialClass_Professor()
        {
            txtBox_ProffEmail.Text = ".@edu.fit.ba";

            AddOptionsToComboBox_Professor();
        }


        // GENERATE Email Address
        private void GenerateProffEmail()
        {
            // Generates email based on Name and Surname
            string generatedEmail = $"{txtBox_ProffName.Text.ToLower()}.{txtBox_ProffSurname.Text.ToLower()}@edu.fit.ba";

            // Gives it to TextBox Email
            txtBox_ProffEmail.Text = generatedEmail;
        }


        private void AddOptionsToComboBox_Professor()
        {
            comboBox_StudyYearProfessor.Items.Add("First Year");
            comboBox_StudyYearProfessor.Items.Add("Second Year");
            comboBox_StudyYearProfessor.Items.Add("Third Year");

            comboBox_StudyYearProfessor.SelectedItem = comboBox_StudyYearProfessor.Items[0];
        }


        private void comboBox_YearForSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkListBox_Subjects.Items.Clear();

            Give_chkListBox_SubjectsByYear();
        }


        private void Give_chkListBox_SubjectsByYear()
        {
            IAsyncCursor<string> listOfSubjects = AtlasAccess.Client.GetDatabase(comboBox_StudyYearProfessor?.SelectedItem?.ToString()?.Replace(" ", "")).
                ListCollectionNames();

            foreach(string subject in listOfSubjects.ToList())
            {
                chkListBox_Subjects.Items.Add(subject);
            }

        }


        // Text Box Name Event
        private void txtBox_ProffName_TextChanged(object sender, EventArgs e)
        {
            GenerateProffEmail();
        }


        // Text Box Surname Event
        private void txtBox_ProffSurname_TextChanged(object sender, EventArgs e)
        {
            GenerateProffEmail();
        }


        // Check Box Custom Email
        private void checkBox_CustomProffEmail_CheckedChanged(object sender, EventArgs e)
        {
            // If checked, allow custom email
            if (checkBox_CustomProffEmail.Checked)
                txtBox_ProffEmail.ReadOnly = false;

            // If unchecked, set to read only and revert to original variant
            else
            {
                txtBox_ProffEmail.ReadOnly = true;
                GenerateProffEmail();
            }
        }


        // Button Load Photo
        private void btn_LoadProffPhoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog_SetProffPhoto.ShowDialog() == DialogResult.OK)
            {
                picBox_ProffPhoto.Image = Image.FromFile(openFileDialog_SetProffPhoto.FileName);
            }
        }


        // Validate Inputs
        private bool InputValidation_Professor(object sender, EventArgs e)
        {
            bool AllGood = false;

            // EMAIL VALIDATION
            if (!MyValidators.ValidateEmail(txtBox_ProffEmail.Text))
                err_ProfessorEmailFormat.SetError(txtBox_ProffEmail, "Wrong Email Format!");

            else
            {
                err_ProfessorEmailFormat.SetError(txtBox_ProffEmail, "");
                AllGood = true;
            }

            // PASSWORD VALIDATION
            if (!MyValidators.ValidatePassword(txtBox_ProffEmail.Text))
                err_ProfessorPasswordFormat.SetError(txtBox_ProffEmail, "Wrong Password Format!");

            else
            {
                err_ProfessorPasswordFormat.SetError(txtBox_ProffEmail, "");
                AllGood = true;
            }

            if (!MyValidators.Validate_ServicerAssignedSubjectsToProfessor(chkListBox_Subjects.CheckedItems.Count))
                err_ProfessorSubjectsNotAssigned.SetError(chkListBox_Subjects, "You must assign at least one subject to Professor");

            else
            {
                err_ProfessorSubjectsNotAssigned.SetError(chkListBox_Subjects, "");
                AllGood = true;
            }

            // Returning
            return AllGood;
        }


        // Create Proff
        private void btn_CreateProffesor_Click(object sender, EventArgs e)
        {

            if (InputValidation_Professor(sender, e))
            {
                Professor newProff = new Professor
                    (
                    txtBox_ProffName.Text,
                    txtBox_ProffSurname.Text,
                    dtTimePicker_Birthdate.Value,
                    picBox_ProffPhoto.Image,

                    txtBox_ProffPassword.Text,
                    txtBox_ProffEmail.Text,

                    // You will add the assigned subjects here
                    new BsonArray(chkListBox_Subjects.CheckedItems.Cast<string>().ToList())

                    );

                if (newProff.CreateAndUpload())
                {
                    MessageBox.Show("Created and Added to ATLAS!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Resseting Input Fields
                    txtBox_ProffName.Text = "";
                    txtBox_ProffSurname.Text = "";
                    dtTimePicker_ProffBirthdate.Value = DateTime.Now;
                    comboBox_StudyYear.Text = "- - - - - - - - - - - - - - - - - - - -";
                    txtBox_ProffEmail.Text = ".@edu.fit.ba";
                    checkBox_EnterCustomEmail.Checked = false;
                    
                    txtBox_ProffPassword.Text = "";
                    picBox_ProffPhoto.Image = null;
                }

                else
                    MessageBox.Show("Problem has occured: Check 'btn_CreateProff_Click'!");
            }

        }
    }
}