using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JackPot.Common
{
   public class ViewModelBase:BaseViewModel
    {

        protected INavigation Navigation { get; }

        public ViewModelBase(INavigation navigation = null)
        {
            Navigation = navigation;
        }

    }
    
}
