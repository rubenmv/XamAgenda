using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamAgenda.Models
{
    class Contact
    {
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
