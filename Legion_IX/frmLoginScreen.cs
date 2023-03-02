using Legion_IX.DB;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Legion_IX
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        // Button LOGIN click event
        private async void button_Login_Click(object sender, EventArgs e)
        {
            AtlasDB filterTest = new AtlasDB();

            string database = "FacultyPersonell";
            string collection = "Student";

            //            var pipeline = new BsonArray
            //{
            //    BsonDocument.Parse("{ $match: { email: 'sead.azemi@edu.fit.ba', password: 'undp123' } }")
            //};


            //var pipeline = new BsonDocument[]
            //{
            //    new BsonDocument("$match",
            //    new BsonDocument
            //{
            //        {"email", "sead.azemi@edu.fit.ba"},
            //        {"password", "undp123"}
            //}
            //    )
            //};

            //var pipline2 = BsonArray

            //            new BsonArray
            //{
            //    new BsonDocument("$match",
            //    new BsonDocument("email", "sead.azemi@edu.fit.ba"))
            //};

            //var matchStage = BsonDocument.Parse
            //    (
            //    @"{ $match: { email: {$eq: 'sead.azemi@edu.fit.ba'}, password: {$eq: 'undp123' } } }"
            //    );
            //var pipeline = PipelineDefinitionBuilder<BsonDocument, BsonDocument>.Create(matchStage)

            //var foundAccount = await filterTest.Client.GetDatabase(database).GetCollection<BsonDocument>(collection).AggregateAsync<BsonDocument>(pipeline);

            var pipeline = new BsonDocument[]
            {
    new BsonDocument("$match",
        new BsonDocument
        {
            {"email", "sead.azemi@edu.fit.ba"},
            {"password", "undp123"}
        })
            };

            var foundAccount = await filterTest.Client.GetDatabase(database).GetCollection<BsonDocument>(collection)
                .AggregateAsync<BsonDocument>(pipeline);


            txtBox_DisplayDocument.Text = foundAccount.ToList().ToString();

            foreach (var doc in foundAccount.ToList())
            {
                txtBox_DisplayDocument.Text += (doc.ToJson());
            }
        }

        // DLWMS link (opens in browser)
        private void linkLabel_DLWMSweb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Look for exceptions in case browser is not found
            try
            {
                System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "https://www.fit.ba/student/login.aspx");
            }

            // Catch the said exception if thrown
            catch (Exception ex)
            {
                //MessageBox.Show("Problem has occured", "Opening the link did not work!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                DialogResult mshBoxResult = MessageBox.Show
                    (
                    "Would you like to choose browser?",
                    "--Default Browser not detected--",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                    );

                // Validate dialog result
                if (mshBoxResult == DialogResult.Yes)
                {
                    // Set filter for '.exe' files only
                    openFileDialog_searchForBrowser.Filter = "Executable Files (*.exe)|*.exe";

                    // Set the dialog title
                    openFileDialog_searchForBrowser.Title = "Choose desired browser.";

                    // Assigning the dialog to a variable
                    DialogResult fileDialogResult = openFileDialog_searchForBrowser.ShowDialog(this);

                    // Open the dialog and allow the user to choose
                    if (fileDialogResult == DialogResult.OK)
                    {
                        string selectedFilePath = openFileDialog_searchForBrowser.FileName;
                        System.Diagnostics.Process.Start(selectedFilePath);
                    }
                }
            }
        }
    }
}