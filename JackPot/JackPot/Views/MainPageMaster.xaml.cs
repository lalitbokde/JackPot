using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        class MainPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainPageMenuItem> MenuItems { get; set; }
            
            public MainPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainPageMenuItem>(new[]
                {
                    new MainPageMenuItem { Id = 0, Title = "Bet Entry" },
                      new MainPageMenuItem { Id = 1, Title = "Previous TRX" },
                        new MainPageMenuItem { Id = 2, Title = "Void Ticket" },
                          new MainPageMenuItem { Id = 3, Title = "Winner Number" },
                            new MainPageMenuItem { Id = 4, Title = "Pay Winner" },
                              new MainPageMenuItem { Id = 5, Title = "Sales Info" },
                                new MainPageMenuItem { Id = 6, Title = "Set Customer" },

                                  new MainPageMenuItem { Id = 7, Title = "Customer Deposit" },
                                  new MainPageMenuItem { Id = 8, Title = "Customer WithDraw" },
                                   new MainPageMenuItem { Id = 9, Title = "Log Out" },


                });
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