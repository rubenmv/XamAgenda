using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamAgenda.Models;

namespace XamAgenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateContactPage : ContentPage
    {
        public CreateContactPage()
        {
            InitializeComponent();
        }

        bool Validate()
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(nameEntry.Text))
            {
                messageLabel.Text = "Debe rellenar al menos el campo de nombre.";
                valid = false;
            }
            return valid;
        }
        
        private void createButton_Clicked(object sender, EventArgs e)
        {
            var isValid = Validate();

            if (isValid)
            {
                var contact = new Contact
                {
                    Name = nameEntry.Text,
                    Email = emailEntry.Text,
                    Address = addressEntry.Text,
                    Photo = phoneEntry.Text,
                    Phone = phoneEntry.Text,
                };


                App.test.LoggedInUser.UserContactList.Add(contact);
                
                Navigation.PopAsync();
            }
        }
    }
}