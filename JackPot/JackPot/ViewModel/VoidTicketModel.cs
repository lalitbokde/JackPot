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

        public ObservableRangeCollection<BetCollection> VoidTicketGridListObservCollection { get; set; } = new ObservableRangeCollection<BetCollection>();
        public ICommand ShowData =>
         Show_Data ?? (Show_Data = new Command(async () => await LoadData()));

        private async Task LoadData()
        {
            var PreviousTicketData = await new loginPageService().GetDetailByUrl(VoidTicketApi.GetNonVoidedTicketBets + TicketNo);
            if (PreviousTicketData.Status == 1)
            {
                var DeserializeGridData = JsonConvert.DeserializeObject< List<vw_TicketBetsView>>(PreviousTicketData.Response.ToString());

                foreach(var item in DeserializeGridData)
                {
                    TotalAmt = TotalAmt + item.Amount;
                    BetCollection Model = new BetCollection();
                    Model.Amt = item.Amount;
                    Model.SB = item.Form;
                  
                    Model.House = item.House;
                    Model.GameID = item.GameID;
                    
                    VoidTicketGridListObservCollection.Add(Model);
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
