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
        

        //Validate data
        private string fullname = "";
        public string Fullname { get => fullname; set => fullname = value; }
        bool isFullNameCorrect = false;

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
        bool isTypeOfServiceCorrect = false;

        private string numberService = "";
        public string NumberService { get => numberService; set => numberService = value; }
        bool isNumberServiceCorrect = false;


        public BookServiceViewModel()
        {
            ClearFocus = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                Keyboard.ClearFocus();
            });

            // Validate Data
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
        }
    }
}

