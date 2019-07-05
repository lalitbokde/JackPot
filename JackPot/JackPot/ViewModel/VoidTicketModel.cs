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
    public class VoidTicketModel : INotifyPropertyChanged
    {
        INavigation Navigation;
        ICommand Show_Data;
        ICommand btn_Voided;
        public ObservableRangeCollection<BetCollection> VoidTicketGridListObservCollection { get; set; } = new ObservableRangeCollection<BetCollection>();
        public ICommand ShowData =>
         Show_Data ?? (Show_Data = new Command(async () => await LoadData()));

        public ICommand btnVoided =>
       btn_Voided ?? (btn_Voided = new Command(async () => await VoidData()));

        private async Task VoidData()
        {
            foreach (var Item in VoidTicketGridListObservCollection)
            {
                var Bets = new tblBetsPerBall();
                Bets.fAmount =Convert.ToDouble( Item.Amt);
                Bets.iGameID = Item.GameID;
                Bets.sStraightBall = Item.StraightBall;
                Bets.dtDateFor = Item.dtBetDate;
                var PreviousTicketData = await new VoidTicketService().PostVoidTicket(Bets, VoidTicketApi.AdjustBetsPerBall);
                if (PreviousTicketData.Status == 1)
                {

                }
            }

        }

        private async Task LoadData()
        {
            var PreviousTicketData = await new loginPageService().GetDetailByUrl(VoidTicketApi.GetNonVoidedTicketBets + TicketNo);
            if (PreviousTicketData.Status == 1)
            {
                var DeserializeData = JsonConvert.DeserializeObject<List<vw_TicketBetsView>>(PreviousTicketData.Response.ToString());
                var LottoDetail = await new loginPageService().GetDetailByUrl(VoidTicketApi.GetLottoBets + DeserializeData[0].TicketID);
                if (LottoDetail.Status == 1)
                {
                    var DeserializeGridData = JsonConvert.DeserializeObject<List<tblLottoBet>>(LottoDetail.Response.ToString());
                    int i = 0;
                    foreach (var item in DeserializeGridData)
                    {
                        TotalAmt = TotalAmt + DeserializeData[i].Amount;
                        BetCollection Model = new BetCollection();
                        Model.Amt = DeserializeData[i].Amount;
                        Model.SB = DeserializeData[i].Form;
                        Model.Numbers = Convert.ToInt32(item.sStraightBall);
                        Model.PayFactor = item.fPayFactor;
                        Model.StraightBall = item.sStraightBall;
                        Model.Amt = item.decBetAmount;
                        Model.House = DeserializeData[i].House;
                        Model.GameID = DeserializeData[i].GameID;
                        Model.dtBetDate = item.dtBetDate;
                        Model.Ball1 = item.sBall1;
                        Model.Ball2 = item.sBall2;
                        Model.Ball3 = item.sBall3;
                        Model.Ball4 = item.sBall4;
                        Model.BetAmount = DeserializeData[i].Amount;
                        VoidTicketGridListObservCollection.Add(Model);
                        i++;
                    }
    //                var Transaction = new tblPanelUserTransaction()
    //                {
    //                    iTransactionID = 0,
                      
     
    //   iTransactionTypeID 
    //    public long iTransactionRecordID { get; set; }
    //    public long iMadeBy { get; set; }
    //    public Nullable<int> iLocationID { get; set; }
    //    public int iShiftID { get; set; }
    //    public long iCustomerID { get; set; }
    //    public long iManagerID { get; set; }
    //    public string sTransactionDetails { get; set; }
    //    public decimal decAmount { get; set; }
    //    public decimal decNewBalance { get; set; }
    //    public System.DateTime dtTransactionDate { get; set; }
    //    public string sMachineName { get; set; }
    //    public string sUsername { get; set; }
    //    public string sIPAddress { get; set; }

    //};

                }

            }
        }

        public VoidTicketModel(INavigation navigation)
        {

            Navigation = navigation;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        string ticketNo;
        public string TicketNo
        {
            get { return ticketNo; }
            set
            {
                if (ticketNo != value)
                {
                    ticketNo = value;
                    OnPropertyChanged(nameof(TicketNo));

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

    }
}
