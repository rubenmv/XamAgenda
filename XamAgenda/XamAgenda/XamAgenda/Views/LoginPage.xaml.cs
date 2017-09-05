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
		public LoginPage ()
		{
			InitializeComponent ();
		}

        // async se utiliza para metodos asincronos. Necesita awaits 
        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        void OnLoginButtonClicked(object sender, EventArgs e)
        {
            if(guestUser.IsToggled)
            {
                LoadMainPage();
                return;
            }
            
            var user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if(isValid)
            {
                App.IsUserLoggedIn = true;
                LoadMainPage();
            }
            else
            {
                messageLabel.Text = "Error de usuario/contraseña";
                passwordEntry.Text = String.Empty;
            }
        }

        void LoadMainPage()
        {
            App.IsUserLoggedIn = true;

            App.Current.MainPage = new MDPage();

            //App.Current.MainPage = new TabbedPage // TabbedPage hereda MultiPage (Children)
            //{
            //    // Multipágina, poblar con colección de páginas de navegación
            //    // Páginas de menú con lista de items y contenido central
            //    Children =
            //    {
            //        new NavigationPage(new ItemsPage())
            //        {
            //            Title = "Browse",
            //            Icon = Device.OnPlatform("tab_feed.png", null, null)
            //        },
            //        new NavigationPage(new AboutPage())
            //        {
            //            Title = "About",
            //            Icon = Device.OnPlatform("tab_about.png", null, null)
            //        },
            //    }
            //};
            
            //Navigation.InsertPageBefore(, this);
            //await Navigation.PopAsync();
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.Username == Constants.Username && user.Password == Constants.Password;
        }
	}
}