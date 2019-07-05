using JackPot.PCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JackPot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        SharedPreference _objShared = new SharedPreference();
        public MainPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainPageMenuItem;
            if (item == null)
                return;
            if (item.TargetType != typeof(LogIn))
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                page.Title = item.Title;

                Detail = new NavigationPage(page);
                IsPresented = false;

                MasterPage.ListView.SelectedItem = null;
            }
            else
            {

                Navigation.PopModalAsync();
                _objShared.SaveApplicationProperty("AccessToken", 0);
                _objShared.SaveApplicationProperty("UserName", 0);
                _objShared.SaveApplicationProperty("CustomerName", 0);
                _objShared.SaveApplicationProperty("UserPassword", 0);

            }
        }
    }
}