using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JackPot.ViewModel
{
  public  class SearchReceiptViewModel : INotifyPropertyChanged
    {
        INavigation Navigation;

        public SearchReceiptViewModel(INavigation navigation)
        {

            Navigation = navigation;

        }
        

       ICommand Btn_voidReceipt; 
            
       ICommand Btn_Close;

        public ICommand btnClose =>
            Btn_Close ?? (Btn_Close = new Command(async () => await SearchData()));

      

        string enterReceipt;

        public string EnterReceipt
        {
            get { return enterReceipt; }
            set
            {
                enterReceipt = value;
                PropertyChanged(this, new PropertyChangedEventArgs("enterReceipt"));
            }
        }

        private async Task SearchData()
        {
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
