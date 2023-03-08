using Amazon.Util.Internal.PlatformServices;
using Legion_IX.DB;
using Legion_IX.Helpers;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Legion_IX
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();

            NetworkListener.NetworkAvailabilityChanged += NetworkAvailability;

        }

        public void displayLogoutMessage(string message)
        {
            lblAccNotFound.Text = message;
            int counter = 0;

            ThreadStart inform = new ThreadStart( () =>
            {
                if (counter >= 5)
                    Thread.CurrentThread.Abort();

                lblAccNotFound.ForeColor = Color.Green;

                Thread.Sleep(500);

                lblAccNotFound.ForeColor = Color.White;

                counter++;
            });

            Thread mythread = new Thread( inform );
            mythread.Start();

            lblAccNotFound.Text = "";
            
            lblAccNotFound.Text = message;
        }

        // Global declaration of `Student` instance for use upon need
        static Student? student;
        static Helpers.Validators vali = new Helpers.Validators();
        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            // Initializing it's instance upon Form Load
            student = new Student();

            NetworkAvailability(sender, e);
        }

        // Button LOGIN click event
        private async void button_Login_Click(object sender, EventArgs e)
        {
            // Reseting the text field of the warning label just in case
            lblAccNotFound.Text = "";

            // Checks if inputs are valid, and returns immediatelty if not
            if (!CheckIfNullOrEmpty() && !CheckIfValid())
                return;

            // Recieving results from `ServerSideFilter_EmailPassword()`
            IAsyncCursor<BsonDocument>? serverSideFilterResult = await student.ServerSideFilter_EmailPassword(textBox_email.Text, textBox_password.Text);

            // Converts said results to `List<BsonDocument>`
            List<BsonDocument>? matchingAccounts = serverSideFilterResult.ToList();
            int matchAccountIndex = 0;

            // Calls checkpoint to enstablish veracity and displays appropriate message
            if (Checkpoint(ref matchingAccounts, ref matchAccountIndex))
            {

                // Saving logged student to send to displaying form
                BsonDocument loggedStudent = new BsonDocument(matchingAccounts[matchAccountIndex]);

                // Creating the instance of the form
                frmStudentProfile frmStudentProfile = new frmStudentProfile(ref loggedStudent);

                // Hiding current
                this.Hide();

                // Showing the profile form
                frmStudentProfile.ShowDialog();

                //Closing this one
                this.Close();
            }

            else
                lblAccNotFound.Text = "--- ACCOUNT NOT FOUND ---";

            #region Checkpoint
            /*if (Checkpoint(ref matchingAccounts))
                MessageBox.Show("Login Successful!", "Operation completed successfully!", MessageBoxButtons.OK);

            else
                MessageBox.Show("Login Failed!", "Operation has failed!", MessageBoxButtons.OK);*/
            #endregion Checkpoint
        }

        // Checks for mattching accounts in Atlas based on login indo provided
        private bool Checkpoint(ref List<BsonDocument> Accounts, ref int index)
        {
            // If `Accounts.Count` is higher or equal to 1, means `ServerSideFilter_EmailPassword()` returned matching account
            if (Accounts.Count >= 1)
            {

                // Could have added another if statement to return true immediately if one document is detected; Would make code more...
                // unredable, so won't implement

                // `Accounts` might hold more than one document, so iterating to check 
                for (int i = 0; i < Accounts.Count; i++)
                {

                    if (Accounts[i].GetValue("email") == textBox_email.Text && Accounts[i].GetValue("password") == textBox_password.Text)
                    {
                        index = i;
                        return true;// Returns `true` if match is found
                    }

                }

                // Returns `false` if none are found
                return false;
            }

            // Returns `false` if `ServerSideFilter_EmailPassword()` found no matches
            return false;
        }

        // Key down event for the form
        private void textBox_EmailPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (CheckIfNullOrEmpty() && CheckIfValid())
                    button_Login_Click(sender, e);

            }
        }

        // Checks if NullOrEmpty()
        private bool CheckIfNullOrEmpty()
        {
            // For EMAIL
            if (textBox_email.Text.IsNullOrEmpty())
            {
                err_EmailPassword.SetError(textBox_email, "This field cannot be empty!");
                return false;
            }
            else
                err_EmailPassword.SetError(textBox_email, "");

            // For PASSWORD
            if (textBox_password.Text.IsNullOrEmpty())
            {
                err_EmailPassword.SetError(textBox_password, "This field cannot be empty!");
                return false;
            }
            else
                err_EmailPassword.SetError(textBox_password, "");

            // Returns TRUE if all is good above
            return true;
        }

        // Checks if Email and Password typed is valid in format
        private bool CheckIfValid()
        {
            // Checks Email
            if (!vali.ValidateEmail(textBox_email.Text))
            {
                err_EmailPassword.SetError(textBox_email, "Invalid Format!");
                return false;
            }

            #region idiot
            //You don't need to check the format for an ALREADY CREATED PASSWORD, you moron

            // Checks Password
            /*if (!vali.ValidatePassword(textBox_password.Text))
            {
                err_EmailPassword.SetError(textBox_password, "Invalid Format!");
                return false;
            }*/
            #endregion idiot

            // Returns true if all is good
            return true;
        }

        // DLWMS link (opens in browser)
        private void linkLabel_DLWMSweb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Look for exceptions in case browser is not found
            try
            {
                System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "https://www.fit.ba/student/login.aspx");
            }

            // Catch the said exception if thrown
            catch (Exception ex)
            {
                //MessageBox.Show("Problem has occured", "Opening the link did not work!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                DialogResult mshBoxResult = MessageBox.Show
                    (
                    "Would you like to choose browser?",
                    "--Default Browser not detected--",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                    );

                // Validate dialog result
                if (mshBoxResult == DialogResult.Yes)
                {
                    // Set filter for '.exe' files only
                    openFileDialog_searchForBrowser.Filter = "Executable Files (*.exe)|*.exe";

                    // Set the dialog title
                    openFileDialog_searchForBrowser.Title = "Choose desired browser.";

                    // Assigning the dialog to a variable
                    DialogResult fileDialogResult = openFileDialog_searchForBrowser.ShowDialog(this);

                    // Open the dialog and allow the user to choose
                    if (fileDialogResult == DialogResult.OK)
                    {
                        string selectedFilePath = openFileDialog_searchForBrowser.FileName;
                        System.Diagnostics.Process.Start(selectedFilePath, "https://www.fit.ba/student/login.aspx");
                    }
                }
            }
        }

        // Check Box ShowPassword
        private void checkBox_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ShowPassword.Checked)
                textBox_password.UseSystemPasswordChar = false;

            else
                textBox_password.UseSystemPasswordChar = true;
        }

        // Network availability detector
        private void NetworkAvailability(object sender, EventArgs e)
        {

            if (NetworkListener.IsConnectedToNet())
            {
                this.Invoke((Action)(() =>
                {
                    txtBox_NetworkStatus.Text = "-ONLINE-";
                    txtBox_NetworkStatus.BackColor = Color.Green;
                }));
            }

            else
            {
                this.Invoke((Action)(() =>
                {
                    txtBox_NetworkStatus.Text = "-OFFLINE-";
                    txtBox_NetworkStatus.BackColor = Color.Red;
                }));
            }

        }
    }
}

