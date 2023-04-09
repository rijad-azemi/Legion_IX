namespace Legion_IX.ProjectForms
{
    partial class frm_ProfessorProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProfessorProfile));
            userControlProf1 = new User_Controls.Professor_UC_s.UserControlProf();
            txtBox_NetworkStatus = new TextBox();
            button_LogOut = new Button();
            btn_DownloadedDocs = new Button();
            btn_ProfileSettings = new Button();
            btn_Profile = new Button();
            btn_Documents = new Button();
            SuspendLayout();
            // 
            // userControlProf1
            // 
            userControlProf1.Location = new Point(215, 26);
            userControlProf1.Name = "userControlProf1";
            userControlProf1.Size = new Size(664, 304);
            userControlProf1.TabIndex = 0;
            // 
            // txtBox_NetworkStatus
            // 
            txtBox_NetworkStatus.Location = new Point(788, 500);
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
            button_LogOut.Location = new Point(689, 501);
            button_LogOut.Margin = new Padding(3, 2, 3, 2);
            button_LogOut.Name = "button_LogOut";
            button_LogOut.Size = new Size(82, 25);
            button_LogOut.TabIndex = 10;
            button_LogOut.Text = "Log Out";
            button_LogOut.UseVisualStyleBackColor = false;
            // 
            // btn_DownloadedDocs
            // 
            btn_DownloadedDocs.AutoSize = true;
            btn_DownloadedDocs.BackColor = Color.DimGray;
            btn_DownloadedDocs.FlatAppearance.BorderSize = 0;
            btn_DownloadedDocs.FlatStyle = FlatStyle.Flat;
            btn_DownloadedDocs.ForeColor = SystemColors.ButtonFace;
            btn_DownloadedDocs.Location = new Point(12, 86);
            btn_DownloadedDocs.Name = "btn_DownloadedDocs";
            btn_DownloadedDocs.Size = new Size(88, 25);
            btn_DownloadedDocs.TabIndex = 20;
            btn_DownloadedDocs.Text = "Downloaded";
            btn_DownloadedDocs.UseVisualStyleBackColor = false;
            // 
            // btn_ProfileSettings
            // 
            btn_ProfileSettings.AutoSize = true;
            btn_ProfileSettings.BackColor = Color.DimGray;
            btn_ProfileSettings.FlatAppearance.BorderSize = 0;
            btn_ProfileSettings.FlatStyle = FlatStyle.Flat;
            btn_ProfileSettings.ForeColor = SystemColors.ButtonFace;
            btn_ProfileSettings.Location = new Point(12, 157);
            btn_ProfileSettings.Name = "btn_ProfileSettings";
            btn_ProfileSettings.Size = new Size(96, 25);
            btn_ProfileSettings.TabIndex = 19;
            btn_ProfileSettings.Text = "Profile Settings";
            btn_ProfileSettings.UseVisualStyleBackColor = false;
            // 
            // btn_Profile
            // 
            btn_Profile.AutoSize = true;
            btn_Profile.BackColor = Color.DimGray;
            btn_Profile.FlatAppearance.BorderSize = 0;
            btn_Profile.FlatStyle = FlatStyle.Flat;
            btn_Profile.ForeColor = SystemColors.ButtonFace;
            btn_Profile.Location = new Point(12, 26);
            btn_Profile.Name = "btn_Profile";
            btn_Profile.Size = new Size(88, 25);
            btn_Profile.TabIndex = 18;
            btn_Profile.Text = "Profile";
            btn_Profile.UseVisualStyleBackColor = false;
            // 
            // btn_Documents
            // 
            btn_Documents.AutoSize = true;
            btn_Documents.BackColor = Color.DimGray;
            btn_Documents.FlatAppearance.BorderSize = 0;
            btn_Documents.FlatStyle = FlatStyle.Flat;
            btn_Documents.ForeColor = SystemColors.ButtonFace;
            btn_Documents.Location = new Point(12, 55);
            btn_Documents.Name = "btn_Documents";
            btn_Documents.Size = new Size(88, 25);
            btn_Documents.TabIndex = 17;
            btn_Documents.Text = "Documents";
            btn_Documents.UseVisualStyleBackColor = false;
            // 
            // frm_ProfessorProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(900, 535);
            Controls.Add(btn_DownloadedDocs);
            Controls.Add(btn_ProfileSettings);
            Controls.Add(btn_Profile);
            Controls.Add(btn_Documents);
            Controls.Add(txtBox_NetworkStatus);
            Controls.Add(button_LogOut);
            Controls.Add(userControlProf1);
            Name = "frm_ProfessorProfile";
            Text = "frm_ProfessorProfile";
            Load += frm_ProfessorProfile_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private User_Controls.Professor_UC_s.UserControlProf userControlProf1;
        private TextBox txtBox_NetworkStatus;
        private Button button_LogOut;
        private Button btn_DownloadedDocs;
        private Button btn_ProfileSettings;
        private Button btn_Profile;
        private Button btn_Documents;
    }
}