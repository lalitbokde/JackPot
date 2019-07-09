using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JackPot.ViewModel
{
    public class CustomerDepositeViewModel: INotifyPropertyChanged
    {

        ICommand btn_Close;
        ICommand btn_Deposite;
        public ICommand btnDeposite =>
        btn_Deposite ?? (btn_Deposite = new Command(async () => DepositeAsync()));

        string customer;
        public string Customer
        {
            get { return customer; }
            set
            {
                if (customer != value)
                {
                    customer = value;
                    OnPropertyChanged(nameof(Customer));

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

        string deposite;
        public string Deposite
        {
            get { return deposite; }
            set
            {
                if (deposite != value)
                {
                    deposite = value;
                    OnPropertyChanged(nameof(Deposite));

                }
            }
        }



        public void Close()
        {
        }

        public void DepositeAsync()
        {
        }



        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
