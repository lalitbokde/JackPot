using JackPot.Model;
using JackPot.PCL;
using JackPot.Service;
using JackPot.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WareHouseManagement.PCL.Common;
using Xamarin.Forms;

namespace JackPot.ViewModel
{
    public class LogInViewModel: INotifyPropertyChanged
    {
        SharedPreference _objShared = new SharedPreference();
        ICommand btn_LogIn;
        INavigation Navigation;
        public ICommand btnLogIn =>
         btn_LogIn ?? (btn_LogIn = new Command(async () => await LogInAsync()));

        private async Task LogInAsync()
        {
           
            
           LogintModel _User = new LogintModel
            {
                UserName =Convert.ToInt64( UserName),
                Password = PassWord
            };
            if (UserName == "" || UserName == null)
            {
                Application.Current.MainPage.DisplayAlert("Message", "Enter UserName.", "Ok");
            }
            else if (PassWord == null || PassWord == "")
            {
                Application.Current.MainPage.DisplayAlert("Message", "Enter Password.", "Ok");
            }
            else
            {
              
                var UserDetail = await new loginPageService().GetLogin(_User, GlobalConstant.GetUserLoginDetail);
                if (UserDetail.Status == 1)
                {
                  var  wrShiipinglist = JsonConvert.DeserializeObject<LogInModel>(UserDetail.Response.ToString());
                    GlobalConstant.UserName = wrShiipinglist.iPanelUserID;
                    GlobalConstant.UserPassword = wrShiipinglist.sPassword;
                    GlobalConstant.CustomerName = wrShiipinglist.sFirstName + " " + wrShiipinglist.sLastName;
                    GlobalConstant.BalanceAmt = wrShiipinglist.decBalance;
                    GlobalConstant.LocationId = wrShiipinglist.iLocationID;
                    _objShared.SaveApplicationProperty("AccessToken", GlobalConstant.AccessToken);
                    _objShared.SaveApplicationProperty("UserName", GlobalConstant.UserName);
                    _objShared.SaveApplicationProperty("CustomerName", GlobalConstant.CustomerName);
                    _objShared.SaveApplicationProperty("UserPassword", GlobalConstant.UserPassword);

                    await Navigation.PushModalAsync(new MainPage());
                }
                else
                {

                    Application.Current.MainPage.DisplayAlert("Message", "UserName Or Password Is Incorrect.", "Ok");

                }
            }
        }

        private async Task AutoLogin(string username, string password)
        {

            try
            {


                LogintModel _User = new LogintModel
                {
                    UserName = Convert.ToInt64(username),
                    Password =password
                };

              

                var UserDetail = await new loginPageService().GetLogin(_User, GlobalConstant.GetUserLoginDetail);
                if (UserDetail.Status == 1)
                {
                    var wrShiipinglist = JsonConvert.DeserializeObject<LogInModel>(UserDetail.Response.ToString());
                    GlobalConstant.UserName = wrShiipinglist.iPanelUserID;
                    GlobalConstant.UserPassword = wrShiipinglist.sPassword;
                    GlobalConstant.CustomerName = wrShiipinglist.sFirstName + " " + wrShiipinglist.sLastName;
                    GlobalConstant.BalanceAmt = wrShiipinglist.decBalance;
                    GlobalConstant.LocationId = wrShiipinglist.iLocationID;
                    await Navigation.PushModalAsync(new MainPage());
                }
                else
                {

                    Application.Current.MainPage.DisplayAlert("Message", "UserName Or Password Is Incorrect.", "Ok");

                }
            }
            catch(Exception ex)
            {

            }
           

        }


            public LogInViewModel(INavigation navigation)
        {
            UserName = "400";
            PassWord = "1234";
            Navigation = navigation;

            var UserNameAuto = _objShared.LoadApplicationProperty<string>("UserName");

            var UserPasswordAuto = _objShared.LoadApplicationProperty<string>("UserPassword");

            if (UserNameAuto != null && UserPasswordAuto != null)
            {
                AutoLogin(UserNameAuto, UserPasswordAuto);
            }
           
        }

        private string _UserName;
        public string UserName
        {
            get { return  _UserName; }
            set
            {
                _UserName = value.ToString();
                OnPropertyChanged(nameof(UserName));

            }
        }

      



        private string _PassWord;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string PassWord
        {
            get { return _PassWord; }
            set
            {
                _PassWord = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
    }
}
