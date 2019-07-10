using JackPot.Service;
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

        public SalesInfoViewModel(INavigation navigation)
        {

            Navigation = navigation;
           
        }


        ICommand Btn_Close;
        ICommand Btn_PrintSales;

        public ICommand btnClose =>
            Btn_Close ?? (Btn_Close = new Command(async () => await SearchData()));
        public ICommand btnPrintSales =>
           Btn_PrintSales ?? (Btn_PrintSales = new Command(async () => await SearchData()));





        private async Task SearchData()
        {

            var TransactionNumberVal = await new loginPageService().GetDetailByUrl(Sales.GetSalesReport + GlobalConstant.LocationId + "&StartDate=" + StartDate + "&EndDate=" + EndDate);
            if (TransactionNumberVal.Status == 1)
            {
                var Val3 = JsonConvert.DeserializeObject<List<vw_rptLocationSalesReport>>(TransactionNumberVal.Response.ToString());
               
            }

        }

        string agentName;

        public string AgentName
        {
            get { return agentName; }
            set
            {
                agentName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("agentName"));
            }
        }


        string salesTotal;

        public string SalesTotal
        {
            get { return salesTotal; }
            set
            {
                salesTotal = value;
                PropertyChanged(this, new PropertyChangedEventArgs("salesTotal"));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
