using Legion_IX.DB;
using Legion_IX.Helpers;
using MongoDB.Bson;

namespace Legion_IX
{
    public partial class frmStudentProfile : Form
    {
        #region UserControl size parameters
        public int Width { get; set; } = 654;
        public int Height { get; set; } = 470;
        public int X_Axis { get; set; } = 234;
        public int Y_Axis { get; set; } = 12;
        #endregion UserControl size parameters

        #region Global Variables

        // Global variable of type `Student` that will recieve Bson Documents
        public static Student? theStudent = new Student();

        // Reference variable to current shown `UserControl`
        private UserControl currentOpen;

        // Reference variable to current clicked Button
        private Button currentButton;

        #endregion Global Variables


        public frmStudentProfile(ref BsonDocument loggedStudent)
        {
            ForDefaultConstructor(ref loggedStudent);

            InitializeComponent();
        }


        private void frmStudentProfile_Load(object sender, EventArgs e)
        {
            // Passing information to User Control
            studentData1.GetDataFrom_frmStudentProfile(in theStudent);

            // Setting size and location to all `User Controls`
            SetLocationSizeToAll_UC();

            ShowCurrent_UserControl();

            // Calling the method to detect and display Network change
            NetworkAvailability_frmStudentProfile(sender, e);
        }


        private void ForDefaultConstructor(ref BsonDocument loggedStudent)
        {

            #region Extracting Student From Bson

            BsonDocument studentBson = new BsonDocument(loggedStudent);
            theStudent = theStudent.GetStudentFromBson(ref studentBson);

            #endregion Extracting Student From Bson

            // Subscribes the `NetworkAvailability` method to `NetworkChange` class
            NetworkListener.NetworkAvailabilityChanged += NetworkAvailability_frmStudentProfile;

        }


        // User Control location and size
        private void SetUserControlSizeAndLocation(UserControl uc)
        {
            uc.Width = Width;
            uc.Height = Height;
            uc.Location = new Point(X_Axis, Y_Axis);
        }


        // Set size and location to all `User Controls`
        private void SetLocationSizeToAll_UC()
        {
            SetUserControlSizeAndLocation(studentData1);
            SetUserControlSizeAndLocation(studentDocuments1);
            SetUserControlSizeAndLocation(studentProfileSettings1);
            SetUserControlSizeAndLocation(downloadedDocs1);
        }


        // Shows current(studentdata1) UserControl
        private void ShowCurrent_UserControl()
        {
            // Assigning current button, open Control and showing it
            currentButton = btn_Profile;
            UC_Clicked();

            currentOpen = studentData1;
            currentOpen.Show();
        }


        // Log Out button event
        private void button_LogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            #region maybeLater
            /*            // Creating again the instance of the login form
                        frmLoginScreen backToTlogIn = new frmLoginScreen();
                        backToTlogIn.loggedOut = true;

                        // Hide current from view
                        this.Hide();

                        // Show the form
                        backToTlogIn.ShowDialog();

                        // This message will be displayed onto the 'lblAccNotFound'
                        //backToTlogIn.displayLogoutMessage("--- You have been logged out ---");

                        // Closing current form
                        this.Close();*/
            #endregion maybeLater
        }


        // Profile button event
        private void btn_Profile_Click(object sender, EventArgs e)
        {
            if (currentButton.Name != btn_Profile.Name)
            {
                UC_Unclicked();

                // Hiding current UserControl
                currentOpen.Hide();

                // Assigning appropriate UC to `currentOpen` and showing it
                currentOpen = studentData1;
                currentOpen.Show();

                // Assigning this button as current
                currentButton = btn_Profile;

                UC_Clicked();
            }
        }


        // Documents button event
        private void btn_Documents_Click(object sender, EventArgs e)
        {
            if (currentButton.Name != btn_Documents.Name)
            {
                UC_Unclicked();

                // Hiding current UserControl
                currentOpen.Hide();

                // Assigning appropriate UC to `currentOpen` and showing it
                currentOpen = studentDocuments1;
                currentOpen.Show();

                // Assining this button as current
                currentButton = btn_Documents;
                UC_Clicked();
            }
        }


        // DownloadedDocs button event
        private void btn_DownloadedDocs_Click(object sender, EventArgs e)
        {
            if(currentButton.Name != btn_DownloadedDocs.Name)
            {
                UC_Unclicked();

                // Hiding current UserControl
                currentOpen.Hide();

                // Assigning appropriate UC to `currentOpen` and showing it
                currentOpen = downloadedDocs1;
                currentOpen.Show();

                // Assining this button as current
                currentButton = btn_DownloadedDocs;
                UC_Clicked();
            }
        }


        // ProfileSettings button event
        private void btn_ProfileSettings_Click(object sender, EventArgs e)
        {
            if (currentButton.Name != btn_ProfileSettings.Name)
            {
                UC_Unclicked();

                // Hiding current UserControl
                currentOpen.Hide();

                // Assigning appropriate UC to `currentOpen` and showing it
                currentOpen = studentProfileSettings1;
                currentOpen.Show();

                // Assining this button as current
                currentButton = btn_ProfileSettings;
                UC_Clicked();
            }
        }


        // Changes `currentButton` clicked BackColor and ForeColor when Clicked
        private void UC_Clicked()
        {
            currentButton.BackColor = Color.White;
            currentButton.ForeColor = Color.Black;

        }


        // Changes `currentButton` clicked BackColor and ForeColor Unclicked (hilarious, I know)
        private void UC_Unclicked() // The name is hilarious, I know...
        {
            currentButton.BackColor = Color.DimGray;
            currentButton.ForeColor = Color.White;
        }


        // Network availability detector
        private void NetworkAvailability_frmStudentProfile(object sender, EventArgs e)
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