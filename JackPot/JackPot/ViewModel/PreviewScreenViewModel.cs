using JackPot.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JackPot.ViewModel
{
    public class PreviewScreenViewModel : INotifyPropertyChanged
    {
        INavigation Navigation;
       
        public PreviewScreenViewModel(INavigation navigation)
        {

            Navigation = navigation;
        }
        ICommand btn_CloseView;
        public ICommand btnCloseView =>
          btn_CloseView ?? (btn_CloseView = new Command(async () => await GoMainActivity()));

        private async Task GoMainActivity()
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        string ticketNo;
        public string TicketNo
        {
            get { return ticketNo; }
            set
            {
                ticketNo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TicketNo"));
            }
        }

        string balAmount;
        public string BalAmount
        {
            get { return balAmount; }
            set
            {
                balAmount = value;
                PropertyChanged(this, new PropertyChangedEventArgs("BalAmount"));
            }
        }

      

     


        public event PropertyChangedEventHandler PropertyChanged;
    }


}
