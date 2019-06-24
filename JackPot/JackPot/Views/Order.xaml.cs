﻿using JackPot.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JackPot.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Order : ContentPage
	{
		public Order ()
		{
			InitializeComponent ();
            BindingContext = new OrderViewModel(Navigation);
		}
	}
}