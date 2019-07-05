using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.Model
{
    public class tblBetsPerBall
    {
        public long iRecordID { get; set; }
        public System.DateTime dtDateFor { get; set; }
        public int iGameID { get; set; }
        public double fAmount { get; set; }
        public string sStraightBall { get; set; }
        public int iBetCount { get; set; }
        public System.DateTime dtCreateDateTime { get; set; }
    }
}
