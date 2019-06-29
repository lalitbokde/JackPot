using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.Model
{
   public class RequestTenderModel
    {

        public long PanelUserID { get; set; }
        public string TenderAmount { get; set; }
        public string Change { get; set; }
       // TicketSource TicketSource { get; set; }
        public int NoOfBets { get; set; }
        public Decimal Totals { get; set; }
        public int MintShiftID { get; set; }
        public double CommissionRate { get; set; }
        public int mdecFreeBetTotal { get; set; }
        public bool UsesFreeBet { get; set; }
        public decimal FreeBetAmount { get; set; }
    }
}
