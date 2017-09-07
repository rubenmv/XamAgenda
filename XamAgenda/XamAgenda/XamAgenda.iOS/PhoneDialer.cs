using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using XamAgenda.Helpers;
using Xamarin.Forms;
using XamAgenda.iOS;

[assembly: Dependency(typeof(PhoneDialer))]
namespace XamAgenda.iOS
{
    class PhoneDialer : IDialer
    {
        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + number));
        }
    }
}