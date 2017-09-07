using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Xamarin.Forms;

using XamAgenda.Models;

namespace XamAgenda.ViewModels
{
    class ContactDetailsViewModel : INotifyPropertyChanged
    {
        string modifyButtonText = "Modificar contacto";
        Contact datosUsuario = null;
        bool modifyModeOn = false;

        public Command ModifyToggleCommand
        {
            get;
        }

        public ContactDetailsViewModel(Contact contact)
        {
            ModifyToggleCommand = new Command(ModifyToggle);
            DatosUsuario = contact;
        }

        #region Implementacion de la interfaz PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        // CallerMemberName hace que no sea necesario, en cada propiedad de la clase (Title, etc),
        // poner OnPropertyChanged(nameof(Title))
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            // ? means is not null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region Propiedades para binding
        
        public Contact DatosUsuario
        {
            get
            {
                return datosUsuario;
            }
            set
            {
                datosUsuario = value;
                OnPropertyChanged();
            }
        }

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

        public string ModifyButtonText
        {
            get { return modifyButtonText; }
            set
            {
                modifyButtonText = value;
                OnPropertyChanged();
            }
        }
        #endregion

        void ModifyToggle()
        {
            ModifyModeOn = !ModifyModeOn;
            ModifyButtonText = modifyModeOn ? "Guardar contacto" : "Modificar contacto";
        }
    }
}
