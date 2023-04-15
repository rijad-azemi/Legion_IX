namespace Legion_IX.User_Controls
{
    partial class StudentDownloadedDocs
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
            btn_Refresh = new Button();
            dgv_Files = new DataGridView();
            NameOfFile = new DataGridViewTextBoxColumn();
            FileType = new DataGridViewTextBoxColumn();
            TimeStamp_Creation = new DataGridViewTextBoxColumn();
            Open = new DataGridViewButtonColumn();
            Export = new DataGridViewButtonColumn();
            comboBox_Subjects = new ComboBox();
            saveFileDialog_ExportDocument = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)dgv_Files).BeginInit();
            SuspendLayout();
            // 
            // btn_Refresh
            // 
            btn_Refresh.Location = new Point(578, 350);
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Size = new Size(75, 23);
            btn_Refresh.TabIndex = 11;
            btn_Refresh.Text = "Refresh?";
            btn_Refresh.UseVisualStyleBackColor = true;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // dgv_Files
            // 
            dgv_Files.AllowUserToAddRows = false;
            dgv_Files.AllowUserToDeleteRows = false;
            dgv_Files.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Files.Columns.AddRange(new DataGridViewColumn[] { NameOfFile, FileType, TimeStamp_Creation, Open, Export });
            dgv_Files.Location = new Point(5, 44);
            dgv_Files.Name = "dgv_Files";
            dgv_Files.ReadOnly = true;
            dgv_Files.RowHeadersVisible = false;
            dgv_Files.RowTemplate.Height = 25;
            dgv_Files.Size = new Size(648, 300);
            dgv_Files.TabIndex = 10;
            dgv_Files.CellContentClick += dgv_Files_CellContentClick;
            // 
            // NameOfFile
            // 
            NameOfFile.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NameOfFile.DataPropertyName = "NameOfFile";
            NameOfFile.HeaderText = "File Name";
            NameOfFile.Name = "NameOfFile";
            NameOfFile.ReadOnly = true;
            NameOfFile.Resizable = DataGridViewTriState.False;
            // 
            // FileType
            // 
            FileType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            FileType.DataPropertyName = "FileType";
            FileType.HeaderText = "File Type";
            FileType.Name = "FileType";
            FileType.ReadOnly = true;
            FileType.Resizable = DataGridViewTriState.False;
            // 
            // TimeStamp_Creation
            // 
            TimeStamp_Creation.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TimeStamp_Creation.DataPropertyName = "TimeStamp_Creation";
            TimeStamp_Creation.HeaderText = "Created";
            TimeStamp_Creation.Name = "TimeStamp_Creation";
            TimeStamp_Creation.ReadOnly = true;
            TimeStamp_Creation.Resizable = DataGridViewTriState.False;
            // 
            // Open
            // 
            Open.HeaderText = "Open";
            Open.Name = "Open";
            Open.ReadOnly = true;
            Open.Resizable = DataGridViewTriState.False;
            Open.Text = "Open";
            Open.UseColumnTextForButtonValue = true;
            // 
            // Export
            // 
            Export.HeaderText = "Export";
            Export.Name = "Export";
            Export.ReadOnly = true;
            Export.Text = "Export";
            Export.UseColumnTextForButtonValue = true;
            // 
            // comboBox_Subjects
            // 
            comboBox_Subjects.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Subjects.FormattingEnabled = true;
            comboBox_Subjects.Location = new Point(5, 3);
            comboBox_Subjects.Name = "comboBox_Subjects";
            comboBox_Subjects.Size = new Size(172, 23);
            comboBox_Subjects.TabIndex = 7;
            comboBox_Subjects.SelectedIndexChanged += comboBox_Subjects_SelectedIndexChanged;
            // 
            // StudentDownloadedDocs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btn_Refresh);
            Controls.Add(dgv_Files);
            Controls.Add(comboBox_Subjects);
            Name = "StudentDownloadedDocs";
            Size = new Size(652, 468);
            Load += DownloadedDocs_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Files).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btn_Refresh;
        private DataGridView dgv_Files;
        private ComboBox comboBox_Subjects;
        private DataGridViewTextBoxColumn NameOfFile;
        private DataGridViewTextBoxColumn FileType;
        private DataGridViewTextBoxColumn TimeStamp_Creation;
        private DataGridViewButtonColumn Open;
        private DataGridViewButtonColumn Export;
        private SaveFileDialog saveFileDialog_ExportDocument;
    }
}
