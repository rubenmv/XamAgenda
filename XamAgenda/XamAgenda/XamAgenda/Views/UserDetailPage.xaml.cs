using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamAgenda.ViewModels;

namespace XamAgenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailPage : ContentPage
    {
        public UserDetailPage()
        {
            InitializeComponent();
            BindingContext = new UserDetailViewModel();
        }

        private void SalirToolbarItem_Clicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}