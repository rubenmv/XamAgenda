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
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            BindingContext = new AboutViewModel();
        }

        public void OpenWebsite()
        {
            Device.OpenUri(new Uri("http://rubenmartinez.es/"));
        }
    }
}