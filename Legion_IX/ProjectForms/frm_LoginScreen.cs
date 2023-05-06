using Amazon.Util.Internal.PlatformServices;
using Legion_IX.DB;
using Legion_IX.Helpers;
using Legion_IX.ProjectForms;
using Legion_IX.Properties;
using Legion_IX.Users;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Button = System.Windows.Forms.Button;

namespace Legion_IX
{
    public partial class frm_LoginScreen : Form
    {
        internal void StudentLogIn() { textBox_email.Text = "rijad.azemi@edu.fit.ba"; textBox_password.Text = "rijadazemi2000"; }
        internal void ProfessorLogIn() { textBox_email.Text = "denis.music@edu.fit.ba"; textBox_password.Text = "denismusic123"; }
        internal void ProfessorLogIn1() { textBox_email.Text = "tester.project@edu.fit.ba"; textBox_password.Text = "tester123"; }
        internal void ServiceLogIn() { textBox_email.Text = "lejla.jazvin@edu.fit.ba"; textBox_password.Text = "lejlajazvin88000"; }


        private enum LogInAs { Student, Professor, StudentService }
        private LogInAs? chosenLoginType = null;


        public frm_LoginScreen()
        {

            InitializeComponent();

            // Subscribing the `SignalThe_CancellationToken` method in an event of the form closing
            this.FormClosing += SignalThe_CancellationToken;

            NetworkListener.NetworkAvailabilityChanged += NetworkAvailability;

        }


        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            NetworkAvailability(sender, e);
        }


        // Method that will signal a static, global `CancellationToken` that the form is closing and the `Task` should be cancelled
        private void SignalThe_CancellationToken(object? sender, FormClosingEventArgs e)
        {
            RequestCancel.killProccess.Cancel();
        }


        // Button LOGIN click event
        private async void button_Login_Click(object sender, EventArgs e)
        {
            //StudentLogIn();
            ProfessorLogIn();
            //ProfessorLogIn1();
            //ServiceLogIn();

            if (NetworkListener.IsConnectedToNet())
            {
                if (clicked_LogInAs == null) { Start_ChooseLoginTypeTask(); return; }

                else if (!CheckIfNullOrEmpty()) { Start_InformUserToFillInAllFieldsTask(); return; }

                // Converts said results to `List<BsonDocument>`
                IAsyncCursor<BsonDocument> result = await GetMatchesFromAtlas();

                List<BsonDocument>? matchingAccounts = result?.ToList() ?? null;

                // Represents the index of a matching account from the `List<BsonDocument>`
                int matchAccountIndex = 0; // (Passed by reference because methods `Checkpoint` and `LoginSuccessful` must have it synced)

                // Calling a method to enstablish veracity and displays appropriate message
                if (matchingAccounts != null && CheckForMatchingAccounts(in matchingAccounts, ref matchAccountIndex) && CheckIfMatchingAccountIsActive(in matchingAccounts, ref matchAccountIndex))
                    LoginSuccessful(in matchingAccounts, in matchAccountIndex);
            }

            else
                Start_InformUserNoInternetTask();
        }


