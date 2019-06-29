using JackPot.Helper;
using JackPot.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JackPot.Service
{
    public class BetEntrySevice:ContentPage
    {
        HttpClientHelper _helper;
        public BetEntrySevice()
        {
            _helper = new HttpClientHelper();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
        public async Task<ResultModel> PostBetEntry(RequestTenderModel model, string Url)
        {
            ResultModel _User = new ResultModel();
            try
            {

                _User = await _helper.Post<RequestTenderModel>(model, Url);

                return _User;
            }
            catch (Exception ex)
            {
                // Crashes.TrackError(ex);
                return _User;
            }
        }

    }
}
