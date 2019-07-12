using JackPot.Model;
using JackPot.Service;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using WareHouseManagement.PCL.Common;
using Xamarin.Forms;

namespace JackPot.ViewModel
{
    public class CustomerDepositeViewModel: INotifyPropertyChanged
    {
        private static long ShiftId = 0;
        ICommand btn_Close;
        ICommand btn_Deposite;
        ICommand btn_Search;
        INavigation Navigation;
        public ObservableRangeCollection<vw_CustomerDetails> CustomerGridListObservCollection { get; set; } = new ObservableRangeCollection<vw_CustomerDetails>();
        public CustomerDepositeViewModel(INavigation navigation)
        {
            Navigation = navigation;
            GetShiftId();
        }
        public async void GetShiftId()
        {
            var TransactionNumberVal = await new loginPageService().GetDetailByUrl(Sales.GetCurrentPanelUserShift + GlobalConstant.UserName + "&LocationId=" + GlobalConstant.LocationId);
            if (TransactionNumberVal.Status == 1)
            {
                ShiftId = JsonConvert.DeserializeObject<long>(TransactionNumberVal.Response.ToString());
            }
        }
        public ICommand btnDeposite =>
        btn_Deposite ?? (btn_Deposite = new Command(async () => DepositeAsync()));

        public ICommand btnSearch =>
      btn_Search ?? (btn_Search = new Command(async () => SearchCustomer()));
        public void Clear()
        {
            CustomerGridListObservCollection.Clear();
            depositeAmt = 0;
            CustomerName = "";
        }
        private async void SearchCustomer()
        {
            if (CustomerAcNo.Length > 2)
            {
                Clear();
                Regex reg = new Regex("[*'\",_&#^@]");
                string AccNo = reg.Replace(CustomerAcNo, string.Empty);
                var CutomerData = await new loginPageService().GetDetailByUrl(CustomerApi.GetCustomerDetailByAccountno + AccNo);
                if (CutomerData.Status == 1)
                {
                    var CustomerDetail = JsonConvert.DeserializeObject<vw_CustomerDetails>(CutomerData.Response.ToString());
                    CustomerGridListObservCollection.Add(CustomerDetail);
                    CustomerName = CustomerDetail.Customer;
                    Depositebool = true;
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Message", "Account No too Short.", "Ok");
            }
        }

        string customerAcNo;
        public string CustomerAcNo
        {
            get { return customerAcNo; }
            set
            {
                if (customerAcNo != value)
                {
                    customerAcNo = value;
                    OnPropertyChanged(nameof(CustomerAcNo));

                }
            }
        }

        string customerName;
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                if (customerName != value)
                {
                    customerName = value;
                    OnPropertyChanged(nameof(CustomerName));

                }
            }
        }

        decimal depositeAmt;
        public decimal DepositeAmt
        {
            get { return depositeAmt; }
            set
            {
                if (depositeAmt != value)
                {
                    depositeAmt = value;
                    OnPropertyChanged(nameof(DepositeAmt));

                }
            }
        }

        bool depositebool;
        public bool Depositebool
        {
            get { return depositebool; }
            set
            {
                if (depositebool != value)
                {
                    depositebool = value;
                    OnPropertyChanged(nameof(Depositebool));

                }
            }
        }



        public void Close()
        {
        }

        public async void DepositeAsync()
        {
            var Transaction = new tblPanelUserTransaction()
            {

                iTransactionTypeID = 8,
                iTransactionRecordID = 0,
                iMadeBy = GlobalConstant.UserName,
                iLocationID = GlobalConstant.LocationId,
                iShiftID =Convert.ToInt32( ShiftId),
                iCustomerID = CustomerGridListObservCollection[0].CustomerID,
                iManagerID = -9999,
                sTransactionDetails = "Customer Account Deposit.",
                decAmount = DepositeAmt,
                decNewBalance = 0,
                dtTransactionDate = DateTime.UtcNow,
                sMachineName = "",
                sTransactionGUID = Guid.NewGuid()

            };
            var CustomerTransaction = new tblCustomerTransaction()
            {

                iTransactionTypeID = 8,
                iTransactionRecordID = 0,
                iMadeBy = GlobalConstant.UserName,
                
                iCustomerID = CustomerGridListObservCollection[0].CustomerID,
                iManagerID = -9999,
                sTransactionDetails = "Customer Account Deposit.",
                decAmount = DepositeAmt,
                decNewBalance = 0,
                dtTransactionDate = DateTime.UtcNow,
              
                sTransactionGUID = Guid.NewGuid()
            };
            var SaveCustomerTransaction = await new Service.CustomerService().PostCustomerTransaction(CustomerTransaction, CustomerApi.InsertCustomerTransaction);
            if (SaveCustomerTransaction.Status == 1)
            {
                var SaveLottoTicket = await new VoidTicketService().PosttblLottoTicket(Transaction, VoidTicketApi.InsertUserTransaction);
                if (SaveLottoTicket.Status == 1)
                {
                    Clear();
                    Application.Current.MainPage.DisplayAlert("Message", "Success.", "Ok");
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
