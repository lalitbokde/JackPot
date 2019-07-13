using JackPot.Model;
using JackPot.Service;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using WareHouseManagement.PCL.Common;
using Xamarin.Forms;

namespace JackPot.ViewModel
{
   
    public class WinnerNumberViewModel : INotifyPropertyChanged
    {
        ICommand btn_PrintResult;
        ICommand btn_StartDate;
        ICommand btn_Show;
        INavigation Navigation;
        public WinnerNumberViewModel(INavigation navigation)
        {
            Navigation = navigation;
            LoadData();
        }
        public ObservableRangeCollection<vw_WinningNumbersGridList> WinnerGridListObservCollection { get; set; } = new ObservableRangeCollection<vw_WinningNumbersGridList>();
        public ICommand btnPrintResult =>
      btn_PrintResult ?? (btn_PrintResult = new Command(async () => PrintResult()));

        public ICommand btnStartDate =>
    btn_StartDate ?? (btn_StartDate = new Command(async () => StartDateSelect()));

        public ICommand btnShow =>
     btn_Show ?? (btn_Show = new Command(async () => LoadData(TxtStartDate)));


        DateTime txtstartDate=DateTime.UtcNow;
        public DateTime TxtStartDate
        {
            get { return txtstartDate; }
            set
            {
                if (txtstartDate != value)
                {
                    txtstartDate = value;
                    OnPropertyChanged(nameof(TxtStartDate));

                }
            }
        }

       



        public void PrintResult()
        {


        }

        public void StartDateSelect()
        {
         

        }
        public async void LoadData(DateTime? DateVal=null)
        {
            try
            {
                
                var UserDetail = await new loginPageService().GetDetailByUrl(Winning.GetWinningNumber +((DateVal == null)? DateTime.UtcNow.ToString("MM/dd/yyyy"): TxtStartDate.ToString("MM/dd/yyyy")));
                if (UserDetail.Status == 1)
                {
                    var wrShiipinglist = JsonConvert.DeserializeObject<List<vw_WinningNumbersGridList>>(UserDetail.Response.ToString());
                    foreach (var item in wrShiipinglist)
                    {
                        WinnerGridListObservCollection.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {

            }
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
