using Azure;
using Legion_IX.DB;
using Legion_IX.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Legion_IX.User_Controls
{
    public partial class StudentDownloadedDocs : UserControl
    {

        #region Global vars

        // Variable that hold the chosen options from `comboBox_Subjects` as string (obviously)
        private string? ChosenSubject { get; set; }

        // This is necessary for Accessing the correct Atlas Data Base holding the collections containing the Subject documents (pdf files)
        private string SubjectsStudyYear = LoggedInStudent.theStudent.StudyYear.Replace(" ", "");

        // Basically information describing the files stored on Atlas associated with Student
        List<AtlasFile> Downloadedfiles;

        #endregion Global vars

        public StudentDownloadedDocs()
        {
            InitializeComponent();
        }


        private void DownloadedDocs_Load(object sender, EventArgs e)
        {
            this.Hide();

            PreppingGlobalVarsForUse();

            AddSubjectsToComboBox();
        }


        // Assigning data/instances to Global Variables
        private void PreppingGlobalVarsForUse()
        {
            string DataBase_byStudyYear = LoggedInStudent.theStudent.StudyYear.Replace(" ", "");

            // Assigning the list of subjects to `theStudent` variable belonging to `frmStudentProfile`
            if (LoggedInStudent.theStudent != null)
                LoggedInStudent.theStudent.Subjects = LoggedInStudent.theStudent.StudentDBConnection.Client.GetDatabase(DataBase_byStudyYear).ListCollectionNames().ToList();

            // Disabling adding autoColumns from `DataSource()`
            dgv_Files.AutoGenerateColumns = false;
            dgv_Files.DataSource = null;
        }


        // Adding `Subject` collections from AtlasDB to comboBox
        public void AddSubjectsToComboBox()
        {
            foreach (string subject in LoggedInStudent.theStudent.Subjects)
                comboBox_Subjects.Items.Add(subject);
        }


        private void GetAvailableDocuments()
        {
            if (Downloadedfiles != null && Downloadedfiles.Count == 0)
                Downloadedfiles.Clear();

            // Only continues if something an option has been chosen from `comboBox_Subjects`
            if (CheckForChosenSubject())
            {
                AtlasFile.GetFilesFrom_SQL(out Downloadedfiles, ChosenSubject ?? "N/A");

                // Assigning the List of collections to `DataGridView` source
                LoadToDataGridView();
            }
        }


        // Refreshes DataGridView
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            GetAvailableDocuments();
        }


        // `comboBox_Subjects` option changed event
        private void comboBox_Subjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChosenSubject = comboBox_Subjects.SelectedItem.ToString();

            // Calling the method For Refreshing
            btn_Refresh_Click(sender, e);
        }


        private void dgv_Files_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_Files.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {

                if ((dgv_Files.Columns[e.ColumnIndex] as DataGridViewButtonColumn)?.Text == "Open")
                {

                    AtlasFile selected_File = (dgv_Files.Rows[e.RowIndex].DataBoundItem as AtlasFile) ?? new AtlasFile();

                    bool? whatExtensionAmI = GetClickedFileExtension(in selected_File);

                    if (whatExtensionAmI != null && (bool)whatExtensionAmI)
                    {
                        OpenPDF_File(in selected_File);
                    }

                    else if (whatExtensionAmI != null && !(bool)whatExtensionAmI)
                    {
                        OpenRAR_File(in selected_File);
                    }

                }

                else if ((dgv_Files.Columns[e.ColumnIndex] as DataGridViewButtonColumn)?.Text == "Export")
                {
                    AtlasFile selected_File = (dgv_Files.Rows[e.RowIndex].DataBoundItem as AtlasFile) ?? new AtlasFile();

                    string whichSQLtable = (GetClickedFileExtension(selected_File) == true)? "PDF" : "RAR";

                    saveFileDialog_ExportDocument.Filter = $"(*{selected_File.FileType})|*{selected_File.FileType}";
                    saveFileDialog_ExportDocument.FileName = selected_File.NameOfFile;

                    if(saveFileDialog_ExportDocument.ShowDialog() == DialogResult.OK)
                    {

                        string queryCommand = $"SELECT BinData FROM table_{whichSQLtable}Files WHERE AtlasObjectId = '{selected_File._id.ToString()}'";
                        byte[] binData;

                        using (SQLiteConnection line = new SQLiteConnection(MySQLcustomConnection.myConnection))
                        {

                            line.Open();

                            using (SQLiteCommand command = new SQLiteCommand(queryCommand, line))
                            {
                                binData = (byte[])(command.ExecuteScalar());
                            }

                        }

                        File.WriteAllBytes(saveFileDialog_ExportDocument.FileName, binData);
                    }
                }

            }
        }


        private void OpenPDF_File(in AtlasFile referenceToFile)
        {
            string queryCommand = $"SELECT BinData FROM table_PDFFiles WHERE AtlasObjectId='{referenceToFile._id.ToString()}'";
            byte[] binData;

            using (SQLiteConnection line = new SQLiteConnection(MySQLcustomConnection.myConnection))
            {
                line.Open();

                using (SQLiteCommand command = new SQLiteCommand(queryCommand, line))
                {
                    binData = (byte[])(command.ExecuteScalar());
                }

            }

            string tempFilePath = Path.GetTempFileName();
            File.WriteAllBytes(tempFilePath, binData);


            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = Default_BrowserDirectory.DefaultBrowser;
            psi.Arguments = tempFilePath;

            Process.Start(psi);
        }


        private void OpenRAR_File(in AtlasFile referenceToFile)
        {
            string queryCommand = $"SELECT BinData FROM table_RARFiles WHERE AtlasObjectId = '{referenceToFile._id.ToString()}'";
            byte[] binData;

            using (SQLiteConnection line = new SQLiteConnection(MySQLcustomConnection.myConnection))
            {
                line.Open();

                using (SQLiteCommand command = new SQLiteCommand(queryCommand, line))
                {
                    binData = (byte[])(command.ExecuteScalar());
                }

            }

            string tempFilePath = Path.GetTempFileName();
            File.WriteAllBytes(tempFilePath, binData);

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = Default_WinRAR_Directory.WinRAR_Directory;
            psi.Arguments = tempFilePath;

            Process.Start(psi);

        }


        private bool? GetClickedFileExtension(in AtlasFile clickedFile)
        {
            if (clickedFile.FileType == ".pdf")
                return true;//".pdf";

            else if (clickedFile.FileType == ".rar")
                return false;//".rar";

            return null;
        }


        // Load Data to `DataGridView`
        private void LoadToDataGridView()
        {
            dgv_Files.DataSource = null;
            dgv_Files.DataSource = Downloadedfiles;
        }


        // If `comboBox_Subject` option has been selected
        private bool CheckForChosenSubject()
        {
            if (ChosenSubject == null)
            {
                #region I know the code is a mess, but I wanted to practise delegates and lambda functions
                Action Lambdi = () =>
                {

                    for (int i = 0; i < 3; i++)
                    {
                        this.Invoke(() =>
                        {
                            comboBox_Subjects.ForeColor = Color.Red;
                        });

                        Thread.Sleep(300);

                        this.Invoke(() =>
                        {
                            comboBox_Subjects.ForeColor = Color.Black;
                        });

                        Thread.Sleep(300);
                    }

                    this.Invoke(() => comboBox_Subjects.ForeColor = Color.Black);
                };
                #endregion I know the code is a mess, but I wanted to practise delegates and lambda functions

                Thread blinker = new Thread(new ThreadStart(Lambdi));
                blinker.Start();

                return false;
            }

            return true;
        }

    }
}
