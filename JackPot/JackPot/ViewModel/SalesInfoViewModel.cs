using JackPot.Model;
using JackPot.Service;
using JackPot.Views;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WareHouseManagement.PCL.Common;
using Xamarin.Forms;

namespace JackPot.ViewModel
{
    public class SalesInfoViewModel : INotifyPropertyChanged
    {
        INavigation Navigation;
        public ObservableRangeCollection<vw_PanelUserShiftTrxSummaryGridList> ShiftGridListObservCollection { get; set; } = new ObservableRangeCollection<vw_PanelUserShiftTrxSummaryGridList>();
        public SalesInfoViewModel(INavigation navigation)
        {

            Navigation = navigation;
            loadData();


        }


        ICommand Btn_Close;
        ICommand Btn_PrintSales;

        public ICommand btnClose =>
            Btn_Close ?? (Btn_Close = new Command(async () => await Gotomain()));
        public ICommand btnPrintSales =>
           Btn_PrintSales ?? (Btn_PrintSales = new Command(async () => await Print()));





        private async Task Gotomain()
        {

            await Navigation.PushModalAsync(new MainPage());

        }

        private async Task Print()
        {

          

        }

        public async void loadData()
        {
            var TransactionNumberVal = await new loginPageService().GetDetailByUrl(Sales.GetCurrentPanelUserShift + GlobalConstant.UserName + "&LocationId=" + GlobalConstant.LocationId);
            if (TransactionNumberVal.Status == 1)
            {
                var Val3 = JsonConvert.DeserializeObject<long>(TransactionNumberVal.Response.ToString());
                var GridData = await new loginPageService().GetDetailByUrl(Sales.GetCloseShiftGridDetai + Val3);
                if (GridData.Status == 1)
                {
                    var GridResponse = JsonConvert.DeserializeObject<List<vw_PanelUserShiftTrxSummaryGridList>>(GridData.Response.ToString());
                
                    foreach (var item in GridResponse)
                    {
                        
                        ShiftGridListObservCollection.Add(item);
                    }
                }
            }
        }

        string agentName;

        public string AgentName
        {
            get { return agentName; }
            set
            {
                agentName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AgentName"));
            }
        }


        decimal salesTotal;

        public decimal SalesTotal
        {
            get { return salesTotal; }
            set
            {
                salesTotal = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SalesTotal"));
            }
        }

        decimal totalAmt;

        public decimal TotalAmt
        {
            get { return totalAmt; }
            set
            {
                totalAmt = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TotalAmt"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
