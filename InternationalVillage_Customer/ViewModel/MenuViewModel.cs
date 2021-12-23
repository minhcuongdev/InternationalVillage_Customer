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

using InternationalVillage_Customer.Store;

namespace InternationalVillage_Customer.ViewModel
{
    class MenuViewModel : BaseViewModel
    {

        public ICommand OpenHomePage { get; set; }
        public ICommand OpenBookingPage { get; set; }
        public ICommand OpenNotificationPage { get; set; }
        public ICommand OpenIncidentPage { get; set; }
        public ICommand OpenBillPage { get; set; }
        public ICommand OpenBookingServicePage { get; set; }
        public ICommand OpenMyBookingPage { get; set; }
        public ICommand OpenChatPage { get; set; }
        public ICommand OpenProfilePage { get; set; }
        public ICommand Signout { get; set; }

        public ICommand MouseLeave { get; set; }
        public ICommand MouseEnter { get; set; }

        public ICommand LoadAvatar { get; set; }
        public ICommand LoadName { get; set; }

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
                p.Navigate(new System.Uri("Pages/MyBillPage.xaml", UriKind.RelativeOrAbsolute));
            });

            OpenBookingServicePage = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                p.Navigate(new System.Uri("Pages/BookingServicePage.xaml", UriKind.RelativeOrAbsolute));
            });

            OpenMyBookingPage = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                p.Navigate(new System.Uri("Pages/MyBookingPage.xaml", UriKind.RelativeOrAbsolute));
            });

            OpenChatPage = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                p.Navigate(new System.Uri("Pages/ChatPage.xaml", UriKind.RelativeOrAbsolute));
            });

            OpenProfilePage = new RelayCommand<Frame>((p) => { return true; }, (p) =>
            {
                p.Navigate(new System.Uri("Pages/EditProfilePage.xaml", UriKind.RelativeOrAbsolute));
            });

            Signout = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Hide();
                LoginWindow loginform = new LoginWindow();
                loginform.Show();
                p.Close();
                

            });

            MouseEnter = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                BrushConverter bc = new BrushConverter();
                p.Background = (Brush)bc.ConvertFrom("#2f9cfa");
            });

            MouseLeave = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {

                p.Background = Brushes.Transparent;
            });

            LoadAvatar = new RelayCommand<ImageBrush>((p) => { return true; }, (p) =>
            {
                if (!AccountStore.Instance.Avatar.Equals(""))
                    p.ImageSource = new ImageSourceConverter().ConvertFromString(AccountStore.Instance.Avatar) as ImageSource;
            });

            LoadName = new RelayCommand<Label>((p) => { return true; }, (p) =>
            {
                p.Content = AccountStore.Instance.Name;
            });
        }
    }
}
