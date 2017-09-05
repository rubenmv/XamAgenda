using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Xamarin.Forms;

namespace XamAgenda.ViewModels
{
    class UserDetailViewModel : INotifyPropertyChanged
    {
        public UserDetailViewModel()
        {
            ModifyToggleCommand = new Command(ModifyToggle);
        }

        public Command ModifyToggleCommand
        {
            get;
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

        bool modifyModeOn = false;

        public bool ModifyModeOn
        {
            get
            {
                return modifyModeOn;
            }
            set
            {
                modifyModeOn = value;
                OnPropertyChanged();
            }
        }

        string modifyButtonText = "Modificar datos";
        public string ModifyButtonText
        {
            get { return modifyButtonText; }
            set
            {
                modifyButtonText = value;
                OnPropertyChanged();
            }
        }

        void ModifyToggle()
        {
            try
            {
                ModifyModeOn = !ModifyModeOn;
                ModifyButtonText = modifyModeOn ? "Guardar Datos" : "Modificar Datos";
            }
            catch
            {

            }
        }
    }
}
