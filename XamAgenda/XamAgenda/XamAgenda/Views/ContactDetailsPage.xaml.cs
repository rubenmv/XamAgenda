using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamAgenda.Models;
using XamAgenda.ViewModels;

namespace XamAgenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailsPage : ContentPage
    {
        public ContactDetailsPage()
        {
            InitializeComponent();
        }

        public ContactDetailsPage(Contact contact)
        {
            InitializeComponent();
            BindingContext = new ContactDetailsViewModel(contact);
        }
    }
}