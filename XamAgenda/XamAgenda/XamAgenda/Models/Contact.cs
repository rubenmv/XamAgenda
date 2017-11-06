using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;


namespace XamAgenda.Models
{
    [Table("Contact")]
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }

        IList<Appointment> appointments = new List<Appointment>();

        public Contact()
        {
            Name = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            Photo = string.Empty;
            Phone = string.Empty;
        }

        public Contact(Contact contact)
        {
            Name = contact.Name;
            Email = contact.Email;
            Address = contact.Address;
            Photo = contact.Photo;
            Phone = contact.Phone;
        }

        public Contact(string name, string email, string address, string photo, string phone)
        {
            Name = name;
            Email = email;
            Address = address;
            Photo = photo;
            Phone = phone;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Email);
        }
    }
}
