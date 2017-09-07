using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.CompilerServices;
using System.ComponentModel;
using Xamarin.Forms;
using XamAgenda.Models;
using XamAgenda.Views;

namespace XamAgenda.ViewModels
{
    class ContactListViewModel : INotifyPropertyChanged
    {
        INavigation Navigation { get; set; }

        IList<Contact> contactos = null;
        public IList<Contact> Contactos
        {
            get
            {
                return contactos;
            }
            set
            {
                contactos = value;
                OnPropertyChanged();
            }
        }

        public Command SearchCommand
        {
            get;
        }
        

        public ContactListViewModel()
        {
            SearchCommand = new Command(SearchContact);
                Contactos = App.test.LoggedInUser.UserContactList;
        }

        void SearchContact()
        {
            //var keyword = UserSearchBar.Text;
            //var suggestions = users.Where(c => c.ToLower().Contains(keyword.ToLower()));
            ////var s = from c in users where c.Contains(keyword) select c;
            //SuggestionsListView.ItemsSource = suggestions;
        }

        /// <summary>
        /// Abre la pagina de detalles del contacto
        /// </summary>
        public void OnContactTappedEvent(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContactDetailsPage());
        }
        
        #region Implementacion interfaz PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        /// CallerMemberName hace que no sea necesario, en cada propiedad de la clase (Title, etc),
        /// poner OnPropertyChanged(nameof(Title))
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            // ? means is not null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
