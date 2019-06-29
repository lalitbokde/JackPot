using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackPot.Views
{

    public class MainPageMenuItem
    {
          public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
        public MainPageMenuItem()
        {
            if(Id==0)
            {
                TargetType = typeof(Order);
            }
            if (Id == 1)
            {
                TargetType = typeof(PreviousTRX);
            }
            if (Id == 2)
            {
                TargetType = typeof(SearchReceipt);
            }
            if (Id == 3)
            {
                TargetType = typeof(Order);
            }
            if (Id == 4)
            {
                TargetType = typeof(Order);
            }
            if (Id == 5)
            {
                TargetType = typeof(Order);
            }
            if (Id == 6)
            {
                TargetType = typeof(Order);
            }
            if (Id == 7)
            {
                TargetType = typeof(CustomerDetail);
            }
            if (Id == 8)
            {
                TargetType = typeof(Order);
            }
            if (Id == 9)
            {
                TargetType = typeof(Order);
            }

        }

      
    }
}