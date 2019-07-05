using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.Model
{
   public class tblLottoBet
    {
        public long iBetID { get; set; }
        public long iTicketID { get; set; }
        public int iGameID { get; set; }
        public int iBetStatusID { get; set; }
        public System.DateTime dtPurchaseDate { get; set; }
        public System.DateTime dtBetDate { get; set; }
        public string sBall1 { get; set; }
        public string sBall2 { get; set; }
        public string sBall3 { get; set; }
        public string sBall4 { get; set; }
        public string sBall5 { get; set; }
        public string sStraightBall { get; set; }
        public bool bBoxed { get; set; }
        public decimal decBetAmount { get; set; }
        public double fPayFactor { get; set; }
        public System.DateTime dtCreateDateTime { get; set; }
        public System.Guid sGUID { get; set; }
        public bool bProcessed { get; set; }
        public System.DateTime dtProcessedOn { get; set; }

    }
}
