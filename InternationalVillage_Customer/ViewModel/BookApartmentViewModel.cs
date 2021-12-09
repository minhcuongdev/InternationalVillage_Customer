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

namespace InternationalVillage_Customer.ViewModel
{
    class BookApartmentViewModel:BaseViewModel
    {
        public ICommand ClearFocus { get; set; }
        public ICommand FullNameChanged { get; set; }
        public ICommand ValidateFullName { get; set; }
        public ICommand NumberPeopleChanged { get; set; }
        public ICommand ValidateNumberPeople { get; set; }
        public ICommand CheckoutDateSetUp { get; set; }
        public ICommand CheckinDateSetUp { get; set; }
        public ICommand CheckinDateChanged { get; set; }
        public ICommand TypeOfApartmentChanged { get; set; }
        public ICommand ValidateTypeOfApartment { get; set; }
        public ICommand ValidateCheckinDate { get; set; }
        public ICommand ValidateCheckoutDate { get; set; }
        public ICommand CheckoutDateChanged { get; set; }
        public ICommand NumberApartmentChanged { get; set; }
        public ICommand ValidateNumberApartment { get; set; }
        public ICommand FullNameLoaded { get; set; }

        public ICommand TypeOfApartmentLoaded { get; set; }

        public ICommand Book { get; set; }

        //Validate data
        private string fullname = "";
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

        private string typeofApartment = BookingTempStore.Instance.TypeOfApartment;
        public string TypeOfApartment { get => typeofApartment; set => typeofApartment = value; }
        bool isTypeOfApartmentCorrect = true;

        private string numberApartment = "";
        public string NumberApartment { get => numberApartment; set => numberApartment = value; }
        bool isNumberApartmentCorrect = false;


        public BookApartmentViewModel()
        {
            ClearFocus = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                Keyboard.ClearFocus();
            });

            // Validate Data
            FullNameLoaded = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                p.Text = AccountStore.Instance.Name;
                fullname = p.Text;
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
                numberPeople = Validate.Instance.TextChanged(p,0, 2);

            });
            ValidateNumberPeople = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isNumberPeopleCorrect = Validate.Instance.NumberRange(p, numberPeople, "Total number of people", 0,150);
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

            TypeOfApartmentLoaded = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                p.SelectedIndex = BookingTempStore.Instance.IndexTypeOfApartment;
                typeofApartment = Validate.Instance.SelecttionChanged(p);
            });

            TypeOfApartmentChanged = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                typeofApartment = Validate.Instance.SelecttionChanged(p);
            });
            ValidateTypeOfApartment = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isTypeOfApartmentCorrect = Validate.Instance.Required(p, typeofApartment, "Type of Apartment");
            });
            NumberApartmentChanged = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                numberApartment = Validate.Instance.TextChanged(p, 0,2);
            });
            ValidateNumberApartment = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isNumberApartmentCorrect = Validate.Instance.NumberRange(p, numberApartment, "Total number of apartment", 0, 72);
            });
            Book = new RelayCommand<Page>((p) => { return isFullNameCorrect && isNumberPeopleCorrect && isCheckinDateCorrect && isCheckoutDateCorrect 
                                                            && isNumberApartmentCorrect && isTypeOfApartmentCorrect; 
            }, (p) =>
            {
               int insertBooking = 0;
               if (typeofApartment.Equals("Luxury (Type 3A)"))
               {
                    insertBooking = BookingTempStore.Instance.InsertBooking(AccountStore.Instance.IdUser, "3A", checkinDate, checkoutDate, Int32.Parse(numberApartment), "No Accept", DateTime.Now);
               }
               else if (typeofApartment.Equals("High Standard (Type 3B)"))
               {
                    insertBooking = BookingTempStore.Instance.InsertBooking(AccountStore.Instance.IdUser, "3B", checkinDate, checkoutDate, Int32.Parse(numberApartment), "No Accept", DateTime.Now);
               }
               else if (typeofApartment.Equals("Standard (Type 2A)"))
               {
                   insertBooking = BookingTempStore.Instance.InsertBooking(AccountStore.Instance.IdUser, "2A", checkinDate, checkoutDate, Int32.Parse(numberApartment), "No Accept", DateTime.Now);
               }

               if (insertBooking > 0 )
               {
                    MessageBox.Show("Success");
                    p.NavigationService.Navigate(new Uri("/Pages/HomePage.xaml", UriKind.RelativeOrAbsolute));
               }
               else 
               {
                    MessageBox.Show("Error");
               }
               
            });
        }
    }
}
