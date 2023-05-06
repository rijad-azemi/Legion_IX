using Legion_IX.DB;
using Legion_IX.Helpers;
using MongoDB.Bson;

namespace Legion_IX
{
    public partial class frm_StudentProfile : Form
    {
        #region UserControl size parameters

        private int Width { get; set; } = 654;
        private int Height { get; set; } = 470;
        private int X_Axis { get; set; } = 234;
        private int Y_Axis { get; set; } = 12;

        #endregion UserControl size parameters


        #region Global Variables

        // Reference variable to current shown `UserControl`
        private UserControl currentOpen;

        // Reference variable to current clicked Button
        private Button currentButton;

        #endregion Global Variables


        public frm_StudentProfile()
        {
            InitializeComponent();

            // Subscribes the `NetworkAvailability` method to `NetworkChange` class
            NetworkListener.NetworkAvailabilityChanged += NetworkAvailability_frmStudentProfile;

            this.FormClosed += Frm_StudentProfile_FormClosed;
        }


        private void Frm_StudentProfile_FormClosed(object? sender, FormClosedEventArgs e) =>
            LoggedInStudent.theStudent.UpdateStudent_LoggedIn_Field_toLoggedOut();


        private void frmStudentProfile_Load(object sender, EventArgs e)
        {
            // Passing information to User Control
            studentData1.GetDataFrom_frmStudentProfile();

            // Setting size and location to all `User Controls`
            SetLocationSizeToAll_UC();

            ShowCurrent_UserControl();

            // Calling the method to detect and display Network change
            NetworkAvailability_frmStudentProfile(sender, e);

            // Updating `LoggedIn` on Atlas to true
            LoggedInStudent.theStudent.UpdateStudent_LoggedIn_Field_toLoggedIn();
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
            SetUserControlSizeAndLocation(studentDownloadedDocs1);
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
            if (currentButton.Name != btn_DownloadedDocs.Name)
            {
                UC_Unclicked();

                // Hiding current UserControl
                currentOpen.Hide();
                studentDownloadedDocs1.Show();
                // Assigning appropriate UC to `currentOpen` and showing it
                currentOpen = studentDownloadedDocs1;
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
        private void NetworkAvailability_frmStudentProfile(object? sender, EventArgs e)
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

        private void defaultBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}