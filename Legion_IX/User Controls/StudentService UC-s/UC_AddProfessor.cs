using Amazon.Runtime.Internal.Transform;
using Legion_IX.DB;
using Legion_IX.Helpers;
using Legion_IX.Users;
using Microsoft.AspNetCore.Http;
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
    public partial class UC_AddProfessor : UserControl
    {

        // Instance that will provide the connection to Atlas
        private AtlasDB AtlasAccess = new AtlasDB();
        // ----------------------------------------- //
        private Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();


        public UC_AddProfessor()
        {
            InitializeComponent();
        }


        private void UC_AddProfessor_Load(object sender, EventArgs e)
        {
            txtBox_ProffEmail.Text = ".@edu.fit.ba";

            AddOptionsToComboBox_Professor();

            chkListBox_Subjects.ItemCheck += ChkListBox_Subjects_ItemCheck;
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
            string[] options = { "First Year", "Second Year", "Third Year" };
            int i = 0;

            foreach (string option in options)
            {
                comboBox_StudyYearProfessor.Items.Add(option);
                dictionary.Add(option, new List<string>()); // !!!!!!!! !!!!!!!!!!!!!!!!!!!!!!! !!!!!!!!!!!!! //
            }

            comboBox_StudyYearProfessor.SelectedItem = comboBox_StudyYearProfessor.Items[0];
        }


        private void comboBox_YearForSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkListBox_Subjects.Items.Clear();

            Give_chkListBox_SubjectsByYear();
        }


        // Gives check list box items based on selcted year; private variable below is used to prevent the event from firing when the method is called from another method
        private bool comingFrom_Give_chkListBox_SubjectsByYear_method = false;
        private void Give_chkListBox_SubjectsByYear()
        {

            IAsyncCursor<string> listOfSubjects = AtlasAccess.Client.GetDatabase(comboBox_StudyYearProfessor?.SelectedItem?
                .ToString()?.Replace(" ", "")).ListCollectionNames();

            List<string> theListFromAtlas = listOfSubjects.ToList();

            for (int i = 0; i < theListFromAtlas.Count; i++)
            {

                chkListBox_Subjects.Items.Add(theListFromAtlas[i]);

                if (dictionary[(string)comboBox_StudyYearProfessor.SelectedItem].Contains(theListFromAtlas[i]))
                {
                    comingFrom_Give_chkListBox_SubjectsByYear_method = true;

                    chkListBox_Subjects.SetItemChecked(i, true);

                    comingFrom_Give_chkListBox_SubjectsByYear_method = false;
                }

            }

        }


        private void ChkListBox_Subjects_ItemCheck(object? sender, ItemCheckEventArgs e)
        {

            if (!comingFrom_Give_chkListBox_SubjectsByYear_method)
            {

                //!dictionary[comboBox_StudyYearProfessor.SelectedIndex].Contains(chkListBox_Subjects.Items[e.Index])
                if (e.NewValue == CheckState.Checked)
                    dictionary[(string)comboBox_StudyYearProfessor.SelectedItem].Add(chkListBox_Subjects?.Items[e.Index]?.ToString() ?? string.Empty);

                else
                    dictionary[(string)comboBox_StudyYearProfessor.SelectedItem].Remove(chkListBox_Subjects?.Items[e.Index]?.ToString() ?? string.Empty);

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
            if (!MyValidators.ValidateEmail(txtBox_ProffEmail.Text) || txtBox_ProffEmail.Text.IsNullOrEmpty())
                err_ProfessorEmailFormat.SetError(txtBox_ProffEmail, "Wrong Email Format!");

            else
            {
                err_ProfessorEmailFormat.SetError(txtBox_ProffEmail, "");
                AllGood = true;
            }

            // PASSWORD VALIDATION
            if (!MyValidators.ValidatePassword(txtBox_ProffEmail.Text) || txtBox_ProffPassword.Text.IsNullOrEmpty())
                err_ProfessorPasswordFormat.SetError(txtBox_ProffEmail, "Wrong Password Format!");

            else
            {
                err_ProfessorPasswordFormat.SetError(txtBox_ProffEmail, "");
                AllGood = true;
            }

            if (!MyValidators.Validate_ServicerAssignedSubjectsToStudent_Dictionary(in dictionary))
                err_ProfessorSubjectsNotAssigned.SetError(comboBox_StudyYearProfessor, "You must assign at least one subject to Professor");

            else
            {
                err_ProfessorSubjectsNotAssigned.SetError(comboBox_StudyYearProfessor, "");
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

                if (CreateProfessorObject().CreateAndUpload())
                {

                    ResetInputFields();

                    Reset_chkListBox();
                }

                else
                    MessageBox.Show("Problem has occured: Check 'btn_CreateProff_Click'!");

            }

        }


        // Creates and returns an object of Professor
        private Professor CreateProfessorObject()
        {
            return new Professor
                (

                txtBox_ProffName.Text,
                txtBox_ProffSurname.Text,
                dtTimePicker_ProffBirthdate.Value,
                picBox_ProffPhoto.Image,

                txtBox_ProffPassword.Text,
                txtBox_ProffEmail.Text,

                Get_FilteredDictionary()

                );
        }


        // Returns a filtered dictionary that does not contain empty lists and empty spaces in keys
        private Dictionary<string, List<string>> Get_FilteredDictionary()
        {
            Dictionary<string, List<string>> filteredDictionary = new Dictionary<string, List<string>>();

            foreach(string key in dictionary.Keys)
                if (dictionary[key].Count > 0)
                    filteredDictionary.Add(key.Replace(" ", ""), new List<string>(dictionary[key]));

            return filteredDictionary;
        }


        // Resets input fields
        private void ResetInputFields()
        {
            MessageBox.Show("Created and Added to ATLAS!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Resseting Input Fields
            txtBox_ProffName.Text = "";
            txtBox_ProffSurname.Text = "";
            dtTimePicker_ProffBirthdate.Value = DateTime.Now;

            txtBox_ProffEmail.Text = ".@edu.fit.ba";
            checkBox_CustomProffEmail.Checked = false;

            txtBox_ProffPassword.Text = "";

            // Resetting the image to be as original
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_AddProfessor));
            picBox_ProffPhoto.Image = (Image)resources.GetObject("picBox_ProffPhoto.Image");

            Reset_chkListBox();
        }


        // Resetting Check List Box checked items
        private void Reset_chkListBox()
        {
            /* Might come in handy...
            foreach(int key in dictionary.Keys)
                dictionary[key].Clear();
            */
            chkListBox_Subjects.Items.Clear();
            comboBox_StudyYearProfessor.Items.Clear();

            foreach (List<string> list in dictionary.Values)
                list.Clear();
            dictionary.Clear();

            dictionary = new Dictionary<string, List<string>>();

            AddOptionsToComboBox_Professor();
            Give_chkListBox_SubjectsByYear();
        }
    }
}