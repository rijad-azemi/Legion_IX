namespace Legion_IX.User_Controls.StudentService_UC_s
{
    partial class UC_AddProfessor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_AddProfessor));
            groupBox2 = new GroupBox();
            label1 = new Label();
            btn_LoadProffPhoto = new Button();
            picBox_ProffPhoto = new PictureBox();
            label3 = new Label();
            btn_CreateProffesor = new Button();
            groupBox3 = new GroupBox();
            checkBox_CustomProffEmail = new CheckBox();
            label4 = new Label();
            label5 = new Label();
            txtBox_ProffPassword = new TextBox();
            txtBox_ProffEmail = new TextBox();
            groupBox4 = new GroupBox();
            label6 = new Label();
            chkListBox_Subjects = new CheckedListBox();
            comboBox_StudyYearProfessor = new ComboBox();
            label8 = new Label();
            dtTimePicker_ProffBirthdate = new DateTimePicker();
            label9 = new Label();
            label10 = new Label();
            txtBox_ProffSurname = new TextBox();
            txtBox_ProffName = new TextBox();
            pictureBox2 = new PictureBox();
            openFileDialog_SetProffPhoto = new OpenFileDialog();
            err_ProfessorEmailFormat = new ErrorProvider(components);
            err_ProfessorPasswordFormat = new ErrorProvider(components);
            err_ProfessorSubjectsNotAssigned = new ErrorProvider(components);
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBox_ProffPhoto).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err_ProfessorEmailFormat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err_ProfessorPasswordFormat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err_ProfessorSubjectsNotAssigned).BeginInit();
            SuspendLayout();
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
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(653, 578);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Add Proffesor";
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(200, 19);
            label1.Name = "label1";
            label1.Size = new Size(2, 168);
            label1.TabIndex = 15;
            // 
            // btn_LoadProffPhoto
            // 
            btn_LoadProffPhoto.Location = new Point(38, 414);
            btn_LoadProffPhoto.Name = "btn_LoadProffPhoto";
            btn_LoadProffPhoto.Size = new Size(151, 23);
            btn_LoadProffPhoto.TabIndex = 14;
            btn_LoadProffPhoto.Text = "LoadPhoto";
            btn_LoadProffPhoto.UseVisualStyleBackColor = true;
            // 
            // picBox_ProffPhoto
            // 
            picBox_ProffPhoto.BorderStyle = BorderStyle.FixedSingle;
            picBox_ProffPhoto.Image = (Image)resources.GetObject("picBox_ProffPhoto.Image");
            picBox_ProffPhoto.Location = new Point(6, 222);
            picBox_ProffPhoto.Name = "picBox_ProffPhoto";
            picBox_ProffPhoto.Size = new Size(218, 187);
            picBox_ProffPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox_ProffPhoto.TabIndex = 13;
            picBox_ProffPhoto.TabStop = false;
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
            // btn_CreateProffesor
            // 
            btn_CreateProffesor.BackColor = Color.DimGray;
            btn_CreateProffesor.FlatStyle = FlatStyle.Flat;
            btn_CreateProffesor.ForeColor = Color.White;
            btn_CreateProffesor.Location = new Point(496, 547);
            btn_CreateProffesor.Name = "btn_CreateProffesor";
            btn_CreateProffesor.Size = new Size(151, 23);
            btn_CreateProffesor.TabIndex = 11;
            btn_CreateProffesor.Text = "Create Profile";
            btn_CreateProffesor.UseVisualStyleBackColor = false;
            btn_CreateProffesor.Click += btn_CreateProffesor_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBox_CustomProffEmail);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(txtBox_ProffPassword);
            groupBox3.Controls.Add(txtBox_ProffEmail);
            groupBox3.ForeColor = SystemColors.ButtonFace;
            groupBox3.Location = new Point(231, 428);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(416, 79);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Login Info";
            // 
            // checkBox_CustomProffEmail
            // 
            checkBox_CustomProffEmail.AutoSize = true;
            checkBox_CustomProffEmail.Location = new Point(279, 25);
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
            label4.Location = new Point(12, 54);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 12;
            label4.Text = "Password:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(33, 25);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 11;
            label5.Text = "Email:";
            // 
            // txtBox_ProffPassword
            // 
            txtBox_ProffPassword.Location = new Point(78, 51);
            txtBox_ProffPassword.Name = "txtBox_ProffPassword";
            txtBox_ProffPassword.PasswordChar = '*';
            txtBox_ProffPassword.Size = new Size(302, 23);
            txtBox_ProffPassword.TabIndex = 10;
            // 
            // txtBox_ProffEmail
            // 
            txtBox_ProffEmail.Location = new Point(78, 22);
            txtBox_ProffEmail.Name = "txtBox_ProffEmail";
            txtBox_ProffEmail.ReadOnly = true;
            txtBox_ProffEmail.Size = new Size(195, 23);
            txtBox_ProffEmail.TabIndex = 9;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(chkListBox_Subjects);
            groupBox4.Controls.Add(comboBox_StudyYearProfessor);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(dtTimePicker_ProffBirthdate);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(txtBox_ProffSurname);
            groupBox4.Controls.Add(txtBox_ProffName);
            groupBox4.ForeColor = SystemColors.ButtonHighlight;
            groupBox4.Location = new Point(230, 109);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(416, 322);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Proffesor Data";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1, 142);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 8;
            label6.Text = "Faculty Year:";
            // 
            // chkListBox_Subjects
            // 
            chkListBox_Subjects.CheckOnClick = true;
            chkListBox_Subjects.FormattingEnabled = true;
            chkListBox_Subjects.Location = new Point(206, 140);
            chkListBox_Subjects.Name = "chkListBox_Subjects";
            chkListBox_Subjects.Size = new Size(176, 184);
            chkListBox_Subjects.TabIndex = 7;
            // 
            // comboBox_StudyYearProfessor
            // 
            comboBox_StudyYearProfessor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_StudyYearProfessor.FormattingEnabled = true;
            comboBox_StudyYearProfessor.Location = new Point(79, 139);
            comboBox_StudyYearProfessor.Name = "comboBox_StudyYearProfessor";
            comboBox_StudyYearProfessor.Size = new Size(121, 23);
            comboBox_StudyYearProfessor.TabIndex = 6;
            comboBox_StudyYearProfessor.SelectedIndexChanged += comboBox_YearForSubjects_SelectedIndexChanged;
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
            // openFileDialog_SetProffPhoto
            // 
            openFileDialog_SetProffPhoto.FileName = "openFileDialog1";
            // 
            // err_ProfessorEmailFormat
            // 
            err_ProfessorEmailFormat.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            err_ProfessorEmailFormat.ContainerControl = this;
            // 
            // err_ProfessorPasswordFormat
            // 
            err_ProfessorPasswordFormat.ContainerControl = this;
            // 
            // err_ProfessorSubjectsNotAssigned
            // 
            err_ProfessorSubjectsNotAssigned.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            err_ProfessorSubjectsNotAssigned.ContainerControl = this;
            // 
            // UC_AddProfessor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(groupBox2);
            Name = "UC_AddProfessor";
            Size = new Size(687, 606);
            Load += UC_AddProfessor_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBox_ProffPhoto).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)err_ProfessorEmailFormat).EndInit();
            ((System.ComponentModel.ISupportInitialize)err_ProfessorPasswordFormat).EndInit();
            ((System.ComponentModel.ISupportInitialize)err_ProfessorSubjectsNotAssigned).EndInit();
            ResumeLayout(false);
        }

        #endregion

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
        internal Label label6;
        private CheckedListBox chkListBox_Subjects;
        private ComboBox comboBox_StudyYearProfessor;
        internal Label label8;
        internal DateTimePicker dtTimePicker_ProffBirthdate;
        internal Label label9;
        internal Label label10;
        internal TextBox txtBox_ProffSurname;
        internal TextBox txtBox_ProffName;
        internal PictureBox pictureBox2;
        internal OpenFileDialog openFileDialog_SetProffPhoto;
        internal ErrorProvider err_ProfessorEmailFormat;
        internal ErrorProvider err_ProfessorPasswordFormat;
        private ErrorProvider err_ProfessorSubjectsNotAssigned;
    }
}
