namespace Legion_IX.User_Controls.Professor_UC_s
{
    partial class ProfessorDocuments
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
            dgv_Files = new DataGridView();
            NameOfFile = new DataGridViewTextBoxColumn();
            FileType = new DataGridViewTextBoxColumn();
            Created = new DataGridViewTextBoxColumn();
            View = new DataGridViewButtonColumn();
            Delete = new DataGridViewButtonColumn();
            comboBox_Subjects = new ComboBox();
            btn_UploadDocument = new Button();
            btn_Refresh = new Button();
            opf_ChooseDocument = new OpenFileDialog();
            lbl_Info = new Label();
            btn_RemoveUnsupported = new Button();
            btn_CancelDrop = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_Files).BeginInit();
            SuspendLayout();
            // 
            // dgv_Files
            // 
            dgv_Files.AllowDrop = true;
            dgv_Files.AllowUserToAddRows = false;
            dgv_Files.AllowUserToDeleteRows = false;
            dgv_Files.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Files.Columns.AddRange(new DataGridViewColumn[] { NameOfFile, FileType, Created, View, Delete });
            dgv_Files.Location = new Point(3, 85);
            dgv_Files.Name = "dgv_Files";
            dgv_Files.ReadOnly = true;
            dgv_Files.RowHeadersVisible = false;
            dgv_Files.RowTemplate.Height = 25;
            dgv_Files.Size = new Size(774, 300);
            dgv_Files.TabIndex = 4;
            dgv_Files.CellContentClick += dgv_Files_CellContentClick;
            dgv_Files.DragDrop += dgv_Files_DragDrop;
            dgv_Files.DragEnter += dgv_Files_DragEnter;
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
            // Created
            // 
            Created.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Created.DataPropertyName = "TimeStamp_Creation";
            Created.HeaderText = "Created";
            Created.Name = "Created";
            Created.ReadOnly = true;
            Created.Resizable = DataGridViewTriState.False;
            // 
            // View
            // 
            View.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            View.HeaderText = "Open";
            View.Name = "View";
            View.ReadOnly = true;
            View.Resizable = DataGridViewTriState.False;
            View.Text = "Open Preview";
            View.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            Delete.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Delete.HeaderText = "Delete Document";
            Delete.Name = "Delete";
            Delete.ReadOnly = true;
            Delete.Text = "Delete Document";
            Delete.UseColumnTextForButtonValue = true;
            // 
            // comboBox_Subjects
            // 
            comboBox_Subjects.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Subjects.FormattingEnabled = true;
            comboBox_Subjects.Location = new Point(3, 15);
            comboBox_Subjects.Name = "comboBox_Subjects";
            comboBox_Subjects.Size = new Size(199, 23);
            comboBox_Subjects.TabIndex = 5;
            comboBox_Subjects.SelectedIndexChanged += comboBox_Subjects_SelectedIndexChanged;
            // 
            // btn_UploadDocument
            // 
            btn_UploadDocument.Location = new Point(583, 391);
            btn_UploadDocument.Name = "btn_UploadDocument";
            btn_UploadDocument.Size = new Size(113, 23);
            btn_UploadDocument.TabIndex = 6;
            btn_UploadDocument.Text = "Upload";
            btn_UploadDocument.UseVisualStyleBackColor = true;
            btn_UploadDocument.Click += btn_UploadDocument_Click;
            // 
            // btn_Refresh
            // 
            btn_Refresh.Location = new Point(702, 391);
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Size = new Size(75, 23);
            btn_Refresh.TabIndex = 7;
            btn_Refresh.Text = "Refresh";
            btn_Refresh.UseVisualStyleBackColor = true;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // opf_ChooseDocument
            // 
            opf_ChooseDocument.FileName = "openFileDialog1";
            // 
            // lbl_Info
            // 
            lbl_Info.BackColor = Color.Black;
            lbl_Info.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Info.ForeColor = Color.White;
            lbl_Info.Location = new Point(253, 15);
            lbl_Info.Name = "lbl_Info";
            lbl_Info.Size = new Size(514, 47);
            lbl_Info.TabIndex = 8;
            lbl_Info.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_RemoveUnsupported
            // 
            btn_RemoveUnsupported.BackColor = Color.DimGray;
            btn_RemoveUnsupported.FlatStyle = FlatStyle.Flat;
            btn_RemoveUnsupported.ForeColor = SystemColors.ButtonFace;
            btn_RemoveUnsupported.Location = new Point(3, 409);
            btn_RemoveUnsupported.Name = "btn_RemoveUnsupported";
            btn_RemoveUnsupported.Size = new Size(155, 23);
            btn_RemoveUnsupported.TabIndex = 9;
            btn_RemoveUnsupported.Text = "Remove unsupported files";
            btn_RemoveUnsupported.UseVisualStyleBackColor = false;
            btn_RemoveUnsupported.Click += btn_RemoveUnsupported_Click;
            // 
            // btn_CancelDrop
            // 
            btn_CancelDrop.BackColor = Color.DimGray;
            btn_CancelDrop.FlatStyle = FlatStyle.Flat;
            btn_CancelDrop.ForeColor = SystemColors.ButtonFace;
            btn_CancelDrop.Location = new Point(179, 409);
            btn_CancelDrop.Name = "btn_CancelDrop";
            btn_CancelDrop.Size = new Size(113, 23);
            btn_CancelDrop.TabIndex = 10;
            btn_CancelDrop.Text = "Cancel";
            btn_CancelDrop.UseVisualStyleBackColor = false;
            btn_CancelDrop.Click += btn_CancelDrop_Click;
            // 
            // ProfessorDocuments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btn_CancelDrop);
            Controls.Add(btn_RemoveUnsupported);
            Controls.Add(lbl_Info);
            Controls.Add(btn_Refresh);
            Controls.Add(btn_UploadDocument);
            Controls.Add(comboBox_Subjects);
            Controls.Add(dgv_Files);
            Name = "ProfessorDocuments";
            Size = new Size(780, 468);
            Load += ProfessorDocuments_Load;
            KeyDown += EscapeKey_Pressed;
            ((System.ComponentModel.ISupportInitialize)dgv_Files).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv_Files;
        private ComboBox comboBox_Subjects;
        private Button btn_UploadDocument;
        private Button btn_Refresh;
        private DataGridViewTextBoxColumn NameOfFile;
        private DataGridViewTextBoxColumn FileType;
        private DataGridViewTextBoxColumn Created;
        private DataGridViewButtonColumn View;
        private DataGridViewButtonColumn Delete;
        private OpenFileDialog opf_ChooseDocument;
        private Label lbl_Info;
        private Button btn_RemoveUnsupported;
        private Button btn_CancelDrop;
    }
}
