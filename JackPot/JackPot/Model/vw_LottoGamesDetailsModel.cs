using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.Model
{
   public class vw_LottoGamesDetailsModel
    {
        public long iGameRecordID { get; set; }
        public int GameID { get; set; }
        public string Game { get; set; }
        public string GameFullName { get; set; }
        public int HouseID { get; set; }
        public int NoOfBalls { get; set; }
        public decimal MaxBet { get; set; }
        public decimal MinBet { get; set; }
        public decimal MaxPerBall { get; set; }
        public decimal WebMinBet { get; set; }
        public decimal WebMaxBet { get; set; }
        public decimal WebMaxPerBall { get; set; }
        public bool DisableGame { get; set; }
        public int GameOrder { get; set; }
    }
}
