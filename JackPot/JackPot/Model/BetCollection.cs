using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.Model
{
    public class BetCollection
    {
        public int Numbers { get; set; }
        public string House { get; set; }
        public string SB { get; set; }
        public decimal Amt { get; set; }
        public int GameID { get; set; }
        public System.DateTime dtBetDate { get; set; }
        public string Ball1 { get; set; }
        public string Ball2 { get; set; }
        public string Ball3 { get; set; }
        public string Ball4 { get; set; }
        public string StraightBall { get; set; }
        public decimal BetAmount { get; set; }
        public double PayFactor { get; set; }
    }
}
