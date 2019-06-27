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
            TotalAmt = TotalAmt - s.Amt;
            OrderGridListObservCollection.Remove(s);
        }

        private async Task AddInGridAsync()
        {
            if (Numbers.ToString().Length==2 || Numbers.ToString().Length==4 || Numbers.ToString().Length == 5)
            {
                foreach(var item in ListItemVal)
                {
                    if (item.chkEarly1 == true)
                    {
                        OrderGridModel Val1 = new OrderGridModel();
                        Val1.Amt = Convert.ToDecimal(Amt);
                        Val1.Numbers = Convert.ToInt32(Numbers);
                        Val1.SB = "S";
                        Val1.House = item.Early1;
                        OrderGridListObservCollection.Add(Val1);
                        TotalAmt = TotalAmt + Val1.Amt;
                    }
                    if (item.chkEarly2 == true)
                    {
                        OrderGridModel Val2 = new OrderGridModel();
                        Val2.Amt = Convert.ToDecimal(Amt);
                        Val2.Numbers = Convert.ToInt32(Numbers);
                        Val2.SB = "S";
                        Val2.House = item.Early2;
                        OrderGridListObservCollection.Add(Val2);
                        TotalAmt = TotalAmt + Val2.Amt;
                    }
                    if (item.chkEarly3 == true)
                    {
                        OrderGridModel Val3 = new OrderGridModel();
                        Val3.Amt =Convert.ToDecimal( Amt);
                        Val3.Numbers = Convert.ToInt32(Numbers);
                        Val3.SB = "S";
                        Val3.House = item.Early3;
                        OrderGridListObservCollection.Add(Val3);
                        TotalAmt = TotalAmt + Val3.Amt;
                    }
                    if (item.chkEarly4 == true)
                    {
                        OrderGridModel Val4 = new OrderGridModel();
                        Val4.Amt = Convert.ToDecimal(Amt);
                        Val4.Numbers =Convert.ToInt32( Numbers);
                        Val4.SB ="S";
                        Val4.House = item.Early4;
                        OrderGridListObservCollection.Add(Val4);
                        TotalAmt = TotalAmt + Val4.Amt;
                    }
                }
               
                Numbers = "";
                SB = "S"; 
                Amt = "";
               
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Message", "Enter Correct  Number.", "Ok");
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
        string lastTransactionNo;
        public string LastTransactionNo
        {
            get { return lastTransactionNo; }
            set
            {
                if (lastTransactionNo != value)
                {
                    lastTransactionNo = value;
                    OnPropertyChanged(nameof(LastTransactionNo));

                }
            }
        }

        string numbers;
        public string Numbers
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

        decimal totalAmt;
        public decimal TotalAmt
        {
            get { return totalAmt; }
            set
            {
                if (totalAmt != value)
                {
                    totalAmt = value;
                    OnPropertyChanged(nameof(TotalAmt));

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

        string amt;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Amt
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
            var TransactionNumberVal = await new loginPageService().GetDetailByUrl(GlobalConstant.GetTrancationNumber+GlobalConstant.UserName);
            if (TransactionNumberVal.Status == 1)
            {
                var wrShiipinglist = JsonConvert.DeserializeObject<string>(TransactionNumberVal.Response.ToString());
                LastTransactionNo = wrShiipinglist;
            }
                SB = "S";
            var UserDetail = await new loginPageService().GetDetailByUrl(GlobalConstant.GetHouseDetail);
            if (UserDetail.Status == 1)
            {
                var wrShiipinglist = JsonConvert.DeserializeObject<List<vw_HousesDetails>>(UserDetail.Response.ToString());
                for(int i=0;i< wrShiipinglist.Count; i++)
                {
                    var Model = new ListOrder();
                    try
                    {
                        Model.Early1 = wrShiipinglist[i].HouseName;
                        Model.chkEarly1 =false/* wrShiipinglist[i].Has4Ball*/;
                        i++;
                    }
                    catch { }
                    try
                    {
                        Model.Early2 = wrShiipinglist[i].HouseName;
                        Model.chkEarly2 = false /*wrShiipinglist[i].Has4Ball*/;
                        i++;
                    }
                    catch { }
                    try
                    {
                        Model.Early3 = wrShiipinglist[i].HouseName;
                        Model.chkEarly3 = false /*wrShiipinglist[i].Has4Ball*/;
                        i++;
                    }
                    catch { }
                    try
                    {
                        Model.Early4 = wrShiipinglist[i].HouseName;
                        Model.chkEarly4 = false /*wrShiipinglist[i].Has4Ball*/;
                    }
                    catch { }
                    ListItemVal.Add(Model);
                }

               //foreach(var Item in wrShiipinglist)
               // {
               //     var Model = new ListOrder();
                   
               //     Model.ECA = "ECA";
               //     Model.chkECA = (Model.ECA == Item.HouseName? Item.Has4Ball:false);
               //     Model.EMI = "EMI";
               //     Model.chkEMI = (Model.EMI == Item.HouseName ? Item.Has4Ball : false);
               //     Model.EGA = "EGA";
               //     Model.chkEGA = (Model.EGA == Item.HouseName ? Item.Has4Ball : false);
               //     Model.ENY = "ENY";
               //     Model.chkENY = (Model.ENY == Item.HouseName ? Item.Has4Ball : false);
               //     Model.ENJ = "ENJ";
               //     Model.chkENJ = (Model.ENJ == Item.HouseName ? Item.Has4Ball : false);
               //     Model.EMIA = "EMIA";
               //     Model.chkEMIA = (Model.EMIA == Item.HouseName ? Item.Has4Ball : false);
               //     Model.LCH = "LCH";
               //     Model.chkLCH = (Model.LCH == Item.HouseName ? Item.Has4Ball : false);

               //     ListItemVal.Add(Model);
                   
               // }

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
