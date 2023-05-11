﻿namespace Legion_IX.User_Controls
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
            opf_ChooseDocument = new OpenFileDialog();
            dgv_Files = new DataGridView();
            NameOfFile = new DataGridViewTextBoxColumn();
            FileType = new DataGridViewTextBoxColumn();
            TimeStamp_Created = new DataGridViewTextBoxColumn();
            Open = new DataGridViewButtonColumn();
            Download = new DataGridViewButtonColumn();
            btn_Refresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_Files).BeginInit();
            SuspendLayout();
            // 
            // comboBox_Subjects
            // 
            comboBox_Subjects.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Subjects.FormattingEnabled = true;
            comboBox_Subjects.Location = new Point(3, 3);
            comboBox_Subjects.Name = "comboBox_Subjects";
            comboBox_Subjects.Size = new Size(155, 23);
            comboBox_Subjects.TabIndex = 0;
            comboBox_Subjects.SelectedIndexChanged += comboBox_Subjects_SelectedIndexChanged;
            // 
            // opf_ChooseDocument
            // 
            opf_ChooseDocument.FileName = "openFileDialog1";
            // 
            // dgv_Files
            // 
            dgv_Files.AllowUserToAddRows = false;
            dgv_Files.AllowUserToDeleteRows = false;
            dgv_Files.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Files.Columns.AddRange(new DataGridViewColumn[] { NameOfFile, FileType, TimeStamp_Created, Open, Download });
            dgv_Files.Location = new Point(3, 44);
            dgv_Files.Name = "dgv_Files";
            dgv_Files.ReadOnly = true;
            dgv_Files.RowHeadersVisible = false;
            dgv_Files.RowTemplate.Height = 25;
            dgv_Files.Size = new Size(648, 300);
            dgv_Files.TabIndex = 3;
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
            // TimeStamp_Created
            // 
            TimeStamp_Created.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TimeStamp_Created.DataPropertyName = "TimeStamp_Creation";
            TimeStamp_Created.HeaderText = "Created";
            TimeStamp_Created.Name = "TimeStamp_Created";
            TimeStamp_Created.ReadOnly = true;
            TimeStamp_Created.Resizable = DataGridViewTriState.False;
            // 
            // Open
            // 
            Open.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Open.HeaderText = "Open";
            Open.Name = "Open";
            Open.ReadOnly = true;
            Open.Resizable = DataGridViewTriState.False;
            Open.Text = "Open Preview";
            Open.UseColumnTextForButtonValue = true;
            // 
            // Download
            // 
            Download.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Download.HeaderText = "Download";
            Download.Name = "Download";
            Download.ReadOnly = true;
            Download.Resizable = DataGridViewTriState.False;
            Download.Text = "Download";
            Download.UseColumnTextForButtonValue = true;
            // 
            // btn_Refresh
            // 
            btn_Refresh.Location = new Point(576, 350);
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Size = new Size(75, 23);
            btn_Refresh.TabIndex = 4;
            btn_Refresh.Text = "Refresh?";
            btn_Refresh.UseVisualStyleBackColor = true;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // StudentDocuments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btn_Refresh);
            Controls.Add(dgv_Files);
            Controls.Add(comboBox_Subjects);
            Name = "StudentDocuments";
            Size = new Size(654, 470);
            Load += StudentDocuments_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Files).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox_Subjects;
        private OpenFileDialog opf_ChooseDocument;
        private DataGridView dgv_Files;
        private Button btn_Refresh;
        private DataGridViewTextBoxColumn NameOfFile;
        private DataGridViewTextBoxColumn FileType;
        private DataGridViewTextBoxColumn TimeStamp_Created;
        private DataGridViewButtonColumn Open;
        private DataGridViewButtonColumn Download;
    }
}
