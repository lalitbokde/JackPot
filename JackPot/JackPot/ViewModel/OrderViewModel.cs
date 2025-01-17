﻿using JackPot.Model;
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
        ICommand btn_PreviewLoadExactTransaction;
        ICommand btn_ClosePreviewTicketView;
        ICommand btnpurchaseTicket;
        ICommand btn_PreviousLoadLate;
        ICommand btn_PreviousLoadEarly;
        INavigation Navigation;
        ICommand checkedBarcodeCommand1;
        ICommand checkedBarcodeCommand2;
        ICommand checkedBarcodeCommand3;
        ICommand checkedBarcodeCommand4;
        ICommand Tab_CommandEarly;
        ICommand Tab_CommandLate;

        ListOrder Model = new ListOrder();
        public ObservableRangeCollection<BetCollection> OrderGridListObservCollection { get; set; } = new ObservableRangeCollection<BetCollection>();
        public ICommand btnPreviousTRX =>
   btn_PreviousTRX ?? (btn_PreviousTRX = new Command(async () => await GoToPreviousTRX()));
        public ICommand btnPreviousLoadEarly =>
            btn_PreviousLoadEarly ?? (btn_PreviousLoadEarly = new Command(async () => await GetLoadEarlyPrevious()));
        public ICommand TabCommandEarly =>
  Tab_CommandEarly ?? (Tab_CommandEarly = new Command(async () => await EnableDisableTab("Early")));
        public ICommand TabCommandLate =>
 Tab_CommandLate ?? (Tab_CommandLate = new Command(async () => await EnableDisableTab("Late")));
        private async Task EnableDisableTab(string Type)
        {
            if (Type == "Early")
            {
                EarlyTabVisibility = true;
                LateTabVisibility = false;
                GetLateHouse(false);
                EarlyhouseTabColor =Color.Black;
                LatehouseTabColor = Color.Red;
            }
            else
            {
                GetLateHouse(true);
                EarlyTabVisibility = false;
                LateTabVisibility = true;
                EarlyhouseTabColor = Color.Red;
                LatehouseTabColor = Color.Black;
            }
        }

        public ICommand btnPreviousLoadLate =>
            btn_PreviousLoadLate ?? (btn_PreviousLoadLate = new Command(async () => await LoadDataByPreviousTicket()));


        //public ICommand CheckedBarcodeCommand =>
        //checkedBarcodeCommand1 ?? (checkedBarcodeCommand1 = new Command<WRProductBarcodeModel>(async (s) => await CheckedBarcodeCammandAsync(s)));

        //public ICommand CheckedBarcodeCommand =>
        //checkedBarcodeCommand1 ?? (checkedBarcodeCommand = new Command<WRProductBarcodeModel>(async (s) => await CheckedBarcodeCammandAsync(s)));

        //public ICommand CheckedBarcodeCommand =>
        //checkedBarcodeCommand ?? (checkedBarcodeCommand = new Command<WRProductBarcodeModel>(async (s) => await CheckedBarcodeCammandAsync(s)));

        //public ICommand CheckedBarcodeCommand =>
        //checkedBarcodeCommand ?? (checkedBarcodeCommand = new Command<WRProductBarcodeModel>(async (s) => await CheckedBarcodeCammandAsync(s)));

      
        public ICommand btnClosePreviewTicketView =>
            btn_ClosePreviewTicketView ?? (btn_ClosePreviewTicketView = new Command(async () => popupPriviewsTickietView = false));
        public ICommand btnPreviewLoadExactTransaction =>
       btn_PreviewLoadExactTransaction ?? (btn_PreviewLoadExactTransaction = new Command(async () => await GetLoadExactPrevious()));

        private async Task GetLoadEarlyPrevious()
        {
            var PreviousTicketData = await new loginPageService().GetDetailByUrl(BetEntry.GetBetEntryByTicketNo + PreviousTicketNoPopup);
            if (PreviousTicketData.Status == 1)
            {
                OrderGridListObservCollection.Clear();
                var DeserializeGridData = JsonConvert.DeserializeObject<List<vw_TicketBetsView>>(PreviousTicketData.Response.ToString());
                TotalAmt = 0;

                PurchaseTicketEnabled = false;
                foreach (var item in DeserializeGridData)
                {
                    if (item.Pick.Length > 3 && item.HouseID==5) { }
                    else
                    {
                        var Val1 = new BetCollection();
                        Val1.Amt = item.Amount;
                        Val1.GameID = item.GameID;
                        Val1.Numbers = Convert.ToInt32(item.Pick);
                        Val1.SB = item.Form;
                        Val1.House = item.House;
                        OrderGridListObservCollection.Add(Val1);
                        TotalAmt = TotalAmt + item.Amount;
                    }

                }
                popupPriviewsTickietView = false;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Message", "Ticket No Not Found.", "Ok");
            }
        }
        private async Task GetLoadExactPrevious()
        {
            var PreviousTicketData = await new loginPageService().GetDetailByUrl(BetEntry.GetBetEntryByTicketNo + PreviousTicketNoPopup);
            if (PreviousTicketData.Status == 1)
            {
                OrderGridListObservCollection.Clear();
                var DeserializeGridData = JsonConvert.DeserializeObject<List<vw_TicketBetsView>>(PreviousTicketData.Response.ToString());
                TotalAmt = 0;
                
                PurchaseTicketEnabled = false;
                foreach (var item in DeserializeGridData)
                {
                    if (item.Pick.Length > 3 && item.HouseID == 5) { }
                    else
                    {
                        var Val1 = new BetCollection();
                        Val1.Amt = item.Amount;
                        Val1.GameID = item.GameID;
                        Val1.Numbers = Convert.ToInt32(item.Pick);
                        Val1.SB = item.Form;
                        Val1.House = item.House;
                        OrderGridListObservCollection.Add(Val1);
                        TotalAmt = TotalAmt + item.Amount;
                    }
                   
                }
                popupPriviewsTickietView = false;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Message", "Ticket No Not Found.", "Ok");
            }
        }
        private async Task LoadDataByPreviousTicket()
        {

            var PreviousTicketData = await new loginPageService().GetDetailByUrl(BetEntry.GetBetEntryByTicketNo + PreviousTicketNoPopup);
            if (PreviousTicketData.Status == 1)
            {
                OrderGridListObservCollection.Clear();
                var DeserializeGridData = JsonConvert.DeserializeObject<List<vw_TicketBetsView>>(PreviousTicketData.Response.ToString());
                TotalAmt = 0;
                PurchaseTicketEnabled = false;
                foreach (var item in DeserializeGridData)
                {

                    var Val1 = new BetCollection();
                    Val1.Amt = item.Amount;
                    Val1.GameID = item.GameID;
                    Val1.Numbers = Convert.ToInt32(item.Pick);
                    Val1.SB = item.Form;
                    Val1.House = item.House;
                    OrderGridListObservCollection.Add(Val1);
                    TotalAmt = TotalAmt + item.Amount;
                }
                popupPriviewsTickietView = false;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Message", "Ticket No Not Found.", "Ok");
            }
        }


        //private async Task GetPreviewTenderAmount()
        //{
        //    var TransactionNumberVal = await new loginPageService().GetDetailByUrl(BetEntry.GetTenderAmountbyTicketNo + PreviousTicketNoPopup);
        //    if (TransactionNumberVal.Status == 1)
        //    {
        //        PreviousTenderAmt = TransactionNumberVal.Response.ToString();
        //    }
        //    else
        //    {
        //        Application.Current.MainPage.DisplayAlert("Message", "Ticket No Not Found.", "Ok");
        //    }
        //}

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

        public List<ListOrder> _listItemValLate { get; set; } = new List<ListOrder>();
        public List<ListOrder> ListItemValLate
        {
            get
            {
                return _listItemValLate;
            }
            set
            {
                _listItemValLate = value;
                OnPropertyChanged(nameof(ListItemValLate));

            }
        }

        //public List<OrderGridModel> OrderGridList { get; set; } = new List<OrderGridModel>();

        ICommand orderGridCommand;
        public ICommand OrderGridCommand =>
           orderGridCommand ?? (orderGridCommand = new Command<BetCollection>(async (s) => await ExecutOrderGridCommandAsync(s)));
        public async Task GoToPreviousTRX()
        {
            try
            {
                PreviousTicketNoPopup = LastTransactionNo;
                popupPriviewsTickietView = true;
                var TransactionNumberVal = await new loginPageService().GetDetailByUrl(BetEntry.GetTenderAmountbyTicketNo + PreviousTicketNoPopup);
                if (TransactionNumberVal.Status == 1)
                {
                    PreviousTenderAmt = TransactionNumberVal.Response.ToString();
                }
            }
            catch (Exception ex)
            {

            }
            //await Navigation.PushModalAsync(new PreviousTRX());
        }
        private async Task ExecutOrderGridCommandAsync(BetCollection s)
        {
            TotalAmt = TotalAmt - s.Amt;
            OrderGridListObservCollection.Remove(s);
        }

        private async Task CalculateTenderAsync()
        {

            Tender = TotalAmt.ToString();

        }

        private async Task ShowSuccessMsg()
        {
            if (Convert.ToDecimal(Tender) >= Convert.ToDecimal(BetsTotal))
            {
                string lBall = Numbers;
                string[] Val = new string[4];

                string mstrBall1 = "";
                string mstrBall2 = "";
                string mstrBall3 = "";
                string mstrBall4 = "";
                int Length = lBall.Length;
                switch (Length.ToString())
                {
                    case "2":
                        lBall = lBall.Insert(1, "-");

                        Val = lBall.Split('-');
                        Array.Sort(Val);

                        mstrBall1 = Val[0].ToString();
                        mstrBall2 = Val[1].ToString();
                        break;
                    case "3":
                        lBall = lBall.Insert(1, "-");
                        lBall = lBall.Insert(3, "-");

                        Val = lBall.Split('-');
                        Array.Sort(Val);

                        mstrBall1 = Val[0];
                        mstrBall2 = Val[1];
                        mstrBall3 = Val[2];
                        break;
                    case "4":
                        lBall = lBall.Insert(1, "-");
                        lBall = lBall.Insert(3, "-");
                        lBall = lBall.Insert(5, "-");

                        Val = lBall.Split('-');
                        Array.Sort(Val);

                        mstrBall1 = Val[0];
                        mstrBall2 = Val[1];
                        mstrBall3 = Val[2];
                        mstrBall4 = Val[3];
                        break;
                }
                var BetEntryModel = new RequestTenderModel();
                int Count = 0;
                BetEntryModel.TenderAmount = tender;
                BetEntryModel.PanelUserID = GlobalConstant.iPanelUserID;
                BetEntryModel.Totals = TotalAmt;
                BetEntryModel.Change = Change;
                BetEntryModel.CommissionRate = 0;
                BetEntryModel.UsesFreeBet = false;
                BetEntryModel.FreeBetAmount = Convert.ToDecimal(tender);
                BetEntryModel.MintShiftID = 8;
                BetEntryModel.mdecFreeBetTotal = Convert.ToInt32(TotalAmt);

                foreach (var Item in OrderGridListObservCollection)
                {
                    Count = Count + 1;
                    var ModelData = new BetCollection();
                    ModelData.Numbers = Item.Numbers;
                    ModelData.House = Item.House;
                    ModelData.SB = Item.SB;
                    ModelData.Amt = Item.Amt;
                    ModelData.GameID = Item.GameID;
                    ModelData.Ball1 = mstrBall1;
                    ModelData.Ball2 = mstrBall2;
                    ModelData.Ball3 = mstrBall3;
                    ModelData.Ball4 = mstrBall4;
                    ModelData.StraightBall = Numbers;
                    ModelData.BetAmount = Item.Amt;
                    ModelData.PayFactor = Convert.ToDouble(Item.Amt);
                    BetEntryModel.BetCollection.Add(ModelData);
                }
                BetEntryModel.NoOfBets = Count;
                PopUpVisibility = false;
                var TransactionNumberVal = await new BetEntrySevice().PostBetEntry(BetEntryModel, BetEntry.TrancatioSaveBetEntry);
                if (TransactionNumberVal.Status == 1)
                {
                    var ResponseSave = JsonConvert.DeserializeObject<LogInModel>(TransactionNumberVal.Response.ToString());
                    GlobalConstant.BalanceAmt = ResponseSave.decBalance;
                    BalAmt = "Balance: $" + GlobalConstant.BalanceAmt.ToString();
                    OrderGridListObservCollection.Clear();
                    ListItemValLate.Clear();
                    Amt = "0";
                    Numbers = "0";
                    TotalAmt = 0;
                    GetLateHouse(false);

                    Application.Current.MainPage.DisplayAlert("Message", "Success", "Ok");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Message", "Error", "Ok");
                }

            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Message", "Enter Proper Amount.", "Ok");
            }

        }

        public async Task ShowPopUpTenderAsync()
        {

            PopUpVisibility = true;

            BetsTotal = TotalAmt.ToString();
            TotalDue = TotalAmt.ToString();
            //var ChangeAmount = Convert.ToInt32(tender) - Convert.ToInt32(TotalAmt);
            Change = "0";
        }

        public async Task CancelPopUpTenderAsync()
        {

            PopUpVisibility = false;
        }

        public bool Validate()
        {
            if (Amt != "" && Convert.ToInt32(Amt) > 0)
            {
                //if (Model.chkEarly1 != false || Model.chkEarly2 != false || Model.chkEarly3 != false || Model.chkEarly4 != false)
                //{
                if (((Numbers == null) ? "" : Numbers).Length > 2 && ((Numbers == null) ? "" : Numbers).Length < 6)
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
                foreach (var item in ListItemValLate)
                {
                    if (item.chkLate1 == true)
                    {
                        var TransactionNumberVal = await new loginPageService().GetDetailByUrl(BetEntry.GetLottoGameDetailByHouseIdandBalls + item.Late1Id + "&NoOfBalls=" + Numbers.Trim().Length);
                        if (TransactionNumberVal.Status == 1)
                        {
                            var Val1 = JsonConvert.DeserializeObject<BetCollection>(TransactionNumberVal.Response.ToString());

                            Val1.Amt = Convert.ToDecimal(Amt);
                            Val1.Numbers = Convert.ToInt32(Numbers);
                            Val1.SB = "S";
                            Val1.House = item.Late1;
                            OrderGridListObservCollection.Add(Val1);
                            TotalAmt = TotalAmt + Val1.Amt;
                        }
                        ChecboxCheck = true;
                    }
                    if (item.chkLate2 == true)
                    {
                        var TransactionNumberVal = await new loginPageService().GetDetailByUrl(BetEntry.GetLottoGameDetailByHouseIdandBalls + item.Late2Id + "&NoOfBalls=" + Numbers.Trim().Length);
                        if (TransactionNumberVal.Status == 1)
                        {
                            var Val2 = JsonConvert.DeserializeObject<BetCollection>(TransactionNumberVal.Response.ToString());
                            Val2.Amt = Convert.ToDecimal(Amt);
                            Val2.Numbers = Convert.ToInt32(Numbers);
                            Val2.SB = "S";
                            Val2.House = item.Late2;
                            OrderGridListObservCollection.Add(Val2);
                            TotalAmt = TotalAmt + Val2.Amt;
                        }
                        ChecboxCheck = true;
                    }
                    if (item.chkLate3 == true)
                    {
                        var TransactionNumberVal = await new loginPageService().GetDetailByUrl(BetEntry.GetLottoGameDetailByHouseIdandBalls + item.Late3Id + "&NoOfBalls=" + Numbers.Trim().Length);
                        if (TransactionNumberVal.Status == 1)
                        {
                            var Val3 = JsonConvert.DeserializeObject<BetCollection>(TransactionNumberVal.Response.ToString());
                            Val3.Amt = Convert.ToDecimal(Amt);
                            Val3.Numbers = Convert.ToInt32(Numbers);
                            Val3.SB = "S";
                            Val3.House = item.Late3;
                            OrderGridListObservCollection.Add(Val3);
                            TotalAmt = TotalAmt + Val3.Amt;
                        }
                        ChecboxCheck = true;
                    }
                    if (item.chkLate4 == true)
                    {
                        var TransactionNumberVal = await new loginPageService().GetDetailByUrl(BetEntry.GetLottoGameDetailByHouseIdandBalls + item.Late4Id + "&NoOfBalls=" + Numbers.Trim().Length);
                        if (TransactionNumberVal.Status == 1)
                        {
                            var Val4 = JsonConvert.DeserializeObject<BetCollection>(TransactionNumberVal.Response.ToString());
                            Val4.Amt = Convert.ToDecimal(Amt);
                            Val4.Numbers = Convert.ToInt32(Numbers);
                            Val4.SB = "S";
                            Val4.House = item.Late4;
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

        Color latehouseTabColor;
        public Color LatehouseTabColor
        {
            get { return latehouseTabColor; }
            set
            {
                if (latehouseTabColor != value)
                {
                    latehouseTabColor = value;
                    OnPropertyChanged(nameof(LatehouseTabColor));

                }
            }
        }

        Color earlyhouseTabColor;
        public Color EarlyhouseTabColor
        {
            get { return earlyhouseTabColor; }
            set
            {
                if (earlyhouseTabColor != value)
                {
                    earlyhouseTabColor = value;
                    OnPropertyChanged(nameof(EarlyhouseTabColor));

                }
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

        bool earlyTabVisibility = true;
        public bool EarlyTabVisibility
        {
            get { return earlyTabVisibility; }
            set
            {
                if (earlyTabVisibility != value)
                {
                    earlyTabVisibility = value;
                    OnPropertyChanged(nameof(EarlyTabVisibility));

                }
            }
        }

        bool lateTabVisibility;
        public bool LateTabVisibility
        {
            get { return lateTabVisibility; }
            set
            {
                if (lateTabVisibility != value)
                {
                    lateTabVisibility = value;
                    OnPropertyChanged(nameof(LateTabVisibility));

                }
            }
        }

        bool purchaseTicketEnabled;
        public bool PurchaseTicketEnabled
        {
            get { return purchaseTicketEnabled; }
            set
            {
                if (purchaseTicketEnabled != value)
                {
                    purchaseTicketEnabled = value;
                    OnPropertyChanged(nameof(PurchaseTicketEnabled));

                }
            }
        }


        bool PriviewsTickietView;
        public bool popupPriviewsTickietView
        {
            get { return PriviewsTickietView; }
            set
            {
                if (PriviewsTickietView != value)
                {
                    PriviewsTickietView = value;
                    OnPropertyChanged(nameof(popupPriviewsTickietView));

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

        string balAmt;
        public string BalAmt
        {
            get { return balAmt; }
            set
            {
                if (balAmt != value)
                {
                    balAmt = value;
                    OnPropertyChanged(nameof(BalAmt));

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

        string previousTicketNoPopup;
        public string PreviousTicketNoPopup
        {
            get { return previousTicketNoPopup; }
            set
            {
                if (previousTicketNoPopup != value)
                {
                    previousTicketNoPopup = value;
                    OnPropertyChanged(nameof(PreviousTicketNoPopup));

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
        string previousTenderAmt;
        public string PreviousTenderAmt
        {
            get { return previousTenderAmt; }
            set
            {
                if (previousTenderAmt != value)
                {
                    previousTenderAmt = value;
                    OnPropertyChanged(nameof(PreviousTenderAmt));

                }
            }
        }
        public void calculate()
        {
            try
            {
                if (tender != "")
                {
                    BetsTotal = TotalAmt.ToString();
                    TotalDue = TotalAmt.ToString();
                    var ChangeAmount = Convert.ToInt32(TotalAmt) - Convert.ToInt32(tender);
                    Change = (System.Math.Abs(ChangeAmount)).ToString();

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
        public async void GetLateHouse(bool Latehouse)
        {
            ListItemValLate = new List<ListOrder>();
            popupPriviewsTickietView = false;
            var TransactionNumberVal = await new loginPageService().GetDetailByUrl(BetEntry.GetTrancationNumber + GlobalConstant.iPanelUserID);
            if (TransactionNumberVal.Status == 1)
            {

                LastTransactionNo = TransactionNumberVal.Response.ToString();
            }

            SB = "S";
            // var UserDetail = await new loginPageService().GetDetailByUrl(BetEntry.GetHouseDetail);
            var UserDetail = await new loginPageService().GetDetailByUrl((Latehouse == false ? BetEntry.GetEarlyHouseForTab : BetEntry.GetLateHouseForTab));
            if (UserDetail.Status == 1)
            {
                var wrShiipinglistVal = JsonConvert.DeserializeObject<List<vw_HousesDetails>>(UserDetail.Response.ToString());
                for (int i = 0; i < wrShiipinglistVal.Count; i++)
                {
                    Model = new ListOrder();
                    try
                    {
                        Model.Late1 = wrShiipinglistVal[i].HouseName;
                        Model.chkLate1 = false;
                        Model.Late1Id = wrShiipinglistVal[i].HouseID;
                        Model.Latehouse1 = Latehouse;
                        i++;
                    }
                    catch { }
                    try
                    {
                        Model.Late2 = wrShiipinglistVal[i].HouseName;
                        Model.chkLate2 = false;
                        Model.Late2Id = wrShiipinglistVal[i].HouseID;
                        Model.Latehouse2 = true;
                        i++;
                    }
                    catch { }
                    try
                    {
                        Model.Late3 = wrShiipinglistVal[i].HouseName;
                        Model.chkLate3 = false;
                        Model.Late3Id = wrShiipinglistVal[i].HouseID;
                        Model.Latehouse3 = true;
                        i++;
                    }
                    catch { }
                    try
                    {
                        Model.Late4 = wrShiipinglistVal[i].HouseName;
                        Model.chkLate4 = false;
                        Model.Late4Id = wrShiipinglistVal[i].HouseID;
                        Model.Latehouse4 = true;
                    }
                    catch { }
                    ListItemValLate.Add(Model);
                }


            }

        }
        public OrderViewModel(INavigation navigation)
        {
            GetLateHouse(false);
            EarlyhouseTabColor = Color.Black;
            LatehouseTabColor = Color.Red;
            EarlyTabVisibility = true;
            LateTabVisibility = false;
            PurchaseTicketEnabled = true;
            Navigation = navigation;
            BalAmt = "Balance: $" + GlobalConstant.BalanceAmt.ToString();
        }



    }
}
