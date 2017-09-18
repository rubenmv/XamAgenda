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
        Contact contactoOriginal = null; // referencia al contacto original para guardar
        Contact datosContacto = null; // Copia del contacto para evitar modificaciones al cancelar
        bool modifyModeOn = false;
        bool showCallButton = true;
        bool isSaving = true;
        int contactPosition = 0;

        INavigation navigation = null;

        public Command ModifyToggleCommand
        {
            get;
        }

        public Command CancelSaveCommand
        {
            get;
        }

        public Command DeleteContactCommand
        {
            get;
        }

        public ContactDetailsViewModel(Contact contact, int position, INavigation nv)
        {
            ModifyToggleCommand = new Command(ModifyToggle);
            CancelSaveCommand = new Command(CancelSave);
            DeleteContactCommand = new Command(DeleteContact);
            contactoOriginal = contact;
            DatosContacto = new Contact(contact);
            contactPosition = position;
            navigation = nv;
        }

        /// <summary>
        /// Guarda la informacion del contacto
        /// </summary>
        void SaveContactData()
        {
            contactoOriginal.Name = datosContacto.Name;
            contactoOriginal.Email = datosContacto.Email;
            contactoOriginal.Address = datosContacto.Address;
            contactoOriginal.Photo = datosContacto.Photo;
            contactoOriginal.Phone = datosContacto.Phone;
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

        public Contact DatosContacto
        {
            get
            {
                return datosContacto;
            }
            set
            {
                datosContacto = value;
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

        public bool ShowCallButton
        {
            get
            {
                return showCallButton;
            }
            set
            {
                showCallButton = value;
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

        #region Comandos
        
        /// <summary>
        /// Cancela el guardado de datos
        /// </summary>
        void CancelSave()
        {
            DatosContacto = new Contact(contactoOriginal);
            isSaving = false;
            ModifyToggle();
        }

        /// <summary>
        /// Cambia el estado de modificacion de datos
        /// </summary>
        void ModifyToggle()
        {
            ModifyModeOn = !ModifyModeOn;
            ShowCallButton = !modifyModeOn;
            // Guardar datos al desactivar el modo modify
            if (!ModifyModeOn && isSaving)
            {
                SaveContactData();
                isSaving = true; // inicializa para la proxima vez
            }
            ModifyButtonText = modifyModeOn ? "Guardar Datos" : "Modificar Datos";
        }

        /// <summary>
        /// Borrar contacto
        /// </summary>
        void DeleteContact()
        {
            App.test.LoggedInUser.UserContactList.Remove(contactoOriginal);
            navigation.PopModalAsync();
        }
        #endregion
    }
}
