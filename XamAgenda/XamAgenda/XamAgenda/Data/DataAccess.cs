using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamAgenda.Helpers;
using XamAgenda.Models;

namespace XamAgenda.Data
{
    class DataAccess
    {
        SQLiteConnection dbConn;
        public DataAccess()
        {
            dbConn = DependencyService.Get<ISQLite>().GetConnection();
            // create the table(s)
            dbConn.CreateTable<User>();
        }
        public List<User> GetAllContacts()
        {
            return dbConn.Query<User>("Select * From [User]");
        }
        public int SaveContact(User aContact)
        {
            return dbConn.Insert(aContact);
        }
        public int DeleteContact(User aContact)
        {
            return dbConn.Delete(aContact);
        }
        public int EditContact(User aContact)
        {
            return dbConn.Update(aContact);
        }
    }
}
