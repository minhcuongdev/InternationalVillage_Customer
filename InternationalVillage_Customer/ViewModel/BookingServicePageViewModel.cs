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
    class BookingServicePageViewModel : BaseViewModel
    {
        public ICommand SwimmingPoolBtnClick { get; set; }
        public ICommand RestaurantBtnClick { get; set; }
        public ICommand GymBtnClick { get; set; }
        public ICommand TennisBtnClick { get; set; }
        public ICommand GolfBtnClick { get; set; }
        public ICommand BarBtnClick { get; set; }

        public BookingServicePageViewModel()
        {
            SwimmingPoolBtnClick = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                BookingTempStore.Instance.TypeOfService = "Swimming Pool";
                BookingTempStore.Instance.IndexTypeOfService = 0;
            });

            RestaurantBtnClick = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                BookingTempStore.Instance.TypeOfService = "Restaurant";
                BookingTempStore.Instance.IndexTypeOfService = 2;
            });

            GymBtnClick = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                BookingTempStore.Instance.TypeOfService = "Gym";
                BookingTempStore.Instance.IndexTypeOfService = 1;
            });

            TennisBtnClick = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                BookingTempStore.Instance.TypeOfService = "Tennis";
                BookingTempStore.Instance.IndexTypeOfService = 3;
            });

            GolfBtnClick = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                BookingTempStore.Instance.TypeOfService = "Golf";
                BookingTempStore.Instance.IndexTypeOfService = 4;
            });

            BarBtnClick = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                BookingTempStore.Instance.TypeOfService = "Bar";
                BookingTempStore.Instance.IndexTypeOfService = 5;
            });
        }
    }
}
