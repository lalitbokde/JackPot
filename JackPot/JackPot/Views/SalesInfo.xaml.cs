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
    public partial class SalesInfo : ContentPage
    {
        SalesInfoViewModel ViewModel;
        public SalesInfo()
        {
            InitializeComponent();
            BindingContext = ViewModel = new SalesInfoViewModel(Navigation);
        }
    }
}