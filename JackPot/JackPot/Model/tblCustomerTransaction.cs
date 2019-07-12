using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.Model
{
   public class tblCustomerTransaction
    {
        public long iTransactionID { get; set; }
        public System.Guid sTransactionGUID { get; set; }
        public int iTransactionTypeID { get; set; }
        public Nullable<long> iTransactionRecordID { get; set; }
        public long iCustomerID { get; set; }
        public long iMadeBy { get; set; }
        public long iManagerID { get; set; }
        public string sTransactionDetails { get; set; }
        public decimal decAmount { get; set; }
        public decimal decNewBalance { get; set; }
        public System.DateTime dtTransactionDate { get; set; }
        public bool bIgnoreForTrigger { get; set; }
        public System.DateTime dtCreateDateTime { get; set; }
        public string sSessionID { get; set; }
        public string sIPAddress { get; set; }
    }
}
