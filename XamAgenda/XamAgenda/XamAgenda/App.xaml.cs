using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamAgenda.Views;
using XamAgenda.Data;

namespace XamAgenda
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static TestDataGenerator test = null;
        public App()
        {
            InitializeComponent();
            test = new TestDataGenerator();

            // Set main page
            // Master Detail page debe ser el root
            if (!IsUserLoggedIn)
            {
                Current.MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                Current.MainPage = new NavigationPage(new MDPage());
            }
        }
        static DataAccess dbUtils;
        static DataAccess DAUtil
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new DataAccess();
                }
                return dbUtils;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