        // IF Login Successful
        private void LoginSuccessful(in List<BsonDocument> matchingAccounts, in int matchAccountIndex)
        {
            // Hiding current
            this.Hide();

            switch (chosenLoginType)
            {
                case LogInAs.Student:
                    {
                        LoggedInStudent.theStudent.GetStudentFromBson(new BsonDocument(matchingAccounts[matchAccountIndex]));

                        // Creating the instance of the form
                        frm_StudentProfile StudentProfile = new frm_StudentProfile();

                        // Performs a check to see if the `frm_StudentProfile` was logged out of or closed, and reacts accordingly
                        CheckAndDoIf_LoggedOut_Or_Closed(StudentProfile);
                    }
                    break;

                case LogInAs.Professor:
                    {
                        LoggedInProfessor.theProf.GetProfessorFromBson(new BsonDocument(matchingAccounts[matchAccountIndex]));

                        // Performs a check to see if the `frm_ProfessorProfile` was logged out of or closed, and reacts accordingly
                        // Creating the instance of the form
                        frm_ProfessorProfile ProfessorProfile = new frm_ProfessorProfile();

                        // Performs a check to see if the `frm_ProfessorProfile` was logged out of or closed, and reacts accordingly
                        CheckAndDoIf_LoggedOut_Or_Closed(ProfessorProfile);
                    }
                    break;

                case LogInAs.StudentService:
                    {
                        // Performs a check to see if the `frm_ProfessorProfile` was logged out of or closed, and reacts accordingly
                        frm_StudentServiceADMIN StudentServicer = new frm_StudentServiceADMIN();

                        // Performs a check to see if the `frm_ProfessorProfile` was logged out of or closed, and reacts accordingly
                        CheckAndDoIf_LoggedOut_Or_Closed(StudentServicer);
                    }
                    break;
            }

            // Clearing Login input fields
            ClearFormTextBoxes();
        }


        // Search and get Matching accounts based on login inputs
        private async Task<IAsyncCursor<BsonDocument>> GetMatchesFromAtlas()
        {
            // Reseting the text field of the warning label just in case
            lblAccNotFound.Text = "";

            // Recieving results from `ServerSideFilter_EmailPassword()`
            IAsyncCursor<BsonDocument> serverSideFilterResult = await AggregateByLogInChoice();

            return serverSideFilterResult;
        }


        // Calls the ServerSideFilter method based on the login type of user
        private async Task<IAsyncCursor<BsonDocument>> AggregateByLogInChoice()
        {
            AtlasDB connectionToAtlas = new AtlasDB();

            switch (chosenLoginType)
            {
                case LogInAs.Student: return await ServerSideFilter_Generic(connectionToAtlas, connectionToAtlas.AtlasDB_FacultyPersonell, connectionToAtlas.AtlasCollection_Student, textBox_email.Text, textBox_password.Text);

                case LogInAs.Professor: return await ServerSideFilter_Generic(connectionToAtlas, connectionToAtlas.AtlasDB_FacultyPersonell, connectionToAtlas.AtlasCollection_Professor, textBox_email.Text, textBox_password.Text);

                case LogInAs.StudentService: return await ServerSideFilter_Generic(connectionToAtlas, connectionToAtlas.AtlasDB_FacultyPersonell, connectionToAtlas.AtlasCollection_StudentService, textBox_email.Text, textBox_password.Text);

                default: return null;
            }
        }


        // Generic method for filtering the collection based on the login inputs
        private async Task<IAsyncCursor<BsonDocument>> ServerSideFilter_Generic(AtlasDB connectionToAtlas, string targetDB, string targetCollection, string email, string password)
        {
            List<BsonDocument> pipeline = new List<BsonDocument>()
            {
                new BsonDocument("$match", new BsonDocument("email", email)),
                new BsonDocument("$match", new BsonDocument("password", password))
            };

            // Aggregating the pipeline
            IAsyncCursor<BsonDocument>? foundAccounts = await
                    connectionToAtlas.Client.
                                        GetDatabase(targetDB).
                                        GetCollection<BsonDocument>(targetCollection).
                                        AggregateAsync<BsonDocument>(pipeline);

            return foundAccounts;
        }


        // Checks for mattching accounts in Atlas based on login indo provided
        private bool CheckForMatchingAccounts(in List<BsonDocument> Accounts, ref int index)
        {
            // If only one account is found, it is automatically the correct one, so no need to itterate true
            if (Accounts.Count == 1) return true;

            // If `Accounts.Count` is higher or equal to 1, means `ServerSideFilter_EmailPassword()` returned matching account
            if (Accounts.Count >= 1)
            {

                // `Accounts` might hold more than one document, so iterating to check 
                for (int i = 0; i < Accounts.Count; i++)
                {

                    if (Accounts[i].GetValue("email") == textBox_email.Text && Accounts[i].GetValue("password") == textBox_password.Text)
                    {
                        index = i;
                        return true;// Returns `true` if match is found
                    }

                }

                // If no matches are found, then the account does not exist so inform the user
                Start_AccountNotFoundTask();

                // Returns `false` if none are found
                return false;

            }

            // If no matches are found, then the account does not exist so inform the user
            Start_AccountNotFoundTask();

            // Returns `false` if `ServerSideFilter_EmailPassword()` found no matches
            return false;
        }


