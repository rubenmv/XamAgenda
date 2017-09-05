using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Threading.Tasks;

namespace XamAgenda.ViewModels
{
    class AboutViewModel : INotifyPropertyChanged
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public AboutViewModel() { }

        public void OpenWebCommand()
        {

        }

        public string displayMessage = string.Empty;

        public string DisplayMessage
        {
            get { return $"This is the message: {Title}";  }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// CallerMemberName hace que no sea necesario, en cada propiedad de la clase (Title, etc),
        /// poner OnPropertyChanged(nameof(Title))
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            // ? means is not null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
