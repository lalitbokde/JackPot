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
    public class SalesReportModel : INotifyPropertyChanged
    {
        ICommand Btn_Show;
        INavigation Navigation;

        public ObservableRangeCollection<vw_rptLocationSalesReport> SalesGridListObservCollection { get; set; } = new ObservableRangeCollection<vw_rptLocationSalesReport>();
      //  public ICommand BtnShow =>
      //Btn_Show ?? (Btn_Show = new Command(async () => await SearchData()));
        public ICommand BtnShow =>
 Btn_Show ?? (Btn_Show = new Command(async () => await SearchData()));
        public event PropertyChangedEventHandler PropertyChanged;
        private async Task SearchData()
        {
            var TransactionNumberVal = await new loginPageService().GetDetailByUrl(Sales.GetSalesReport +GlobalConstant.LocationId + "&StartDate=" + StartDate+"&EndDate="+EndDate);
            if (TransactionNumberVal.Status == 1)
            {
                var Val3 = JsonConvert.DeserializeObject<List<vw_rptLocationSalesReport>>(TransactionNumberVal.Response.ToString());
                foreach(var item in Val3)
                {
                    SalesGridListObservCollection.Add(item);
                    TotalSale = TotalSale + item.Sales;
                    CashiorCommission = CashiorCommission + Convert.ToDouble(item.Commissions);
                    Commission = Commission + Convert.ToDouble( item.Commissions);
                }
                Name = GlobalConstant.CustomerName;
                Location = GlobalConstant.LocationId.ToString();
            }
        }
        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        DateTime startDate=DateTime.UtcNow;
       
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("StartDate"));
            }
        }
        DateTime endDate =DateTime.UtcNow;

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EndDate"));
            }
        }

        string location;

        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Location"));
            }
        }

        string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }

        double commission; 

        public double Commission
        {
            get { return commission; }
            set
            {
                commission = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Commission"));
            }
        }

        double cashiorCommission;

        public double CashiorCommission
        {
            get { return cashiorCommission; }
            set
            {
                cashiorCommission = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CashiorCommission"));
            }
        }
        decimal? totalSale;
        public decimal? TotalSale
        {
            get { return totalSale; }
            set
            {
                totalSale = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TotalSale"));
            }
        }



        public SalesReportModel(INavigation navigation)
        {
           
            Navigation = navigation;
            //EndDate = DateTime.UtcNow;
            //StartDate = DateTime.UtcNow;
        }
    }
}
