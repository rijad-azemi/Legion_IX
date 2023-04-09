using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void frm_StudentServiceADMIN_Load(object sender, EventArgs e)
        {

        }

        private void button_LogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}