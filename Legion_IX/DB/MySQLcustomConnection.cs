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
        public static string myConnection = "Data Source = C:\\Users\\quan2um_kille0\\Desktop\\BadChoice_WiseMan\\Legion_IX\\Legion_IX\\DB\\SQLiteDataBase.db";

        public MySQLcustomConnection()
        {
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