using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

using InternationalVillage_Customer.Store;
using InternationalVillage_Customer.Model;
using System.Windows;

namespace InternationalVillage_Customer.ViewModel
{
    public class BookingInfoUCViewModel : BaseViewModel
    {
        public ICommand Choose { get; set; }

        public BookingInfoUCViewModel()
        {
            Choose = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
            {
                TextBlock id = p.FindName("Type") as TextBlock;
                TextBlock checkIn = p.FindName("CheckIn") as TextBlock;
                TextBlock checkOut = p.FindName("CheckOut") as TextBlock;

                foreach(BookingApartmentTemp b in BookingTempStore.Instance.bookingApartmentTemps)
                {
                    if(id.Text.Equals(b.IdApartment) && checkIn.Text.Equals(b.CheckInDate.ToString("dd/MM/yyyy")) && checkOut.Text.Equals(b.CheckOutDate.ToString("dd/MM/yyyy")))
                    {
                        BookingTempStore.Instance.MyBookingSelected = b;
                        break;
                    }
                }

                Page page = GetPage(p) as Page;
                page.NavigationService.Navigate(new Uri("/Pages/BookingDetailPage.xaml", UriKind.RelativeOrAbsolute));

            });
        }

        FrameworkElement GetPage(UserControl p)
        {
            FrameworkElement page = p;
            for(int i=0;i<4;i++)
            {
                page = page.Parent as FrameworkElement;
            }

            return page;
        }
    }
}
