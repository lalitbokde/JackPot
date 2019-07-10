using JackPot.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouseManagement.PCL.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JackPot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalesInfo : ContentPage
    {
        SalesInfoViewModel ViewModel;
        public SalesInfo()
        {
            InitializeComponent();
            BindingContext = ViewModel = new SalesInfoViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.TotalAmt =( ViewModel.ShiftGridListObservCollection.Where(a => a.IsDebit == true).Sum(a => a.Total).Value + ViewModel.ShiftGridListObservCollection.Where(a => a.IsDebit == false).Sum(a => a.Total).Value);
            ViewModel.SalesTotal = ViewModel.ShiftGridListObservCollection.Where(a => a.IsDebit == true).Sum(a => a.Total).Value;
            ViewModel.AgentName = GlobalConstant.CustomerName;
        }
    }
}