using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAgenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        List<string> users = new List<string>
        {
            "ruben", "manuel", "hector", "maria", "gemma"
        };

        public SearchPage()
        {
            InitializeComponent();
        }

        private void UserSearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var keyword = UserSearchBar.Text;
            var suggestions = users.Where(c => c.ToLower().Contains(keyword.ToLower()));
            //var s = from c in users where c.Contains(keyword) select c;
            SuggestionsListView.ItemsSource = suggestions;
        }
    }
}