using JackPot.Model;
using JackPot.Service;
using JackPot.Views;
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
        ICommand btn_PreviousTRX;
             ICommand btn_PrintReceipt; 
            ICommand btn_CloseAddProductView; 
             ICommand btn_PopupCancel;
        ICommand btn_Exact; 
        ICommand btn_Add; 
      
             ICommand btnpurchaseTicket;
        INavigation Navigation;
        ListOrder Model = new ListOrder();

             public ICommand btnPreviousTRX =>
           btn_PreviousTRX ?? (btn_PreviousTRX = new Command(async () => await GoToPreviousTRX()));


        public ICommand btnCloseAddProductView =>
           btn_CloseAddProductView ?? (btn_CloseAddProductView = new Command(async () => await CancelPopUpTenderAsync()));


        public ICommand btnPrintReceipt =>
            btn_PrintReceipt ?? (btn_PrintReceipt = new Command(async () => await ShowSuccessMsg()));

        public ICommand btnPopupCancel =>
   btn_PopupCancel ?? (btn_PopupCancel = new Command(async () => await CancelPopUpTenderAsync()));


        public ICommand btnPurchaseTicket =>
   btnpurchaseTicket ?? (btnpurchaseTicket = new Command(async () => await ShowPopUpTenderAsync()));

        public ICommand btnExact =>
     btn_Exact ?? (btn_Exact = new Command(async () => await CalculateTenderAsync()));


        public ICommand btnAdd =>
     btn_Add ?? (btn_Add = new Command(async () => await AddInGridAsync()));

        public List<ListOrder> ListItemVal { get; set; } = new List<ListOrder>();
        public ObservableRangeCollection<BetCollection> OrderGridListObservCollection { get; set; } = new ObservableRangeCollection<BetCollection>();
        //public List<OrderGridModel> OrderGridList { get; set; } = new List<OrderGridModel>();

        ICommand orderGridCommand;
        public ICommand OrderGridCommand =>
           orderGridCommand ?? (orderGridCommand = new Command<BetCollection>(async (s) => await ExecutOrderGridCommandAsync(s)));
 public async Task GoToPreviousTRX()
        {

            await Navigation.PushModalAsync(new PreviousTRX());
        }
        private async Task ExecutOrderGridCommandAsync(BetCollection s)
        {
            TotalAmt = TotalAmt - s.Amt;
            OrderGridListObservCollection.Remove(s);
        }

        private async Task CalculateTenderAsync()
        {

            Tender = Amt.ToString();

        }

        private async Task ShowSuccessMsg()
        {
            //var BetEntryModel = new RequestTenderModel();
            //int Count = 0;
            //BetEntryModel.TenderAmount = tender;
            //BetEntryModel.PanelUserID = GlobalConstant.UserName;
            //BetEntryModel.Totals =TotalAmt;
            //BetEntryModel.Change = Change;
            //BetEntryModel.CommissionRate = 0;
            //BetEntryModel.UsesFreeBet = false;
            //BetEntryModel.FreeBetAmount =Convert.ToDecimal( tender);
            //BetEntryModel.MintShiftID = 8;
            //BetEntryModel.mdecFreeBetTotal =Convert.ToInt32( TotalAmt);
            
            //foreach (var Item in OrderGridListObservCollection)
            //{
            //    Count = Count + 1;
            //    BetEntryModel.BetCollection.Add(Item);
            //}
            //BetEntryModel.NoOfBets = Count;
             PopUpVisibility = false;
            //var TransactionNumberVal = await new BetEntrySevice().PostBetEntry(BetEntryModel, BetEntry.TrancatioSaveBetEntry);
            //if (TransactionNumberVal.Status == 1)
            //{
                Application.Current.MainPage.DisplayAlert("Message", "Success", "Ok");
            //}
            //else
            //{
            //    Application.Current.MainPage.DisplayAlert("Message", "Error", "Ok");
            //}
            OrderGridListObservCollection.Clear();
            ListItemVal.Clear();
            Amt ="0";
            Numbers = "0";
            TotalAmt = 0;


        }

        public async Task ShowPopUpTenderAsync()
        {

            PopUpVisibility = true;

            BetsTotal = Amt.ToString();
            TotalDue = Amt.ToString();
            var ChangeAmount = Convert.ToInt32(tender) - Convert.ToInt32(Amt);
            Change = ChangeAmount.ToString();
        }

        public async Task CancelPopUpTenderAsync()
        {

            PopUpVisibility = false;
        }

        public bool Validate()
        {
            if (Amt != "" && Convert.ToInt32(Amt)>0)
            {
                //if (Model.chkEarly1 != false || Model.chkEarly2 != false || Model.chkEarly3 != false || Model.chkEarly4 != false)
                //{
                    if (((Numbers==null)?"" : Numbers).Length  > 2 && ((Numbers ==null)?"" : Numbers).Length < 6)
                    {
                       
                        return true;
                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Message", "Enter Correct  Number.", "Ok");
                      
                        return false;
                    }
                //}
                //else
                //{
                //    Application.Current.MainPage.DisplayAlert("Message", "Please Select CheckBox.", "Ok");
                //    return false;
                //}
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Message", "Please Select Amount.", "Ok");
                return false;
            }
        }
        public bool ChecboxCheck = false;
        private async Task AddInGridAsync()
        {
            
            if (Validate())
            {
                foreach (var item in ListItemVal)
                {
                    if (item.chkEarly1 == true)
                    {
                        var TransactionNumberVal = await new loginPageService().GetDetailByUrl(BetEntry.GetLottoGameDetailByHouseIdandBalls + item.Early1Id + "&NoOfBalls=" + Numbers.Trim().Length);
                        if (TransactionNumberVal.Status == 1)
                        {
                            var Val1 = JsonConvert.DeserializeObject<BetCollection>(TransactionNumberVal.Response.ToString());

                            Val1.Amt = Convert.ToDecimal(Amt);
                            Val1.Numbers = Convert.ToInt32(Numbers);
                            Val1.SB = "S";
                            Val1.House = item.Early1;
                            OrderGridListObservCollection.Add(Val1);
                            TotalAmt = TotalAmt + Val1.Amt;
                        }
                        ChecboxCheck = true;
                    }
                    if (item.chkEarly2 == true)
                    {
                        var TransactionNumberVal = await new loginPageService().GetDetailByUrl(BetEntry.GetLottoGameDetailByHouseIdandBalls + item.Early2Id + "&NoOfBalls=" + Numbers.Trim().Length);
                        if (TransactionNumberVal.Status == 1)
                        {
                            var Val2 = JsonConvert.DeserializeObject<BetCollection>(TransactionNumberVal.Response.ToString());
                            Val2.Amt = Convert.ToDecimal(Amt);
                            Val2.Numbers = Convert.ToInt32(Numbers);
                            Val2.SB = "S";
                            Val2.House = item.Early2;
                            OrderGridListObservCollection.Add(Val2);
                            TotalAmt = TotalAmt + Val2.Amt;
                        }
                        ChecboxCheck = true;
                    }
                    if (item.chkEarly3 == true)
                    {
                        var TransactionNumberVal = await new loginPageService().GetDetailByUrl(BetEntry.GetLottoGameDetailByHouseIdandBalls + item.Early3Id + "&NoOfBalls=" + Numbers.Trim().Length);
                        if (TransactionNumberVal.Status == 1)
                        {
                            var Val3 = JsonConvert.DeserializeObject<BetCollection>(TransactionNumberVal.Response.ToString());
                            Val3.Amt = Convert.ToDecimal(Amt);
                            Val3.Numbers = Convert.ToInt32(Numbers);
                            Val3.SB = "S";
                            Val3.House = item.Early3;
                            OrderGridListObservCollection.Add(Val3);
                            TotalAmt = TotalAmt + Val3.Amt;
                        }
                        ChecboxCheck = true;
                    }
                    if (item.chkEarly4 == true)
                    {
                        var TransactionNumberVal = await new loginPageService().GetDetailByUrl(BetEntry.GetLottoGameDetailByHouseIdandBalls + item.Early4Id + "&NoOfBalls=" + Numbers.Trim().Length);
                        if (TransactionNumberVal.Status == 1)
                        {
                            var Val4 = JsonConvert.DeserializeObject<BetCollection>(TransactionNumberVal.Response.ToString());
                            Val4.Amt = Convert.ToDecimal(Amt);
                            Val4.Numbers = Convert.ToInt32(Numbers);
                            Val4.SB = "S";
                            Val4.House = item.Early4;
                            OrderGridListObservCollection.Add(Val4);
                            TotalAmt = TotalAmt + Val4.Amt;
                        }
                        ChecboxCheck = true;
                    }
                }
                if (ChecboxCheck == false)
                {
                    Application.Current.MainPage.DisplayAlert("Message", "Please Select CheckBox.", "Ok");
                }

                //Numbers = "";
                //SB = "S";
                //Amt = "";

            }
           

        }



        bool popUpVisibility;
        public bool PopUpVisibility
        {
            get { return popUpVisibility; }
            set
            {
                if (popUpVisibility != value)
                {
                    popUpVisibility = value;
                    OnPropertyChanged(nameof(PopUpVisibility));

                }
            }
        }

        string change;
        public string Change
        {
            get { return change; }
            set
            {
                if (change != value)
                {
                    change = value;
                    OnPropertyChanged(nameof(Change));

                }
            }
        }


        string tender;
        public string Tender
        {
            get { return tender; }
            set
            {
                if (tender != value)
                {
                    tender = value;
                    OnPropertyChanged(nameof(Tender));
                    calculate();
                }
            }
        }


        string totalDue;
        public string TotalDue
        {
            get { return totalDue; }
            set
            {
                if (totalDue != value)
                {
                    totalDue = value;
                    OnPropertyChanged(nameof(TotalDue));

                }
            }
        }

        string betsTotal;
        public string BetsTotal
        {
            get { return betsTotal; }
            set
            {
                if (betsTotal != value)
                {
                    betsTotal = value;
                    OnPropertyChanged(nameof(BetsTotal));

                }
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

        public void calculate()
        {
            try
            {
                if (tender != "")
                {
                    BetsTotal = Amt.ToString();
                    TotalDue = Amt.ToString();
                    var ChangeAmount = Convert.ToInt32(Amt) - Convert.ToInt32(tender);
                    Change = ChangeAmount.ToString();

                }

                else
                {
                    Change = "0";

                }
            }
            catch { }

        }

        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public async void GetLateHouse()
        {
            var TransactionNumberVal = await new loginPageService().GetDetailByUrl(BetEntry.GetTrancationNumber + GlobalConstant.UserName);
            if (TransactionNumberVal.Status == 1)
            {
                var wrShiipinglist = JsonConvert.DeserializeObject<string>(TransactionNumberVal.Response.ToString());
                LastTransactionNo = wrShiipinglist;
            }
            SB = "S";
            var UserDetail = await new loginPageService().GetDetailByUrl(BetEntry.GetHouseDetail);
            if (UserDetail.Status == 1)
            {
                var wrShiipinglistVal = JsonConvert.DeserializeObject<List<vw_HousesDetails>>(UserDetail.Response.ToString());
                for (int i = 0; i < wrShiipinglistVal.Count; i++)
                {
                    Model = new ListOrder();
                    try
                    {
                        Model.Early1 = wrShiipinglistVal[i].HouseName;
                        Model.chkEarly1 = false;
                        Model.Early1Id = wrShiipinglistVal[i].HouseID;
                        i++;
                    }
                    catch { }
                    try
                    {
                        Model.Early2 = wrShiipinglistVal[i].HouseName;
                        Model.chkEarly2 = false;
                        Model.Early2Id = wrShiipinglistVal[i].HouseID;
                        i++;
                    }
                    catch { }
                    try
                    {
                        Model.Early3 = wrShiipinglistVal[i].HouseName;
                        Model.chkEarly3 = false;
                        Model.Early3Id = wrShiipinglistVal[i].HouseID;
                        i++;
                    }
                    catch { }
                    try
                    {
                        Model.Early4 = wrShiipinglistVal[i].HouseName;
                        Model.chkEarly4 = false;
                        Model.Early4Id = wrShiipinglistVal[i].HouseID;
                    }
                    catch { }
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
