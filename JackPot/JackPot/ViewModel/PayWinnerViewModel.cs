using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JackPot.ViewModel
{
   public class PayWinnerViewModel : INotifyPropertyChanged
    {
        ICommand btn_ShowData;
        ICommand btn_PayWinner;
        ICommand btn_Close;

        public ICommand btnShowData =>
       btn_ShowData ?? (btn_ShowData = new Command(async () => ShowData()));

        public ICommand PayWinner =>
    btn_PayWinner ?? (btn_PayWinner = new Command(async () => ShowData()));

        public ICommand btnClose =>
           btn_Close ?? (btn_Close = new Command(async () => ShowData()));



        string enterReceipt;
        public string EnterReceipt
        {
            get { return enterReceipt; }
            
            set
            {
                if (enterReceipt != value)
                {
                    enterReceipt = value;
                    OnPropertyChanged(nameof(EnterReceipt));

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


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
