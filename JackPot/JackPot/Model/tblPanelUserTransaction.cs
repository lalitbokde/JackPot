using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.Model
{
   public class tblPanelUserTransaction
    {
        public long iTransactionID { get; set; }
        public System.Guid sTransactionGUID { get; set; }
        public int iTransactionTypeID { get; set; }
        public long iTransactionRecordID { get; set; }
        public long iMadeBy { get; set; }
        public Nullable<int> iLocationID { get; set; }
        public int iShiftID { get; set; }
        public long iCustomerID { get; set; }
        public long iManagerID { get; set; }
        public string sTransactionDetails { get; set; }
        public decimal decAmount { get; set; }
        public decimal decNewBalance { get; set; }
        public System.DateTime dtTransactionDate { get; set; }
        public string sMachineName { get; set; }
        public string sUsername { get; set; }
        public string sIPAddress { get; set; }
    }
}
