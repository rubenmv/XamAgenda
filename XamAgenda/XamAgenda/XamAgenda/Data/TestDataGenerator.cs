using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XamAgenda.Models;

namespace XamAgenda.Data
{
    class TestDataGenerator
    {
        public IList<Contact> contactos = new List<Contact>();
        public TestDataGenerator()
        {
            // Crear contactos
            Contact con = new Contact("Manuel Fabrega", "manuel@gmail.com", "Alfonso Puchades 19", "", "695652565");
            contactos.Add(con);
            con = new Contact("Ruben Martinez", "rub3nmv@gmail.com", "Alfonso Puchades 19", "", "998754566");
            contactos.Add(con);
            con = new Contact("Hector Martinez", "hector@gmail.com", "Alfonso Puchades 19", "", "6632551146");
            contactos.Add(con);
            con = new Contact("Daniel Pujano", "danipu@gmail.com", "Av de los Limones 2", "", "969599666");
            contactos.Add(con);
            con = new Contact("Oscar Fernandez", "oscfer@gmail.com", "Av de Francia 25", "", "555668885");
            contactos.Add(con);
        }
    }
}
