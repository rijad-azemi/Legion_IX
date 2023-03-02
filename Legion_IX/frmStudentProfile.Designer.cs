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
            lbl_Index = new Label();
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
            lbl_Birthdate.Location = new Point(275, 103);
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
            lbl_StudyYear.Location = new Point(247, 148);
            lbl_StudyYear.Name = "lbl_StudyYear";
            lbl_StudyYear.Size = new Size(104, 21);
            lbl_StudyYear.TabIndex = 4;
            lbl_StudyYear.Text = "Year of Study:";
            // 
            // groupBox_StudentInfo
            // 
            groupBox_StudentInfo.BackColor = Color.Transparent;
            groupBox_StudentInfo.Controls.Add(lbl_Index);
            groupBox_StudentInfo.Controls.Add(picBox_StudentPhoto);
            groupBox_StudentInfo.Controls.Add(lbl_StudyYear);
            groupBox_StudentInfo.Controls.Add(lbl_Name);
            groupBox_StudentInfo.Controls.Add(lbl_Birthdate);
            groupBox_StudentInfo.Controls.Add(lbl_Surname);
            groupBox_StudentInfo.ForeColor = SystemColors.ButtonFace;
            groupBox_StudentInfo.Location = new Point(112, 12);
            groupBox_StudentInfo.Name = "groupBox_StudentInfo";
            groupBox_StudentInfo.Size = new Size(598, 303);
            groupBox_StudentInfo.TabIndex = 5;
            groupBox_StudentInfo.TabStop = false;
            groupBox_StudentInfo.Text = "Student Information";
            // 
            // lbl_Index
            // 
            lbl_Index.AutoSize = true;
            lbl_Index.BackColor = Color.Transparent;
            lbl_Index.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_Index.ForeColor = SystemColors.ButtonFace;
            lbl_Index.Location = new Point(296, 186);
            lbl_Index.Name = "lbl_Index";
            lbl_Index.Size = new Size(50, 21);
            lbl_Index.TabIndex = 5;
            lbl_Index.Text = "Index:";
            // 
            // frmStudentProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(996, 534);
            Controls.Add(groupBox_StudentInfo);
            Name = "frmStudentProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmStudentProfile";
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
    }
}