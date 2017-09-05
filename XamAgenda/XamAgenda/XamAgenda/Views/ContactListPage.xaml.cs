using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamAgenda.Data;
using XamAgenda.Models;
using System.Collections.Generic;

namespace XamAgenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactListPage : ContentPage
    {
        TestDataGenerator datagen;
        IList<Contact> Contactos = new List<Contact>();
        public ContactListPage()
        {
            InitializeComponent();
            datagen = new TestDataGenerator();
            Contactos = datagen.contactos;
            ContactListView.ItemsSource = Contactos;
        }

        private void ContactSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var keyword = ContactSearchBar.Text;
            var suggestions = Contactos.Where(c => c.Name.ToLower().Contains(keyword.ToLower()));
            //var s = from c in users where c.Contains(keyword) select c;
            ContactListView.ItemsSource = suggestions;
        }
    }
}