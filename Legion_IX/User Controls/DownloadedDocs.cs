﻿using Azure;
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
    public partial class DownloadedDocs : UserControl
    {

        #region Global vars

        // Directories for starting Browser (opening .pdf preview) and WinRAR(opening .rar preview)
        static string? ChromeLocation = frmLoginScreen.GetBrowserPathFromSQL();
        static string? WinRarLocation = GetWinrarPathFromSQL();

        // Variable that hold the chosen options from `comboBox_Subjects` as string (obviously)
        public string? ChosenSubject { get; set; }

        // This is necessary for Accessing the correct Atlas Data Base holding the collections containing the Subject documents (pdf files)
        public string SubjectsStudyYear = frmStudentProfile.theStudent.StudyYear.Replace(" ", "");


        MySQLcustomConnection SQL_db = new MySQLcustomConnection();


        // Reference variable to `Student` object belonging to `frmStudentProfile`
        Student? theStudent = frmStudentProfile.theStudent;

        // PDF file
        PDF_File? pdf;

        // RAR file
        RAR_File? rar;

        // Basically information describing the files stored on Atlas associated with Student
        List<AtlasFile> Downloadedfiles;

        #endregion Global vars

        public DownloadedDocs()
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
            string DataBase_byStudyYear = theStudent.StudyYear.Replace(" ", "");

            // Assigning the list of subjects to `theStudent` variable belonging to `frmStudentProfile`
            if (theStudent != null)
                theStudent.Subjects = theStudent.StudentDBConnection.Client.GetDatabase(DataBase_byStudyYear).ListCollectionNames().ToList();

            // Creating instance
            pdf = new PDF_File();
            rar = new RAR_File();
            //Downloadedfiles = new List<AtlasFile>();

            // Disabling adding autoColumns from `DataSource()`
            dgv_Files.AutoGenerateColumns = false;
            dgv_Files.DataSource = null;
        }


        // Adding `Subject` collections from AtlasDB to comboBox
        public void AddSubjectsToComboBox()
        {
            foreach (string subject in theStudent.Subjects)
                comboBox_Subjects.Items.Add(subject);
        }


        private void GetAvailableDocuments()
        {
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

                    AtlasFile selectedPDF_File = (dgv_Files.Rows[e.RowIndex].DataBoundItem as AtlasFile) ?? new AtlasFile();

                    bool? whatExtensionAmI = GetClickedFileExtension(in selectedPDF_File);

                    if(whatExtensionAmI != null && (bool)whatExtensionAmI)
                    {
                        OpenPDF_File(in selectedPDF_File);
                    }

                    else if(whatExtensionAmI != null && !(bool)whatExtensionAmI)
                    {
                        OpenRAR_File(in selectedPDF_File);
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
            psi.FileName = ChromeLocation;
            psi.Arguments = tempFilePath;

            Process.Start(psi);
        }


        private void OpenRAR_File(in AtlasFile referenceToFile)
        {
            string queryCommand = $"SELECT BinData FROM table_RARFiles WHERE AtlasObjectId = '{referenceToFile._id.ToString()}'";
            byte[] binData;

            using(SQLiteConnection line = new SQLiteConnection(MySQLcustomConnection.myConnection))
            {
                line.Open();

                using(SQLiteCommand command = new SQLiteCommand(queryCommand, line))
                {
                    binData = (byte[])(command.ExecuteScalar());
                }

            }

            string tempFilePath = Path.GetTempFileName();
            File.WriteAllBytes(tempFilePath, binData);

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = WinRarLocation;
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
                    this.Invoke(() => lbl_StatusMessage.Text = "You Must Choose a Subject.");

                    for (int i = 0; i < 3; i++)
                    {
                        this.Invoke(() =>
                        {
                            comboBox_Subjects.ForeColor = Color.Red;
                            lbl_StatusMessage.ForeColor = Color.Red;
                        });

                        Thread.Sleep(300);

                        this.Invoke(() =>
                        {
                            lbl_StatusMessage.ForeColor = Color.White;
                            comboBox_Subjects.ForeColor = Color.Black;
                        });

                        Thread.Sleep(300);
                    }

                    this.Invoke(() => comboBox_Subjects.ForeColor = Color.Black);
                    this.Invoke(() => lbl_StatusMessage.Text = "");
                };
                #endregion I know the code is a mess, but I wanted to practise delegates and lambda functions

                Thread blinker = new Thread(new ThreadStart(Lambdi));
                blinker.Start();

                return false;
            }

            return true;
        }


        // Get Winrar Directory from SQL
        private static string? GetWinrarPathFromSQL()
        {
            string SQLaccess = MySQLcustomConnection.myConnection;
            string command = "SELECT WinrarDirectory FROM table_WinrarDirectory LIMIT 1;";
            string? directoryFromSQL = null;

            using (SQLiteConnection line = new SQLiteConnection(SQLaccess))
            {
                line.Open();

                using (SQLiteCommand instruction = new SQLiteCommand(command, line))
                {

                    using (SQLiteDataReader reader = instruction.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            directoryFromSQL = reader.GetString(0);
                        }

                    }

                }

            }

            return directoryFromSQL;
        }


    }
}
