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
    class ReportIncidentViewModel : BaseViewModel
    {
        public ICommand ClearFocus { get; set; }
        public ICommand FullNameChanged { get; set; }
        public ICommand ValidateFullName { get; set; }
        public ICommand NumberOfApartmentChanged { get; set; }
        public ICommand ValidateNumberOfApartment { get; set; }
        public ICommand TypeOfIncidentChanged { get; set; }
        public ICommand ValidateTypeOfIncident { get; set; }
        public ICommand LevelOfAffectionChanged { get; set; }
        public ICommand ValidateLevelOfAffection { get; set; }
        public ICommand DescriptionChanged { get; set; }
        public ICommand ValidateDescription { get; set; }
        public ICommand Report { get; set; }

        //Validate data
        private string fullname = "";
        public string Fullname { get => fullname; set => fullname = value; }
        bool isFullNameCorrect = false;

        private string numberofapartment = "";
        public string Numberofapartment { get => numberofapartment; set => numberofapartment = value; }
        bool isNumberOfApartmentCorrect = false;

        private string typeofincident = "";
        public string TypeOfIncident { get => typeofincident; set => typeofincident = value; }
        bool isTypeOfIncidentCorrect = false;

        private string levelofaffection = "";
        public string LevelOfAffection { get => levelofaffection; set => levelofaffection = value; }
        bool isLevelOfAffectionCorrect = false;

        private string description = "";
        public string Description { get => description; set => description = value; }
        bool isDescriptionCorrect = false;

        public ReportIncidentViewModel()
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

            NumberOfApartmentChanged = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                numberofapartment = Validate.Instance.TextChanged(p, 1,4);

            });
            ValidateNumberOfApartment = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isNumberOfApartmentCorrect = Validate.Instance.Required(p, numberofapartment, "Number of Apartment", 0,4);
            });

            TypeOfIncidentChanged = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                typeofincident = Validate.Instance.SelecttionChanged(p);

            });
            ValidateTypeOfIncident = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isTypeOfIncidentCorrect = Validate.Instance.Required(p, typeofincident, "Type of Apartment");
               
            });

            LevelOfAffectionChanged = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                levelofaffection = Validate.Instance.SelecttionChanged(p);

            });
            ValidateLevelOfAffection = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isLevelOfAffectionCorrect = Validate.Instance.Required(p, levelofaffection, "Level of Affection");
             
            });

            DescriptionChanged = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                description = Validate.Instance.TextChanged(p, 0,1000);

            });
            ValidateDescription = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isDescriptionCorrect = Validate.Instance.Required(p, description, "Description", 0);
            });

            Report = new RelayCommand<Button>((p) => {
                return isFullNameCorrect && isNumberOfApartmentCorrect && isTypeOfIncidentCorrect && isLevelOfAffectionCorrect
                     && isDescriptionCorrect ;
            }, (p) =>
            {
                bool checkIdApartment = BookingTempStore.Instance.CheckIdApartment(numberofapartment);
                if (checkIdApartment == false)
                {
                    MessageBox.Show("Number of apartment is not exist");
                }
                else
                {
                    int insertReport = 0;
                    string Id_Incicdent = "I"+(BookingTempStore.Instance.CountIncident()+1).ToString();
                    {
                        insertReport = BookingTempStore.Instance.InsertIncident(Id_Incicdent, AccountStore.Instance.IdUser, "", numberofapartment, typeofincident, description, levelofaffection, "No accepted");
                    }

                    if (insertReport > 0)
                    {
                        MessageBox.Show("Success");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }

            });

        }
    }
}
