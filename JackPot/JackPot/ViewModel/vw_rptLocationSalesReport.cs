using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.ViewModel
{
   public class vw_rptLocationSalesReport
    {
        public Nullable<decimal> Sales { get; set; }
        public Nullable<double> Commissions { get; set; }
        public string Cashier { get; set; }
        public string DateFor { get; set; }
        public int LocationID { get; set; }
        public string Location { get; set; }
    }
}
