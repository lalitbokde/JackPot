using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.Model
{
    public class vw_PanelUserShiftTrxSummaryGridList
    {
        public Nullable<int> NoOfTrx { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string TrxType { get; set; }
        public long PanelUserID { get; set; }
        public bool IsDebit { get; set; }
        public int ShiftID { get; set; }
    }
}
