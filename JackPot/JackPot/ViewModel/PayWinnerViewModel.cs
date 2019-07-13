using JackPot.Model;
using JackPot.Service;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using WareHouseManagement.PCL.Common;
using Xamarin.Forms;

namespace JackPot.ViewModel
{
   public class PayWinnerViewModel : INotifyPropertyChanged
    {
        ICommand btn_ShowData;
        ICommand btn_PayWinner;
        ICommand btn_Close;
        INavigation Navigation;
        public PayWinnerViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        public ObservableRangeCollection<vw_TicketWinnersGridList> PayWinnerGridListObservCollection { get; set; } = new ObservableRangeCollection<vw_TicketWinnersGridList>();
        public ICommand btnShowData =>
       btn_ShowData ?? (btn_ShowData = new Command(async () => LoadDetail()));

        public ICommand PayWinner =>
    btn_PayWinner ?? (btn_PayWinner = new Command(async () => SaveData()));

        private void SaveData()
        {
            //var Transaction = new tblPanelUserTransaction()
            //{

            //    iTransactionTypeID = 8,
            //    iTransactionRecordID = 0,
            //    iMadeBy = GlobalConstant.iPanelUserID,
            //    iLocationID = GlobalConstant.LocationId,
            //    iShiftID = Convert.ToInt32(ShiftId),
            //    iCustomerID = -9999,
            //    iManagerID = -9999,
            //    sTransactionDetails = "Customer Account Deposit.",
            //    decAmount = DepositeAmt,
            //    decNewBalance = 0,
            //    dtTransactionDate = DateTime.UtcNow,
            //    sMachineName = "",
            //    sTransactionGUID = Guid.NewGuid()

            //};
        }

        public ICommand btnClose =>
           btn_Close ?? (btn_Close = new Command(async () => ShowData()));



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

        string _totalAmt;
        public string TotalAmt
        {
            get { return _totalAmt; }
            set
            {
                if (_totalAmt != value)
                {
                    _totalAmt = value;
                    OnPropertyChanged(nameof(TotalAmt));

                }
            }
        }


        public void ShowData()
        {
        }
        public async void LoadDetail()
        {
            var CutomerData = await new loginPageService().GetDetailByUrl(payout.GetUnpaidTicket + TicketNo);
            if (CutomerData.Status == 1)
            {
                var CustomerDetail = JsonConvert.DeserializeObject<List< vw_TicketWinnersGridList >> (CutomerData.Response.ToString());
                foreach(var item in CustomerDetail)
                {
                    PayWinnerGridListObservCollection.Add(item);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
