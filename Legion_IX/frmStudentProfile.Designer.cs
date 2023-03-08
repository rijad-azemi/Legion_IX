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
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            button_LogOut = new Button();
            ((System.ComponentModel.ISupportInitialize)picBox_StudentPhoto).BeginInit();
            groupBox_StudentInfo.SuspendLayout();
            SuspendLayout();
            // 
            // picBox_StudentPhoto
            // 
            picBox_StudentPhoto.BorderStyle = BorderStyle.FixedSingle;
            picBox_StudentPhoto.Location = new Point(7, 29);
            picBox_StudentPhoto.Margin = new Padding(3, 4, 3, 4);
            picBox_StudentPhoto.Name = "picBox_StudentPhoto";
            picBox_StudentPhoto.Size = new Size(213, 213);
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
            lbl_Name.Location = new Point(338, 29);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(68, 28);
            lbl_Name.TabIndex = 1;
            lbl_Name.Text = "Name:";
            // 
            // lbl_Surname
            // 
            lbl_Surname.AutoSize = true;
            lbl_Surname.BackColor = Color.Transparent;
            lbl_Surname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Surname.ForeColor = Color.Transparent;
            lbl_Surname.Location = new Point(314, 80);
            lbl_Surname.Name = "lbl_Surname";
            lbl_Surname.Size = new Size(93, 28);
            lbl_Surname.TabIndex = 2;
            lbl_Surname.Text = "Surname:";
            // 
            // lbl_Birthdate
            // 
            lbl_Birthdate.AutoSize = true;
            lbl_Birthdate.BackColor = Color.Transparent;
            lbl_Birthdate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Birthdate.ForeColor = SystemColors.ButtonFace;
            lbl_Birthdate.Location = new Point(314, 183);
            lbl_Birthdate.Name = "lbl_Birthdate";
            lbl_Birthdate.Size = new Size(96, 28);
            lbl_Birthdate.TabIndex = 3;
            lbl_Birthdate.Text = "Birthdate:";
            // 
            // lbl_StudyYear
            // 
            lbl_StudyYear.AutoSize = true;
            lbl_StudyYear.BackColor = Color.Transparent;
            lbl_StudyYear.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_StudyYear.ForeColor = SystemColors.ButtonFace;
            lbl_StudyYear.Location = new Point(282, 237);
            lbl_StudyYear.Name = "lbl_StudyYear";
            lbl_StudyYear.Size = new Size(130, 28);
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
            groupBox_StudentInfo.Location = new Point(253, 16);
            groupBox_StudentInfo.Margin = new Padding(3, 4, 3, 4);
            groupBox_StudentInfo.Name = "groupBox_StudentInfo";
            groupBox_StudentInfo.Padding = new Padding(3, 4, 3, 4);
            groupBox_StudentInfo.Size = new Size(683, 404);
            groupBox_StudentInfo.TabIndex = 5;
            groupBox_StudentInfo.TabStop = false;
            groupBox_StudentInfo.Text = "Student Information";
            // 
            // lblLine
            // 
            lblLine.BackColor = Color.DarkGray;
            lblLine.Location = new Point(230, 21);
            lblLine.Name = "lblLine";
            lblLine.Size = new Size(2, 375);
            lblLine.TabIndex = 15;
            // 
            // txtBox_Revised
            // 
            txtBox_Revised.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_Revised.Location = new Point(408, 348);
            txtBox_Revised.Margin = new Padding(3, 4, 3, 4);
            txtBox_Revised.Name = "txtBox_Revised";
            txtBox_Revised.ReadOnly = true;
            txtBox_Revised.Size = new Size(150, 27);
            txtBox_Revised.TabIndex = 14;
            txtBox_Revised.TextAlign = HorizontalAlignment.Center;
            // 
            // lblRevised
            // 
            lblRevised.AutoSize = true;
            lblRevised.BackColor = Color.Transparent;
            lblRevised.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblRevised.ForeColor = SystemColors.ButtonFace;
            lblRevised.Location = new Point(314, 345);
            lblRevised.Name = "lblRevised";
            lblRevised.Size = new Size(82, 28);
            lblRevised.TabIndex = 13;
            lblRevised.Text = "Revised:";
            // 
            // txtBox_Email
            // 
            txtBox_Email.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_Email.Location = new Point(408, 127);
            txtBox_Email.Margin = new Padding(3, 4, 3, 4);
            txtBox_Email.Name = "txtBox_Email";
            txtBox_Email.ReadOnly = true;
            txtBox_Email.Size = new Size(150, 27);
            txtBox_Email.TabIndex = 12;
            txtBox_Email.TextAlign = HorizontalAlignment.Center;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblEmail.ForeColor = Color.Transparent;
            lblEmail.Location = new Point(330, 127);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(71, 28);
            lblEmail.TabIndex = 11;
            lblEmail.Text = "E-mail:";
            // 
            // txtBox_DisplayIndex
            // 
            txtBox_DisplayIndex.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_DisplayIndex.Location = new Point(408, 291);
            txtBox_DisplayIndex.Margin = new Padding(3, 4, 3, 4);
            txtBox_DisplayIndex.Name = "txtBox_DisplayIndex";
            txtBox_DisplayIndex.ReadOnly = true;
            txtBox_DisplayIndex.Size = new Size(150, 27);
            txtBox_DisplayIndex.TabIndex = 10;
            txtBox_DisplayIndex.TextAlign = HorizontalAlignment.Center;
            // 
            // txtBox_DisplayStudyYear
            // 
            txtBox_DisplayStudyYear.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_DisplayStudyYear.Location = new Point(408, 235);
            txtBox_DisplayStudyYear.Margin = new Padding(3, 4, 3, 4);
            txtBox_DisplayStudyYear.Name = "txtBox_DisplayStudyYear";
            txtBox_DisplayStudyYear.ReadOnly = true;
            txtBox_DisplayStudyYear.Size = new Size(150, 27);
            txtBox_DisplayStudyYear.TabIndex = 9;
            txtBox_DisplayStudyYear.TextAlign = HorizontalAlignment.Center;
            // 
            // txtBox_DisplayBirthdate
            // 
            txtBox_DisplayBirthdate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_DisplayBirthdate.Location = new Point(408, 180);
            txtBox_DisplayBirthdate.Margin = new Padding(3, 4, 3, 4);
            txtBox_DisplayBirthdate.Name = "txtBox_DisplayBirthdate";
            txtBox_DisplayBirthdate.ReadOnly = true;
            txtBox_DisplayBirthdate.Size = new Size(150, 27);
            txtBox_DisplayBirthdate.TabIndex = 8;
            txtBox_DisplayBirthdate.TextAlign = HorizontalAlignment.Center;
            // 
            // txtBox_DisplaySurname
            // 
            txtBox_DisplaySurname.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_DisplaySurname.Location = new Point(408, 83);
            txtBox_DisplaySurname.Margin = new Padding(3, 4, 3, 4);
            txtBox_DisplaySurname.Name = "txtBox_DisplaySurname";
            txtBox_DisplaySurname.ReadOnly = true;
            txtBox_DisplaySurname.Size = new Size(150, 27);
            txtBox_DisplaySurname.TabIndex = 7;
            txtBox_DisplaySurname.TextAlign = HorizontalAlignment.Center;
            // 
            // txtBox_DisplayName
            // 
            txtBox_DisplayName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtBox_DisplayName.Location = new Point(408, 32);
            txtBox_DisplayName.Margin = new Padding(3, 4, 3, 4);
            txtBox_DisplayName.Name = "txtBox_DisplayName";
            txtBox_DisplayName.ReadOnly = true;
            txtBox_DisplayName.Size = new Size(150, 27);
            txtBox_DisplayName.TabIndex = 6;
            txtBox_DisplayName.TextAlign = HorizontalAlignment.Center;
            // 
            // lbl_Index
            // 
            lbl_Index.AutoSize = true;
            lbl_Index.BackColor = Color.Transparent;
            lbl_Index.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Index.ForeColor = SystemColors.ButtonFace;
            lbl_Index.Location = new Point(338, 288);
            lbl_Index.Name = "lbl_Index";
            lbl_Index.Size = new Size(63, 28);
            lbl_Index.TabIndex = 5;
            lbl_Index.Text = "Index:";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // button_LogOut
            // 
            button_LogOut.Location = new Point(926, 671);
            button_LogOut.Name = "button_LogOut";
            button_LogOut.Size = new Size(94, 29);
            button_LogOut.TabIndex = 6;
            button_LogOut.Text = "Log Out";
            button_LogOut.UseVisualStyleBackColor = true;
            button_LogOut.Click += button_LogOut_Click;
            // 
            // frmStudentProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1028, 712);
            Controls.Add(button_LogOut);
            Controls.Add(groupBox_StudentInfo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmStudentProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmStudentProfile_Load;
            ((System.ComponentModel.ISupportInitialize)picBox_StudentPhoto).EndInit();
            groupBox_StudentInfo.ResumeLayout(false);
            groupBox_StudentInfo.PerformLayout();
            ResumeLayout(false);
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
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label lblLine;
        private Button button_LogOut;
    }
}