using JackPot.Model;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JackPot.ViewModel
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        ICommand btn_Add;
        INavigation Navigation;

        public ICommand btnAdd =>
       btn_Add ?? (btn_Add = new Command(async () => await AddInGridAsync()));
        public List<ListOrder> ListItemVal { get; set; } = new List<ListOrder>();
        public ObservableRangeCollection<OrderGridModel> OrderGridListObservCollection { get; set; } = new ObservableRangeCollection<OrderGridModel>();
        //public List<OrderGridModel> OrderGridList { get; set; } = new List<OrderGridModel>();
        private async Task AddInGridAsync()
        {
            OrderGridModel Val = new OrderGridModel();
            Val.Amt = Amt;
            Val.Number = Number;
            Val.SB = SB;
            Val.House = "EMI";
            OrderGridListObservCollection.Add(Val);


        }

        string house;
        public string House
        {
            get { return house; }
            set
            {
                if (house != value)
                {
                    house = value;
                    OnPropertyChanged(nameof(House));

                }
            }
        }
        int number;
        public int Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    OnPropertyChanged(nameof(Number));

                }
            }
        }
        string sb;
        public string SB
        {
            get { return sb; }
            set
            {
                if (sb != value)
                {
                    sb = value;
                    OnPropertyChanged(nameof(SB));

                }
            }
        }

        decimal amt;

        public event PropertyChangedEventHandler PropertyChanged;

        public decimal Amt
        {
            get { return amt; }
            set
            {
                if (amt != value)
                {
                    amt = value;
                    OnPropertyChanged(nameof(Amt));

                }
            }
        }
        void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public OrderViewModel(INavigation navigation)
        {
            for(int i = 0; i < 10; i++)
            {

           
            var Model = new ListOrder();
            Model.ECA = "ECA";
            Model.EMI = "EMI";
            Model.EGA = "EGA";
            Model.ENY = "ENY";
            Model.ENJ = "ENJ";
            Model.EMIA = "EMIA";
            ListItemVal.Add(Model);
                i++;
            }

            Navigation = navigation;
        }
      
    }
}
