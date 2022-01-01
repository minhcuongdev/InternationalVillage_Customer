﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using InternationalVillage_Customer.Store;
using InternationalVillage_Customer.Model;
using System.Windows.Media.Imaging;

namespace InternationalVillage_Customer.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        public ICommand CloseLoginWindow { get; set; }
        public ICommand ClearFocus { get; set; }
        public ICommand SignIn { get; set; }
        public ICommand HandleTextChanged { get; set; }
        public ICommand HandlePasswordChanged { get; set; }      
        public ICommand CreateAccount { get; set; }
        public ICommand Drag { get; set; }

        public ICommand ShowPassword { get; set; }
        public ICommand HidePassword { get; set; }
        public ICommand OpenForgotPassword { get; set; }


        private string username = "";
        private string password = "";

        public string Username { get => username; set { username = value; OnPropertyChanged(); } }
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }

        

        public LoginViewModel()
        {
            HandleTextChanged = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                Username = p.Text;
            });
            HandlePasswordChanged = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password = p.Password;
                if (p.Parent is Grid container)
                {
                    Image img = container.FindName("ImgShowHide") as Image;
                    if(Password.Length>0)
                    {
                        img.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        img.Visibility = Visibility.Hidden;
                    }
                }
 
            });

            ShowPassword = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                showPassword(p);
            });

            HidePassword = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                hidePassword(p);
            });

            CloseLoginWindow = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });

            ClearFocus = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Keyboard.ClearFocus();
            });

            SignIn = new RelayCommand<Window>((p) => {
                return !Username.Equals("") && !Password.Equals("");
            }, (p) =>
            {
                if (AccountStore.Instance.Authentication(Username,Password))
                {
                    Account acc = AccountStore.Instance.GetAccount(Username, Password);
                    MenuWindow menuform = new MenuWindow();
                    menuform.Show();
                    p.Close();
                } else
                {
                    MessageBox.Show("Wrong Account !! Please, enter again !!");
                }
            });

            OpenForgotPassword = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {               
                    ForgotPasswordWindow Fforgotpassword = new ForgotPasswordWindow();
                    Fforgotpassword.ShowDialog();                              
            });

            CreateAccount = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
              
               SignupWindow signupform = new SignupWindow();
               signupform.Show();
               p.Close();
            });

            Drag = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                try
                {
                    p.DragMove();
                }
                catch(Exception)
                {
                    //throw
                }
            });
        }

        void showPassword(Grid p)
        {
            Image img = p.FindName("ImgShowHide") as Image;
            TextBox visiblePassword = p.FindName("VisiblePassword") as TextBox;
            PasswordBox password = p.FindName("PasswordBox") as PasswordBox;

            img.Source = new BitmapImage(new Uri("Image/Hide.jpg", UriKind.RelativeOrAbsolute));
            visiblePassword.Visibility = Visibility.Visible;
            password.Visibility = Visibility.Hidden;

            visiblePassword.Text = password.Password;
        }

        void hidePassword(Grid p)
        {
            Image img = p.FindName("ImgShowHide") as Image;
            TextBox visiblePassword = p.FindName("VisiblePassword") as TextBox;
            PasswordBox password = p.FindName("PasswordBox") as PasswordBox;

            img.Source = new BitmapImage(new Uri("Image/Show.jpg", UriKind.RelativeOrAbsolute));
            visiblePassword.Visibility = Visibility.Hidden;
            password.Visibility = Visibility.Visible;

            password.Focus();
        }
    }
}
