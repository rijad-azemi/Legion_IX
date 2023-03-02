namespace Legion_IX
{
    partial class frmLoginScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginScreen));
            lbl_email = new Label();
            lbl_password = new Label();
            textBox_email = new TextBox();
            textBox_password = new TextBox();
            linkLabel_DLWMSweb = new LinkLabel();
            button_Login = new Button();
            openFileDialog_searchForBrowser = new OpenFileDialog();
            txtBox_DisplayDocument = new TextBox();
            SuspendLayout();
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.BackColor = Color.Transparent;
            lbl_email.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_email.ForeColor = SystemColors.ButtonFace;
            lbl_email.Location = new Point(235, 256);
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
            lbl_password.Location = new Point(221, 312);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(73, 20);
            lbl_password.TabIndex = 1;
            lbl_password.Text = "Password:";
            // 
            // textBox_email
            // 
            textBox_email.BorderStyle = BorderStyle.None;
            textBox_email.Location = new Point(314, 260);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(144, 16);
            textBox_email.TabIndex = 2;
            // 
            // textBox_password
            // 
            textBox_password.BorderStyle = BorderStyle.None;
            textBox_password.Location = new Point(314, 316);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(144, 16);
            textBox_password.TabIndex = 3;
            // 
            // linkLabel_DLWMSweb
            // 
            linkLabel_DLWMSweb.AutoSize = true;
            linkLabel_DLWMSweb.BackColor = Color.Transparent;
            linkLabel_DLWMSweb.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel_DLWMSweb.ForeColor = SystemColors.ControlLight;
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
            button_Login.BackColor = Color.LightGray;
            button_Login.BackgroundImage = (Image)resources.GetObject("button_Login.BackgroundImage");
            button_Login.FlatAppearance.BorderSize = 0;
            button_Login.ForeColor = SystemColors.ButtonFace;
            button_Login.Location = new Point(339, 354);
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
            // txtBox_DisplayDocument
            // 
            txtBox_DisplayDocument.Location = new Point(12, 12);
            txtBox_DisplayDocument.Multiline = true;
            txtBox_DisplayDocument.Name = "txtBox_DisplayDocument";
            txtBox_DisplayDocument.Size = new Size(382, 210);
            txtBox_DisplayDocument.TabIndex = 6;
            // 
            // frmLoginScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(714, 576);
            Controls.Add(txtBox_DisplayDocument);
            Controls.Add(button_Login);
            Controls.Add(linkLabel_DLWMSweb);
            Controls.Add(textBox_password);
            Controls.Add(textBox_email);
            Controls.Add(lbl_password);
            Controls.Add(lbl_email);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "frmLoginScreen";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLoginScreen";
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
        private TextBox txtBox_DisplayDocument;
    }
}