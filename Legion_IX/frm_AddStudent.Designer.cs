namespace Legion_IX
{
    partial class frm_AddStudent
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddStudent));
            pictureBox_fitLogo = new PictureBox();
            groupBox_StudentData = new GroupBox();
            lbl_StudyYear = new Label();
            comboBox_StudyYear = new ComboBox();
            lbl_Birthdate = new Label();
            dtTimePicker_Birthdate = new DateTimePicker();
            lbl_Surname = new Label();
            lbl_Name = new Label();
            txtBox_Surname = new TextBox();
            txtBox_Name = new TextBox();
            groupBox_LoginInfo = new GroupBox();
            checkBox_EnterCustomEmail = new CheckBox();
            label2 = new Label();
            lbl_Email = new Label();
            lbl_Index = new Label();
            textBox_Password = new TextBox();
            txtBox_Email = new TextBox();
            txtBox_Index = new TextBox();
            btn_CreateStudent = new Button();
            lbl_University = new Label();
            pictureBox_StudentPhoto = new PictureBox();
            btn_LoadPhoto = new Button();
            lbl_SeperatorLine = new Label();
            err_EmailFormat = new ErrorProvider(components);
            openFileDialog_SetPhoto = new OpenFileDialog();
            err_PasswordFormat = new ErrorProvider(components);
            checkBox_Revised = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_fitLogo).BeginInit();
            groupBox_StudentData.SuspendLayout();
            groupBox_LoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_StudentPhoto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err_EmailFormat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err_PasswordFormat).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_fitLogo
            // 
            pictureBox_fitLogo.Image = (Image)resources.GetObject("pictureBox_fitLogo.Image");
            pictureBox_fitLogo.Location = new Point(12, 12);
            pictureBox_fitLogo.Name = "pictureBox_fitLogo";
            pictureBox_fitLogo.Size = new Size(176, 149);
            pictureBox_fitLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_fitLogo.TabIndex = 0;
            pictureBox_fitLogo.TabStop = false;
            // 
            // groupBox_StudentData
            // 
            groupBox_StudentData.Controls.Add(lbl_StudyYear);
            groupBox_StudentData.Controls.Add(comboBox_StudyYear);
            groupBox_StudentData.Controls.Add(lbl_Birthdate);
            groupBox_StudentData.Controls.Add(dtTimePicker_Birthdate);
            groupBox_StudentData.Controls.Add(lbl_Surname);
            groupBox_StudentData.Controls.Add(lbl_Name);
            groupBox_StudentData.Controls.Add(txtBox_Surname);
            groupBox_StudentData.Controls.Add(txtBox_Name);
            groupBox_StudentData.Location = new Point(236, 99);
            groupBox_StudentData.Name = "groupBox_StudentData";
            groupBox_StudentData.Size = new Size(416, 178);
            groupBox_StudentData.TabIndex = 1;
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
            dtTimePicker_Birthdate.AccessibleName = "dtTimePicker_Birthdate";
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
            // txtBox_Surname
            // 
            txtBox_Surname.AccessibleName = "txtBox_Surname";
            txtBox_Surname.Location = new Point(79, 78);
            txtBox_Surname.Name = "txtBox_Surname";
            txtBox_Surname.Size = new Size(302, 23);
            txtBox_Surname.TabIndex = 1;
            txtBox_Surname.TextChanged += txtBox_Surname_TextChanged;
            // 
            // txtBox_Name
            // 
            txtBox_Name.AccessibleName = "txtBox_Name";
            txtBox_Name.Location = new Point(79, 49);
            txtBox_Name.Name = "txtBox_Name";
            txtBox_Name.Size = new Size(302, 23);
            txtBox_Name.TabIndex = 0;
            txtBox_Name.TextChanged += txtBox_Name_TextChanged;
            // 
            // groupBox_LoginInfo
            // 
            groupBox_LoginInfo.Controls.Add(checkBox_Revised);
            groupBox_LoginInfo.Controls.Add(checkBox_EnterCustomEmail);
            groupBox_LoginInfo.Controls.Add(label2);
            groupBox_LoginInfo.Controls.Add(lbl_Email);
            groupBox_LoginInfo.Controls.Add(lbl_Index);
            groupBox_LoginInfo.Controls.Add(textBox_Password);
            groupBox_LoginInfo.Controls.Add(txtBox_Email);
            groupBox_LoginInfo.Controls.Add(txtBox_Index);
            groupBox_LoginInfo.Location = new Point(236, 283);
            groupBox_LoginInfo.Name = "groupBox_LoginInfo";
            groupBox_LoginInfo.Size = new Size(416, 144);
            groupBox_LoginInfo.TabIndex = 2;
            groupBox_LoginInfo.TabStop = false;
            groupBox_LoginInfo.Text = "Login Info";
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
            // textBox_Password
            // 
            textBox_Password.Location = new Point(79, 90);
            textBox_Password.Name = "textBox_Password";
            textBox_Password.Size = new Size(302, 23);
            textBox_Password.TabIndex = 10;
            // 
            // txtBox_Email
            // 
            txtBox_Email.Location = new Point(79, 61);
            txtBox_Email.Name = "txtBox_Email";
            txtBox_Email.ReadOnly = true;
            txtBox_Email.Size = new Size(195, 23);
            txtBox_Email.TabIndex = 9;
            // 
            // txtBox_Index
            // 
            txtBox_Index.Location = new Point(79, 32);
            txtBox_Index.Name = "txtBox_Index";
            txtBox_Index.ReadOnly = false;
            txtBox_Index.Size = new Size(302, 23);
            txtBox_Index.TabIndex = 8;
            // 
            // btn_CreateStudent
            // 
            btn_CreateStudent.Location = new Point(501, 434);
            btn_CreateStudent.Name = "btn_CreateStudent";
            btn_CreateStudent.Size = new Size(151, 23);
            btn_CreateStudent.TabIndex = 3;
            btn_CreateStudent.Text = "Create Profile";
            btn_CreateStudent.UseVisualStyleBackColor = true;
            btn_CreateStudent.Click += btn_CreateStudent_Click;
            // 
            // lbl_University
            // 
            lbl_University.Font = new Font("Lucida Fax", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_University.Location = new Point(194, 12);
            lbl_University.Name = "lbl_University";
            lbl_University.Size = new Size(482, 84);
            lbl_University.TabIndex = 4;
            lbl_University.Text = "\"Fakultet informacijskih tehnologija\r\nUniverzitet „Džemal Bijedić“ - Mostaru";
            lbl_University.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox_StudentPhoto
            // 
            pictureBox_StudentPhoto.BorderStyle = BorderStyle.FixedSingle;
            pictureBox_StudentPhoto.Location = new Point(12, 212);
            pictureBox_StudentPhoto.Name = "pictureBox_StudentPhoto";
            pictureBox_StudentPhoto.Size = new Size(218, 187);
            pictureBox_StudentPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_StudentPhoto.TabIndex = 5;
            pictureBox_StudentPhoto.TabStop = false;
            // 
            // btn_LoadPhoto
            // 
            btn_LoadPhoto.Location = new Point(44, 404);
            btn_LoadPhoto.Name = "btn_LoadPhoto";
            btn_LoadPhoto.Size = new Size(151, 23);
            btn_LoadPhoto.TabIndex = 6;
            btn_LoadPhoto.Text = "LoadPhoto";
            btn_LoadPhoto.UseVisualStyleBackColor = true;
            btn_LoadPhoto.Click += btn_LoadPhoto_Click;
            // 
            // lbl_SeperatorLine
            // 
            lbl_SeperatorLine.BackColor = SystemColors.ActiveCaptionText;
            lbl_SeperatorLine.Location = new Point(206, 9);
            lbl_SeperatorLine.Name = "lbl_SeperatorLine";
            lbl_SeperatorLine.Size = new Size(2, 168);
            lbl_SeperatorLine.TabIndex = 7;
            // 
            // err_EmailFormat
            // 
            err_EmailFormat.ContainerControl = this;
            // 
            // openFileDialog_SetPhoto
            // 
            openFileDialog_SetPhoto.FileName = "openFileDialog1";
            // 
            // err_PasswordFormat
            // 
            err_PasswordFormat.ContainerControl = this;
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
            // frm_AddStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 469);
            Controls.Add(lbl_SeperatorLine);
            Controls.Add(btn_LoadPhoto);
            Controls.Add(pictureBox_StudentPhoto);
            Controls.Add(lbl_University);
            Controls.Add(btn_CreateStudent);
            Controls.Add(groupBox_LoginInfo);
            Controls.Add(groupBox_StudentData);
            Controls.Add(pictureBox_fitLogo);
            Name = "frm_AddStudent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Student";
            Load += frm_AddStudent_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox_fitLogo).EndInit();
            groupBox_StudentData.ResumeLayout(false);
            groupBox_StudentData.PerformLayout();
            groupBox_LoginInfo.ResumeLayout(false);
            groupBox_LoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_StudentPhoto).EndInit();
            ((System.ComponentModel.ISupportInitialize)err_EmailFormat).EndInit();
            ((System.ComponentModel.ISupportInitialize)err_PasswordFormat).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_fitLogo;
        private GroupBox groupBox_StudentData;
        private Label lbl_Name;
        private TextBox txtBox_Surname;
        private TextBox txtBox_Name;
        private Label lbl_Surname;
        private Label lbl_Birthdate;
        private DateTimePicker dtTimePicker_Birthdate;
        private ComboBox comboBox_StudyYear;
        private Label lbl_StudyYear;
        private GroupBox groupBox_LoginInfo;
        private TextBox textBox_Password;
        private TextBox txtBox_Email;
        private TextBox txtBox_Index;
        private Button btn_CreateStudent;
        private Label lbl_University;
        private PictureBox pictureBox_StudentPhoto;
        private Button btn_LoadPhoto;
        private Label lbl_SeperatorLine;
        private Label lbl_Index;
        private Label label2;
        private Label lbl_Email;
        private ErrorProvider err_EmailFormat;
        private CheckBox checkBox_EnterCustomEmail;
        private OpenFileDialog openFileDialog_SetPhoto;
        private ErrorProvider err_PasswordFormat;
        private CheckBox checkBox_Revised;
    }
}