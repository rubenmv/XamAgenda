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
        Contact selectedItem = null;

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

        public Command TappedCommand
        {
            get;
        }


        public Contact SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }


        public ContactListViewModel()
        {
            SearchCommand = new Command(SearchContact);
            //TappedCommand = new Command(OnItemTapped);
            Contactos = App.test.LoggedInUser.UserContactList;
        }
        
        /// <summary>
        /// Abre informacion de contacto seleccionado
        /// </summary>
        //void OnItemTapped()
        //{
        //    if (selectedItem == null)
        //        return;
        //    Navigation.PushAsync(new ContactDetailsPage(selectedItem, position));

        //}

        void SearchContact()
        {
            //var keyword = UserSearchBar.Text;
            //var suggestions = users.Where(c => c.ToLower().Contains(keyword.ToLower()));
            ////var s = from c in users where c.Contains(keyword) select c;
            //SuggestionsListView.ItemsSource = suggestions;
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
