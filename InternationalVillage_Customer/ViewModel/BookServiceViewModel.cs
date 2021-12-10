using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using InternationalVillage_Customer.Utilities;
using InternationalVillage_Customer.Store;
using InternationalVillage_Customer.Model;

namespace InternationalVillage_Customer.ViewModel
{
    class BookServiceViewModel:BaseViewModel
    {
        public ICommand ClearFocus { get; set; }
        public ICommand FullNameChanged { get; set; }
        public ICommand ValidateFullName { get; set; }
        public ICommand NumberPeopleChanged { get; set; }
        public ICommand ValidateNumberPeople { get; set; }
        public ICommand CheckoutDateSetUp { get; set; }
        public ICommand CheckinDateSetUp { get; set; }
        public ICommand CheckinDateChanged { get; set; }
        public ICommand ValidateCheckinDate { get; set; }
        public ICommand ValidateCheckoutDate { get; set; }
        public ICommand CheckoutDateChanged { get; set; }
        public ICommand TypeOfServiceChanged { get; set; }
        public ICommand ValidateTypeOfService { get; set; }
        public ICommand NumberServiceChanged { get; set; }
        public ICommand ValidateNumberService { get; set; }
        public ICommand TypeOfServiceLoaded { get; set; }

        public ICommand FullNameLoaded { get; set; }

        public ICommand Order { get; set; }
        public ICommand LoadTable { get; set; }
        public ICommand SelectedTable { get; set; }

        //Validate data
        private string fullname = AccountStore.Instance.Name;
        public string Fullname { get => fullname; set => fullname = value; }
        bool isFullNameCorrect = true;

        private string numberPeople = "";
        public string NumberPeople { get => numberPeople; set => numberPeople = value; }

        bool isNumberPeopleCorrect = false;

        private DateTime checkinDate = System.DateTime.Now;
        public DateTime CheckinDate { get => checkinDate; set => checkinDate = value; }
        private string strCheckinDate = "";
        public string StrCheckinDate { get => strCheckinDate; set => strCheckinDate = value; }
        bool isCheckinDateCorrect = false;


        private DateTime checkoutDate = System.DateTime.Now;
        public DateTime CheckoutDate { get => checkoutDate; set => checkoutDate = value; }
        private string strCheckoutDate = "";
        public string StrCheckoutDate { get => strCheckoutDate; set => strCheckoutDate = value; }
        bool isCheckoutDateCorrect = false;

        private string typeofService = BookingTempStore.Instance.TypeOfService;
        public string TypeOfService { get => typeofService; set => typeofService = value; }
        bool isTypeOfServiceCorrect = true;

        private string numberService = "";
        public string NumberService { get => numberService; set => numberService = value; }
        bool isNumberServiceCorrect = false;

        DetailApartmentBill selectedtale;

        public BookServiceViewModel()
        {
            ClearFocus = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                Keyboard.ClearFocus();
            });

