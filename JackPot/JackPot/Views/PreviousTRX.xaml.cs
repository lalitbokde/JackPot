using JackPot.Service;
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
	public partial class PreviousTRX : ContentPage
	{
        PreviewScreenViewModel Model;
        public PreviousTRX ()
		{
			InitializeComponent ();
            BindingContext = Model = new PreviewScreenViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadDetail();
        }
            public async void LoadDetail()
        {
            var TransactionNumberVal = await new loginPageService().GetDetailByUrl(BetEntry.GetTrancationNumber + GlobalConstant.UserName);
            if (TransactionNumberVal.Status == 1)
            {

                Model.TicketNo = TransactionNumberVal.Response.ToString();
                Model.BalAmount ="$ "+ GlobalConstant.BalanceAmt.ToString();
            }
        }
       

}
}