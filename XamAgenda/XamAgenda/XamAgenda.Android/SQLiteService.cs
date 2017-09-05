using System;
using Xamarin.Forms;
using XamAgenda.Droid;
using System.IO;

using XamAgenda.Helpers;

[assembly: Dependency(typeof(SQLiteService))]
namespace XamAgenda.Droid
{
    public class SQLiteService : ISQLite
    {
        #region ISQLite implementation
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "XamAgenda.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            Console.WriteLine(path);
            if (!File.Exists(path)) File.Create(path);
            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);
            // Return the database connection 
            return conn;
        }

        #endregion
    }
}
