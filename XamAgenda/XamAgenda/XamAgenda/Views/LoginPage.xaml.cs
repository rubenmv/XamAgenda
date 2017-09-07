using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XamAgenda.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAgenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void LoadMainPage()
        {
            App.IsUserLoggedIn = true;

            App.Current.MainPage = new MDPage();
        }

        /// <summary>
        /// Busca usuario y comprueba sus credenciales
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool AreCredentialsCorrect(User user)
        {
            bool valid = false;
            var foundUsers = App.test.usuarios.SingleOrDefault(c => c.Username == user.Username);
            if (foundUsers != null)
            {
                valid = user.Password == foundUsers.Password;
            }

            return valid;
        }

        #region Eventos de boton

        // async se utiliza para metodos asincronos. Necesita awaits 
        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        void OnLoginButtonClicked(object sender, EventArgs e)
        {
            if (guestUser.IsToggled)
            {
                App.test.LoggedInUser = new User("Invitado", "password");
                LoadMainPage();
                return;
            }

            var user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                // Guarda el usuario
                App.test.LoggedInUser = App.test.usuarios.SingleOrDefault(c => c.Username == user.Username); ;
                LoadMainPage();
            }
            else
            {
                messageLabel.Text = "Error de usuario/contraseña";
                passwordEntry.Text = String.Empty;
            }
        }
        #endregion

    }
}