            // Validate Data
            FullNameLoaded = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                p.Text = fullname;
                fullname = Validate.Instance.TextChanged(p, 5);

            });
            FullNameChanged = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                fullname = Validate.Instance.TextChanged(p, 5);

            });
            ValidateFullName = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isFullNameCorrect = Validate.Instance.Required(p, fullname, "Full Name", 5);
                
            });

            NumberPeopleChanged = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                numberPeople = Validate.Instance.TextChanged(p, 0,2);

            });
            ValidateNumberPeople = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
               
               isNumberPeopleCorrect = Validate.Instance.NumberRange(p, numberPeople, "Total number of people", 0, 150);
                
            });

            ValidateCheckinDate = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isCheckinDateCorrect = Validate.Instance.Required(p, strCheckinDate, "Check in Date");
                
            });
            ValidateCheckoutDate = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isCheckoutDateCorrect = Validate.Instance.Required(p, strCheckoutDate, "Check out Date");
              
            });
            //// Set up
            CheckinDateSetUp = new RelayCommand<CalendarDateRange>((p) => { return true; }, (p) =>
            {
                p.Start = System.DateTime.MinValue;
                p.End = (System.DateTime.Now.AddDays(-1));

            });
            CheckoutDateSetUp = new RelayCommand<CalendarDateRange>((p) => { return true; }, (p) =>
            {
                p.Start = System.DateTime.MinValue;
                p.End = (checkinDate.AddDays(-1));

            });

            CheckinDateChanged = new RelayCommand<DatePicker>((p) => { return true; }, (p) =>
            {
                checkinDate = Validate.Instance.DateChanged(p);
                strCheckinDate = checkinDate.ToString();
            });
            CheckoutDateChanged = new RelayCommand<DatePicker>((p) => { return true; }, (p) =>
            {
                checkoutDate = Validate.Instance.DateChanged(p);
                strCheckoutDate = checkoutDate.ToString();
            });

            TypeOfServiceLoaded = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = BookingTempStore.Instance.IndexTypeOfService;
                typeofService = Validate.Instance.SelecttionChanged(p);
                
            });

            TypeOfServiceChanged = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                typeofService = Validate.Instance.SelecttionChanged(p);
            });
            ValidateTypeOfService = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isTypeOfServiceCorrect = Validate.Instance.Required(p, typeofService, "Type of Service");
               

            });

            NumberServiceChanged = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                numberService = Validate.Instance.TextChanged(p,0, 2);

            });
            ValidateNumberService = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isNumberServiceCorrect = Validate.Instance.NumberRange(p, numberService, "Total number of service", 0, 150);
                
            });

            LoadTable = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                selectedtale = null;
                List<DetailApartmentBill> list = DetailBillStore.Instance.GetDetailApartmentBills(AccountStore.Instance.IdUser);
                p.ItemsSource = list;
               
            });

            SelectedTable = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                selectedtale = p.SelectedItem as DetailApartmentBill;
                

            });
            Order = new RelayCommand<Page>((p) => {
                return isFullNameCorrect && isNumberPeopleCorrect && (selectedtale != null)
                     && isNumberServiceCorrect && isTypeOfServiceCorrect;
            }, (p) =>
            {
                int insertBooking = 0;
                if (typeofService.Equals("Pool"))
                {
                    insertBooking = BookingTempStore.Instance.InsertService(AccountStore.Instance.IdUser, "S01", DateTime.Parse(selectedtale.Checkindate), DateTime.Parse(selectedtale.Checkoutdate), DateTime.Now, Int32.Parse(numberService),selectedtale.Id,int.Parse(numberPeople),0);
                }
                else if (typeofService.Equals("Gym"))
                {
                    insertBooking = BookingTempStore.Instance.InsertService(AccountStore.Instance.IdUser, "S02", DateTime.Parse(selectedtale.Checkindate), DateTime.Parse(selectedtale.Checkoutdate), DateTime.Now,Int32.Parse(numberService), selectedtale.Id, int.Parse(numberPeople),9);
                }
                else if (typeofService.Equals("Restaurant"))
                {
                    insertBooking = BookingTempStore.Instance.InsertService(AccountStore.Instance.IdUser, "S03", DateTime.Parse(selectedtale.Checkindate), DateTime.Parse(selectedtale.Checkoutdate), DateTime.Now, Int32.Parse(numberService), selectedtale.Id, int.Parse(numberPeople),20);
                }
                else if (typeofService.Equals("Tennis"))
                {
                    insertBooking = BookingTempStore.Instance.InsertService(AccountStore.Instance.IdUser, "S04", DateTime.Parse(selectedtale.Checkindate), DateTime.Parse(selectedtale.Checkoutdate), DateTime.Now, Int32.Parse(numberService), selectedtale.Id, int.Parse(numberPeople),13);
                }
                else if (typeofService.Equals("Golf"))
                {
                    insertBooking = BookingTempStore.Instance.InsertService(AccountStore.Instance.IdUser, "S05", DateTime.Parse(selectedtale.Checkindate), DateTime.Parse(selectedtale.Checkoutdate), DateTime.Now, Int32.Parse(numberService), selectedtale.Id, int.Parse(numberPeople),22);
                }
                else if (typeofService.Equals("Bar"))
                {
                    insertBooking = BookingTempStore.Instance.InsertService(AccountStore.Instance.IdUser, "S06", DateTime.Parse(selectedtale.Checkindate), DateTime.Parse(selectedtale.Checkoutdate), DateTime.Now, Int32.Parse(numberService), selectedtale.Id, int.Parse(numberPeople),22);
                }

                if (insertBooking > 0)
                {
                    MessageBox.Show("Success");
                    p.NavigationService.Navigate(new Uri("Pages/BookingServicePage.xaml", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    MessageBox.Show("Error");
                }

            });
        }
    }
}

