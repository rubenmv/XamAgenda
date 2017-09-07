using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamAgenda.Models;
using XamAgenda.ViewModels;
using XamAgenda.Helpers;

namespace XamAgenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailsPage : ContentPage
    {
        public ContactDetailsPage()
        {
            InitializeComponent();
        }

        public ContactDetailsPage(Contact contact)
        {
            InitializeComponent();
            BindingContext = new ContactDetailsViewModel(contact);
        }
        //public string ToNumber(string raw)
        //{
        //    if (string.IsNullOrWhiteSpace(raw))
        //        return null;

        //    raw = raw.ToUpperInvariant();

        //    var newNumber = new StringBuilder();
        //    foreach (var c in raw)
        //    {
        //        if (" -0123456789".Contains(c.ToString()))
        //            newNumber.Append(c);
        //        else
        //        {
        //            var result = TranslateToNumber(c);
        //            if (result != null)
        //                newNumber.Append(result);
        //            // Bad character?
        //            else
        //                return null;
        //        }
        //    }
        //    return newNumber.ToString();
        //}

        //bool Contains(this string keyString, char c)
        //{
        //    return keyString.IndexOf(c) >= 0;
        //}

        //readonly string[] digits = {
        //    "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
        //};

        //int? TranslateToNumber(char c)
        //{
        //    for (int i = 0; i < digits.Length; i++)
        //    {
        //        if (digits[i].Contains(c.ToString()))
        //            return 2 + i;
        //    }
        //    return null;
        //}
    

    async void CallButton_Clicked(object sender, EventArgs e)
        {
            //string translatedNumber = ToNumber(PhoneEntry.Text);
            if (await this.DisplayAlert(
                    "Dial a Number",
                    "Would you like to call " + PhoneEntry.Text + "?",
                    "Yes",
                    "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                    dialer.Dial(PhoneEntry.Text);
            }
        }
    }
}