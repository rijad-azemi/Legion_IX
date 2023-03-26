namespace Legion_IX.User_Controls
{
    partial class StudentDocuments
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
            comboBox_Subjects = new ComboBox();
            btn_UploadPdf = new Button();
            opf_ChooseDocument = new OpenFileDialog();
            btn_GetMe = new Button();
            dgv_Files = new DataGridView();
            btn_Refresh = new Button();
            NameOfFile = new DataGridViewTextBoxColumn();
            Open = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_Files).BeginInit();
            SuspendLayout();
            // 
            // comboBox_Subjects
            // 
            comboBox_Subjects.FormattingEnabled = true;
            comboBox_Subjects.Location = new Point(3, 3);
            comboBox_Subjects.Name = "comboBox_Subjects";
            comboBox_Subjects.Size = new Size(155, 23);
            comboBox_Subjects.TabIndex = 0;
            // 
            // btn_UploadPdf
            // 
            btn_UploadPdf.Location = new Point(16, 61);
            btn_UploadPdf.Name = "btn_UploadPdf";
            btn_UploadPdf.Size = new Size(113, 23);
            btn_UploadPdf.TabIndex = 1;
            btn_UploadPdf.Text = "Upload me?";
            btn_UploadPdf.UseVisualStyleBackColor = true;
            btn_UploadPdf.Click += btn_UploadPdf_Click;
            // 
            // opf_ChooseDocument
            // 
            opf_ChooseDocument.FileName = "openFileDialog1";
            // 
            // btn_GetMe
            // 
            btn_GetMe.Location = new Point(16, 104);
            btn_GetMe.Name = "btn_GetMe";
            btn_GetMe.Size = new Size(75, 23);
            btn_GetMe.TabIndex = 2;
            btn_GetMe.Text = "GetMe";
            btn_GetMe.UseVisualStyleBackColor = true;
            btn_GetMe.Click += btn_GetMe_Click;
            // 
            // dgv_Files
            // 
            dgv_Files.AllowUserToAddRows = false;
            dgv_Files.AllowUserToDeleteRows = false;
            dgv_Files.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Files.Columns.AddRange(new DataGridViewColumn[] { NameOfFile, Open });
            dgv_Files.Location = new Point(164, 3);
            dgv_Files.Name = "dgv_Files";
            dgv_Files.ReadOnly = true;
            dgv_Files.RowHeadersVisible = false;
            dgv_Files.RowTemplate.Height = 25;
            dgv_Files.Size = new Size(487, 300);
            dgv_Files.TabIndex = 3;
            dgv_Files.CellContentClick += dgv_Files_CellContentClick;
            // 
            // btn_Refresh
            // 
            btn_Refresh.Location = new Point(576, 309);
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Size = new Size(75, 23);
            btn_Refresh.TabIndex = 4;
            btn_Refresh.Text = "Refresh?";
            btn_Refresh.UseVisualStyleBackColor = true;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // NameOfFile
            // 
            NameOfFile.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NameOfFile.DataPropertyName = "NameOfFile";
            NameOfFile.HeaderText = "File Name";
            NameOfFile.Name = "NameOfFile";
            NameOfFile.ReadOnly = true;
            // 
            // Open
            // 
            Open.HeaderText = "Open";
            Open.Name = "Open";
            Open.ReadOnly = true;
            Open.Text = "Open";
            Open.UseColumnTextForButtonValue = true;
            // 
            // StudentDocuments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btn_Refresh);
            Controls.Add(dgv_Files);
            Controls.Add(btn_GetMe);
            Controls.Add(btn_UploadPdf);
            Controls.Add(comboBox_Subjects);
            Name = "StudentDocuments";
            Size = new Size(654, 335);
            Load += StudentDocuments_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Files).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox_Subjects;
        private Button btn_UploadPdf;
        private OpenFileDialog opf_ChooseDocument;
        private Button btn_GetMe;
        private DataGridView dgv_Files;
        private Button btn_Refresh;
        private DataGridViewTextBoxColumn NameOfFile;
        private DataGridViewButtonColumn Open;
    }
}
