using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;

using XamAgenda.Models;
using XamAgenda.Helpers;
using Xamarin.Forms;

namespace XamAgenda.Data
{
    public class TestDataGenerator
    {
        private readonly SQLiteConnection _sqLiteConnection;

        public IList<Contact> contactos = new List<Contact>();
        public IList<User> usuarios = new List<User>();
        public User LoggedInUser = null;

        public TestDataGenerator()
        {
            try
            {
                //_sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

                //_sqLiteConnection.CreateTable<Contact>();
                //_sqLiteConnection.CreateTable<User>();
                //_sqLiteConnection.Insert(new User
                //{
                //    Username = "ruben",
                //    Password = "ruben"
                //});

                //_sqLiteConnection.Insert(new Contact
                //{
                //    Name = "Manuel Fabrega",
                //    Email = "manuel@gmail.com",
                //    Address = "Alfonso Puchades 19",
                //    Photo = "",
                //    Phone = "695652565"
                //});

                //_sqLiteConnection.Insert(new Contact
                //{
                //    Name = "Hector Martinez",
                //    Email = "hector@gmail.com",
                //    Address = "Alfonso Puchades 19",
                //    Photo = "",
                //    Phone = "998754566"
                //});
                ////string query = "CREATE TABLE User()";
                ////_sqLiteConnection.Execute(query);
                //string query = "INSERT INTO Contact VALUES('Ruben Martinez', 'rub3nmv@gmail.com', 'Alfonso Puchades 19', '', '998754566')";
                //_sqLiteConnection.Execute(query);
            }
            catch (SQLiteException e)
            {
                System.Diagnostics.Debug.WriteLine("Excepcion SQL: " + e.Message);
            }

            // Crear usuarios
            User user = new User("ruben", "ruben");
            usuarios.Add(user);
            user = new User("xamarin", "xamarin");
            usuarios.Add(user);

            // Crear contactos
            Contact con = new Contact("Manuel Fabrega", "manuel@gmail.com", "Alfonso Puchades 19", "", "695652565");
            contactos.Add(con);
            con = new Contact("Ruben Martinez", "rub3nmv@gmail.com", "Alfonso Puchades 19", "", "998754566");
            contactos.Add(con);
            // Informacion del usuario
            usuarios[0].UserContact = con;
            con = new Contact("Hector Martinez", "hector@gmail.com", "Alfonso Puchades 19", "", "6632551146");
            contactos.Add(con);
            con = new Contact("Daniel Pujano", "danipu@gmail.com", "Av de los Limones 2", "", "969599666");
            contactos.Add(con);
            con = new Contact("Oscar Fernandez", "oscfer@gmail.com", "Av de Francia 25", "", "555668885");
            contactos.Add(con);

            usuarios[0].UserContactList = contactos;
        }
    }
}
