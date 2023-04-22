using Legion_IX.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legion_IX.ProjectForms
{
    public partial class frm_StudentServiceADMIN : Form
    {
        public frm_StudentServiceADMIN()
        {

            InitializeComponent();

            NetworkListener.NetworkAvailabilityChanged += NetworkAvailability_frmStudentService;

        }


        private void frm_StudentServiceADMIN_Load(object sender, EventArgs e)
        {
            NetworkAvailability_frmStudentService(sender, e);
        }


        private void button_LogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }


        private void NetworkAvailability_frmStudentService(object? sender, EventArgs e)
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


        private void btn_ViewActiveProfessors_Click(object sender, EventArgs e)
        {
            uc_ActiveProfessors1.Show();
        }
    }
}