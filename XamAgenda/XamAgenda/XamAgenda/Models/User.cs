using System.Collections.Generic;
using SQLite.Net.Attributes;
using System;

namespace XamAgenda.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        
        //public Contact UserContact { get; set; }

        public IList<Appointment> appointments = new List<Appointment>();
        public IList<Contact> UserContactList = new List<Contact>();

        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
            //UserContact = null;
        }

        public User(string username, string pass)
        {
            Username = username;
            Password = pass;
        }

        //public override string ToString()
        //{
        //    return string.Format("{0} {1} {2} {3}", Username, Name, Email, Address);
        //}
    }
}