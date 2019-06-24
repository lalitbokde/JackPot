using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.ViewModel
{
    class LogInModel
    {
        public long iPanelUserID { get; set; }
        public string sUserName { get; set; }
        public string sPassword { get; set; }
        public string sFirstName { get; set; }
        public string sLastName { get; set; }
        public string sTel { get; set; }
        public string sAddress { get; set; }
        public string sWindowUser { get; set; }
        public string sMachineName { get; set; }
        public System.DateTime dtStartDate { get; set; }
        public bool bEnforceSalesLimit { get; set; }
        public decimal decSalesLimit { get; set; }
        public int iCommissionTypeID { get; set; }
        public double fCommissionRate { get; set; }
        public int iLocationID { get; set; }
        public int iPayoutSchemeID { get; set; }
        public int iReceiptMessageID { get; set; }
        public bool bIsSystemUser { get; set; }
        public bool bIsManager { get; set; }
        public bool bInactive { get; set; }
        public bool bLocked { get; set; }
        public bool bDisable { get; set; }
        public decimal decBalance { get; set; }
        public string sNotes { get; set; }
        public int iCreatedBy { get; set; }
        public System.DateTime dtCreatedOn { get; set; }
        public int iUpdatedBy { get; set; }
        public System.DateTime dtUpdatedOn { get; set; }
        public System.DateTime dtLastLoginOn { get; set; }
        public bool bDeleted { get; set; }
        public int iDeletedBy { get; set; }
        public System.DateTime dtDeletedOn { get; set; }
        public decimal decFixedFloat { get; set; }

    }
}
