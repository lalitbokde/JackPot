using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WareHouseManagement.PCL.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JackPot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage
    {
        public ListView ListView;

        public MainPageMaster()
        {
            InitializeComponent();

            BindingContext = new MainPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        


      MainPageMenuItem SelectType;
        public MainPageMenuItem MenuItemsListSelect
        {
            get { return SelectType; }
            set
            {
                if (SelectType != value)
                {
                    SelectType = value;
                    OnPropertyChanged(nameof(MenuItemsListSelect));

                }
            }
        }




        class MainPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainPageMenuItem> MenuItems { get; set; }

            

          string agentName;
            public string AgentName
            {
                get { return agentName; }
                set
                {
                    if (agentName != value)
                    {
                        agentName = value;
                        OnPropertyChanged(nameof(AgentName));

                    }
                }
            }

            public  MainPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainPageMenuItem>(new[]
                {
                    new MainPageMenuItem { Id = 0, Title = "Bet Entry",TargetType=typeof(Order)},
                      new MainPageMenuItem { Id = 1, Title = "Previous TRX" ,TargetType=typeof(PreviousTRX)},
                        new MainPageMenuItem { Id = 2, Title = "Void Ticket" ,TargetType=typeof(VoidTicket) },
                          new MainPageMenuItem { Id = 7, Title = "Customer Deposit" ,TargetType=typeof(CustomerDetail)},
                          new MainPageMenuItem { Id = 3, Title = "Winner Number" ,TargetType=typeof(WiningScreen) },
                            new MainPageMenuItem { Id = 4, Title = "Pay Winner" ,TargetType=typeof(PayWinnerScreen) },
                              new MainPageMenuItem { Id = 5, Title = "Sales Info" ,TargetType=typeof(SalesInfo) },
                                new MainPageMenuItem { Id = 6, Title = "Set Customer" ,TargetType=typeof(SetCustomerScreen) },

                                
                                  new MainPageMenuItem { Id = 8, Title = "Customer WithDraw" ,TargetType=typeof(CustomerWithdrawalScreen)},
                                   new MainPageMenuItem { Id = 9, Title = "Log Out",TargetType=typeof(LogIn) },


                });

                AgentName = GlobalConstant.CustomerName;
               
            }

            
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}