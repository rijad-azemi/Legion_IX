using Legion_IX.User_Controls.StudentService_UC_s;

namespace Legion_IX.ProjectForms
{
    partial class frm_StudentServiceADMIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_StudentServiceADMIN));
            txtBox_NetworkStatus = new TextBox();
            button_LogOut = new Button();
            uc_AddStudent1 = new UC_AddStudent();
            uc_AddProfessor1 = new UC_AddProfessor();
            btn_ViewActiveStudents = new Button();
            btn_ViewActiveProfessors = new Button();
            uc_ActiveProfessors1 = new UC_ActiveProfessors();
            SuspendLayout();
            // 
            // txtBox_NetworkStatus
            // 
            txtBox_NetworkStatus.Location = new Point(1343, 642);
            txtBox_NetworkStatus.Name = "txtBox_NetworkStatus";
            txtBox_NetworkStatus.ReadOnly = true;
            txtBox_NetworkStatus.Size = new Size(100, 23);
            txtBox_NetworkStatus.TabIndex = 11;
            txtBox_NetworkStatus.TextAlign = HorizontalAlignment.Center;
            // 
            // button_LogOut
            // 
            button_LogOut.AutoSize = true;
            button_LogOut.BackColor = Color.DimGray;
            button_LogOut.FlatAppearance.BorderSize = 0;
            button_LogOut.FlatStyle = FlatStyle.Flat;
            button_LogOut.ForeColor = SystemColors.ButtonFace;
            button_LogOut.Location = new Point(1244, 643);
            button_LogOut.Margin = new Padding(3, 2, 3, 2);
            button_LogOut.Name = "button_LogOut";
            button_LogOut.Size = new Size(82, 25);
            button_LogOut.TabIndex = 10;
            button_LogOut.Text = "Log Out";
            button_LogOut.UseVisualStyleBackColor = false;
            button_LogOut.Click += button_LogOut_Click;
            // 
            // uc_AddStudent1
            // 
            uc_AddStudent1.BackColor = Color.Transparent;
            uc_AddStudent1.BackgroundImage = (Image)resources.GetObject("uc_AddStudent1.BackgroundImage");
            uc_AddStudent1.BorderStyle = BorderStyle.FixedSingle;
            uc_AddStudent1.Location = new Point(12, 11);
            uc_AddStudent1.Name = "uc_AddStudent1";
            uc_AddStudent1.Size = new Size(687, 606);
            uc_AddStudent1.TabIndex = 12;
            // 
            // uc_AddProfessor1
            // 
            uc_AddProfessor1.BackColor = Color.Transparent;
            uc_AddProfessor1.BackgroundImage = (Image)resources.GetObject("uc_AddProfessor1.BackgroundImage");
            uc_AddProfessor1.BorderStyle = BorderStyle.FixedSingle;
            uc_AddProfessor1.Location = new Point(740, 11);
            uc_AddProfessor1.Name = "uc_AddProfessor1";
            uc_AddProfessor1.Size = new Size(662, 606);
            uc_AddProfessor1.TabIndex = 13;
            // 
            // btn_ViewActiveStudents
            // 
            btn_ViewActiveStudents.BackColor = Color.DimGray;
            btn_ViewActiveStudents.FlatStyle = FlatStyle.Flat;
            btn_ViewActiveStudents.ForeColor = Color.White;
            btn_ViewActiveStudents.Location = new Point(282, 623);
            btn_ViewActiveStudents.Name = "btn_ViewActiveStudents";
            btn_ViewActiveStudents.Size = new Size(151, 23);
            btn_ViewActiveStudents.TabIndex = 14;
            btn_ViewActiveStudents.Text = "View Active Students";
            btn_ViewActiveStudents.UseVisualStyleBackColor = false;
            // 
            // btn_ViewActiveProfessors
            // 
            btn_ViewActiveProfessors.BackColor = Color.DimGray;
            btn_ViewActiveProfessors.FlatStyle = FlatStyle.Flat;
            btn_ViewActiveProfessors.ForeColor = Color.White;
            btn_ViewActiveProfessors.Location = new Point(1016, 623);
            btn_ViewActiveProfessors.Name = "btn_ViewActiveProfessors";
            btn_ViewActiveProfessors.Size = new Size(151, 23);
            btn_ViewActiveProfessors.TabIndex = 15;
            btn_ViewActiveProfessors.Text = "View Active Professors";
            btn_ViewActiveProfessors.UseVisualStyleBackColor = false;
            btn_ViewActiveProfessors.Click += btn_ViewActiveProfessors_Click;
            // 
            // uc_ActiveProfessors1
            // 
            uc_ActiveProfessors1.Location = new Point(260, 56);
            uc_ActiveProfessors1.Name = "uc_ActiveProfessors1";
            uc_ActiveProfessors1.Size = new Size(947, 499);
            uc_ActiveProfessors1.TabIndex = 16;
            uc_ActiveProfessors1.Visible = false;
            // 
            // frm_StudentServiceADMIN
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1455, 679);
            Controls.Add(uc_ActiveProfessors1);
            Controls.Add(btn_ViewActiveProfessors);
            Controls.Add(btn_ViewActiveStudents);
            Controls.Add(uc_AddProfessor1);
            Controls.Add(uc_AddStudent1);
            Controls.Add(txtBox_NetworkStatus);
            Controls.Add(button_LogOut);
            Name = "frm_StudentServiceADMIN";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Service";
            Load += frm_StudentServiceADMIN_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBox_NetworkStatus;
        private Button button_LogOut;
        private UC_AddStudent uc_AddStudent1;
        private UC_AddProfessor uc_AddProfessor1;
        internal Button btn_ViewActiveStudents;
        internal Button btn_ViewActiveProfessors;
        private UC_ActiveProfessors uc_ActiveProfessors1;
    }
}