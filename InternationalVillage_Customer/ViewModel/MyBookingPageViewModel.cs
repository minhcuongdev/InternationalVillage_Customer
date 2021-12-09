using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

using InternationalVillage_Customer.Component;
using InternationalVillage_Customer.Model;
using InternationalVillage_Customer.Store;

namespace InternationalVillage_Customer.ViewModel
{
    class MyBookingPageViewModel : BaseViewModel
    {
        public ICommand LoadNotification { get; set; }

        public MyBookingPageViewModel()
        {
            LoadNotification = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                List<BookingApartmentTemp> list = BookingTempStore.Instance.GetMyBooking();
                foreach(BookingApartmentTemp b in list)
                {
                    BookingInfoUC booking = new BookingInfoUC();
                    booking.Type.Text = b.IdApartment;
                    booking.CheckIn.Text = b.CheckInDate.ToString("dd/MM/yyyy");
                    booking.CheckOut.Text = b.CheckOutDate.ToString("dd/MM/yyyy");
                    booking.State.Text = "Approved";
                    p.Children.Add(booking);
                }
                
            });
        }
    }
}
