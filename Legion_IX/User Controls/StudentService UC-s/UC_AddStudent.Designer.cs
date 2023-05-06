namespace Legion_IX.User_Controls.StudentService_UC_s
{
    partial class UC_AddStudent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_AddStudent));
            groupBox1 = new GroupBox();
            lbl_SeperatorLine = new Label();
            btn_LoadStudPhoto = new Button();
            picBox_StudentPhoto = new PictureBox();
            lbl_University = new Label();
            btn_CreateStudent = new Button();
            groupBox_LoginInfo = new GroupBox();
            checkBox_Revised = new CheckBox();
            checkBox_EnterCustomEmail = new CheckBox();
            label2 = new Label();
            lbl_Email = new Label();
            lbl_Index = new Label();
            txtBox_StudentPassword = new TextBox();
            txtBox_StudentEmail = new TextBox();
            txtBox_Index = new TextBox();
            groupBox_StudentData = new GroupBox();
            lbl_StudyYear = new Label();
            comboBox_StudyYear = new ComboBox();
            lbl_Birthdate = new Label();
            dtTimePicker_Birthdate = new DateTimePicker();
            lbl_Surname = new Label();
            lbl_Name = new Label();
            txtBox_StudentSurname = new TextBox();
            txtBox_StudentName = new TextBox();
            pictureBox_fitLogo = new PictureBox();
            err_StudentEmailFormat = new ErrorProvider(components);
            err_StudentPasswordFormat = new ErrorProvider(components);
            openFileDialog_SetStudentPhoto = new OpenFileDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBox_StudentPhoto).BeginInit();
            groupBox_LoginInfo.SuspendLayout();
            groupBox_StudentData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_fitLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err_StudentEmailFormat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err_StudentPasswordFormat).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(lbl_SeperatorLine);
            groupBox1.Controls.Add(btn_LoadStudPhoto);
            groupBox1.Controls.Add(picBox_StudentPhoto);
            groupBox1.Controls.Add(lbl_University);
            groupBox1.Controls.Add(btn_CreateStudent);
            groupBox1.Controls.Add(groupBox_LoginInfo);
            groupBox1.Controls.Add(groupBox_StudentData);
            groupBox1.Controls.Add(pictureBox_fitLogo);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.Blue;
            groupBox1.Location = new Point(16, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(653, 578);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add Student";
            // 
            // lbl_SeperatorLine
            // 
            lbl_SeperatorLine.BackColor = SystemColors.ActiveCaptionText;
            lbl_SeperatorLine.Location = new Point(200, 19);
            lbl_SeperatorLine.Name = "lbl_SeperatorLine";
            lbl_SeperatorLine.Size = new Size(2, 168);
            lbl_SeperatorLine.TabIndex = 15;
            // 
            // btn_LoadStudPhoto
            // 
            btn_LoadStudPhoto.Location = new Point(38, 414);
            btn_LoadStudPhoto.Name = "btn_LoadStudPhoto";
            btn_LoadStudPhoto.Size = new Size(151, 23);
            btn_LoadStudPhoto.TabIndex = 14;
            btn_LoadStudPhoto.Text = "LoadPhoto";
            btn_LoadStudPhoto.UseVisualStyleBackColor = true;
            btn_LoadStudPhoto.Click += btn_LoadPhoto_Click;
            // 
            // picBox_StudentPhoto
            // 
            picBox_StudentPhoto.BorderStyle = BorderStyle.FixedSingle;
            picBox_StudentPhoto.Image = (Image)resources.GetObject("picBox_StudentPhoto.Image");
            picBox_StudentPhoto.Location = new Point(6, 222);
            picBox_StudentPhoto.Name = "picBox_StudentPhoto";
            picBox_StudentPhoto.Size = new Size(218, 187);
            picBox_StudentPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox_StudentPhoto.TabIndex = 13;
            picBox_StudentPhoto.TabStop = false;
            // 
            // lbl_University
            // 
            lbl_University.Font = new Font("Lucida Fax", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_University.ForeColor = SystemColors.ButtonFace;
            lbl_University.Location = new Point(188, 22);
            lbl_University.Name = "lbl_University";
            lbl_University.Size = new Size(482, 84);
            lbl_University.TabIndex = 12;
            lbl_University.Text = "\"Fakultet informacijskih tehnologija\r\nUniverzitet „Džemal Bijedić“ - Mostaru";
            lbl_University.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_CreateStudent
            // 
            btn_CreateStudent.BackColor = Color.DimGray;
            btn_CreateStudent.FlatStyle = FlatStyle.Flat;
            btn_CreateStudent.ForeColor = Color.White;
            btn_CreateStudent.Location = new Point(496, 550);
            btn_CreateStudent.Name = "btn_CreateStudent";
            btn_CreateStudent.Size = new Size(151, 23);
            btn_CreateStudent.TabIndex = 11;
            btn_CreateStudent.Text = "Create Profile";
            btn_CreateStudent.UseVisualStyleBackColor = false;
            btn_CreateStudent.Click += btn_CreateStudent_Click;
            // 
            // groupBox_LoginInfo
            // 
            groupBox_LoginInfo.Controls.Add(checkBox_Revised);
            groupBox_LoginInfo.Controls.Add(checkBox_EnterCustomEmail);
            groupBox_LoginInfo.Controls.Add(label2);
            groupBox_LoginInfo.Controls.Add(lbl_Email);
            groupBox_LoginInfo.Controls.Add(lbl_Index);
            groupBox_LoginInfo.Controls.Add(txtBox_StudentPassword);
            groupBox_LoginInfo.Controls.Add(txtBox_StudentEmail);
            groupBox_LoginInfo.Controls.Add(txtBox_Index);
            groupBox_LoginInfo.ForeColor = SystemColors.ButtonFace;
            groupBox_LoginInfo.Location = new Point(230, 293);
            groupBox_LoginInfo.Name = "groupBox_LoginInfo";
            groupBox_LoginInfo.Size = new Size(416, 144);
            groupBox_LoginInfo.TabIndex = 10;
            groupBox_LoginInfo.TabStop = false;
            groupBox_LoginInfo.Text = "Login Info";
            // 
            // checkBox_Revised
            // 
            checkBox_Revised.AutoSize = true;
            checkBox_Revised.Location = new Point(79, 119);
            checkBox_Revised.Name = "checkBox_Revised";
            checkBox_Revised.Size = new Size(100, 19);
            checkBox_Revised.TabIndex = 14;
            checkBox_Revised.Text = "Revising Year?";
            checkBox_Revised.UseVisualStyleBackColor = true;
            // 
            // checkBox_EnterCustomEmail
            // 
            checkBox_EnterCustomEmail.AutoSize = true;
            checkBox_EnterCustomEmail.Location = new Point(280, 64);
            checkBox_EnterCustomEmail.Name = "checkBox_EnterCustomEmail";
            checkBox_EnterCustomEmail.Size = new Size(130, 19);
            checkBox_EnterCustomEmail.TabIndex = 13;
            checkBox_EnterCustomEmail.Text = "Enter Custom Email";
            checkBox_EnterCustomEmail.UseVisualStyleBackColor = true;
            checkBox_EnterCustomEmail.CheckedChanged += checkBox_EnterCustomEmail_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 93);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 12;
            label2.Text = "Password:";
            // 
            // lbl_Email
            // 
            lbl_Email.AutoSize = true;
            lbl_Email.Location = new Point(34, 64);
            lbl_Email.Name = "lbl_Email";
            lbl_Email.Size = new Size(39, 15);
            lbl_Email.TabIndex = 11;
            lbl_Email.Text = "Email:";
            // 
            // lbl_Index
            // 
            lbl_Index.AutoSize = true;
            lbl_Index.Location = new Point(34, 35);
            lbl_Index.Name = "lbl_Index";
            lbl_Index.Size = new Size(39, 15);
            lbl_Index.TabIndex = 8;
            lbl_Index.Text = "Index:";
            // 
            // txtBox_StudentPassword
            // 
            txtBox_StudentPassword.Location = new Point(79, 90);
            txtBox_StudentPassword.Name = "txtBox_StudentPassword";
            txtBox_StudentPassword.PasswordChar = '*';
            txtBox_StudentPassword.Size = new Size(302, 23);
            txtBox_StudentPassword.TabIndex = 10;
            // 
            // txtBox_StudentEmail
            // 
            txtBox_StudentEmail.Location = new Point(79, 61);
            txtBox_StudentEmail.Name = "txtBox_StudentEmail";
            txtBox_StudentEmail.ReadOnly = true;
            txtBox_StudentEmail.Size = new Size(195, 23);
            txtBox_StudentEmail.TabIndex = 9;
            // 
            // txtBox_Index
            // 
            txtBox_Index.Location = new Point(79, 32);
            txtBox_Index.Name = "txtBox_Index";
            txtBox_Index.Size = new Size(302, 23);
            txtBox_Index.TabIndex = 8;
            // 
            // groupBox_StudentData
            // 
            groupBox_StudentData.Controls.Add(lbl_StudyYear);
            groupBox_StudentData.Controls.Add(comboBox_StudyYear);
            groupBox_StudentData.Controls.Add(lbl_Birthdate);
            groupBox_StudentData.Controls.Add(dtTimePicker_Birthdate);
            groupBox_StudentData.Controls.Add(lbl_Surname);
            groupBox_StudentData.Controls.Add(lbl_Name);
            groupBox_StudentData.Controls.Add(txtBox_StudentSurname);
            groupBox_StudentData.Controls.Add(txtBox_StudentName);
            groupBox_StudentData.ForeColor = SystemColors.ButtonHighlight;
            groupBox_StudentData.Location = new Point(230, 109);
            groupBox_StudentData.Name = "groupBox_StudentData";
            groupBox_StudentData.Size = new Size(416, 178);
            groupBox_StudentData.TabIndex = 9;
            groupBox_StudentData.TabStop = false;
            groupBox_StudentData.Text = "Student Data";
            // 
            // lbl_StudyYear
            // 
            lbl_StudyYear.AutoSize = true;
            lbl_StudyYear.Location = new Point(8, 139);
            lbl_StudyYear.Name = "lbl_StudyYear";
            lbl_StudyYear.Size = new Size(65, 15);
            lbl_StudyYear.TabIndex = 7;
            lbl_StudyYear.Text = "Study Year:";
            // 
            // comboBox_StudyYear
            // 
            comboBox_StudyYear.AccessibleName = "";
            comboBox_StudyYear.FormattingEnabled = true;
            comboBox_StudyYear.Location = new Point(79, 136);
            comboBox_StudyYear.Name = "comboBox_StudyYear";
            comboBox_StudyYear.Size = new Size(155, 23);
            comboBox_StudyYear.TabIndex = 6;
            // 
            // lbl_Birthdate
            // 
            lbl_Birthdate.AutoSize = true;
            lbl_Birthdate.Location = new Point(15, 113);
            lbl_Birthdate.Name = "lbl_Birthdate";
            lbl_Birthdate.Size = new Size(58, 15);
            lbl_Birthdate.TabIndex = 5;
            lbl_Birthdate.Text = "Birthdate:";
            // 
            // dtTimePicker_Birthdate
            // 
            dtTimePicker_Birthdate.AccessibleName = "dtTimePicker_StudentBirthdate";
            dtTimePicker_Birthdate.Location = new Point(79, 107);
            dtTimePicker_Birthdate.Name = "dtTimePicker_Birthdate";
            dtTimePicker_Birthdate.Size = new Size(302, 23);
            dtTimePicker_Birthdate.TabIndex = 4;
            // 
            // lbl_Surname
            // 
            lbl_Surname.AutoSize = true;
            lbl_Surname.Location = new Point(16, 81);
            lbl_Surname.Name = "lbl_Surname";
            lbl_Surname.Size = new Size(57, 15);
            lbl_Surname.TabIndex = 3;
            lbl_Surname.Text = "Surname:";
            // 
            // lbl_Name
            // 
            lbl_Name.AutoSize = true;
            lbl_Name.Location = new Point(28, 52);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(45, 15);
            lbl_Name.TabIndex = 2;
            lbl_Name.Text = "Name: ";
            // 
            // txtBox_StudentSurname
            // 
            txtBox_StudentSurname.AccessibleName = "txtBox_StudentSurname";
            txtBox_StudentSurname.Location = new Point(79, 78);
            txtBox_StudentSurname.Name = "txtBox_StudentSurname";
            txtBox_StudentSurname.Size = new Size(302, 23);
            txtBox_StudentSurname.TabIndex = 1;
            txtBox_StudentSurname.TextChanged += txtBox_StudentSurname_TextChanged;
            // 
            // txtBox_StudentName
            // 
            txtBox_StudentName.AccessibleName = "txtBox_StudentName";
            txtBox_StudentName.Location = new Point(79, 49);
            txtBox_StudentName.Name = "txtBox_StudentName";
            txtBox_StudentName.Size = new Size(302, 23);
            txtBox_StudentName.TabIndex = 0;
            txtBox_StudentName.TextChanged += txtBox_StudentName_TextChanged;
            // 
            // pictureBox_fitLogo
            // 
            pictureBox_fitLogo.Image = (Image)resources.GetObject("pictureBox_fitLogo.Image");
            pictureBox_fitLogo.Location = new Point(6, 22);
            pictureBox_fitLogo.Name = "pictureBox_fitLogo";
            pictureBox_fitLogo.Size = new Size(176, 149);
            pictureBox_fitLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_fitLogo.TabIndex = 8;
            pictureBox_fitLogo.TabStop = false;
            // 
            // err_StudentEmailFormat
            // 
            err_StudentEmailFormat.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            err_StudentEmailFormat.ContainerControl = this;
            // 
            // err_StudentPasswordFormat
            // 
            err_StudentPasswordFormat.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            err_StudentPasswordFormat.ContainerControl = this;
            // 
            // openFileDialog_SetStudentPhoto
            // 
            openFileDialog_SetStudentPhoto.FileName = "openFileDialog1";
            // 
            // UC_AddStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(groupBox1);
            Name = "UC_AddStudent";
            Size = new Size(687, 606);
            Load += UC_AddStudent_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBox_StudentPhoto).EndInit();
            groupBox_LoginInfo.ResumeLayout(false);
            groupBox_LoginInfo.PerformLayout();
            groupBox_StudentData.ResumeLayout(false);
            groupBox_StudentData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_fitLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)err_StudentEmailFormat).EndInit();
            ((System.ComponentModel.ISupportInitialize)err_StudentPasswordFormat).EndInit();
            ResumeLayout(false);
        }

        #endregion

        internal GroupBox groupBox1;
        internal Label lbl_SeperatorLine;
        internal Button btn_LoadStudPhoto;
        internal PictureBox picBox_StudentPhoto;
        internal Label lbl_University;
        internal Button btn_CreateStudent;
        internal GroupBox groupBox_LoginInfo;
        internal CheckBox checkBox_Revised;
        internal CheckBox checkBox_EnterCustomEmail;
        internal Label label2;
        internal Label lbl_Email;
        internal Label lbl_Index;
        internal TextBox txtBox_StudentPassword;
        internal TextBox txtBox_StudentEmail;
        internal TextBox txtBox_Index;
        internal GroupBox groupBox_StudentData;
        internal Label lbl_StudyYear;
        internal ComboBox comboBox_StudyYear;
        internal Label lbl_Birthdate;
        internal DateTimePicker dtTimePicker_Birthdate;
        internal Label lbl_Surname;
        internal Label lbl_Name;
        internal TextBox txtBox_StudentSurname;
        internal TextBox txtBox_StudentName;
        internal PictureBox pictureBox_fitLogo;
        internal ErrorProvider err_StudentEmailFormat;
        internal ErrorProvider err_StudentPasswordFormat;
        internal OpenFileDialog openFileDialog_SetStudentPhoto;
    }
}
