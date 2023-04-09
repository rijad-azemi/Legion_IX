namespace Legion_IX.User_Controls.StudentService_UC_s
{
    partial class UC_StudentService_ADMIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_StudentService_ADMIN));
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
            openFileDialog_SetStudentPhoto = new OpenFileDialog();
            openFileDialog_SetProffPhoto = new OpenFileDialog();
            err_EmailFormat = new ErrorProvider(components);
            err_PasswordFormat = new ErrorProvider(components);
            pictureBox2 = new PictureBox();
            groupBox4 = new GroupBox();
            btn_AssignProfSubjects = new Button();
            label8 = new Label();
            dtTimePicker_ProffBirthdate = new DateTimePicker();
            label9 = new Label();
            label10 = new Label();
            txtBox_ProffSurname = new TextBox();
            txtBox_ProffName = new TextBox();
            groupBox3 = new GroupBox();
            checkBox_CustomProffEmail = new CheckBox();
            label4 = new Label();
            label5 = new Label();
            txtBox_ProffPassword = new TextBox();
            txtBox_ProffEmail = new TextBox();
            btn_CreateProffesor = new Button();
            label3 = new Label();
            picBox_ProffPhoto = new PictureBox();
            btn_LoadProffPhoto = new Button();
            label1 = new Label();
            groupBox2 = new GroupBox();
            professorsSubjects1 = new ProfessorsSubjects();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBox_StudentPhoto).BeginInit();
            groupBox_LoginInfo.SuspendLayout();
            groupBox_StudentData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_fitLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err_EmailFormat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err_PasswordFormat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBox_ProffPhoto).BeginInit();
            groupBox2.SuspendLayout();
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
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(653, 478);
            groupBox1.TabIndex = 0;
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
            // 
            // picBox_StudentPhoto
            // 
            picBox_StudentPhoto.BorderStyle = BorderStyle.FixedSingle;
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
            lbl_University.ForeColor = SystemColors.ActiveCaptionText;
            lbl_University.Location = new Point(188, 22);
            lbl_University.Name = "lbl_University";
            lbl_University.Size = new Size(482, 84);
            lbl_University.TabIndex = 12;
            lbl_University.Text = "\"Fakultet informacijskih tehnologija\r\nUniverzitet „Džemal Bijedić“ - Mostaru";
            lbl_University.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_CreateStudent
            // 
            btn_CreateStudent.Location = new Point(495, 444);
            btn_CreateStudent.Name = "btn_CreateStudent";
            btn_CreateStudent.Size = new Size(151, 23);
            btn_CreateStudent.TabIndex = 11;
            btn_CreateStudent.Text = "Create Profile";
            btn_CreateStudent.UseVisualStyleBackColor = true;
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
            comboBox_StudyYear.Text = "- - - - - - - - - - - - - - - - - - - -";
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
            // 
            // txtBox_StudentName
            // 
            txtBox_StudentName.AccessibleName = "txtBox_StudentName";
            txtBox_StudentName.Location = new Point(79, 49);
            txtBox_StudentName.Name = "txtBox_StudentName";
            txtBox_StudentName.Size = new Size(302, 23);
            txtBox_StudentName.TabIndex = 0;
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
            // openFileDialog_SetStudentPhoto
            // 
            openFileDialog_SetStudentPhoto.FileName = "openFileDialog1";
            // 
            // openFileDialog_SetProffPhoto
            // 
            openFileDialog_SetProffPhoto.FileName = "openFileDialog1";
            // 
            // err_EmailFormat
            // 
            err_EmailFormat.ContainerControl = this;
            // 
            // err_PasswordFormat
            // 
            err_PasswordFormat.ContainerControl = this;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(6, 22);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(176, 149);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btn_AssignProfSubjects);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(dtTimePicker_ProffBirthdate);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(txtBox_ProffSurname);
            groupBox4.Controls.Add(txtBox_ProffName);
            groupBox4.ForeColor = SystemColors.ButtonHighlight;
            groupBox4.Location = new Point(230, 109);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(416, 178);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Proffesor Data";
            // 
            // btn_AssignProfSubjects
            // 
            btn_AssignProfSubjects.AutoSize = true;
            btn_AssignProfSubjects.BackColor = Color.DimGray;
            btn_AssignProfSubjects.FlatAppearance.BorderSize = 0;
            btn_AssignProfSubjects.FlatStyle = FlatStyle.Flat;
            btn_AssignProfSubjects.ForeColor = SystemColors.ButtonFace;
            btn_AssignProfSubjects.Location = new Point(293, 139);
            btn_AssignProfSubjects.Name = "btn_AssignProfSubjects";
            btn_AssignProfSubjects.Size = new Size(99, 25);
            btn_AssignProfSubjects.TabIndex = 19;
            btn_AssignProfSubjects.Text = "Assign Subjects";
            btn_AssignProfSubjects.UseVisualStyleBackColor = false;
            btn_AssignProfSubjects.Click += btn_AssignProfSubjects_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 113);
            label8.Name = "label8";
            label8.Size = new Size(58, 15);
            label8.TabIndex = 5;
            label8.Text = "Birthdate:";
            // 
            // dtTimePicker_ProffBirthdate
            // 
            dtTimePicker_ProffBirthdate.AccessibleName = "dtTimePicker_Birthdate";
            dtTimePicker_ProffBirthdate.Location = new Point(79, 107);
            dtTimePicker_ProffBirthdate.Name = "dtTimePicker_ProffBirthdate";
            dtTimePicker_ProffBirthdate.Size = new Size(302, 23);
            dtTimePicker_ProffBirthdate.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(16, 81);
            label9.Name = "label9";
            label9.Size = new Size(57, 15);
            label9.TabIndex = 3;
            label9.Text = "Surname:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(28, 52);
            label10.Name = "label10";
            label10.Size = new Size(45, 15);
            label10.TabIndex = 2;
            label10.Text = "Name: ";
            // 
            // txtBox_ProffSurname
            // 
            txtBox_ProffSurname.AccessibleName = "txtBox_Surname";
            txtBox_ProffSurname.Location = new Point(79, 78);
            txtBox_ProffSurname.Name = "txtBox_ProffSurname";
            txtBox_ProffSurname.Size = new Size(302, 23);
            txtBox_ProffSurname.TabIndex = 1;
            txtBox_ProffSurname.TextChanged += txtBox_ProffSurname_TextChanged;
            // 
            // txtBox_ProffName
            // 
            txtBox_ProffName.AccessibleName = "txtBox_Name";
            txtBox_ProffName.Location = new Point(79, 49);
            txtBox_ProffName.Name = "txtBox_ProffName";
            txtBox_ProffName.Size = new Size(302, 23);
            txtBox_ProffName.TabIndex = 0;
            txtBox_ProffName.TextChanged += txtBox_ProffName_TextChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBox_CustomProffEmail);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(txtBox_ProffPassword);
            groupBox3.Controls.Add(txtBox_ProffEmail);
            groupBox3.ForeColor = SystemColors.ButtonFace;
            groupBox3.Location = new Point(230, 293);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(416, 144);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Login Info";
            // 
            // checkBox_CustomProffEmail
            // 
            checkBox_CustomProffEmail.AutoSize = true;
            checkBox_CustomProffEmail.Location = new Point(280, 64);
            checkBox_CustomProffEmail.Name = "checkBox_CustomProffEmail";
            checkBox_CustomProffEmail.Size = new Size(130, 19);
            checkBox_CustomProffEmail.TabIndex = 13;
            checkBox_CustomProffEmail.Text = "Enter Custom Email";
            checkBox_CustomProffEmail.UseVisualStyleBackColor = true;
            checkBox_CustomProffEmail.CheckedChanged += checkBox_CustomProffEmail_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(13, 93);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 12;
            label4.Text = "Password:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(34, 64);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 11;
            label5.Text = "Email:";
            // 
            // txtBox_ProffPassword
            // 
            txtBox_ProffPassword.Location = new Point(79, 90);
            txtBox_ProffPassword.Name = "txtBox_ProffPassword";
            txtBox_ProffPassword.PasswordChar = '*';
            txtBox_ProffPassword.Size = new Size(302, 23);
            txtBox_ProffPassword.TabIndex = 10;
            // 
            // txtBox_ProffEmail
            // 
            txtBox_ProffEmail.Location = new Point(79, 61);
            txtBox_ProffEmail.Name = "txtBox_ProffEmail";
            txtBox_ProffEmail.ReadOnly = true;
            txtBox_ProffEmail.Size = new Size(195, 23);
            txtBox_ProffEmail.TabIndex = 9;
            // 
            // btn_CreateProffesor
            // 
            btn_CreateProffesor.Location = new Point(495, 444);
            btn_CreateProffesor.Name = "btn_CreateProffesor";
            btn_CreateProffesor.Size = new Size(151, 23);
            btn_CreateProffesor.TabIndex = 11;
            btn_CreateProffesor.Text = "Create Profile";
            btn_CreateProffesor.UseVisualStyleBackColor = true;
            btn_CreateProffesor.Click += btn_CreateProffesor_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Lucida Fax", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(188, 22);
            label3.Name = "label3";
            label3.Size = new Size(482, 84);
            label3.TabIndex = 12;
            label3.Text = "\"Fakultet informacijskih tehnologija\r\nUniverzitet „Džemal Bijedić“ - Mostaru";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picBox_ProffPhoto
            // 
            picBox_ProffPhoto.BorderStyle = BorderStyle.FixedSingle;
            picBox_ProffPhoto.Location = new Point(6, 222);
            picBox_ProffPhoto.Name = "picBox_ProffPhoto";
            picBox_ProffPhoto.Size = new Size(218, 187);
            picBox_ProffPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox_ProffPhoto.TabIndex = 13;
            picBox_ProffPhoto.TabStop = false;
            // 
            // btn_LoadProffPhoto
            // 
            btn_LoadProffPhoto.Location = new Point(38, 414);
            btn_LoadProffPhoto.Name = "btn_LoadProffPhoto";
            btn_LoadProffPhoto.Size = new Size(151, 23);
            btn_LoadProffPhoto.TabIndex = 14;
            btn_LoadProffPhoto.Text = "LoadPhoto";
            btn_LoadProffPhoto.UseVisualStyleBackColor = true;
            btn_LoadProffPhoto.Click += btn_LoadProffPhoto_Click;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(200, 19);
            label1.Name = "label1";
            label1.Size = new Size(2, 168);
            label1.TabIndex = 15;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(btn_LoadProffPhoto);
            groupBox2.Controls.Add(picBox_ProffPhoto);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(btn_CreateProffesor);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(pictureBox2);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.ForeColor = Color.FromArgb(192, 0, 0);
            groupBox2.Location = new Point(761, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(653, 478);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Add Proffesor";
            // 
            // professorsSubjects1
            // 
            professorsSubjects1.BackColor = Color.Black;
            professorsSubjects1.BackgroundImage = (Image)resources.GetObject("professorsSubjects1.BackgroundImage");
            professorsSubjects1.BackgroundImageLayout = ImageLayout.Center;
            professorsSubjects1.BorderStyle = BorderStyle.FixedSingle;
            professorsSubjects1.Location = new Point(526, 116);
            professorsSubjects1.Name = "professorsSubjects1";
            professorsSubjects1.Size = new Size(1018, 426);
            professorsSubjects1.TabIndex = 2;
            // 
            // UC_StudentService_ADMIN
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(professorsSubjects1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "UC_StudentService_ADMIN";
            Size = new Size(1425, 584);
            Load += StudentService_ADMIN_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBox_StudentPhoto).EndInit();
            groupBox_LoginInfo.ResumeLayout(false);
            groupBox_LoginInfo.PerformLayout();
            groupBox_StudentData.ResumeLayout(false);
            groupBox_StudentData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_fitLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)err_EmailFormat).EndInit();
            ((System.ComponentModel.ISupportInitialize)err_PasswordFormat).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBox_ProffPhoto).EndInit();
            groupBox2.ResumeLayout(false);
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
        internal OpenFileDialog openFileDialog_SetStudentPhoto;
        internal OpenFileDialog openFileDialog_SetProffPhoto;
        internal ErrorProvider err_EmailFormat;
        internal ErrorProvider err_PasswordFormat;
        internal GroupBox groupBox2;
        internal Label label1;
        internal Button btn_LoadProffPhoto;
        internal PictureBox picBox_ProffPhoto;
        internal Label label3;
        internal Button btn_CreateProffesor;
        internal GroupBox groupBox3;
        internal CheckBox checkBox_CustomProffEmail;
        internal Label label4;
        internal Label label5;
        internal TextBox txtBox_ProffPassword;
        internal TextBox txtBox_ProffEmail;
        internal GroupBox groupBox4;
        private Button btn_AssignProfSubjects;
        internal Label label8;
        internal DateTimePicker dtTimePicker_ProffBirthdate;
        internal Label label9;
        internal Label label10;
        internal TextBox txtBox_ProffSurname;
        internal TextBox txtBox_ProffName;
        internal PictureBox pictureBox2;
        internal ProfessorsSubjects professorsSubjects1;
    }
}
