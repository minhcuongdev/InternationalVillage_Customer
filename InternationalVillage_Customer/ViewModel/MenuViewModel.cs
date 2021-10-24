using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InternationalVillage_Customer.ViewModel
{
    class MenuViewModel : BaseViewModel
    {

        public ICommand OpenHomePage { get; set; }
        public ICommand OpenBookingPage { get; set; }
        public ICommand OpenNotificationPage { get; set; }
        public ICommand OpenIncidentPage { get; set; }
        public ICommand OpenBillPage { get; set; }
        public ICommand Signout { get; set; }



        public MenuViewModel()
        {
            
            OpenHomePage = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                p.Navigate(new System.Uri("Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));
            });

            OpenBookingPage = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                p.Navigate(new System.Uri("Pages/BookingPage.xaml", UriKind.RelativeOrAbsolute));
            });

            OpenNotificationPage = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                p.Navigate(new System.Uri("Pages/NotificationPage.xaml", UriKind.RelativeOrAbsolute));
            });

            OpenIncidentPage = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                p.Navigate(new System.Uri("Pages/IncidentPage.xaml", UriKind.RelativeOrAbsolute));
            });

            OpenBillPage = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                p.Navigate(new System.Uri("Pages/BillPage.xaml", UriKind.RelativeOrAbsolute));
            });

            Signout = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Hide();
                LoginWindow loginform = new LoginWindow();
                loginform.Show();
                p.Close();
                

            });
        }
    }
}
