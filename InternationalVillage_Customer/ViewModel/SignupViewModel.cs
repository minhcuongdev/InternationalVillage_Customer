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
using System.Windows.Media.Imaging;

namespace InternationalVillage_Customer.ViewModel
{
    class SignupViewModel: BaseViewModel
    {
        public ICommand CloseSignupWindow { get; set; }
        public ICommand Signin { get; set; }
        public ICommand Drag { get; set; }
        public ICommand ClearFocus { get; set; }

        public ICommand ShowPassword { get; set; }
        public ICommand HidePassword { get; set; }

        // Validate Data
        private string fullname = "";
        public string Fullname { get => fullname; set => fullname = value; }
        bool isFullNameCorrect = false;
        private string identification = "";
        public string Identification { get => identification; set => identification = value; }
        bool isIdentificationCorrect = false;
        private string visa = "";
        public string Visa { get => visa; set => visa = value; }
        bool isVisaCorrect = false;
        private string username = "";
        public string Username { get => username; set => username = value; }
        bool isUserNameCorrect = false;
        private string password = "";
        public string Password { get => password; set => password = value; }
        bool isPasswordCorrect = false;

        public ICommand FullNameChanged { get; set; }
        public ICommand ValidateFullName { get; set; }
        public ICommand IdentificationChanged { get; set; }
        public ICommand ValidateIdentification { get; set; }
        public ICommand VisaChanged { get; set; }
        public ICommand ValidateVisa { get; set; }
        public ICommand UserNameChanged { get; set; }
        public ICommand ValidateUserName { get; set; }
        public ICommand PasswordChanged { get; set; }
        public ICommand ValidatePassword { get; set; }

        // Policy
        private bool isCheckPolicy = false;
        public bool IsCheckPolicy { get => isCheckPolicy; set => isCheckPolicy = value; }

        public ICommand PolicyClicked { get; set; }

        //submit
        public ICommand Submited { get; set; }

        public SignupViewModel()
        {
            CloseSignupWindow = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });

            Signin = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                LoginWindow loginform = new LoginWindow();
                loginform.Show();
                p.Close();
            });

            Drag = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {

                try
                {
                    p.DragMove();
                }
                catch (Exception)
                {
                    //throw
                }
            });

            ClearFocus = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Keyboard.ClearFocus();
            });

            // Validate Data
            FullNameChanged = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                Fullname = Validate.Instance.TextChanged(p, 5);

            });
            ValidateFullName = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isFullNameCorrect = Validate.Instance.Required(p, Fullname,"Full Name", 5);
            });

            IdentificationChanged = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                Identification = Validate.Instance.TextChanged(p,9);

            });
            ValidateIdentification = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                if (Visa.Equals("") || !Identification.Equals(""))
                { 
                    isIdentificationCorrect = Validate.Instance.Required(p, Identification, "Identification");
                    if(isIdentificationCorrect)
                    {
                        isIdentificationCorrect = Validate.Instance.Number(p, Identification, "Identification", 9);
                    }
                }
                else
                {
                    isIdentificationCorrect = true;
                    p.Visibility = Visibility.Hidden;
                }
            });

            VisaChanged = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                Visa = Validate.Instance.TextChanged(p,7);
            });
            ValidateVisa = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                if (Identification.Equals("") || !Visa.Equals(""))
                {
                    isVisaCorrect = Validate.Instance.Required(p, Visa, "VISA", 7);
                }
                else
                {
                    isVisaCorrect = true;
                    p.Visibility = Visibility.Hidden;
                }
            });

            UserNameChanged = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                Username = Validate.Instance.TextChanged(p, 5);

            });
            ValidateUserName = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isUserNameCorrect = Validate.Instance.Required(p, Username, "Username", 5);
            });

            PasswordChanged = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password = Validate.Instance.PasswordChanged(p, 5);
                EnableImage(p, "ImgPasswordShowHide");
            });
            ValidatePassword = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isPasswordCorrect = Validate.Instance.Required(p, Password, "Password", 5);
            });

            // Policy
            PolicyClicked = new RelayCommand<CheckBox>((p) => { return true; }, (p) =>
            {
                isCheckPolicy = (bool)p.IsChecked;
            });

            //Submit
            Submited = new RelayCommand<Window>((p) => { return isFullNameCorrect && isIdentificationCorrect && isVisaCorrect && isUserNameCorrect && isPasswordCorrect && IsCheckPolicy; }, (p) =>
            {
                int insertCustomer = CustomerStore.Instance.InsertCustomer(Fullname, Identification, Visa, "");
                int insertAccount = AccountStore.Instance.InsertAccount(Username, Password, "Customer", CustomerStore.Instance.ID);
                if(insertAccount > 0 && insertCustomer > 0 )
                {
                    MessageBox.Show("succes");
                    LoginWindow loginform = new LoginWindow();
                    loginform.Show();
                    p.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
                
            });

            ShowPassword = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                showPassword(p, "ImgPasswordShowHide", "Password", "VisiblePassword");
            });

            HidePassword = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                hidePassword(p, "ImgPasswordShowHide", "Password", "VisiblePassword");
            });
        }

        void EnableImage(PasswordBox p, string image)
        {
            if (p.Parent is Grid parent)
            {
                Image img = parent.FindName(image) as Image;
                if (Password.Length > 0)
                {
                    img.Visibility = Visibility.Visible;
                }
                else
                {
                    img.Visibility = Visibility.Hidden;
                }
            }
        }

        void showPassword(Grid p, string image, string passwordBox, string visiblePasswordBox)
        {
            Image img = p.FindName(image) as Image;
            TextBox visiblePassword = p.FindName(visiblePasswordBox) as TextBox;
            PasswordBox password = p.FindName(passwordBox) as PasswordBox;

            img.Source = new BitmapImage(new Uri("Image/Hide.jpg", UriKind.RelativeOrAbsolute));
            visiblePassword.Visibility = Visibility.Visible;
            password.Visibility = Visibility.Hidden;

            visiblePassword.Text = password.Password;
        }

        void hidePassword(Grid p, string image, string passwordBox, string visiblePasswordBox)
        {
            Image img = p.FindName(image) as Image;
            TextBox visiblePassword = p.FindName(visiblePasswordBox) as TextBox;
            PasswordBox password = p.FindName(passwordBox) as PasswordBox;

            img.Source = new BitmapImage(new Uri("Image/Show.jpg", UriKind.RelativeOrAbsolute));
            visiblePassword.Visibility = Visibility.Hidden;
            password.Visibility = Visibility.Visible;

            password.Focus();
        }

    }
}
