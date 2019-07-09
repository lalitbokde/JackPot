using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JackPot.ViewModel
{
   
    public class WinnerNumberViewModel : INotifyPropertyChanged
    {
        ICommand btn_PrintResult;
        ICommand btn_StartDate;
        ICommand btn_EndDate;


        public ICommand btnPrintResult =>
      btn_PrintResult ?? (btn_PrintResult = new Command(async () => PrintResult()));

        public ICommand btnStartDate =>
    btn_StartDate ?? (btn_StartDate = new Command(async () => StartDateSelect()));

        public ICommand btnEndDate =>
     btn_EndDate ?? (btn_EndDate = new Command(async () => EndDateSelect()));


        string txtstartDate;
        public string txtStartDate
        {
            get { return txtstartDate; }
            set
            {
                if (txtstartDate != value)
                {
                    txtstartDate = value;
                    OnPropertyChanged(nameof(txtStartDate));

                }
            }
        }

        string txtendtDate;
        public string txtEndtDate
        {
            get { return txtendtDate; }
            set
            {
                if (txtendtDate != value)
                {
                    txtendtDate = value;
                    OnPropertyChanged(nameof(txtEndtDate));

                }
            }
        }



        public void PrintResult()
        {


        }

        public void StartDateSelect()
        {
         

        }

        public void EndDateSelect()
        {
          

        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
