using Legion_IX.DB;
using Legion_IX.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

namespace Legion_IX.User_Controls
{
    public partial class StudentProfileSettings : UserControl
    {

        #region GlobalVariables


        // Static variable that is set to true if changes have been made to profile
        public static bool ChangesMade { get; set; } = false;
        public static bool HasPhotoChanged { get; set; } = false;
        public static bool HasEmailChanged { get; set; } = false;

        // Reference Variable to the logged in Student
        Student? theStudent = frmStudentProfile.theStudent;

        // I didn't create static methods from the start, so I have to have an instance to access it's methods
        Validators vali = new Validators();


        #endregion GlobalVariables

        public StudentProfileSettings()
        {
            InitializeComponent();
        }


        private void StudentProfileSettings_Load(object sender, EventArgs e)
        {
            GetData();

            // Hiding the User Control from view and `btn_SaveChanges`
            HideControls();
        }


        private void GetData()
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


        // Hiding controls
        private void HideControls()
        {
            this.Hide();

            btn_SaveChanges.Hide();

            btn_DiscardChanges.Hide();
        }


        private bool WereChangesMade()
        {
            if (HasPhotoChanged || HasEmailChanged)
                return true;

            return false;
        }


        private void btn_ChangePhoto_Click(object sender, EventArgs e)
        {
            opf_ChangePhoto.Filter = "JPG;IMG;PNG|*.jpg;*.img;*.png";

            if (opf_ChangePhoto.ShowDialog() == DialogResult.OK)
            {
                picBox_uc_StudentPhoto.Image = Image.FromFile(opf_ChangePhoto.FileName);

                HasPhotoChanged = true;

                // Shows the button for saving changes
                ShowButtonSaveChanges(ChangesMade = true);
            }
        }


        private async void btn_SaveChanges_Click(object sender, EventArgs e)
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("index", theStudent.Index);

            if (ChangesMade)
            {
                await UpdatePhoto(HasPhotoChanged, filter);
                await UpdateEmail(HasEmailChanged, filter);
            }

            Thread signalChange = new Thread(new ThreadStart(() => SignalChangesSaved(5)));
            signalChange.Start();

            #region Remember This...might come in handy


            /*            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("image", ImageHelper.FromImageToByte(picBox_uc_StudentPhoto.Image));

                        await theStudent.StudentDBConnection.Client.GetDatabase("FacultyPersonell").GetCollection<BsonDocument>("Student").UpdateOneAsync(filter, update);

                        ChangesMade = false;
                        ShowButtonSaveChanges(ChangesMade);*/


            /*            //string DB = theStudent.StudyYear.Replace(" ", "");

                        var filter = Builders<BsonDocument>.Filter.Eq("index", theStudent.Index);
                        var update = Builders<BsonDocument>.Update.Set("surname", "Azemi");


                        theStudent.StudentDBConnection.Client.GetDatabase("FacultyPersonell").GetCollection<BsonDocument>("Student").UpdateOneAsync(filter, update);*/


            #endregion Remember This...might come in handy

        }

        private void btn_DiscardChanges_Click(object sender, EventArgs e)
        {
            ShowButtonSaveChanges(ChangesMade = false);

            if (HasEmailChanged)
                btn_EmailChange_Reset_UI();
        }


        private async Task UpdatePhoto(bool save, FilterDefinition<BsonDocument> filter)
        {
            if (save)
            {
                UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("image", ImageHelper.FromImageToByte(picBox_uc_StudentPhoto.Image));
                await theStudent.StudentDBConnection.Client.GetDatabase("FacultyPersonell").GetCollection<BsonDocument>("Student").UpdateOneAsync(filter, update);
            }
        }


        private async Task UpdateEmail(bool save, FilterDefinition<BsonDocument> filter)
        {
            if (save)
            {
                UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("email", txtBox_uc_Email.Text);
                await theStudent.StudentDBConnection.Client.GetDatabase("FacultyPersonell").GetCollection<BsonDocument>("Student").UpdateOneAsync(filter, update);

                btn_EmailChange_Reset_UI();
            }
        }


        private void ShowButtonSaveChanges(bool showButtonSaveChanges)
        {
            if (showButtonSaveChanges)
                btn_SaveChanges.Show();

            else
                btn_SaveChanges.Hide();
        }


        private void btn_ChangeEmail_Click(object sender, EventArgs e)
        {

            // If the Colour is green (signifying user wants to edit) and if email format is valid and if the newly entered email is not the same as the existing one
            if (btn_ChangeEmail.BackColor == Color.Green && vali.ValidateEmail(txtBox_uc_Email.Text))
            {
                // If user clicked on the button, but didn't edit anything, it's labeled as a misclick and the button UI is reset
                if (txtBox_uc_Email.Text == theStudent.Email)
                {
                    btn_EmailChange_Reset_UI();
                    return;
                }

                btn_EmailChange_PendingSave();
            }

            else
            {
                btn_EmailChange_ConfirmChange_UI();
            }

        }


        private void txtBox_uc_Email_TextChanged(object sender, EventArgs e)
        {

            if (btn_ChangeEmail.BackColor == Color.Green && !vali.ValidateEmail(txtBox_uc_Email.Text))
                err_EmailFormat.SetError(btn_ChangeEmail, "Incorrect Format");

            else
                err_EmailFormat.SetError(btn_ChangeEmail, "");

        }


        private void btn_EmailChange_ConfirmChange_UI()
        {
            // Set Email textBox to READONLY
            txtBox_uc_Email.ReadOnly = false;

            HasEmailChanged = false;
            ShowButtonSaveChanges(ChangesMade = false);

            btn_ChangeEmail.Text = "CONFIRM";

            btn_ChangeEmail.BackColor = Color.Green;
            btn_ChangeEmail.ForeColor = Color.White;
        }


        private void btn_EmailChange_PendingSave()
        {
            // Set Email textBox to READONLY
            txtBox_uc_Email.ReadOnly = true;

            HasEmailChanged = true;
            ShowButtonSaveChanges(ChangesMade = true);

            btn_ChangeEmail.Text = "Pending Save";

            btn_ChangeEmail.BackColor = Color.Red;
            btn_ChangeEmail.ForeColor = Color.White;
        }


        private void btn_EmailChange_Reset_UI()
        {
            // Set Email textBox to READONLY
            txtBox_uc_Email.ReadOnly = true;

            btn_ChangeEmail.Text = "Change Email?";

            btn_ChangeEmail.BackColor = Color.DimGray;
            btn_ChangeEmail.ForeColor = Color.White;
        }


        private void SignalChangesSaved(int blinkTimes)
        {
            this.Invoke(() =>
            {
                btn_SaveChanges.Show();

                btn_SaveChanges.Text = "CHANGES SAVED";
                btn_SaveChanges.ForeColor = Color.Black;
                btn_SaveChanges.BackColor = Color.White;
            });

            for (int i = 0; i < blinkTimes; i++)
            {
                this.Invoke(() => btn_SaveChanges.ForeColor = Color.Red);

                Thread.Sleep(300);

                this.Invoke(() => btn_SaveChanges.ForeColor = Color.Black);

                Thread.Sleep(300);
            }

            this.Invoke(() =>
            {
                btn_SaveChanges.Text = "Save Changes";
                btn_SaveChanges.ForeColor = Color.White;
                btn_SaveChanges.BackColor = Color.DimGray;

                ShowButtonSaveChanges(ChangesMade = false);
            });
        }

    }
}