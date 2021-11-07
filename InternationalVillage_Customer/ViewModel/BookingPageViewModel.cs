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
    class BookingPageViewModel : BaseViewModel
    {
        public ICommand LuxuryBtnClick { get; set; }
        public ICommand HighBtnClick { get; set; }
        public ICommand StandardBtnClick { get; set; }

        public BookingPageViewModel()
        {
            LuxuryBtnClick = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                BookingTempStore.Instance.TypeOfApartment = "Luxury (Type 3A)";
                BookingTempStore.Instance.IndexTypeOfApartment = 0;
            });

            HighBtnClick = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                BookingTempStore.Instance.TypeOfApartment = "High Standard(Type 3B)";
                BookingTempStore.Instance.IndexTypeOfApartment = 1;
            });

            StandardBtnClick = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                BookingTempStore.Instance.TypeOfApartment = "Standard (Type 2A)";
                BookingTempStore.Instance.IndexTypeOfApartment = 2;
            });
        }
    }
}
