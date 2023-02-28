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
            dgv_Databases = new DataGridView();
            dgv_Collections = new DataGridView();
            btn_RefreshDB = new Button();
            txtBox_AvailableCollections = new TextBox();
            cmBox_ChooseDB = new ComboBox();
            err_ChooseDatabase = new ErrorProvider(components);
            tabControl_FullContainer = new TabControl();
            tabPage_TestingGround = new TabPage();
            tabPage_FacultyPersonell = new TabPage();
            btn_AddStudent = new Button();
            dataGridView1 = new DataGridView();
            grpBox_Main.SuspendLayout();
            grpBox_Main2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Databases).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Collections).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err_ChooseDatabase).BeginInit();
            tabControl_FullContainer.SuspendLayout();
            tabPage_TestingGround.SuspendLayout();
            tabPage_FacultyPersonell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            txtBox_ChangeEmail.Location = new Point(17, 277);
            txtBox_ChangeEmail.Name = "txtBox_ChangeEmail";
            txtBox_ChangeEmail.Size = new Size(158, 23);
            txtBox_ChangeEmail.TabIndex = 1;
            txtBox_ChangeEmail.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_ConfrimEmailChange
            // 
            btn_ConfrimEmailChange.Location = new Point(53, 306);
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
            lbl_ShowDatabaseNames.Location = new Point(6, 37);
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
            grpBox_Main.Location = new Point(393, 6);
            grpBox_Main.Name = "grpBox_Main";
            grpBox_Main.Size = new Size(437, 338);
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
            grpBox_Main2.Controls.Add(dgv_Databases);
            grpBox_Main2.Controls.Add(dgv_Collections);
            grpBox_Main2.Controls.Add(btn_RefreshDB);
            grpBox_Main2.Controls.Add(txtBox_AvailableCollections);
            grpBox_Main2.Controls.Add(cmBox_ChooseDB);
            grpBox_Main2.Controls.Add(lbl_ShowDatabaseNames);
            grpBox_Main2.Controls.Add(infoLbl_AvailableDatabases);
            grpBox_Main2.Location = new Point(6, 6);
            grpBox_Main2.Name = "grpBox_Main2";
            grpBox_Main2.Size = new Size(381, 493);
            grpBox_Main2.TabIndex = 9;
            grpBox_Main2.TabStop = false;
            grpBox_Main2.Text = "Visualizer";
            // 
            // dgv_Databases
            // 
            dgv_Databases.AllowUserToAddRows = false;
            dgv_Databases.AllowUserToDeleteRows = false;
            dgv_Databases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Databases.Location = new Point(6, 283);
            dgv_Databases.Name = "dgv_Databases";
            dgv_Databases.ReadOnly = true;
            dgv_Databases.RowTemplate.Height = 25;
            dgv_Databases.Size = new Size(369, 108);
            dgv_Databases.TabIndex = 10;
            // 
            // dgv_Collections
            // 
            dgv_Collections.AllowUserToAddRows = false;
            dgv_Collections.AllowUserToDeleteRows = false;
            dgv_Collections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Collections.Location = new Point(6, 397);
            dgv_Collections.Name = "dgv_Collections";
            dgv_Collections.ReadOnly = true;
            dgv_Collections.RowTemplate.Height = 25;
            dgv_Collections.Size = new Size(369, 96);
            dgv_Collections.TabIndex = 11;
            // 
            // btn_RefreshDB
            // 
            btn_RefreshDB.Location = new Point(252, 241);
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
            txtBox_AvailableCollections.Location = new Point(224, 66);
            txtBox_AvailableCollections.Multiline = true;
            txtBox_AvailableCollections.Name = "txtBox_AvailableCollections";
            txtBox_AvailableCollections.Size = new Size(130, 169);
            txtBox_AvailableCollections.TabIndex = 6;
            txtBox_AvailableCollections.TextAlign = HorizontalAlignment.Center;
            // 
            // cmBox_ChooseDB
            // 
            cmBox_ChooseDB.FormattingEnabled = true;
            cmBox_ChooseDB.Location = new Point(224, 37);
            cmBox_ChooseDB.Name = "cmBox_ChooseDB";
            cmBox_ChooseDB.Size = new Size(130, 23);
            cmBox_ChooseDB.TabIndex = 5;
            cmBox_ChooseDB.Text = "Choose DB";
            cmBox_ChooseDB.SelectedIndexChanged += cmBox_ChooseDB_SelectedIndexChanged;
            // 
            // err_ChooseDatabase
            // 
            err_ChooseDatabase.ContainerControl = this;
            // 
            // tabControl_FullContainer
            // 
            tabControl_FullContainer.Controls.Add(tabPage_TestingGround);
            tabControl_FullContainer.Controls.Add(tabPage_FacultyPersonell);
            tabControl_FullContainer.Location = new Point(12, 12);
            tabControl_FullContainer.Name = "tabControl_FullContainer";
            tabControl_FullContainer.SelectedIndex = 0;
            tabControl_FullContainer.Size = new Size(1121, 533);
            tabControl_FullContainer.TabIndex = 13;
            // 
            // tabPage_TestingGround
            // 
            tabPage_TestingGround.Controls.Add(grpBox_Main2);
            tabPage_TestingGround.Controls.Add(grpBox_Main);
            tabPage_TestingGround.Location = new Point(4, 24);
            tabPage_TestingGround.Name = "tabPage_TestingGround";
            tabPage_TestingGround.Padding = new Padding(3);
            tabPage_TestingGround.Size = new Size(1113, 505);
            tabPage_TestingGround.TabIndex = 0;
            tabPage_TestingGround.Text = "TestingGround";
            tabPage_TestingGround.UseVisualStyleBackColor = true;
            // 
            // tabPage_FacultyPersonell
            // 
            tabPage_FacultyPersonell.Controls.Add(btn_AddStudent);
            tabPage_FacultyPersonell.Controls.Add(dataGridView1);
            tabPage_FacultyPersonell.Location = new Point(4, 24);
            tabPage_FacultyPersonell.Name = "tabPage_FacultyPersonell";
            tabPage_FacultyPersonell.Padding = new Padding(3);
            tabPage_FacultyPersonell.Size = new Size(1113, 505);
            tabPage_FacultyPersonell.TabIndex = 1;
            tabPage_FacultyPersonell.Text = "Personell";
            tabPage_FacultyPersonell.UseVisualStyleBackColor = true;
            // 
            // btn_AddStudent
            // 
            btn_AddStudent.Location = new Point(541, 80);
            btn_AddStudent.Name = "btn_AddStudent";
            btn_AddStudent.Size = new Size(116, 23);
            btn_AddStudent.TabIndex = 14;
            btn_AddStudent.Text = "Add Student";
            btn_AddStudent.UseVisualStyleBackColor = true;
            btn_AddStudent.Click += btn_AddStudent_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 109);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(651, 196);
            dataGridView1.TabIndex = 13;
            // 
            // frmHeartBeat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(1143, 550);
            Controls.Add(tabControl_FullContainer);
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
            tabControl_FullContainer.ResumeLayout(false);
            tabPage_TestingGround.ResumeLayout(false);
            tabPage_FacultyPersonell.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private ErrorProvider err_ChooseDatabase;
        private Button btn_RefreshDB;
        private TabControl tabControl_FullContainer;
        private TabPage tabPage_TestingGround;
        private TabPage tabPage_FacultyPersonell;
        private DataGridView dataGridView1;
        private Button btn_AddStudent;
    }
}