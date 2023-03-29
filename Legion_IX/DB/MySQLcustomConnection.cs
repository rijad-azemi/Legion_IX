using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legion_IX.DB
{
    public class MySQLcustomConnection : DbContext
    {
        // Gets a connection string to SQL
        public static string myConnection = "Data Source = " + GetSQL_Directory(); // I also lost like 35 minutes here, Because I was giving this variable a path that had no
                                                                                   // "Data Source = " at the begining. I thought that 15 cups of coffe from this morning would
                                                                                   // help me... HahaHaHAhaaHAHA
                                                                                   //    'laughing in faulty brain cells'
        public MySQLcustomConnection()
        {
        }

        public static string GetSQL_Directory()
        {
            string projectDirectory = Directory.GetCurrentDirectory();

            // Going down one directory until the project file is found. This is done in order to reach the `DB` folder
            while (!File.Exists(Path.Combine(projectDirectory, "Legion_IX.csproj")))
            {
                projectDirectory = Directory.GetParent(projectDirectory).FullName;
            }

            projectDirectory = Path.Combine(projectDirectory, "DB", "SQLiteDataBase.db");

            return projectDirectory;
        }

        // This method gets automatically called on application startup and connects the already existing SQLite `.db` file to the app
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(myConnection);
        }

        public DbSet<UserSettings> table_UserSettings{ get; set; }
    }

    // Class for User Settings
    public class UserSettings
    {
        // Classic User Information
        public int Id { get; set; }
        public string? UserName { get; set; } = null;
        public string? Email { get; set; } = null;

        // User Preferance
        public string? BrowserDirectory { get; set; } = null;

        public UserSettings()
        {
            // `Id` field is assigned by SQLite itself
            UserName = null;
            Email = null;
            BrowserDirectory = null;
        }

        public UserSettings(UserSettings settings)
        {
            UserName = settings.UserName;
            Email = settings.Email;
            BrowserDirectory = settings.BrowserDirectory;
        }

        public UserSettings(string? username, string? email, string? browserDirectory)
        {
            UserName = username;
            Email = email;
            BrowserDirectory = browserDirectory;
        }
    }

}