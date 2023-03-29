using Legion_IX.DB;
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

        // Reference Variable to the logged in Student
        Student theStudent = frmStudentProfile.theStudent;

        #endregion GlobalVariables

        public StudentProfileSettings()
        {
            InitializeComponent();
        }
        private void StudentProfileSettings_Load(object sender, EventArgs e)
        {
            // Hiding from view on load
            this.Hide();
        }

        private void btn_ChangePhoto_Click(object sender, EventArgs e)
        {
            opf_ChangePhoto.Filter = "JPG (*.jpg)|*.jpg|IMG (*.img)|*.img|PNG (*.png)|*png";

            if(opf_ChangePhoto.ShowDialog() == DialogResult.OK )
            {
                picBox_uc_StudentPhoto.Image = Image.FromFile(opf_ChangePhoto.FileName);
            }
        }
    }
}
