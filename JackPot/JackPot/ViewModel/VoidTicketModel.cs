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
        ICommand btn_Cancel;

         tblPanelUserTransaction Transaction;
        public ObservableRangeCollection<BetCollection> VoidTicketGridListObservCollection { get; set; } = new ObservableRangeCollection<BetCollection>();
        public ICommand ShowData =>
         Show_Data ?? (Show_Data = new Command(async () => await LoadData()));


        public ICommand btnVoided =>
     btn_Voided ?? (btn_Voided = new Command(async () => await VoidData()));
        public ICommand btnCancel =>
       btn_Cancel ?? (btn_Cancel = new Command(async () => await GoToMain()));

        private async Task GoToMain()
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        private async Task VoidData()
        {
            if (VoidTicketGridListObservCollection != null)
            {
                bool StatusCheck = false;
                foreach (var Item in VoidTicketGridListObservCollection)
                {
                    var Bets = new tblBetsPerBall();
                    Bets.fAmount = Convert.ToDouble(Item.Amt);
                    Bets.iGameID = Item.GameID;
                    Bets.sStraightBall = Item.StraightBall;
                    Bets.dtDateFor = Item.dtBetDate;
                    var PreviousTicketData = await new VoidTicketService().PostVoidTicket(Bets, VoidTicketApi.AdjustBetsPerBall);
                    if (PreviousTicketData.Status == 1)
                    {
                        StatusCheck = true;
                    }
                }
                var Detail = new tblLottoTicket();
                Detail.bActive = false;
                Detail.bVoided = true;
                Detail.iVoidedBy = Convert.ToInt32(GlobalConstant.UserName);
                Detail.dtVoidedOn = DateTime.UtcNow;
                Detail.iVoidApprovedBy = 0;
                Detail.sTicketNo = TicketNo;

                if (StatusCheck == true)
                {
                    var UpdateLotto = await new VoidTicketService().UpdatetblLottoTicket(Detail, VoidTicketApi.UpdatetblLottoTicket);
                    if (UpdateLotto.Status == 1)
                    {

                    }
                    var SaveLottoTicket = await new VoidTicketService().PosttblLottoTicket(Transaction, VoidTicketApi.InsertUserTransaction);
                    if (SaveLottoTicket.Status == 1)
                    {
                        ClearData();
                        Application.Current.MainPage.DisplayAlert("Message", "Success.", "Ok");
                    }
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Message", "Fill Proper Detail.", "Ok");
            }

        }
        public void ClearData()
        {
            VoidTicketGridListObservCollection.Clear();
            TicketNo = null;
            TotalAmt = 0;
        }
        private async Task LoadData()
        {
            var PreviousTicketData = await new loginPageService().GetDetailByUrl(VoidTicketApi.GetNonVoidedTicketBets + TicketNo);
            if (PreviousTicketData.Status == 1)
            {
               
                var DeserializeData = JsonConvert.DeserializeObject<List<vw_TicketBetsView>>(PreviousTicketData.Response.ToString());
                if (DeserializeData.Count > 0)
                {
                    if (DeserializeData[0].PurchasedDate.ToString("MM/dd/yyyy") == DateTime.UtcNow.ToString("MM/dd/yyyy"))
                    {
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
                            var GettblLottoTicket = await new loginPageService().GetDetailByUrl(VoidTicketApi.GetLottoTicketbyTicketId + DeserializeData[0].TicketNo);
                            if (GettblLottoTicket.Status == 1)
                            {
                                var DeserializeLottoTicketData = JsonConvert.DeserializeObject<tblLottoTicket>(GettblLottoTicket.Response.ToString());


                                Transaction = new tblPanelUserTransaction()
                                {

                                    iTransactionTypeID = 8,
                                    iTransactionRecordID = 0,
                                    iMadeBy = GlobalConstant.iPanelUserID,
                                    iLocationID = GlobalConstant.LocationId,
                                    iShiftID = DeserializeLottoTicketData.iShiftID,
                                    iCustomerID = Convert.ToInt64(DeserializeLottoTicketData.iCustomerID),
                                    iManagerID = -9999,
                                    sTransactionDetails = String.Format("Void Lotto Ticket - {0}", DeserializeLottoTicketData.sTicketNo),
                                    decAmount = TotalAmt,
                                    decNewBalance = 0,
                                    dtTransactionDate = DateTime.UtcNow,
                                    sMachineName = "",
                                    sTransactionGUID = Guid.NewGuid()

                                };

                            }

                        }
                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Message", "This Ticket Is Out Of Date.", "Ok");
                    }
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Message", "Ticket No Already Voided.", "Ok");
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
