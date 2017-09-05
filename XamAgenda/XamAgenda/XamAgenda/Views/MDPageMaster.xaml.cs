using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamAgenda.Models;

namespace XamAgenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPageMaster : ContentPage
    {
        public ListView ListView;

        public MDPageMaster()
        {
            InitializeComponent();

            BindingContext = new MDPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MDPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MDPageMenuItem> MenuItems { get; set; }

            public MDPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MDPageMenuItem>(new[]
                {
                    new MDPageMenuItem { Id = 0, Title = "Mis Datos", TargetType = typeof(UserDetailPage) },
                    new MDPageMenuItem { Id = 1, Title = "Contactos", TargetType = typeof(ContactListPage) },
                    new MDPageMenuItem { Id = 2, Title = "About", TargetType = typeof(AboutPage) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}