#region commentedCode
/*TO hell with this
//            var pipeline = new BsonArray
//{
//    BsonDocument.Parse("{ $match: { email: 'sead.azemi@edu.fit.ba', password: 'undp123' } }")
//};


//var pipeline = new BsonDocument[]
//{
//    new BsonDocument("$match",
//    new BsonDocument
//{
//        {"email", "sead.azemi@edu.fit.ba"},
//        {"password", "undp123"}
//}
//    )
//};

//var pipline2 = BsonArray

//            new BsonArray
//{
//    new BsonDocument("$match",
//    new BsonDocument("email", "sead.azemi@edu.fit.ba"))
//};

//var matchStage = BsonDocument.Parse
//    (
//    @"{ $match: { email: {$eq: 'sead.azemi@edu.fit.ba'}, password: {$eq: 'undp123' } } }"
//    );
//var pipeline = PipelineDefinitionBuilder<BsonDocument, BsonDocument>.Create(matchStage)

//var foundAccount = await filterTest.Client.GetDatabase(database).GetCollection<BsonDocument>(collection).AggregateAsync<BsonDocument>(pipeline);

//txtBox_DisplayDocument.Text = foundAccount.ToString();


var pipeline = new BsonDocument[]
{
new BsonDocument("$match",
new BsonDocument
{
{"email", "sead.azemi@edu.fit.ba"},
{"password", "undp123"}
})
};
            //if (firstDocument != null)
//{
//    foreach (var field in firstDocument.ToJson()) 
//    {
//        txtBox_DisplayDocument.Text += field.ToString();
//    }
//}

            //var studyYear = firstDocument.GetValue("studyYear");
//var revised = firstDocument.GetValue("revised");
//var index = firstDocument.GetValue("index");
//txtBox_DisplayDocument.Text = $"{studyYear+Environment.NewLine+revised+Environment.NewLine+index}";

            //var firstDocument = await foundAccount.FirstOrDefaultAsync();

//if (textBox_email.Text == firstDocument.GetValue("email")
//    && textBox_password.Text == firstDocument.GetValue("password"))
//{
//    MessageBox.Show("Login Successful", "Success!", MessageBoxButtons.OK);
//}
//else
//    MessageBox.Show("Account not found!", "Failed", MessageBoxButtons.OK);
*/
#endregion commentedCode