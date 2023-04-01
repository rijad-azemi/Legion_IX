﻿using Amazon.Util.Internal.PlatformServices;
using Legion_IX.DB;
using Legion_IX.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Legion_IX
{
    public partial class frmLoginScreen : Form
    {
        #region Global Variables

        static frmStudentProfile? theProfile;

        static Student? student;
        static Helpers.Validators vali = new Helpers.Validators();

        //public bool loggedOut { get; set; } = false;

        MySQLcustomConnection connection = new MySQLcustomConnection();

        #endregion Global Variables


        public frmLoginScreen()
        {
            InitializeComponent();

            NetworkListener.NetworkAvailabilityChanged += NetworkAvailability;

        }


        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            // Initializing it's instance upon Form Load
            student = new Student();

            NetworkAvailability(sender, e);
        }


        // Button LOGIN click event
        private async void button_Login_Click(object sender, EventArgs e)
        {
            if(NetworkListener.IsConnectedToNet())
            {
                // Converts said results to `List<BsonDocument>`
                IAsyncCursor<BsonDocument>? result = await GetMatchesFromAtlas();

                List<BsonDocument>? matchingAccounts = result?.ToList() ?? null;

                // Represents the index of a matching account from the `List<BsonDocument>`
                int matchAccountIndex = 0; // (Passed by reference because methods `Checkpoint` and `LoginSuccessful` must have it synced)

                // Calls checkpoint to enstablish veracity and displays appropriate message
                if (matchingAccounts != null && Checkpoint(in matchingAccounts, ref matchAccountIndex))
                    
                    LoginSuccessful(in matchingAccounts, in matchAccountIndex);

                else
                    lblAccNotFound.Text = "--- ACCOUNT NOT FOUND ---";

            }

            else
            {
                lblAccNotFound.Text = "--- You are OFFLINE => !Cannot LOGIN! ---";

                Start_InformUserNoInternetThread();
            }

            #region Checkpoint
            /*if (Checkpoint(ref matchingAccounts))
                MessageBox.Show("Login Successful!", "Operation completed successfully!", MessageBoxButtons.OK);

            else
                MessageBox.Show("Login Failed!", "Operation has failed!", MessageBoxButtons.OK);*/
            #endregion Checkpoint
        }


        private void LoginSuccessful(in List<BsonDocument> matchingAccounts, in int matchAccountIndex)
        {
            // Hiding current
            this.Hide();

            // Saving logged student to send to displaying form
            BsonDocument loggedStudent = new BsonDocument(matchingAccounts[matchAccountIndex]);

            // Creating the instance of the form
            frmStudentProfile StudentProfile = new frmStudentProfile(ref loggedStudent);

            // Performs a check to see if the `frmStudentProfile` was logged out of or closed, and reacts accordingly
            CheckAndDoIf_LoggedOut_Or_Closed(in StudentProfile);

            // Clearing Login input fields
            ClearFormTextBoxes();
        }


        // Search and get Matching accounts based on login inputs
        private async Task<IAsyncCursor<BsonDocument>>? GetMatchesFromAtlas()
        {
            // Reseting the text field of the warning label just in case
            lblAccNotFound.Text = "";

            // Checks if inputs are valid, and returns immediatelty if not
            if (!CheckIfNullOrEmpty() && !CheckIfValid())
                return null;

            // Recieving results from `ServerSideFilter_EmailPassword()`
            IAsyncCursor<BsonDocument>? serverSideFilterResult = await student.ServerSideFilter_EmailPassword(textBox_email.Text, textBox_password.Text);

            return serverSideFilterResult;
        }
        

        // Checks for mattching accounts in Atlas based on login indo provided
        private bool Checkpoint(in List<BsonDocument> Accounts, ref int index)
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
                // Assigning the existing directory to a chosen browser if it exists or if it's valid
                // Assigning `null` if path doesn't exist inside the SQL DB and Throwing Exception where user get's to choose his own Browser
                string? DefaultBrowserPath = GetBrowserPathFromSQL();

                // Opening the `.exe` file (assumed browser) by the given directory.
                System.Diagnostics.Process.Start(DefaultBrowserPath, "https://www.fit.ba/student/login.aspx");
            }

            // Catch the said exception if thrown
            catch (Exception)
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
                        // Getting directory of assumed browser `.exe` file
                        string selectedFilePath = openFileDialog_searchForBrowser.FileName;

                        // Mesmorizing said directory inside SQLite DataBase
                        Update_Add_BrowserToSQL(selectedFilePath);

                        // Opening the `.exe` file (assumed browser) by the given directory.
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


        // This method is called to check if either the `frmStudentProfile` instance was logged out of or closed, and reacts accordingly
        private void CheckAndDoIf_LoggedOut_Or_Closed(in frmStudentProfile profileForm)
        {

            try
            {
                if (profileForm.ShowDialog() == DialogResult.OK)
                {
                    //Show this form
                    this.Show();

                    // Inform user of Logout
                    Start_LogoutBlinkingThread(true);
                }

                else
                    //Closing this one
                    this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Message);
            }

        }


        // Creates a thread for blinking LOGOUT message
        private void Start_LogoutBlinkingThread(bool loggedOut)
        {
            if (loggedOut)
            {
                lblAccNotFound.Text = "--- You have logged out ---";
                int blinkTimes = 3;

                Thread blinker = new Thread(new ThreadStart(() => displayLogoutMessage(blinkTimes)));
                blinker.Start();
            }
        }


        // Gets called when logging out and displays a blinking message informing the user
        public void displayLogoutMessage(int blinkTimes) // Test the following idea, make the method STATIC!
        {
            for (int i = 0; i < blinkTimes; i++)
            {
                lblAccNotFound.ForeColor = Color.Green;
                Thread.Sleep(400);

                lblAccNotFound.ForeColor = Color.White;
                Thread.Sleep(400);
            }
            lblAccNotFound.ForeColor = Color.White;

            // Invoking action for a control on it's original created thread to prevent cross threading exception
            this.Invoke((Action)(() => lblAccNotFound.Text = ""));
        }


        // Creates and starts a thread for blinking No internet message
        private void Start_InformUserNoInternetThread()
        {
            int blinkTimes = 4;

            Thread blinkNoInternet_Message = new Thread(new ThreadStart(() => InformUserNoInternet(blinkTimes)));
        }


        // Blinking message informing User that access to the internet has ceased
        public void InformUserNoInternet(int blinkTimes)
        {
            for (int i = 0; i < blinkTimes; i++)
            {
                lblAccNotFound.ForeColor = Color.Red;
                Thread.Sleep(400);

                lblAccNotFound.ForeColor = Color.White;
                Thread.Sleep(400);
            }
            lblAccNotFound.ForeColor = Color.White;

            // Invoking action for a control on it's original created thread to prevent cross threading exception
            this.Invoke((Action)(() => lblAccNotFound.Text = ""));
        }


        // Updates the browser record path to SQL DataBase
        public static void Update_Add_BrowserToSQL(string path)
        {
            try
            {
                string access = MySQLcustomConnection.myConnection;
                string updateCommand = "UPDATE table_DefaultBrowser SET DefaultBrowserPath = @NewPath";

                using (SQLiteConnection line = new SQLiteConnection(access))
                {
                    line.Open();

                    using (SQLiteCommand command = new SQLiteCommand(updateCommand, line))
                    {
                        command.Parameters.AddWithValue("@NewPath", path);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Method `AddBrowserToSQL` at `frmLoginScreen` encountered a problem",
                    "Problem encountered with SQL DB",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }


        // Retrieve browser `.exe` file from SQL => returns null if field in SQL table is null
        public static string? GetBrowserPathFromSQL()
        {
            try
            {
                string access = MySQLcustomConnection.myConnection;
                string? directoryFromSQL = null;
                string queryCommand = "SELECT DefaultBrowserPath FROM table_DefaultBrowser LIMIT 1;";

                using (SQLiteConnection line = new SQLiteConnection(access))
                {
                    line.Open();

                    using (SQLiteCommand command = new SQLiteCommand(queryCommand, line))
                    {

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                directoryFromSQL = reader.GetString(0);
                            }
                        }

                    }

                }

                return directoryFromSQL;
            }

            catch (Exception)
            {
                MessageBox.Show("Method `GetBrowserPathFromSQL` at `frmLoginScreen` encountered a problem",
                    "Problem encountered with SQL DB",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return null;
        }


        // Clearing Login input fields
        private void ClearFormTextBoxes()
        {
            textBox_email.Text = "";
            textBox_password.Text = "";
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