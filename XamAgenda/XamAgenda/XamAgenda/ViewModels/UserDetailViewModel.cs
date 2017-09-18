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
    class UserDetailViewModel : INotifyPropertyChanged
    {
        string modifyButtonText = "Modificar datos";
        Contact datosUsuario = null;
        bool isSaving = true;
        bool modifyModeOn = false;

        public Command ModifyToggleCommand
        {
            get;
        }
        public Command CancelSaveCommand
        {
            get;
        }
        
        public UserDetailViewModel()
        {
            ModifyToggleCommand = new Command(ModifyToggle);
            CancelSaveCommand = new Command(CancelSave);
            DatosUsuario = new Contact(App.test.LoggedInUser.UserContact);
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

        void SaveUserData()
        {
            App.test.LoggedInUser.UserContact = datosUsuario;
        }

        #region Commands

        //bool Validate()
        //{
        //    bool valid = true;

        //    if (string.IsNullOrWhiteSpace(nameEntry.Text))
        //    {
        //        messageLabel.Text = "Debe rellenar al menos el campo de nombre.";
        //        valid = false;
        //    }
        //    return valid;
        //}

        void CancelSave()
        {
            isSaving = false;
            ModifyToggle();
        }

        void ModifyToggle()
        {
            ModifyModeOn = !ModifyModeOn;
            // Guardar datos al desactivar el modo modify
            if (!ModifyModeOn && isSaving)
            {
                SaveUserData();
                isSaving = true; // inicializa para la proxima vez
            }
            ModifyButtonText = modifyModeOn ? "Guardar Datos" : "Modificar Datos";
        }
        #endregion
    }
}
