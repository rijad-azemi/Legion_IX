namespace Legion_IX
{
    partial class frmStudentProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentProfile));
            button_LogOut = new Button();
            btn_Documents = new Button();
            txtBox_NetworkStatus = new TextBox();
            studentData1 = new User_Controls.StudentData();
            studentDocuments1 = new User_Controls.StudentDocuments();
            btn_Profile = new Button();
            btn_ProfileSettings = new Button();
            studentProfileSettings1 = new User_Controls.StudentProfileSettings();
            SuspendLayout();
            // 
            // button_LogOut
            // 
            button_LogOut.AutoSize = true;
            button_LogOut.BackColor = Color.DimGray;
            button_LogOut.FlatAppearance.BorderSize = 0;
            button_LogOut.FlatStyle = FlatStyle.Flat;
            button_LogOut.ForeColor = SystemColors.ButtonFace;
            button_LogOut.Location = new Point(689, 503);
            button_LogOut.Margin = new Padding(3, 2, 3, 2);
            button_LogOut.Name = "button_LogOut";
            button_LogOut.Size = new Size(82, 25);
            button_LogOut.TabIndex = 6;
            button_LogOut.Text = "Log Out";
            button_LogOut.UseVisualStyleBackColor = false;
            button_LogOut.Click += button_LogOut_Click;
            // 
            // btn_Documents
            // 
            btn_Documents.AutoSize = true;
            btn_Documents.BackColor = Color.DimGray;
            btn_Documents.FlatAppearance.BorderSize = 0;
            btn_Documents.FlatStyle = FlatStyle.Flat;
            btn_Documents.ForeColor = SystemColors.ButtonFace;
            btn_Documents.Location = new Point(12, 71);
            btn_Documents.Name = "btn_Documents";
            btn_Documents.Size = new Size(88, 25);
            btn_Documents.TabIndex = 7;
            btn_Documents.Text = "Documents";
            btn_Documents.UseVisualStyleBackColor = false;
            btn_Documents.Click += btn_Documents_Click;
            // 
            // txtBox_NetworkStatus
            // 
            txtBox_NetworkStatus.Location = new Point(788, 502);
            txtBox_NetworkStatus.Name = "txtBox_NetworkStatus";
            txtBox_NetworkStatus.ReadOnly = true;
            txtBox_NetworkStatus.Size = new Size(100, 23);
            txtBox_NetworkStatus.TabIndex = 9;
            txtBox_NetworkStatus.TextAlign = HorizontalAlignment.Center;
            // 
            // studentData1
            // 
            studentData1.BackColor = Color.Transparent;
            studentData1.BorderStyle = BorderStyle.FixedSingle;
            studentData1.Location = new Point(234, 12);
            studentData1.Name = "studentData1";
            studentData1.Size = new Size(63, 35);
            studentData1.TabIndex = 10;
            // 
            // studentDocuments1
            // 
            studentDocuments1.BackColor = Color.Transparent;
            studentDocuments1.BorderStyle = BorderStyle.FixedSingle;
            studentDocuments1.ChosenSubject = null;
            studentDocuments1.Location = new Point(356, 12);
            studentDocuments1.Name = "studentDocuments1";
            studentDocuments1.Size = new Size(50, 35);
            studentDocuments1.TabIndex = 11;
            // 
            // btn_Profile
            // 
            btn_Profile.AutoSize = true;
            btn_Profile.BackColor = Color.DimGray;
            btn_Profile.FlatAppearance.BorderSize = 0;
            btn_Profile.FlatStyle = FlatStyle.Flat;
            btn_Profile.ForeColor = SystemColors.ButtonFace;
            btn_Profile.Location = new Point(12, 42);
            btn_Profile.Name = "btn_Profile";
            btn_Profile.Size = new Size(88, 25);
            btn_Profile.TabIndex = 12;
            btn_Profile.Text = "Profile";
            btn_Profile.UseVisualStyleBackColor = false;
            btn_Profile.Click += btn_Profile_Click;
            // 
            // btn_ProfileSettings
            // 
            btn_ProfileSettings.AutoSize = true;
            btn_ProfileSettings.BackColor = Color.DimGray;
            btn_ProfileSettings.FlatAppearance.BorderSize = 0;
            btn_ProfileSettings.FlatStyle = FlatStyle.Flat;
            btn_ProfileSettings.ForeColor = SystemColors.ButtonFace;
            btn_ProfileSettings.Location = new Point(12, 102);
            btn_ProfileSettings.Name = "btn_ProfileSettings";
            btn_ProfileSettings.Size = new Size(96, 25);
            btn_ProfileSettings.TabIndex = 14;
            btn_ProfileSettings.Text = "Profile Settings";
            btn_ProfileSettings.UseVisualStyleBackColor = false;
            btn_ProfileSettings.Click += btn_ProfileSettings_Click;
            // 
            // studentProfileSettings1
            // 
            studentProfileSettings1.Location = new Point(303, 264);
            studentProfileSettings1.Name = "studentProfileSettings1";
            studentProfileSettings1.Size = new Size(150, 150);
            studentProfileSettings1.TabIndex = 15;
            // 
            // frmStudentProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(900, 534);
            Controls.Add(studentProfileSettings1);
            Controls.Add(btn_ProfileSettings);
            Controls.Add(btn_Profile);
            Controls.Add(studentDocuments1);
            Controls.Add(studentData1);
            Controls.Add(txtBox_NetworkStatus);
            Controls.Add(btn_Documents);
            Controls.Add(button_LogOut);
            Name = "frmStudentProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmStudentProfile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button_LogOut;
        private Button btn_Documents;
        private TextBox txtBox_NetworkStatus;
        private User_Controls.StudentData studentData1;
        private User_Controls.StudentDocuments studentDocuments1;
        private Button btn_Profile;
        private Button btn_ProfileSettings;
        private User_Controls.StudentProfileSettings studentProfileSettings1;
    }
}