using Legion_IX.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legion_IX.User_Controls.StudentService_UC_s
{
    internal partial class UC_StudentService_ADMIN : UserControl
    {

        public UC_StudentService_ADMIN()
        {
            InitializeComponent();
        }


        private void StudentService_ADMIN_Load(object sender, EventArgs e)
        {

            OnLoadPartialClass_Student();

            OnLoadPartialClass_Professor();

        }

    }
}