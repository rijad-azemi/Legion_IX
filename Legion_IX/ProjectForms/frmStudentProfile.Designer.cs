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
            picBox_StudentPhoto = new PictureBox();
            lbl_Name = new Label();
            lbl_Surname = new Label();
            lbl_Birthdate = new Label();
            lbl_StudyYear = new Label();
            groupBox_StudentInfo = new GroupBox();
            lblLine = new Label();
            txtBox_Revised = new TextBox();
            lblRevised = new Label();
            txtBox_Email = new TextBox();
            lblEmail = new Label();
            txtBox_DisplayIndex = new TextBox();
            txtBox_DisplayStudyYear = new TextBox();
            txtBox_DisplayBirthdate = new TextBox();
            txtBox_DisplaySurname = new TextBox();
            txtBox_DisplayName = new TextBox();
            lbl_Index = new Label();
            button_LogOut = new Button();
            btn_Documents = new Button();
            txtBox_NetworkStatus = new TextBox();
            studentData1 = new User_Controls.StudentData();
            studentDocuments1 = new User_Controls.StudentDocuments();
            btn_Profile = new Button();
            ((System.ComponentModel.ISupportInitialize)picBox_StudentPhoto).BeginInit();
            groupBox_StudentInfo.SuspendLayout();
            SuspendLayout();
            // 
            // picBox_StudentPhoto
            // 
            picBox_StudentPhoto.BorderStyle = BorderStyle.FixedSingle;
            picBox_StudentPhoto.Location = new Point(6, 22);
            picBox_StudentPhoto.Name = "picBox_StudentPhoto";
            picBox_StudentPhoto.Size = new Size(187, 160);
            picBox_StudentPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox_StudentPhoto.TabIndex = 0;
            picBox_StudentPhoto.TabStop = false;
            // 
            // lbl_Name
            // 
            lbl_Name.AutoSize = true;
            lbl_Name.BackColor = Color.Transparent;
            lbl_Name.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Name.ForeColor = SystemColors.ButtonFace;
            lbl_Name.Location = new Point(296, 22);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(55, 21);
            lbl_Name.TabIndex = 1;
            lbl_Name.Text = "Name:";
            // 
            // lbl_Surname
            // 
            lbl_Surname.AutoSize = true;
            lbl_Surname.BackColor = Color.Transparent;
            lbl_Surname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Surname.ForeColor = Color.Transparent;
            lbl_Surname.Location = new Point(275, 60);
            lbl_Surname.Name = "lbl_Surname";
            lbl_Surname.Size = new Size(76, 21);
            lbl_Surname.TabIndex = 2;
            lbl_Surname.Text = "Surname:";
            // 
            // lbl_Birthdate
            // 
            lbl_Birthdate.AutoSize = true;
            lbl_Birthdate.BackColor = Color.Transparent;
            lbl_Birthdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Birthdate.ForeColor = SystemColors.ButtonFace;
            lbl_Birthdate.Location = new Point(275, 137);
            lbl_Birthdate.Name = "lbl_Birthdate";
            lbl_Birthdate.Size = new Size(76, 21);
            lbl_Birthdate.TabIndex = 3;
            lbl_Birthdate.Text = "Birthdate:";
            // 
            // lbl_StudyYear
            // 
            lbl_StudyYear.AutoSize = true;
            lbl_StudyYear.BackColor = Color.Transparent;
            lbl_StudyYear.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StudyYear.ForeColor = SystemColors.ButtonFace;
            lbl_StudyYear.Location = new Point(247, 178);
            lbl_StudyYear.Name = "lbl_StudyYear";
            lbl_StudyYear.Size = new Size(104, 21);
            lbl_StudyYear.TabIndex = 4;
            lbl_StudyYear.Text = "Year of Study:";
            // 
            // groupBox_StudentInfo
            // 
            groupBox_StudentInfo.BackColor = Color.Transparent;
            groupBox_StudentInfo.Controls.Add(lblLine);
            groupBox_StudentInfo.Controls.Add(txtBox_Revised);
            groupBox_StudentInfo.Controls.Add(lblRevised);
            groupBox_StudentInfo.Controls.Add(txtBox_Email);
            groupBox_StudentInfo.Controls.Add(lblEmail);
            groupBox_StudentInfo.Controls.Add(txtBox_DisplayIndex);
            groupBox_StudentInfo.Controls.Add(txtBox_DisplayStudyYear);
            groupBox_StudentInfo.Controls.Add(txtBox_DisplayBirthdate);
            groupBox_StudentInfo.Controls.Add(txtBox_DisplaySurname);
            groupBox_StudentInfo.Controls.Add(txtBox_DisplayName);
            groupBox_StudentInfo.Controls.Add(lbl_Index);
            groupBox_StudentInfo.Controls.Add(picBox_StudentPhoto);
            groupBox_StudentInfo.Controls.Add(lbl_StudyYear);
            groupBox_StudentInfo.Controls.Add(lbl_Name);
            groupBox_StudentInfo.Controls.Add(lbl_Birthdate);
            groupBox_StudentInfo.Controls.Add(lbl_Surname);
            groupBox_StudentInfo.ForeColor = SystemColors.ButtonFace;
            groupBox_StudentInfo.Location = new Point(12, 470);
            groupBox_StudentInfo.Name = "groupBox_StudentInfo";
            groupBox_StudentInfo.Size = new Size(285, 52);
            groupBox_StudentInfo.TabIndex = 5;
            groupBox_StudentInfo.TabStop = false;
            groupBox_StudentInfo.Text = "Student Information";
            // 
            // lblLine
            // 
            lblLine.BackColor = Color.DarkGray;
            lblLine.Location = new Point(201, 16);
            lblLine.Name = "lblLine";
            lblLine.Size = new Size(2, 281);
            lblLine.TabIndex = 15;
            // 
            // txtBox_Revised
            // 
            txtBox_Revised.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_Revised.Location = new Point(357, 261);
            txtBox_Revised.Name = "txtBox_Revised";
            txtBox_Revised.ReadOnly = true;
            txtBox_Revised.Size = new Size(132, 23);
            txtBox_Revised.TabIndex = 14;
            txtBox_Revised.TextAlign = HorizontalAlignment.Center;
            // 
            // lblRevised
            // 
            lblRevised.AutoSize = true;
            lblRevised.BackColor = Color.Transparent;
            lblRevised.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblRevised.ForeColor = SystemColors.ButtonFace;
            lblRevised.Location = new Point(275, 259);
            lblRevised.Name = "lblRevised";
            lblRevised.Size = new Size(67, 21);
            lblRevised.TabIndex = 13;
            lblRevised.Text = "Revised:";
            // 
            // txtBox_Email
            // 
            txtBox_Email.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_Email.Location = new Point(357, 95);
            txtBox_Email.Name = "txtBox_Email";
            txtBox_Email.ReadOnly = true;
            txtBox_Email.Size = new Size(132, 23);
            txtBox_Email.TabIndex = 12;
            txtBox_Email.TextAlign = HorizontalAlignment.Center;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmail.ForeColor = Color.Transparent;
            lblEmail.Location = new Point(289, 95);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(57, 21);
            lblEmail.TabIndex = 11;
            lblEmail.Text = "E-mail:";
            // 
            // txtBox_DisplayIndex
            // 
            txtBox_DisplayIndex.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_DisplayIndex.Location = new Point(357, 218);
            txtBox_DisplayIndex.Name = "txtBox_DisplayIndex";
            txtBox_DisplayIndex.ReadOnly = true;
            txtBox_DisplayIndex.Size = new Size(132, 23);
            txtBox_DisplayIndex.TabIndex = 10;
            txtBox_DisplayIndex.TextAlign = HorizontalAlignment.Center;
            // 
            // txtBox_DisplayStudyYear
            // 
            txtBox_DisplayStudyYear.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_DisplayStudyYear.Location = new Point(357, 176);
            txtBox_DisplayStudyYear.Name = "txtBox_DisplayStudyYear";
            txtBox_DisplayStudyYear.ReadOnly = true;
            txtBox_DisplayStudyYear.Size = new Size(132, 23);
            txtBox_DisplayStudyYear.TabIndex = 9;
            txtBox_DisplayStudyYear.TextAlign = HorizontalAlignment.Center;
            // 
            // txtBox_DisplayBirthdate
            // 
            txtBox_DisplayBirthdate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_DisplayBirthdate.Location = new Point(357, 135);
            txtBox_DisplayBirthdate.Name = "txtBox_DisplayBirthdate";
            txtBox_DisplayBirthdate.ReadOnly = true;
            txtBox_DisplayBirthdate.Size = new Size(132, 23);
            txtBox_DisplayBirthdate.TabIndex = 8;
            txtBox_DisplayBirthdate.TextAlign = HorizontalAlignment.Center;
            // 
            // txtBox_DisplaySurname
            // 
            txtBox_DisplaySurname.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_DisplaySurname.Location = new Point(357, 62);
            txtBox_DisplaySurname.Name = "txtBox_DisplaySurname";
            txtBox_DisplaySurname.ReadOnly = true;
            txtBox_DisplaySurname.Size = new Size(132, 23);
            txtBox_DisplaySurname.TabIndex = 7;
            txtBox_DisplaySurname.TextAlign = HorizontalAlignment.Center;
            // 
            // txtBox_DisplayName
            // 
            txtBox_DisplayName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_DisplayName.Location = new Point(357, 24);
            txtBox_DisplayName.Name = "txtBox_DisplayName";
            txtBox_DisplayName.ReadOnly = true;
            txtBox_DisplayName.Size = new Size(132, 23);
            txtBox_DisplayName.TabIndex = 6;
            txtBox_DisplayName.TextAlign = HorizontalAlignment.Center;
            // 
            // lbl_Index
            // 
            lbl_Index.AutoSize = true;
            lbl_Index.BackColor = Color.Transparent;
            lbl_Index.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Index.ForeColor = SystemColors.ButtonFace;
            lbl_Index.Location = new Point(296, 216);
            lbl_Index.Name = "lbl_Index";
            lbl_Index.Size = new Size(50, 21);
            lbl_Index.TabIndex = 5;
            lbl_Index.Text = "Index:";
            // 
            // button_LogOut
            // 
            button_LogOut.Location = new Point(689, 503);
            button_LogOut.Margin = new Padding(3, 2, 3, 2);
            button_LogOut.Name = "button_LogOut";
            button_LogOut.Size = new Size(82, 22);
            button_LogOut.TabIndex = 6;
            button_LogOut.Text = "Log Out";
            button_LogOut.UseVisualStyleBackColor = true;
            button_LogOut.Click += button_LogOut_Click;
            // 
            // btn_Documents
            // 
            btn_Documents.Location = new Point(12, 71);
            btn_Documents.Name = "btn_Documents";
            btn_Documents.Size = new Size(88, 23);
            btn_Documents.TabIndex = 7;
            btn_Documents.Text = "Documents";
            btn_Documents.UseVisualStyleBackColor = true;
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
            studentData1.Location = new Point(234, 12);
            studentData1.Name = "studentData1";
            studentData1.Size = new Size(63, 35);
            studentData1.TabIndex = 10;
            // 
            // studentDocuments1
            // 
            studentDocuments1.Location = new Point(356, 12);
            studentDocuments1.Name = "studentDocuments1";
            studentDocuments1.Size = new Size(50, 35);
            studentDocuments1.TabIndex = 11;
            // 
            // btn_Profile
            // 
            btn_Profile.Location = new Point(12, 42);
            btn_Profile.Name = "btn_Profile";
            btn_Profile.Size = new Size(88, 23);
            btn_Profile.TabIndex = 12;
            btn_Profile.Text = "Profile";
            btn_Profile.UseVisualStyleBackColor = true;
            btn_Profile.Click += btn_Profile_Click;
            // 
            // frmStudentProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(900, 534);
            Controls.Add(btn_Profile);
            Controls.Add(studentDocuments1);
            Controls.Add(studentData1);
            Controls.Add(txtBox_NetworkStatus);
            Controls.Add(btn_Documents);
            Controls.Add(button_LogOut);
            Controls.Add(groupBox_StudentInfo);
            Name = "frmStudentProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmStudentProfile_Load;
            ((System.ComponentModel.ISupportInitialize)picBox_StudentPhoto).EndInit();
            groupBox_StudentInfo.ResumeLayout(false);
            groupBox_StudentInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picBox_StudentPhoto;
        private Label lbl_Name;
        private Label lbl_Surname;
        private Label lbl_Birthdate;
        private Label lbl_StudyYear;
        private GroupBox groupBox_StudentInfo;
        private Label lbl_Index;
        private TextBox txtBox_DisplayIndex;
        private TextBox txtBox_DisplayStudyYear;
        private TextBox txtBox_DisplayBirthdate;
        private TextBox txtBox_DisplaySurname;
        private TextBox txtBox_DisplayName;
        private Label lblEmail;
        private TextBox txtBox_Email;
        private TextBox txtBox_Revised;
        private Label lblRevised;
        private Label lblLine;
        private Button button_LogOut;
        private Button btn_Documents;
        private TextBox txtBox_NetworkStatus;
        private User_Controls.StudentData studentData1;
        private User_Controls.StudentDocuments studentDocuments1;
        private Button btn_Profile;
    }
}