namespace Legion_IX.User_Controls.StudentService_UC_s
{
    partial class UC_ActiveProfessors
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
            btn_Close = new Button();
            dgv_ActiveProfessors = new DataGridView();
            FirstName = new DataGridViewTextBoxColumn();
            Surname = new DataGridViewTextBoxColumn();
            BirthData = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Active = new DataGridViewTextBoxColumn();
            RevokePrivileges = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_ActiveProfessors).BeginInit();
            SuspendLayout();
            // 
            // btn_Close
            // 
            btn_Close.BackColor = Color.DimGray;
            btn_Close.FlatAppearance.BorderSize = 0;
            btn_Close.FlatStyle = FlatStyle.Flat;
            btn_Close.ForeColor = SystemColors.ButtonFace;
            btn_Close.Location = new Point(899, 2);
            btn_Close.Margin = new Padding(3, 2, 3, 2);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new Size(45, 25);
            btn_Close.TabIndex = 12;
            btn_Close.Text = "X";
            btn_Close.UseVisualStyleBackColor = false;
            btn_Close.Click += btn_Close_Click;
            // 
            // dgv_ActiveProfessors
            // 
            dgv_ActiveProfessors.AllowUserToAddRows = false;
            dgv_ActiveProfessors.AllowUserToDeleteRows = false;
            dgv_ActiveProfessors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ActiveProfessors.Columns.AddRange(new DataGridViewColumn[] { FirstName, Surname, BirthData, Email, Active, RevokePrivileges });
            dgv_ActiveProfessors.Location = new Point(3, 77);
            dgv_ActiveProfessors.Name = "dgv_ActiveProfessors";
            dgv_ActiveProfessors.ReadOnly = true;
            dgv_ActiveProfessors.RowTemplate.Height = 25;
            dgv_ActiveProfessors.Size = new Size(941, 419);
            dgv_ActiveProfessors.TabIndex = 13;
            dgv_ActiveProfessors.CellContentClick += dgv_ActiveProfessors_CellContentClick;
            // 
            // FirstName
            // 
            FirstName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FirstName.DataPropertyName = "FirstName";
            FirstName.HeaderText = "First Name";
            FirstName.Name = "FirstName";
            FirstName.ReadOnly = true;
            // 
            // Surname
            // 
            Surname.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Surname.DataPropertyName = "Surname";
            Surname.HeaderText = "Surname";
            Surname.Name = "Surname";
            Surname.ReadOnly = true;
            // 
            // BirthData
            // 
            BirthData.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            BirthData.DataPropertyName = "Birthdate";
            BirthData.HeaderText = "Birth Date";
            BirthData.Name = "BirthData";
            BirthData.ReadOnly = true;
            // 
            // Email
            // 
            Email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Email.DataPropertyName = "Email";
            Email.HeaderText = "Email";
            Email.Name = "Email";
            Email.ReadOnly = true;
            // 
            // Active
            // 
            Active.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Active.DataPropertyName = "Active";
            Active.HeaderText = "Active";
            Active.Name = "Active";
            Active.ReadOnly = true;
            // 
            // RevokePrivileges
            // 
            RevokePrivileges.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RevokePrivileges.HeaderText = "Revoke Privileges";
            RevokePrivileges.Name = "RevokePrivileges";
            RevokePrivileges.ReadOnly = true;
            RevokePrivileges.Text = "Revoke Privileges";
            RevokePrivileges.UseColumnTextForButtonValue = true;
            // 
            // UC_ActiveProfessors
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgv_ActiveProfessors);
            Controls.Add(btn_Close);
            Name = "UC_ActiveProfessors";
            Size = new Size(947, 499);
            Load += UC_ActiveProfessors_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_ActiveProfessors).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btn_Close;
        private DataGridViewTextBoxColumn ProfName;
        internal DataGridView dgv_ActiveProfessors;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn Surname;
        private DataGridViewTextBoxColumn BirthData;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Active;
        private DataGridViewButtonColumn RevokePrivileges;
    }
}
