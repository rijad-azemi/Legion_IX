using Amazon.Util.Internal.PlatformServices;
using Legion_IX.DB;
using Legion_IX.Helpers;
using Legion_IX.ProjectForms;
using Legion_IX.Properties;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Button = System.Windows.Forms.Button;

namespace Legion_IX
{
    public partial class frm_LoginScreen : Form
    {
        private enum LogInAs { Student, Professor, StudentService }
        private LogInAs? chosenLoginType = null;


        public frm_LoginScreen()
        {
            InitializeComponent();

            this.FormClosing += SignalCancellationToken;

            NetworkListener.NetworkAvailabilityChanged += NetworkAvailability;

        }

        private void SignalCancellationToken(object? sender, FormClosingEventArgs e)
        {
            RequestCancel.killProccess.Cancel();
        }


        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            NetworkAvailability(sender, e);
        }


        // Button LOGIN click event
        private async void button_Login_Click(object sender, EventArgs e)
        {
            /*textBox_email.Text = "rijad.azemi@edu.fit.ba";
            textBox_password.Text = "rijadazemi2000";*/

            textBox_email.Text = "lejla.jazvin@edu.fit.ba";
            textBox_password.Text = "lejlajazvin88000";

            if (NetworkListener.IsConnectedToNet())
            {
                // Converts said results to `List<BsonDocument>`
                IAsyncCursor<BsonDocument> result = await GetMatchesFromAtlas();

                List<BsonDocument>? matchingAccounts = result?.ToList() ?? null;

                // Represents the index of a matching account from the `List<BsonDocument>`
                int matchAccountIndex = 0; // (Passed by reference because methods `Checkpoint` and `LoginSuccessful` must have it synced)

                // Calls checkpoint to enstablish veracity and displays appropriate message
                if (matchingAccounts != null && Checkpoint(in matchingAccounts, ref matchAccountIndex))
                    LoginSuccessful(in matchingAccounts, in matchAccountIndex);

                else if (!CheckIfNullOrEmpty())
                    lblAccNotFound.Text = "--- Please fill in all fields ---";

                else
                    lblAccNotFound.Text = "--- Account not found ---";
            }

            else
            {
                lblAccNotFound.Text = "--- No Internet Access ---";

                Start_InformUserNoInternetThread();
            }

            #region Checkpoint
            /*if (Checkpoint(ref matchingAccounts))
                MessageBox.Show("Login Successful!", "Operation completed successfully!", MessageBoxButtons.OK);

            else
                MessageBox.Show("Login Failed!", "Operation has failed!", MessageBoxButtons.OK);*/
            #endregion Checkpoint
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


        private async Task<IAsyncCursor<BsonDocument>> AggregateByLogInChoice()
        {
            switch (chosenLoginType)
            {
                case LogInAs.Student: return await ServerSideFilter_Student_EmailPassword(textBox_email.Text, textBox_password.Text);

                case LogInAs.Professor: return await ServerSideFilter_Professor_EmailPassword(textBox_email.Text, textBox_password.Text);

                case LogInAs.StudentService: return await ServerSideFilter_StudentService_EmailPassword(textBox_email.Text, textBox_password.Text);

                default: return null;
            }
        }


        // Server Side filtering for Student
        private async Task<IAsyncCursor<BsonDocument>> ServerSideFilter_Student_EmailPassword(string email, string password)
        {
            AtlasDB connectionToAtlas = new AtlasDB();

            List<BsonDocument> pipeline = new List<BsonDocument>()
            {
                new BsonDocument("$match", new BsonDocument("email", email)),
                new BsonDocument("$match", new BsonDocument("password", password))
            };

            // Aggregating the pipeline
            IAsyncCursor<BsonDocument>? foundAccounts = await
                    connectionToAtlas.Client.
                                        GetDatabase(connectionToAtlas.AtlasDB_FacultyPersonell).
                                        GetCollection<BsonDocument>(connectionToAtlas.AtlasCollection_Student).
                                        AggregateAsync<BsonDocument>(pipeline);

            return foundAccounts;
        }


        // Server Side filtering for Professor
        private async Task<IAsyncCursor<BsonDocument>> ServerSideFilter_Professor_EmailPassword(string email, string password)
        {
            AtlasDB connectionToAtlas = new AtlasDB();

            List<BsonDocument> pipeline = new List<BsonDocument>()
            {
                new BsonDocument("$match", new BsonDocument("email", email)),
                new BsonDocument("$match", new BsonDocument("password", password))
            };

            // Aggregating the pipeline
            IAsyncCursor<BsonDocument>? foundAccounts = await
                connectionToAtlas.Client.
                                        GetDatabase(connectionToAtlas.AtlasDB_FacultyPersonell).
                                        GetCollection<BsonDocument>(connectionToAtlas.AtlasCollection_Professor).
                                        AggregateAsync<BsonDocument>(pipeline);

            return foundAccounts;
        }


        // Server Side filtering for Professor
        private async Task<IAsyncCursor<BsonDocument>> ServerSideFilter_StudentService_EmailPassword(string email, string password)
        {
            AtlasDB connectionToAtlas = new AtlasDB();

            List<BsonDocument> pipeline = new List<BsonDocument>()
            {
                new BsonDocument("$match", new BsonDocument("email", email)),
                new BsonDocument("$match", new BsonDocument("password", password))
            };

            // Aggregating the pipeline
            IAsyncCursor<BsonDocument>? foundAccounts = await
                connectionToAtlas.Client.
                                        GetDatabase(connectionToAtlas.AtlasDB_FacultyPersonell).
                                        GetCollection<BsonDocument>(connectionToAtlas.AtlasCollection_StudentService).
                                        AggregateAsync<BsonDocument>(pipeline);

            return foundAccounts;
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
            // For BOTH
            if (textBox_email.Text.IsNullOrEmpty() && textBox_password.Text.IsNullOrEmpty())
            {
                err_EmailPassword.SetError(textBox_email, "This field cannot be empty!");
                err_EmailPassword.SetError(textBox_password, "This field cannot be empty!");

                return false;
            }

            // For EMAIL
            else if (textBox_email.Text.IsNullOrEmpty())
            {
                err_EmailPassword.SetError(textBox_email, "This field cannot be empty!");
                return false;
            }

            // For PASSWORD
            else if (textBox_password.Text.IsNullOrEmpty())
            {
                err_EmailPassword.SetError(textBox_password, "This field cannot be empty!");
                return false;
            }

            // Returns TRUE if all is good above
            return true;
        }


        // Checks if Email and Password typed is valid in format
        private bool CheckIfValid()
        {
            // Checks Email
            if (!MyValidators.ValidateEmail(textBox_email.Text))
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

                // Validate dialog result
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
                    Start_LogoutBlinkingThread(true);
                }

                else if (profileForm is frm_ProfessorProfile && profileForm.ShowDialog() == DialogResult.OK)
                {
                    //Show this form
                    this.Show();

                    // Inform user of Logout
                    Start_LogoutBlinkingThread(true);
                }

                else if (profileForm is frm_StudentServiceADMIN && profileForm.ShowDialog() == DialogResult.OK)
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

            catch (Exception ex)
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

                CancellationTokenSource requestCancellation = new CancellationTokenSource();
                CancellationToken token = requestCancellation.Token;

                Thread blinker = new Thread(new ThreadStart(() => displayLogoutMessage(blinkTimes, token)));
                blinker.Start();
            }
        }


        // Gets called when logging out and displays a blinking message informing the user
        public void displayLogoutMessage(int blinkTimes, CancellationToken killProccessToken) // Test the following idea, make the method STATIC!
        {
            for (int i = 0; i < blinkTimes; i++)
            {

                if (RequestCancel.killProccess.IsCancellationRequested)
                    return;

                lblAccNotFound.ForeColor = Color.Green;
                Thread.Sleep(400);

                lblAccNotFound.ForeColor = Color.White;
                Thread.Sleep(400);

            }


            lblAccNotFound.ForeColor = Color.White;

            //if (!this.IsDisposed)


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

                if (RequestCancel.killProccess.IsCancellationRequested)
                    return;

                lblAccNotFound.ForeColor = Color.Red;
                Thread.Sleep(400);

                lblAccNotFound.ForeColor = Color.White;
                Thread.Sleep(400);
            }
            lblAccNotFound.ForeColor = Color.White;

            // Invoking action for a control on it's original created thread to prevent cross threading exception
            this.Invoke((Action)(() => lblAccNotFound.Text = ""));
        }


        // Clearing Login input fields
        private void ClearFormTextBoxes()
        {
            textBox_email.Text = "";
            textBox_password.Text = "";
        }


        // Reference to clicked buttons
        private Button? clicked_LogInAs = null;

        // Button Login Student option
        private void btn_LogAsStudent_Click(object sender, EventArgs e)
        {

            if(clicked_LogInAs == null || clicked_LogInAs.Name != btn_LogAsStudent.Name)
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

            else if(clicked_LogInAs.Name == btn_LogAsStudentService.Name)
                ShowClicked(in this.btn_LogAsStudentService, e);

        }


        private void ShowClicked(in Button sender, EventArgs e)
        {

            if(clicked_LogInAs != null && clicked_LogInAs.Name == sender.Name)
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


        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_LoginScreen));
        private void ShowUnclicked()
        {

            if(clicked_LogInAs  != null)
            {

                clicked_LogInAs.BackgroundImage = (Image)resources.GetObject("btn_LogAsStudent.BackgroundImage");

                clicked_LogInAs.BackColor = Color.DimGray;
                clicked_LogInAs.ForeColor = SystemColors.ButtonFace;

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