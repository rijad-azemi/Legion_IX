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
            SuspendLayout();
            // 
            // comboBox_Subjects
            // 
            comboBox_Subjects.FormattingEnabled = true;
            comboBox_Subjects.Location = new Point(96, 32);
            comboBox_Subjects.Name = "comboBox_Subjects";
            comboBox_Subjects.Size = new Size(230, 23);
            comboBox_Subjects.TabIndex = 0;
            // 
            // StudentDocuments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBox_Subjects);
            Name = "StudentDocuments";
            Size = new Size(415, 150);
            Load += StudentDocuments_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox_Subjects;
    }
}
