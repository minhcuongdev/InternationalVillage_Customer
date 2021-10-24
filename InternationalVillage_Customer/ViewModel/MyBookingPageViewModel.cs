using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

using InternationalVillage_Customer.Component;

namespace InternationalVillage_Customer.ViewModel
{
    class MyBookingPageViewModel : BaseViewModel
    {
        public ICommand LoadNotification { get; set; }

        public MyBookingPageViewModel()
        {
            LoadNotification = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                for (int i = 0; i < 20; i++)
                {
                    BookingInfoUC BookingInfoUC = new BookingInfoUC();                   
                    p.Children.Add(BookingInfoUC);
                }
            });
        }
    }
}
