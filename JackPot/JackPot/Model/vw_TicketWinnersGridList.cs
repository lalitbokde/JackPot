using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.Model
{
    public class vw_TicketWinnersGridList
    {
        public long BetID { get; set; }
        public string TicketNo { get; set; }
        public long WinnerID { get; set; }
        public System.DateTime WinDate { get; set; }
        public decimal WinningAmount { get; set; }
        public string Choice { get; set; }
        public string House { get; set; }
        public string Form { get; set; }
        public decimal BetAmount { get; set; }
        public bool Paid { get; set; }
        public string Bet { get; set; }
        public System.DateTime TicketDate { get; set; }
    }
}
