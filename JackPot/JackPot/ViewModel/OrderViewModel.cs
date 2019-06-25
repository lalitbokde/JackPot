using JackPot.Model;
using JackPot.Service;
using MvvmHelpers;
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
    public class OrderViewModel : INotifyPropertyChanged
    {
        ICommand btn_Add;
        INavigation Navigation;

        public ICommand btnAdd =>
       btn_Add ?? (btn_Add = new Command(async () => await AddInGridAsync()));
        public List<ListOrder> ListItemVal { get; set; } = new List<ListOrder>();
        public ObservableRangeCollection<OrderGridModel> OrderGridListObservCollection { get; set; } = new ObservableRangeCollection<OrderGridModel>();
        //public List<OrderGridModel> OrderGridList { get; set; } = new List<OrderGridModel>();

        ICommand orderGridCommand;
        public ICommand OrderGridCommand =>
           orderGridCommand ?? (orderGridCommand = new Command<OrderGridModel>(async (s) => await ExecutOrderGridCommandAsync(s)));

        private async Task ExecutOrderGridCommandAsync(OrderGridModel s)
        {
            OrderGridListObservCollection.Remove(s);
        }

        private async Task AddInGridAsync()
        {
            if (Numbers != 0 && Numbers!=null)
            {
                OrderGridModel Val = new OrderGridModel();
                Val.Amt = Amt;
                Val.Numbers = Numbers;
                Val.SB = SB;
                Val.House = "EMI";
                OrderGridListObservCollection.Add(Val);
                Numbers = 0;
                SB = "";
                Amt = 0;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Message", "Enter Number.", "Ok");
            }

        }

        string house;
        public string House
        {
            get { return house; }
            set
            {
                if (house != value)
                {
                    house = value;
                    OnPropertyChanged(nameof(House));

                }
            }
        }
        int numbers;
        public int Numbers
        {
            get { return numbers; }
            set
            {
                if (numbers != value)
                {
                    numbers = value;
                    OnPropertyChanged(nameof(Numbers));

                }
            }
        }
        string sb;
        public string SB
        {
            get { return sb; }
            set
            {
                if (sb != value)
                {
                    sb = value;
                    OnPropertyChanged(nameof(SB));

                }
            }
        }

        decimal amt;

        public event PropertyChangedEventHandler PropertyChanged;

        public decimal Amt
        {
            get { return amt; }
            set
            {
                if (amt != value)
                {
                    amt = value;
                    OnPropertyChanged(nameof(Amt));

                }
            }
        }
        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public async void GetLateHouse()
        {
            var UserDetail = await new loginPageService().GetDetailByUrl(GlobalConstant.GetHouseDetail);
            if (UserDetail.Status == 1)
            {
                var wrShiipinglist = JsonConvert.DeserializeObject<List<vw_HousesDetails>>(UserDetail.Response.ToString());
               foreach(var Item in wrShiipinglist)
                {
                    var Model = new ListOrder();
                   
                    Model.ECA = "ECA";
                    Model.chkECA = (Model.ECA == Item.HouseName? Item.Has4Ball:false);
                    Model.EMI = "EMI";
                    Model.chkEMI = (Model.EMI == Item.HouseName ? Item.Has4Ball : false);
                    Model.EGA = "EGA";
                    Model.chkEGA = (Model.EGA == Item.HouseName ? Item.Has4Ball : false);
                    Model.ENY = "ENY";
                    Model.chkENY = (Model.ENY == Item.HouseName ? Item.Has4Ball : false);
                    Model.ENJ = "ENJ";
                    Model.chkENJ = (Model.ENJ == Item.HouseName ? Item.Has4Ball : false);
                    Model.EMIA = "EMIA";
                    Model.chkEMIA = (Model.EMIA == Item.HouseName ? Item.Has4Ball : false);
                    
                    ListItemVal.Add(Model);
                   
                }

            }
            else
            {

                Application.Current.MainPage.DisplayAlert("Message", "UserName Or Password Is Incorrect.", "Ok");

            }
        }
        public OrderViewModel(INavigation navigation)
        {
            GetLateHouse();

            Navigation = navigation;
        }
      
    }
}
