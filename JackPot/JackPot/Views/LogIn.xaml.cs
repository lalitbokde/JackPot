using JackPot.Model;
using JackPot.Service;
using JackPot.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouseManagement.PCL.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JackPot.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogIn : ContentPage
	{
        LogInViewModel ViewModel;
        public LogIn ()
		{
			InitializeComponent ();
            BindingContext = ViewModel = new LogInViewModel(Navigation);
		}

        private void Btn_login_Clicked(object sender, EventArgs e)
        {
          
        }

        //private async void GetUserLoginAsync()
        //{
        //    LogintModel _User = new LogintModel
        //    {
        //        UserName = Convert.ToInt64( txt_UserName.Text),
        //        Password = txt_PassWord.Text
        //    };
        //    var UserDetail = await new loginPageService().GetLogin(_User, GlobalConstant.GetUserLoginDetail);
        //    if (UserDetail.Status == 1)
        //    {
          


        //        App.Current.MainPage = new NavigationPage(new MainPage());


               
        //    }
        //    else
        //    {
             


        //    }
        //}

        private void Btn_login_Clicked_1(object sender, EventArgs e)
        {
         //   GetUserLoginAsync();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //GetUserLoginAsync();
        }
    }
}