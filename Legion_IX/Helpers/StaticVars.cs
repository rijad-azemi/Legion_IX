using Legion_IX.DB;
using Legion_IX.Users;
using Microsoft.AspNetCore.Routing;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.Helpers
{
    internal abstract class LoggedInProfessor
    {
        internal static Professor theProf { get; set; } = new Professor();
    }


    internal abstract class LoggedInStudent
    {
        internal static Student theStudent { get; set; } = new Student();
    }


    internal abstract class RequestCancel
    {
        internal static CancellationTokenSource killProccess { get; set; } = new CancellationTokenSource();
    }


    internal abstract class Default_BrowserDirectory
    {
        internal static string? DefaultBrowser { get; set; } = GetDefaultBrowserFrom_SQL();
        internal static string SQL_DBConnection { get; } = MySQLcustomConnection.myConnection;


        // Gets the dafault browser from SQL database
        internal static string? GetDefaultBrowserFrom_SQL()
        {
            string queryCommand = "SELECT DefaultBrowserPath FROM table_DefaultBrowser LIMIT 1;";

            string? defaultBrowserDirectory = null;

            try
            {

                using (SQLiteConnection line = new SQLiteConnection(SQL_DBConnection))
                {

                    line.Open();

                    using (SQLiteCommand command = new SQLiteCommand(queryCommand, line))
                    {

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                                defaultBrowserDirectory = reader.GetString(0);

                        }

                    }

                }

                return defaultBrowserDirectory;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Would you like to add a default browser manually?", ex.Message, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            return defaultBrowserDirectory;
        }


        // Updates the existing or adds a new default browser path to SQL database
        internal static void Update_or_Add_BrowserToSQL(string? path)
        {

            string queryCommand = "UPDATE table_DefaultBrowser SET DefaultBrowserPath = @NewPath";

            try
            {

                using (SQLiteConnection line = new SQLiteConnection(SQL_DBConnection))
                {
                    line.Open();

                    using(SQLiteCommand command = new SQLiteCommand(queryCommand, line))
                    {
                        command.Parameters.AddWithValue("@NewPath", path);
                        command.ExecuteNonQuery();
                    }

                }

            }

            catch (Exception)
            {
                MessageBox.Show("Method `Update_or_Add_BrowserToSQL` at `StaticVars.cs` encountered a problem",
                                "Problem encountered with SQL DB",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }


        // Checks to see if `DefaultBrowser` is set
        internal static bool CheckIfDefaultBrowserSet()
        {
            if (DefaultBrowser.IsNullOrEmpty())
                return false;

            else
                return true;
        }
    }


    internal abstract class Default_WinRAR_Directory
    {
        internal static string? WinRAR_Directory { get; set; } = GetWinRAR_dir_From_SQL();
        

        // Gets WinRAR directory from SQL database
        internal static string? GetWinRAR_dir_From_SQL()
        {
            string queryCommand = "SELECT WinrarDirectory FROM table_WinrarDirectory LIMIT 1;";

            string? winrarDirectory = null;

            try
            {

                using(SQLiteConnection line = new SQLiteConnection( Default_BrowserDirectory.SQL_DBConnection ))
                {

                    line.Open();

                    using(SQLiteCommand command = new SQLiteCommand(queryCommand, line))
                    {

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {

                            if(reader.Read())
                                winrarDirectory = reader.GetString(0);

                        }

                    }

                }

                return winrarDirectory;

            }

            catch (Exception)
            {
                MessageBox.Show("Method `GetWinRAR_dir_From_SQL` at `StaticVars.cs` encountered a problem",
                "Problem encountered with SQL DB",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

            return winrarDirectory;


        }


        // Updates the existing or adds a new WinRAR path to SQL database
        internal static void Update_or_Add_WinRAR_ToSQL(string path)
        {
            string queryCommand = "UPDATE table_WinrarDirectory SET WinrarDirectory = @NewPath";

            using (SQLiteConnection line = new SQLiteConnection(Default_BrowserDirectory.SQL_DBConnection))
            {
                line.Open();

                using (SQLiteCommand execute = new SQLiteCommand(queryCommand, line))
                {
                    execute.Parameters.AddWithValue("@NewPath", path);
                    execute.ExecuteNonQuery();
                }

            }
        }


        // Checks to see if the directory is set properly or at all
        internal static bool CheckIfWinRAR_dirSet()
        {
            if (WinRAR_Directory == null || WinRAR_Directory.IsNullOrEmpty() || Path.GetFileName(WinRAR_Directory) != "WinRAR.exe")
                return false;

            else
                return true;
        }
    }
}