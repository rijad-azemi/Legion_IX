using Legion_IX.Helpers;
using Legion_IX.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legion_IX.ProjectForms
{
    public partial class frm_ProfessorProfile : Form
    {
        #region UserControl size parameters

        private int Width { get; set; } = 780;
        private int Height { get; set; } = 470;
        private int X_Axis { get; set; } = 120;
        private int Y_Axis { get; set; } = 12;

        #endregion UserControl size parameters


        #region Global Variables

        // Reference variable to current shown `UserControl`
        private UserControl currentOpen;

        // Reference variable to current clicked Button
        private Button currentButton;

        #endregion Global Variables


        public frm_ProfessorProfile()
        {
            InitializeComponent();

            // Subscribes the `NetworkAvailability` method to `NetworkChange` class
            NetworkListener.NetworkAvailabilityChanged += NetworkAvailability_frmProfessorProfile;

            this.FormClosed += FormClosedEvent;
        }


        // Ocurring event after form has closed
        private void FormClosedEvent(object? sender, FormClosedEventArgs e) =>
            LoggedInProfessor.theProf.UpdateProfessor_LoggedIn_Field_toLoggedOut();


        // Form load event
        private void frm_ProfessorProfile_Load(object sender, EventArgs e)
        {
            //btn_Documents.Hide();
            btn_DownloadedDocs.Hide();
            btn_ProfileSettings.Hide();

            // Getting data from `frmProfessorProfile` and passing it to `ProfessorData` UserControl
            professorData1.GetDataFrom_frmProfessorProfile();

            // Setting size and location to all `User Controls`
            SetLocationSizeToAll_UC();

            // Calling the method to detect and display Network change
            NetworkAvailability_frmProfessorProfile(sender, e);

            ShowCurrent_UserControl();

            LoggedInProfessor.theProf.UpdateProfessor_LoggedIn_Field_toLoggedIn();
        }


        // Shows current(professor1) UserControl
        private void ShowCurrent_UserControl()
        {
            // Assigning current button, open Control and showing it
            currentButton = btn_Profile;
            UC_Clicked();

            currentOpen = professorData1;
            currentOpen.Show();
        }


        // Set size and location to all `User Controls`
        private void SetLocationSizeToAll_UC()
        {
            SetUserControlSizeAndLocation(professorData1);
            SetUserControlSizeAndLocation(professorDocuments1);
        }


        // User Control location and size
        private void SetUserControlSizeAndLocation(UserControl uc)
        {
            uc.Width = Width;
            uc.Height = Height;
            uc.Location = new Point(X_Axis, Y_Axis);
        }


        // Network availability detector
        private void NetworkAvailability_frmProfessorProfile(object? sender, EventArgs e)
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


        // Profile button event
        private void btn_Profile_Click(object sender, EventArgs e)
        {
            if (currentButton.Name != btn_Profile.Name)
            {
                UC_Unclicked();

                // Hiding current UserControl
                currentOpen.Hide();

                // Assigning appropriate UC to `currentOpen` and showing it
                currentOpen = professorData1;
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
                currentOpen = professorDocuments1;
                currentOpen.Show();

                // Assigning this button as current
                currentButton = btn_Documents;

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


        // Button Logout event
        private void button_LogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

    }
}
