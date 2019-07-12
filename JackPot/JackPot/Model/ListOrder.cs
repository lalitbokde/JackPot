using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JackPot.Model
{
   public class ListOrder
    {
        public bool chkEarly1 { get; set; }
        public string Early1 { get; set; }
        public int Early1Id { get; set; }
        public bool chkEarly2 { get; set; }
        public string Early2 { get; set; }
        public int Early2Id { get; set; }
        public bool chkEarly3 { get; set; }
        public string Early3 { get; set; }
        public int Early3Id { get; set; }
        public bool chkEarly4 { get; set; }
        public string Early4 { get; set; }
        public int Early4Id { get; set; }
        public Color RowColor { get; set; }
    }
}