        // Iterates through the list of Accounts as BsonDocuments and searches for the matching account in based on entered email and password
        private bool CheckIfMatchingAccountIsActive(in List<BsonDocument> Accounts, ref int indexOfAccount)
        {
            if ((bool)Accounts[indexOfAccount].GetValue("active") == true)
                return true;

            else
            {
                Start_InformUserAccountHasBeenDisabledTask();
                return false;
            }
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
                textBox_email.BackColor = Color.Red;
                textBox_email.Text = " -- FIELD CANNOT BE EMPTY --";

                textBox_email.Click += textBox_ClickedEvent_Generic;
            }

            else
            {
                textBox_email.BackColor = Color.White;
                textBox_email.Click -= textBox_ClickedEvent_Generic;
            }

            // For PASSWORD
            if (textBox_password.Text.IsNullOrEmpty())
            {
                textBox_password.BackColor = Color.Red;

                textBox_password.UseSystemPasswordChar = false;
                textBox_password.Text = " -- FIELD CANNOT BE EMPTY --";

                textBox_password.Click += textBox_ClickedEvent_Generic;

                return false;
            }

            else
            {
                textBox_password.BackColor = Color.White;
                textBox_password.Click -= textBox_ClickedEvent_Generic;
            }

            // Returns TRUE if all is good above
            return true;
        }


        // After the `textBox_email` and `textBox_password` were used to inform to user that they cannot be empty, this event is called to clear the textboxes when the user
        // clicks on them signifying that they are ready to retype the login information
        private void textBox_ClickedEvent_Generic(object? sender, EventArgs e)
        {
            System.Windows.Forms.TextBox txtBox = (System.Windows.Forms.TextBox)sender;

            if(txtBox?.Name == textBox_email.Name)
            {
                textBox_email.Text = "";
                textBox_email.BackColor = Color.White;
            }

            else if(txtBox?.Name == textBox_password.Name)
            {
                textBox_password.Text = "";
                textBox_password.UseSystemPasswordChar = true;
                textBox_password.BackColor = Color.White;
            }
        }


        // Checks if Email and Password typed is valid in format
        private bool CheckIfValid()
        {
            // Checks Email
            if (!MyValidators.ValidateEmail(textBox_email.Text))
            {
                
                textBox_email.BackColor = Color.OrangeRed;
                //textBox_email.Text = "Invalid Format!";
                //textBox_email.ForeColor = Color.White;

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
                // Opening the `.exe` file (assumed browser) by the given directory.
                System.Diagnostics.Process.Start(Default_BrowserDirectory.DefaultBrowser, "https://www.fit.ba/student/login.aspx");
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

                // Validate dialog fieldsEmpty
                if (mshBoxResult == DialogResult.Yes)
                {
                    ValidateDialog_SetBrowser_AndOpen();
                }
            }
        }


        // Method for opening external link in browser
        private void ValidateDialog_SetBrowser_AndOpen()
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
                Default_BrowserDirectory.Update_or_Add_BrowserToSQL(selectedFilePath);

                // Opening the `.exe` file (assumed browser) by the given directory.
                System.Diagnostics.Process.Start(selectedFilePath, "https://www.fit.ba/student/login.aspx");
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
        private void NetworkAvailability(object? sender, EventArgs e)
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
        private void CheckAndDoIf_LoggedOut_Or_Closed(in Form profileForm)
        {

            try
            {
                if (profileForm is frm_StudentProfile && profileForm.ShowDialog() == DialogResult.OK)
                {
                    //Show this form
                    this.Show();

                    // Inform user of Logout
                    Start_LogoutBlinkingTask(true);
                }

                else if (profileForm is frm_ProfessorProfile && profileForm.ShowDialog() == DialogResult.OK)
                {
                    LoggedInProfessor.theProf.UpdateProfessor_LoggedIn_Field_toLoggedOut();

                    //Show this form
                    this.Show();

                    // Inform user of Logout
                    Start_LogoutBlinkingTask(true);
                }

                else if (profileForm is frm_StudentServiceADMIN && profileForm.ShowDialog() == DialogResult.OK)
                {
                    //Show this form
                    this.Show();

                    // Inform user of Logout
                    Start_LogoutBlinkingTask(true);
                }

                else
                    //Closing this one
                    this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Message);
            }

        }


        // Creates a Task for blinking LOGOUT message
        private void Start_LogoutBlinkingTask(bool loggedOut)
        {
            if (loggedOut)
            {
                string displayMessage = "--- You have logged out ---";
                int blinkTimes = 4;

                Color firstBlink = Color.White;
                Color secondBlink = Color.Green;

                Task.Run(() => BlinkingMessage_Generic(displayMessage, blinkTimes, firstBlink, secondBlink));
            }
        }


        // Creates and starts a Task for blinking `No internet` message
        private void Start_InformUserNoInternetTask()
        {
            string displayMessage = "--- No internet connection ---";
            int blinkTimes = 4;

            Color firstBlink = Color.Red;
            Color secondBlink = Color.White;

            Task.Run(() => BlinkingMessage_Generic(displayMessage, blinkTimes, firstBlink, secondBlink));
        }


        // Creates and starts a Task for blinking `Fill in all fields` message
        private void Start_InformUserToFillInAllFieldsTask()
        {
            string displayMessage = "--- Please fill in all fields ---";
            int blinkTimes = 4;

            Color firstBlink = Color.Red;
            Color secondBlink = Color.White;

            Task.Run(() => BlinkingMessage_Generic(displayMessage, blinkTimes, firstBlink, secondBlink));
        }


        // Creates and starts a Task for blinking `Account not found` message
        private void Start_AccountNotFoundTask()
        {
            string displayMessage = "--- Account not found ---";
            int blinkTimes = 4;

            Color firstBlink = Color.Yellow;
            Color secondBlink = Color.White;

            Task.Run(() => BlinkingMessage_Generic(displayMessage, blinkTimes, firstBlink, secondBlink));
        }


        // Creates and starts a Task for blinking `Choose login type` message
        private void Start_ChooseLoginTypeTask()
        {
            string displayMessage = "--- Please choose a login type ---";
            int blinkTimes = 4;

            Color firstBlink = Color.Yellow;
            Color secondBlink = Color.White;

            Task.Run(() => BlinkingMessage_Generic(displayMessage, blinkTimes, firstBlink, secondBlink));
        }


        // Creates and starts a Task for blinking `Account has been disabled` message
        private void Start_InformUserAccountHasBeenDisabledTask()
        {
            string displayMessage = "--- Your account has been REVOKED ---";
            int blinkTimes = 8;

            Color firstBlink = Color.Red;
            Color secondBlink = Color.White;

            Task.Run(() => BlinkingMessage_Generic(displayMessage, blinkTimes, firstBlink, secondBlink));
        }


        // Generic method for blinking a message
        private async Task BlinkingMessage_Generic(string message, int blinkTimes, Color firstBlink, Color secondBlink)
        {
            RequestCancel.killProccess.Token.ThrowIfCancellationRequested();
            this.Invoke(() => { lblAccNotFound.Text = message; });

            for (int i = 0; i < blinkTimes; i++)
            {
                RequestCancel.killProccess.Token.ThrowIfCancellationRequested();

                lblAccNotFound.ForeColor = firstBlink;
                await Task.Delay(400);

                RequestCancel.killProccess.Token.ThrowIfCancellationRequested();

                lblAccNotFound.ForeColor = secondBlink;
                await Task.Delay(400);

                RequestCancel.killProccess.Token.ThrowIfCancellationRequested();

            }

            RequestCancel.killProccess.Token.ThrowIfCancellationRequested();

            lblAccNotFound.ForeColor = Color.White;

            RequestCancel.killProccess.Token.ThrowIfCancellationRequested();

            // Invoking action for a control on it's original created thread to prevent cross threading exception
            this.Invoke(() => lblAccNotFound.Text = "");
        }


        // Clearing Login input fields
        private void ClearFormTextBoxes()
        {
            textBox_email.Text = "";
            textBox_password.Text = "";
        }


        private Button? clicked_LogInAs = null; /* Reference to clicked buttons */


        // Button Login Student option
        private void btn_LogAsStudent_Click(object sender, EventArgs e)
        {

            if (clicked_LogInAs == null || clicked_LogInAs.Name != btn_LogAsStudent.Name)
            {

                ShowUnclicked();

                ShowClicked(in this.btn_LogAsStudent, e);
                chosenLoginType = LogInAs.Student;

            }

            else if (clicked_LogInAs.Name == btn_LogAsStudent.Name)
                ShowClicked(in this.btn_LogAsStudent, e);

        }


        // Button Login Professor option
        private void btn_LogAsProfessor_Click(object sender, EventArgs e)
        {

            if (clicked_LogInAs == null || clicked_LogInAs.Name != btn_LogAsProfessor.Name)
            {
                ShowUnclicked();

                ShowClicked(in this.btn_LogAsProfessor, e);
                chosenLoginType = LogInAs.Professor;

            }

            else if (clicked_LogInAs.Name == btn_LogAsProfessor.Name)
                ShowClicked(in this.btn_LogAsProfessor, e);
        }


        // Button Login StudentService option
        private void btn_LogAsStudentService_Click(object sender, EventArgs e)
        {

            if (clicked_LogInAs == null || clicked_LogInAs.Name != btn_LogAsStudentService.Name)
            {

                ShowUnclicked();

                ShowClicked(in this.btn_LogAsStudentService, e);
                chosenLoginType = LogInAs.StudentService;

            }

            else if (clicked_LogInAs.Name == btn_LogAsStudentService.Name)
                ShowClicked(in this.btn_LogAsStudentService, e);

        }


        // Changes the appearance of the button to show taht it is clicked
        private void ShowClicked(in Button sender, EventArgs e)
        {

            if (clicked_LogInAs != null && clicked_LogInAs.Name == sender.Name)
            {

                clicked_LogInAs.BackgroundImage = (Image)resources.GetObject("btn_LogAsStudent.BackgroundImage");

                clicked_LogInAs.BackColor = Color.DimGray;
                clicked_LogInAs.ForeColor = SystemColors.ButtonFace;

                clicked_LogInAs = null;

                chosenLoginType = null;

                return;
            }

            clicked_LogInAs = sender;

            clicked_LogInAs.BackgroundImage = null;

            clicked_LogInAs.ForeColor = Color.Black;
            clicked_LogInAs.BackColor = Color.White;
        }


        // Changes the appearance of the button to show that it is unclicked
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_LoginScreen));
        private void ShowUnclicked()
        {

            if (clicked_LogInAs != null)
            {

                clicked_LogInAs.BackgroundImage = (Image)resources.GetObject("btn_LogAsStudent.BackgroundImage");

                clicked_LogInAs.BackColor = Color.DimGray;
                clicked_LogInAs.ForeColor = SystemColors.ButtonFace;

            }

        }


        private void btn_StarTest_Click(object sender, EventArgs e)
        {
            AzureSignalR_Server signalR = new AzureSignalR_Server();

            signalR.StartTheConnection();

            signalR.InvokeHubMethod();
        }
    }

}