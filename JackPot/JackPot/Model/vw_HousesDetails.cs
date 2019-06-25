using System;
using System.Collections.Generic;
using System.Text;

namespace JackPot.Model
{
    public  class vw_HousesDetails
    {
        public int HouseID { get; set; }
        public string HouseName { get; set; }
        public string FullHouseName { get; set; }
        public System.DateTime PanelCutOff { get; set; }
        public System.DateTime PDACutOff { get; set; }
        public System.DateTime WebCutOff { get; set; }
        public int HouseOrder { get; set; }
        public string ControlName { get; set; }
        public bool DisableHouse { get; set; }
        public bool IsLottoGame { get; set; }
        public bool DisableWeb { get; set; }
        public string StateCode { get; set; }
        public bool IsEarlyHouse { get; set; }
        public bool PlaysOnSunday { get; set; }
        public bool Has4Ball { get; set; }
    }
}
