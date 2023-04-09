using Legion_IX.User_Controls.StudentService_UC_s;

namespace Legion_IX.ProjectForms
{
    partial class frm_StudentServiceADMIN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_StudentServiceADMIN));
            studentService_admin1 = new User_Controls.StudentService_UC_s.UC_StudentService_ADMIN();
            txtBox_NetworkStatus = new TextBox();
            button_LogOut = new Button();
            SuspendLayout();
            // 
            // studentService_admin1
            // 
            studentService_admin1.BackgroundImage = (Image)resources.GetObject("studentService_admin1.BackgroundImage");
            studentService_admin1.BackgroundImageLayout = ImageLayout.Stretch;
            studentService_admin1.Location = new Point(12, 12);
            studentService_admin1.Name = "studentService_admin1";
            studentService_admin1.Size = new Size(1425, 584);
            studentService_admin1.TabIndex = 0;
            // 
            // txtBox_NetworkStatus
            // 
            txtBox_NetworkStatus.Location = new Point(1337, 600);
            txtBox_NetworkStatus.Name = "txtBox_NetworkStatus";
            txtBox_NetworkStatus.ReadOnly = true;
            txtBox_NetworkStatus.Size = new Size(100, 23);
            txtBox_NetworkStatus.TabIndex = 11;
            txtBox_NetworkStatus.TextAlign = HorizontalAlignment.Center;
            // 
            // button_LogOut
            // 
            button_LogOut.AutoSize = true;
            button_LogOut.BackColor = Color.DimGray;
            button_LogOut.FlatAppearance.BorderSize = 0;
            button_LogOut.FlatStyle = FlatStyle.Flat;
            button_LogOut.ForeColor = SystemColors.ButtonFace;
            button_LogOut.Location = new Point(1238, 601);
            button_LogOut.Margin = new Padding(3, 2, 3, 2);
            button_LogOut.Name = "button_LogOut";
            button_LogOut.Size = new Size(82, 25);
            button_LogOut.TabIndex = 10;
            button_LogOut.Text = "Log Out";
            button_LogOut.UseVisualStyleBackColor = false;
            button_LogOut.Click += button_LogOut_Click;
            // 
            // frm_StudentServiceADMIN
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1455, 629);
            Controls.Add(txtBox_NetworkStatus);
            Controls.Add(button_LogOut);
            Controls.Add(studentService_admin1);
            //Controls.Add(studentService_admin1.professorsSubjects1);
            Name = "frm_StudentServiceADMIN";
            Text = "frm_StudentServiceADMIN";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal User_Controls.StudentService_UC_s.UC_StudentService_ADMIN studentService_admin1;
        private TextBox txtBox_NetworkStatus;
        private Button button_LogOut;
    }
}