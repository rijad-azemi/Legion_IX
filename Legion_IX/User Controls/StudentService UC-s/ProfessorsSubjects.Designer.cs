namespace Legion_IX.User_Controls.StudentService_UC_s
{
    partial class ProfessorsSubjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfessorsSubjects));
            dgv_ProfessorsSubjects = new DataGridView();
            Subject = new DataGridViewTextBoxColumn();
            GiveSubjects = new DataGridViewCheckBoxColumn();
            comboBox_ExistingProfessors = new ComboBox();
            lbl_ExistingProfessors = new Label();
            btn_CloseProfSubjects = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_ProfessorsSubjects).BeginInit();
            SuspendLayout();
            // 
            // dgv_ProfessorsSubjects
            // 
            dgv_ProfessorsSubjects.AllowUserToAddRows = false;
            dgv_ProfessorsSubjects.AllowUserToDeleteRows = false;
            dgv_ProfessorsSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ProfessorsSubjects.Columns.AddRange(new DataGridViewColumn[] { Subject, GiveSubjects });
            dgv_ProfessorsSubjects.Location = new Point(352, 38);
            dgv_ProfessorsSubjects.Name = "dgv_ProfessorsSubjects";
            dgv_ProfessorsSubjects.ReadOnly = true;
            dgv_ProfessorsSubjects.RowHeadersVisible = false;
            dgv_ProfessorsSubjects.RowTemplate.Height = 25;
            dgv_ProfessorsSubjects.Size = new Size(526, 385);
            dgv_ProfessorsSubjects.TabIndex = 0;
            // 
            // Subject
            // 
            Subject.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Subject.HeaderText = "Subject";
            Subject.Name = "Subject";
            Subject.ReadOnly = true;
            // 
            // GiveSubjects
            // 
            GiveSubjects.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GiveSubjects.HeaderText = "Give Subjects";
            GiveSubjects.Name = "GiveSubjects";
            GiveSubjects.ReadOnly = true;
            // 
            // comboBox_ExistingProfessors
            // 
            comboBox_ExistingProfessors.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_ExistingProfessors.FormattingEnabled = true;
            comboBox_ExistingProfessors.Location = new Point(-1, 38);
            comboBox_ExistingProfessors.Name = "comboBox_ExistingProfessors";
            comboBox_ExistingProfessors.Size = new Size(165, 23);
            comboBox_ExistingProfessors.TabIndex = 1;
            comboBox_ExistingProfessors.SelectedIndexChanged += comboBox_ExistingProfessors_SelectedIndexChanged;
            // 
            // lbl_ExistingProfessors
            // 
            lbl_ExistingProfessors.AutoSize = true;
            lbl_ExistingProfessors.ForeColor = SystemColors.ButtonFace;
            lbl_ExistingProfessors.Location = new Point(28, 20);
            lbl_ExistingProfessors.Name = "lbl_ExistingProfessors";
            lbl_ExistingProfessors.Size = new Size(105, 15);
            lbl_ExistingProfessors.TabIndex = 2;
            lbl_ExistingProfessors.Text = "Existing Professors";
            // 
            // btn_CloseProfSubjects
            // 
            btn_CloseProfSubjects.AutoSize = true;
            btn_CloseProfSubjects.BackColor = Color.DimGray;
            btn_CloseProfSubjects.FlatAppearance.BorderSize = 0;
            btn_CloseProfSubjects.FlatStyle = FlatStyle.Flat;
            btn_CloseProfSubjects.ForeColor = SystemColors.ButtonFace;
            btn_CloseProfSubjects.Location = new Point(844, 3);
            btn_CloseProfSubjects.Name = "btn_CloseProfSubjects";
            btn_CloseProfSubjects.Size = new Size(34, 25);
            btn_CloseProfSubjects.TabIndex = 19;
            btn_CloseProfSubjects.Text = "X";
            btn_CloseProfSubjects.UseVisualStyleBackColor = false;
            btn_CloseProfSubjects.Click += btn_CloseProfSubjects_Click;
            // 
            // ProfessorsSubjects
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btn_CloseProfSubjects);
            Controls.Add(lbl_ExistingProfessors);
            Controls.Add(comboBox_ExistingProfessors);
            Controls.Add(dgv_ProfessorsSubjects);
            DoubleBuffered = true;
            Location = new Point(761, 3);
            Name = "ProfessorsSubjects";
            Size = new Size(881, 426);
            Load += ProfessorsSubjects_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_ProfessorsSubjects).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_ProfessorsSubjects;
        private DataGridViewTextBoxColumn Subject;
        private DataGridViewCheckBoxColumn GiveSubjects;
        private ComboBox comboBox_ExistingProfessors;
        private Label lbl_ExistingProfessors;
        private Button btn_CloseProfSubjects;
    }
}
