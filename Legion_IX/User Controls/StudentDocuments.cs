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
    public partial class StudentDocuments : UserControl
    {
        public StudentDocuments()
        {
            InitializeComponent();
        }
        private void StudentDocuments_Load(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        // Shows UC in view
        public void ShowMe() => this.Visible = true;

        // Hides UC from view
        public void HideMe() => this.Visible = false;

    }
}
