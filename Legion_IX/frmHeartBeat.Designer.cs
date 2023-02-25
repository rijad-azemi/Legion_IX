namespace Legion_IX
{
    partial class frmHeartBeat
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtBox_Data = new TextBox();
            txtBox_ChangeEmail = new TextBox();
            btn_ConfrimEmailChange = new Button();
            lbl_ShowDatabaseNames = new Label();
            infoLbl_AvailableDatabases = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            grpBox_Main = new GroupBox();
            txtBox_TypeCollection = new TextBox();
            lbl_CollectionToDisplay = new Label();
            contextMenuStrip2 = new ContextMenuStrip(components);
            grpBox_Main2 = new GroupBox();
            btn_RefreshDB = new Button();
            txtBox_AvailableCollections = new TextBox();
            cmBox_ChooseDB = new ComboBox();
            dgv_Databases = new DataGridView();
            Database = new DataGridViewTextBoxColumn();
            dgv_Collections = new DataGridView();
            err_ChooseDatabase = new ErrorProvider(components);
            grpBox_Main.SuspendLayout();
            grpBox_Main2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Databases).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Collections).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err_ChooseDatabase).BeginInit();
            SuspendLayout();
            // 
            // txtBox_Data
            // 
            txtBox_Data.BorderStyle = BorderStyle.FixedSingle;
            txtBox_Data.Location = new Point(17, 48);
            txtBox_Data.Multiline = true;
            txtBox_Data.Name = "txtBox_Data";
            txtBox_Data.Size = new Size(394, 221);
            txtBox_Data.TabIndex = 0;
            // 
            // txtBox_ChangeEmail
            // 
            txtBox_ChangeEmail.Location = new Point(17, 427);
            txtBox_ChangeEmail.Name = "txtBox_ChangeEmail";
            txtBox_ChangeEmail.Size = new Size(158, 23);
            txtBox_ChangeEmail.TabIndex = 1;
            txtBox_ChangeEmail.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_ConfrimEmailChange
            // 
            btn_ConfrimEmailChange.Location = new Point(53, 456);
            btn_ConfrimEmailChange.Name = "btn_ConfrimEmailChange";
            btn_ConfrimEmailChange.Size = new Size(75, 25);
            btn_ConfrimEmailChange.TabIndex = 2;
            btn_ConfrimEmailChange.Text = "Change Email";
            btn_ConfrimEmailChange.UseVisualStyleBackColor = true;
            btn_ConfrimEmailChange.Click += btn_ConfrimEmailChange_Click;
            // 
            // lbl_ShowDatabaseNames
            // 
            lbl_ShowDatabaseNames.BorderStyle = BorderStyle.FixedSingle;
            lbl_ShowDatabaseNames.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_ShowDatabaseNames.Location = new Point(6, 54);
            lbl_ShowDatabaseNames.Name = "lbl_ShowDatabaseNames";
            lbl_ShowDatabaseNames.Size = new Size(212, 198);
            lbl_ShowDatabaseNames.TabIndex = 3;
            lbl_ShowDatabaseNames.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // infoLbl_AvailableDatabases
            // 
            infoLbl_AvailableDatabases.AutoSize = true;
            infoLbl_AvailableDatabases.Location = new Point(56, 22);
            infoLbl_AvailableDatabases.Name = "infoLbl_AvailableDatabases";
            infoLbl_AvailableDatabases.Size = new Size(111, 15);
            infoLbl_AvailableDatabases.TabIndex = 4;
            infoLbl_AvailableDatabases.Text = "Available Databases";
            infoLbl_AvailableDatabases.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // grpBox_Main
            // 
            grpBox_Main.Controls.Add(txtBox_TypeCollection);
            grpBox_Main.Controls.Add(lbl_CollectionToDisplay);
            grpBox_Main.Controls.Add(txtBox_Data);
            grpBox_Main.Controls.Add(btn_ConfrimEmailChange);
            grpBox_Main.Controls.Add(txtBox_ChangeEmail);
            grpBox_Main.Location = new Point(388, 12);
            grpBox_Main.Name = "grpBox_Main";
            grpBox_Main.Size = new Size(459, 492);
            grpBox_Main.TabIndex = 7;
            grpBox_Main.TabStop = false;
            grpBox_Main.Text = "Keeper";
            // 
            // txtBox_TypeCollection
            // 
            txtBox_TypeCollection.Location = new Point(141, 19);
            txtBox_TypeCollection.Name = "txtBox_TypeCollection";
            txtBox_TypeCollection.Size = new Size(158, 23);
            txtBox_TypeCollection.TabIndex = 6;
            txtBox_TypeCollection.KeyDown += txtBox_TypeCollection_KeyDown;
            // 
            // lbl_CollectionToDisplay
            // 
            lbl_CollectionToDisplay.AutoSize = true;
            lbl_CollectionToDisplay.Location = new Point(17, 22);
            lbl_CollectionToDisplay.Name = "lbl_CollectionToDisplay";
            lbl_CollectionToDisplay.Size = new Size(118, 15);
            lbl_CollectionToDisplay.TabIndex = 5;
            lbl_CollectionToDisplay.Text = "Collection to display:";
            lbl_CollectionToDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // grpBox_Main2
            // 
            grpBox_Main2.Controls.Add(btn_RefreshDB);
            grpBox_Main2.Controls.Add(txtBox_AvailableCollections);
            grpBox_Main2.Controls.Add(cmBox_ChooseDB);
            grpBox_Main2.Controls.Add(lbl_ShowDatabaseNames);
            grpBox_Main2.Controls.Add(infoLbl_AvailableDatabases);
            grpBox_Main2.Location = new Point(1, 12);
            grpBox_Main2.Name = "grpBox_Main2";
            grpBox_Main2.Size = new Size(381, 290);
            grpBox_Main2.TabIndex = 9;
            grpBox_Main2.TabStop = false;
            grpBox_Main2.Text = "Visualizer";
            // 
            // btn_RefreshDB
            // 
            btn_RefreshDB.Location = new Point(252, 25);
            btn_RefreshDB.Name = "btn_RefreshDB";
            btn_RefreshDB.Size = new Size(75, 23);
            btn_RefreshDB.TabIndex = 7;
            btn_RefreshDB.Text = "Refresh";
            btn_RefreshDB.UseVisualStyleBackColor = true;
            btn_RefreshDB.Click += btn_RefreshDB_Click;
            // 
            // txtBox_AvailableCollections
            // 
            txtBox_AvailableCollections.BorderStyle = BorderStyle.FixedSingle;
            txtBox_AvailableCollections.Location = new Point(224, 83);
            txtBox_AvailableCollections.Multiline = true;
            txtBox_AvailableCollections.Name = "txtBox_AvailableCollections";
            txtBox_AvailableCollections.Size = new Size(130, 169);
            txtBox_AvailableCollections.TabIndex = 6;
            txtBox_AvailableCollections.TextAlign = HorizontalAlignment.Center;
            // 
            // cmBox_ChooseDB
            // 
            cmBox_ChooseDB.FormattingEnabled = true;
            cmBox_ChooseDB.Location = new Point(224, 54);
            cmBox_ChooseDB.Name = "cmBox_ChooseDB";
            cmBox_ChooseDB.Size = new Size(130, 23);
            cmBox_ChooseDB.TabIndex = 5;
            cmBox_ChooseDB.Text = "Choose DB";
            cmBox_ChooseDB.SelectedIndexChanged += cmBox_ChooseDB_SelectedIndexChanged;
            // 
            // dgv_Databases
            // 
            dgv_Databases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Databases.Columns.AddRange(new DataGridViewColumn[] { Database });
            dgv_Databases.Location = new Point(12, 308);
            dgv_Databases.Name = "dgv_Databases";
            dgv_Databases.RowTemplate.Height = 25;
            dgv_Databases.Size = new Size(167, 196);
            dgv_Databases.TabIndex = 10;
            // 
            // Database
            // 
            Database.HeaderText = "Available Databases";
            Database.Name = "Database";
            // 
            // dgv_Collections
            // 
            dgv_Collections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Collections.Location = new Point(197, 308);
            dgv_Collections.Name = "dgv_Collections";
            dgv_Collections.RowTemplate.Height = 25;
            dgv_Collections.Size = new Size(169, 196);
            dgv_Collections.TabIndex = 11;
            // 
            // err_ChooseDatabase
            // 
            err_ChooseDatabase.ContainerControl = this;
            // 
            // frmHeartBeat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(850, 516);
            Controls.Add(dgv_Collections);
            Controls.Add(dgv_Databases);
            Controls.Add(grpBox_Main2);
            Controls.Add(grpBox_Main);
            Name = "frmHeartBeat";
            Text = "HeartBeat";
            Load += frmHeartBeat_Load;
            grpBox_Main.ResumeLayout(false);
            grpBox_Main.PerformLayout();
            grpBox_Main2.ResumeLayout(false);
            grpBox_Main2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Databases).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Collections).EndInit();
            ((System.ComponentModel.ISupportInitialize)err_ChooseDatabase).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtBox_Data;
        private TextBox txtBox_ChangeEmail;
        private Button btn_ConfrimEmailChange;
        private Label lbl_ShowDatabaseNames;
        private Label infoLbl_AvailableDatabases;
        private ContextMenuStrip contextMenuStrip1;
        private GroupBox grpBox_Main;
        private ContextMenuStrip contextMenuStrip2;
        private GroupBox grpBox_Main2;
        private ComboBox cmBox_ChooseDB;
        private TextBox txtBox_AvailableCollections;
        private TextBox txtBox_TypeCollection;
        private Label lbl_CollectionToDisplay;
        private DataGridView dgv_Databases;
        private DataGridView dgv_Collections;
        private DataGridViewTextBoxColumn Database;
        private ErrorProvider err_ChooseDatabase;
        private Button btn_RefreshDB;
    }
}