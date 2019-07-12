using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JackPot.CustomControls;
using JackPot.Droid.CustomControlAndroid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryAndroid))]

namespace JackPot.Droid.CustomControlAndroid
{
    class CustomEntryAndroid : EntryRenderer
    {
        public CustomEntryAndroid(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {

                Control.SetBackgroundColor(global::Android.Graphics.Color.ParseColor("#efefef"));
            }
        }
    }
}