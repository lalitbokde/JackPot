using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.Model
{
    public class tblLottoTicket
    {
        public long iTicketID { get; set; }
        public string sTicketNo { get; set; }
        public int iTicketSourceID { get; set; }
        public System.DateTime dtTicketDate { get; set; }
        public System.DateTime dtPurchaseDate { get; set; }
        public int iNoOfBets { get; set; }
        public int iCashierID { get; set; }
        public int iLocationID { get; set; }
        public int iShiftID { get; set; }
        public Nullable<int> iCustomerID { get; set; }
        public decimal decTotal { get; set; }
        public decimal decTender { get; set; }
        public decimal decChange { get; set; }
        public double fCommissionRate { get; set; }
        public bool bUsesFreeBet { get; set; }
        public decimal decFreeBetAmount { get; set; }
        public System.DateTime dtCreateDateTime { get; set; }
        public bool bActive { get; set; }
        public bool bVoided { get; set; }
        public Nullable<int> iVoidedBy { get; set; }
        public int iVoidApprovedBy { get; set; }
        public Nullable<System.DateTime> dtVoidedOn { get; set; }
        public string sIPAddress { get; set; }
        public System.Guid sTicketGUID { get; set; }
        public string sSessionID { get; set; }
    }
}
