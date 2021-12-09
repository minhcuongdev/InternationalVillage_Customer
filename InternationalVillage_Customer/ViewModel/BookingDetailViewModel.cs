using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

using InternationalVillage_Customer.Store;

namespace InternationalVillage_Customer.ViewModel
{
    class BookingDetailViewModel : BaseViewModel
    {
        public ICommand LoadFullName { get; set; }
        public ICommand LoadCheckIn { get; set; }
        public ICommand LoadCheckOut { get; set; }
        public ICommand LoadType { get; set; }
        public ICommand LoadRoom { get; set; }
        public ICommand LoadPrice { get; set; }

        public BookingDetailViewModel()
        {
            LoadFullName = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                p.Text = BookingTempStore.Instance.MyBookingSelected.FullName;
            });
            LoadCheckIn = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                p.Text = BookingTempStore.Instance.MyBookingSelected.CheckInDate.ToString("dd/MM/yyyy");
            });
            LoadCheckOut = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                p.Text = BookingTempStore.Instance.MyBookingSelected.CheckOutDate.ToString("dd/MM/yyyy");

            });
            LoadType = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                p.Text = BookingTempStore.Instance.MyBookingSelected.TypeOfApartment;
            });
            LoadRoom = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                p.Text = BookingTempStore.Instance.MyBookingSelected.IdApartment;
            });
            LoadPrice = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                p.Text = BookingTempStore.Instance.MyBookingSelected.Price.ToString() + "$";
            });
        }
    }
}
