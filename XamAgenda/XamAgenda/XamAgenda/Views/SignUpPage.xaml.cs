using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamAgenda.Models;

namespace XamAgenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        bool Validate()
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(usernameEntry.Text) ||
                string.IsNullOrWhiteSpace(passwordEntry.Text) ||
                string.IsNullOrWhiteSpace(nameEntry.Text))
            {
                messageLabel.Text = "Debe rellenar los campos de usuario, password y nombre.";
                valid = false;
            }
            else
            {
                var foundUsers = App.test.usuarios.SingleOrDefault(c => c.Username == usernameEntry.Text);
                if (foundUsers != null)
                {
                    messageLabel.Text = "El usuario es incorrecto o ya existe";
                    valid = false;
                }
            }

            return valid;
        }

        void LoadMainPage()
        {
            App.IsUserLoggedIn = true;
            App.Current.MainPage = new MDPage();
        }

        void OnSendButtonClicked(object sender, EventArgs e)
        {
            var isValid = Validate();
            
            if (isValid)
            {
                var contact = new Contact
                {
                    Name = nameEntry.Text,
                    Email = emailEntry.Text,
                    Address = addressEntry.Text,
                    Photo = phoneEntry.Text,
                    Phone = phoneEntry.Text,
                };

                var user = new User
                {
                    Username = usernameEntry.Text,
                    Password = passwordEntry.Text,
                    UserContact = contact,
                };

                App.test.usuarios.Add(user);

                App.IsUserLoggedIn = true;
                // Guarda el usuario
                App.test.LoggedInUser = App.test.usuarios.SingleOrDefault(c => c.Username == user.Username); ;
                LoadMainPage();
            }
            else
            {
                passwordEntry.Text = String.Empty;
            }
        }
    }
}