using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.Model
{
    public class vw_CustomerDetails
    {
        public long CustomerID { get; set; }
        public string CustomerNo { get; set; }
        public string Customer { get; set; }
        public decimal Balance { get; set; }
        public string Password { get; set; }
        public string CardNo { get; set; }
        public bool Locked { get; set; }
        public bool Disabled { get; set; }
    }
}
