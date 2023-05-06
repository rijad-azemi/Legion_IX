namespace Legion_IX
{
    partial class frm_LoginScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_LoginScreen));
            lbl_email = new Label();
            lbl_password = new Label();
            textBox_email = new TextBox();
            textBox_password = new TextBox();
            linkLabel_DLWMSweb = new LinkLabel();
            button_Login = new Button();
            openFileDialog_searchForBrowser = new OpenFileDialog();
            checkBox_ShowPassword = new CheckBox();
            lblAccNotFound = new Label();
            txtBox_NetworkStatus = new TextBox();
            btn_LogAsStudent = new Button();
            btn_LogAsProfessor = new Button();
            btn_LogAsStudentService = new Button();
            btn_StarTest = new Button();
            SuspendLayout();
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.BackColor = Color.Transparent;
            lbl_email.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_email.ForeColor = SystemColors.ButtonFace;
            lbl_email.Location = new Point(203, 233);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(59, 20);
            lbl_email.TabIndex = 0;
            lbl_email.Text = "E-mail: ";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.BackColor = Color.Transparent;
            lbl_password.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_password.ForeColor = SystemColors.ButtonFace;
            lbl_password.Location = new Point(189, 289);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(73, 20);
            lbl_password.TabIndex = 1;
            lbl_password.Text = "Password:";
            // 
            // textBox_email
            // 
            textBox_email.BorderStyle = BorderStyle.None;
            textBox_email.Location = new Point(282, 237);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(215, 16);
            textBox_email.TabIndex = 2;
            textBox_email.KeyDown += textBox_EmailPassword_KeyDown;
            // 
            // textBox_password
            // 
            textBox_password.BorderStyle = BorderStyle.None;
            textBox_password.Location = new Point(282, 293);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(215, 16);
            textBox_password.TabIndex = 3;
            textBox_password.UseSystemPasswordChar = true;
            textBox_password.KeyDown += textBox_EmailPassword_KeyDown;
            // 
            // linkLabel_DLWMSweb
            // 
            linkLabel_DLWMSweb.AutoSize = true;
            linkLabel_DLWMSweb.BackColor = Color.Transparent;
            linkLabel_DLWMSweb.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel_DLWMSweb.ForeColor = SystemColors.ControlLight;
            linkLabel_DLWMSweb.LinkColor = Color.White;
            linkLabel_DLWMSweb.Location = new Point(12, 534);
            linkLabel_DLWMSweb.Name = "linkLabel_DLWMSweb";
            linkLabel_DLWMSweb.Size = new Size(100, 15);
            linkLabel_DLWMSweb.TabIndex = 4;
            linkLabel_DLWMSweb.TabStop = true;
            linkLabel_DLWMSweb.Text = "Visit DLWMS Web";
            linkLabel_DLWMSweb.LinkClicked += linkLabel_DLWMSweb_LinkClicked;
            // 
            // button_Login
            // 
            button_Login.BackColor = Color.DimGray;
            button_Login.BackgroundImage = (Image)resources.GetObject("button_Login.BackgroundImage");
            button_Login.FlatAppearance.BorderSize = 0;
            button_Login.FlatStyle = FlatStyle.Flat;
            button_Login.ForeColor = SystemColors.ButtonFace;
            button_Login.Location = new Point(350, 315);
            button_Login.Name = "button_Login";
            button_Login.Size = new Size(75, 23);
            button_Login.TabIndex = 5;
            button_Login.Text = "Log in";
            button_Login.UseVisualStyleBackColor = false;
            button_Login.Click += button_Login_Click;
            // 
            // openFileDialog_searchForBrowser
            // 
            openFileDialog_searchForBrowser.FileName = "Choose your browser";
            // 
            // checkBox_ShowPassword
            // 
            checkBox_ShowPassword.AutoSize = true;
            checkBox_ShowPassword.BackColor = Color.Transparent;
            checkBox_ShowPassword.ForeColor = SystemColors.ButtonFace;
            checkBox_ShowPassword.Location = new Point(532, 292);
            checkBox_ShowPassword.Name = "checkBox_ShowPassword";
            checkBox_ShowPassword.Size = new Size(113, 19);
            checkBox_ShowPassword.TabIndex = 6;
            checkBox_ShowPassword.Text = "Show password?";
            checkBox_ShowPassword.UseVisualStyleBackColor = false;
            checkBox_ShowPassword.CheckedChanged += checkBox_ShowPassword_CheckedChanged;
            // 
            // lblAccNotFound
            // 
            lblAccNotFound.BackColor = Color.Transparent;
            lblAccNotFound.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblAccNotFound.ForeColor = Color.Red;
            lblAccNotFound.Location = new Point(232, 146);
            lblAccNotFound.Name = "lblAccNotFound";
            lblAccNotFound.Size = new Size(325, 23);
            lblAccNotFound.TabIndex = 7;
            lblAccNotFound.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtBox_NetworkStatus
            // 
            txtBox_NetworkStatus.Location = new Point(602, 541);
            txtBox_NetworkStatus.Name = "txtBox_NetworkStatus";
            txtBox_NetworkStatus.ReadOnly = true;
            txtBox_NetworkStatus.Size = new Size(100, 23);
            txtBox_NetworkStatus.TabIndex = 8;
            txtBox_NetworkStatus.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_LogAsStudent
            // 
            btn_LogAsStudent.BackColor = Color.DimGray;
            btn_LogAsStudent.BackgroundImage = (Image)resources.GetObject("btn_LogAsStudent.BackgroundImage");
            btn_LogAsStudent.FlatAppearance.BorderSize = 0;
            btn_LogAsStudent.FlatStyle = FlatStyle.Flat;
            btn_LogAsStudent.ForeColor = SystemColors.ButtonFace;
            btn_LogAsStudent.Location = new Point(222, 172);
            btn_LogAsStudent.Name = "btn_LogAsStudent";
            btn_LogAsStudent.Size = new Size(75, 23);
            btn_LogAsStudent.TabIndex = 9;
            btn_LogAsStudent.Text = "Student";
            btn_LogAsStudent.UseVisualStyleBackColor = false;
            btn_LogAsStudent.Click += btn_LogAsStudent_Click;
            // 
            // btn_LogAsProfessor
            // 
            btn_LogAsProfessor.BackColor = Color.DimGray;
            btn_LogAsProfessor.BackgroundImage = (Image)resources.GetObject("btn_LogAsProfessor.BackgroundImage");
            btn_LogAsProfessor.FlatAppearance.BorderSize = 0;
            btn_LogAsProfessor.FlatStyle = FlatStyle.Flat;
            btn_LogAsProfessor.ForeColor = SystemColors.ButtonFace;
            btn_LogAsProfessor.Location = new Point(350, 172);
            btn_LogAsProfessor.Name = "btn_LogAsProfessor";
            btn_LogAsProfessor.Size = new Size(75, 23);
            btn_LogAsProfessor.TabIndex = 10;
            btn_LogAsProfessor.Text = "Professor";
            btn_LogAsProfessor.UseVisualStyleBackColor = false;
            btn_LogAsProfessor.Click += btn_LogAsProfessor_Click;
            // 
            // btn_LogAsStudentService
            // 
            btn_LogAsStudentService.BackColor = Color.DimGray;
            btn_LogAsStudentService.BackgroundImage = (Image)resources.GetObject("btn_LogAsStudentService.BackgroundImage");
            btn_LogAsStudentService.FlatAppearance.BorderSize = 0;
            btn_LogAsStudentService.FlatStyle = FlatStyle.Flat;
            btn_LogAsStudentService.ForeColor = SystemColors.ButtonFace;
            btn_LogAsStudentService.Location = new Point(491, 172);
            btn_LogAsStudentService.Name = "btn_LogAsStudentService";
            btn_LogAsStudentService.Size = new Size(75, 23);
            btn_LogAsStudentService.TabIndex = 11;
            btn_LogAsStudentService.Text = "Service";
            btn_LogAsStudentService.UseVisualStyleBackColor = false;
            btn_LogAsStudentService.Click += btn_LogAsStudentService_Click;
            // 
            // btn_StarTest
            // 
            btn_StarTest.BackColor = Color.DimGray;
            btn_StarTest.BackgroundImage = (Image)resources.GetObject("btn_StarTest.BackgroundImage");
            btn_StarTest.FlatAppearance.BorderSize = 0;
            btn_StarTest.FlatStyle = FlatStyle.Flat;
            btn_StarTest.ForeColor = SystemColors.ButtonFace;
            btn_StarTest.Location = new Point(282, 530);
            btn_StarTest.Name = "btn_StarTest";
            btn_StarTest.Size = new Size(175, 23);
            btn_StarTest.TabIndex = 12;
            btn_StarTest.Text = "?Azure SignalR Test?";
            btn_StarTest.UseVisualStyleBackColor = false;
            btn_StarTest.Click += btn_StarTest_Click;
            // 
            // frm_LoginScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(714, 576);
            Controls.Add(btn_StarTest);
            Controls.Add(btn_LogAsStudentService);
            Controls.Add(btn_LogAsProfessor);
            Controls.Add(btn_LogAsStudent);
            Controls.Add(txtBox_NetworkStatus);
            Controls.Add(lblAccNotFound);
            Controls.Add(checkBox_ShowPassword);
            Controls.Add(button_Login);
            Controls.Add(linkLabel_DLWMSweb);
            Controls.Add(textBox_password);
            Controls.Add(textBox_email);
            Controls.Add(lbl_password);
            Controls.Add(lbl_email);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frm_LoginScreen";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += frmLoginScreen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_email;
        private Label lbl_password;
        private TextBox textBox_email;
        private TextBox textBox_password;
        private LinkLabel linkLabel_DLWMSweb;
        private Button button_Login;
        private OpenFileDialog openFileDialog_searchForBrowser;
        private CheckBox checkBox_ShowPassword;
        private Label lblAccNotFound;
        private TextBox txtBox_NetworkStatus;
        private Button btn_LogAsStudentService;
        private Button btn_LogAsProfessor;
        private Button btn_LogAsStudent;
        private Button btn_StarTest;
    }
}