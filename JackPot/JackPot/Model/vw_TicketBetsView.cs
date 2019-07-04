using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.Model
{
   public class vw_TicketBetsView
    {
        public string TicketNo { get; set; }
        public int HouseID { get; set; }
        public int GameID { get; set; }
        public string Pick { get; set; }
        public bool Boxed { get; set; }
        public decimal Amount { get; set; }
        public double PayFactor { get; set; }
        public string Form { get; set; }
        public string House { get; set; }
        public System.DateTime PurchasedDate { get; set; }
        public bool Voided { get; set; }
        public long TicketID { get; set; }
    }
}
