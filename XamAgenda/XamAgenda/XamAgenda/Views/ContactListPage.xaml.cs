using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamAgenda.Data;
using XamAgenda.Models;
using XamAgenda.ViewModels;
using System.Collections.Generic;

namespace XamAgenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactListPage : ContentPage
    {
        
        public ContactListPage()
        {
            InitializeComponent();
            BindingContext = new ContactListViewModel();
        }
        // TODO: PASAR AL VIEWMODEL
        public async void OnContactTappedEvent(object sender, ItemTappedEventArgs e)
        {
            var contact = (Contact)e.Item;
            if (contact == null)
                return;

            await Navigation.PushAsync(new ContactDetailsPage(contact));
        }

        private async void newContactToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateContactPage());
        }

        //private void ContactSearchBar_SearchButtonPressed(object sender, EventArgs e)
        //{
        //    var keyword = ContactSearchBar.Text;
        //    var suggestions = Contactos.Where(c => c.Name.ToLower().Contains(keyword.ToLower()));
        //    //var s = from c in users where c.Contains(keyword) select c;
        //    ContactListView.ItemsSource = suggestions;
        //}
    }
}