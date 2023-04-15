namespace Legion_IX.User_Controls.StudentService_UC_s
{
    partial class AssignSubjectsToProfessor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignSubjectsToProfessor));
            dgv_Subjects = new DataGridView();
            comboBox_FacultyYear = new ComboBox();
            lbl_FacultyYear = new Label();
            btn_CloseUC = new Button();
            btn_AssignSubjects = new Button();
            Subject = new DataGridViewTextBoxColumn();
            GiveSubjects = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_Subjects).BeginInit();
            SuspendLayout();
            // 
            // dgv_Subjects
            // 
            dgv_Subjects.AllowUserToAddRows = false;
            dgv_Subjects.AllowUserToDeleteRows = false;
            dgv_Subjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Subjects.Columns.AddRange(new DataGridViewColumn[] { Subject, GiveSubjects });
            dgv_Subjects.Location = new Point(352, 38);
            dgv_Subjects.Name = "dgv_Subjects";
            dgv_Subjects.ReadOnly = true;
            dgv_Subjects.RowHeadersVisible = false;
            dgv_Subjects.RowTemplate.Height = 25;
            dgv_Subjects.Size = new Size(526, 354);
            dgv_Subjects.TabIndex = 0;
            dgv_Subjects.CellContentClick += dgv_Subjects_CellContentClick;
            // 
            // comboBox_FacultyYear
            // 
            comboBox_FacultyYear.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_FacultyYear.FormattingEnabled = true;
            comboBox_FacultyYear.Location = new Point(-1, 38);
            comboBox_FacultyYear.Name = "comboBox_FacultyYear";
            comboBox_FacultyYear.Size = new Size(165, 23);
            comboBox_FacultyYear.TabIndex = 1;
            comboBox_FacultyYear.SelectedIndexChanged += comboBox_ExistingSubjects_SelectedIndexChanged;
            // 
            // lbl_FacultyYear
            // 
            lbl_FacultyYear.AutoSize = true;
            lbl_FacultyYear.ForeColor = SystemColors.ButtonFace;
            lbl_FacultyYear.Location = new Point(43, 20);
            lbl_FacultyYear.Name = "lbl_FacultyYear";
            lbl_FacultyYear.Size = new Size(70, 15);
            lbl_FacultyYear.TabIndex = 2;
            lbl_FacultyYear.Text = "Faculty Year";
            // 
            // btn_CloseUC
            // 
            btn_CloseUC.AutoSize = true;
            btn_CloseUC.BackColor = Color.DimGray;
            btn_CloseUC.FlatAppearance.BorderSize = 0;
            btn_CloseUC.FlatStyle = FlatStyle.Flat;
            btn_CloseUC.ForeColor = SystemColors.ButtonFace;
            btn_CloseUC.Location = new Point(844, 3);
            btn_CloseUC.Name = "btn_CloseUC";
            btn_CloseUC.Size = new Size(34, 25);
            btn_CloseUC.TabIndex = 19;
            btn_CloseUC.Text = "X";
            btn_CloseUC.UseVisualStyleBackColor = false;
            btn_CloseUC.Click += btn_CloseUC_Click;
            // 
            // btn_AssignSubjects
            // 
            btn_AssignSubjects.AutoSize = true;
            btn_AssignSubjects.BackColor = Color.DimGray;
            btn_AssignSubjects.FlatAppearance.BorderSize = 0;
            btn_AssignSubjects.FlatStyle = FlatStyle.Flat;
            btn_AssignSubjects.ForeColor = SystemColors.ButtonFace;
            btn_AssignSubjects.Location = new Point(785, 398);
            btn_AssignSubjects.Name = "btn_AssignSubjects";
            btn_AssignSubjects.Size = new Size(93, 25);
            btn_AssignSubjects.TabIndex = 20;
            btn_AssignSubjects.Text = "Assign";
            btn_AssignSubjects.UseVisualStyleBackColor = false;
            btn_AssignSubjects.Click += btn_AssignSubjects_Click;
            // 
            // Subject
            // 
            Subject.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Subject.DataPropertyName = "AtlasSubject";
            Subject.HeaderText = "Subject";
            Subject.Name = "Subject";
            Subject.ReadOnly = true;
            // 
            // GiveSubjects
            // 
            GiveSubjects.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GiveSubjects.FalseValue = "false";
            GiveSubjects.HeaderText = "Give Subject";
            GiveSubjects.IndeterminateValue = "false";
            GiveSubjects.Name = "GiveSubjects";
            GiveSubjects.ReadOnly = true;
            GiveSubjects.TrueValue = "true";
            // 
            // AssignSubjectsToProfessor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btn_AssignSubjects);
            Controls.Add(btn_CloseUC);
            Controls.Add(lbl_FacultyYear);
            Controls.Add(comboBox_FacultyYear);
            Controls.Add(dgv_Subjects);
            DoubleBuffered = true;
            Location = new Point(761, 3);
            Name = "AssignSubjectsToProfessor";
            Size = new Size(881, 426);
            Load += ProfessorsSubjects_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Subjects).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_Subjects;
        private ComboBox comboBox_FacultyYear;
        private Label lbl_FacultyYear;
        private Button btn_CloseUC;
        private Button btn_AssignSubjects;
        private DataGridViewTextBoxColumn Subject;
        private DataGridViewCheckBoxColumn GiveSubjects;
    }
}
