using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace XamAgenda.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        private string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }

        IList<Appointment> appointments = new List<Appointment>();

        public User()
        {
            Username = string.Empty;
            Password = string.Empty;
            Name = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            Photo = string.Empty;
            Phone = string.Empty;
        }

        public User(string username, string pass, string name, string email, string address, string photo, string phone)
        {
            Username = username;
            Password = pass;
            Name = name;
            Email = email;
            Address = address;
            Photo = photo;
            Phone = phone;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Username, Name, Email, Address);
        }
    }
}