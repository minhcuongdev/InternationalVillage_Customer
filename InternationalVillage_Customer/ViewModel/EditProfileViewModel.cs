using InternationalVillage_Customer.Store;
using InternationalVillage_Customer.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace InternationalVillage_Customer.ViewModel
{
    class EditProfileViewModel : BaseViewModel
    {
        public ICommand LoadProfile { get; set; }
        public ICommand SelectPicture { get; set; }
        public ICommand OpenChangePassword { get; set; }

        public ICommand SavePersonalInfomation { get; set; }
        public ICommand SaveUsername { get; set; }

        public ICommand FullNameChanged { get; set; }
        public ICommand ValidateFullName { get; set; }
        public ICommand IdentificationChanged { get; set; }
        public ICommand ValidateIdentification { get; set; }
        public ICommand VisaChanged { get; set; }
        public ICommand ValidateVisa { get; set; }
        public ICommand UserNameChanged { get; set; }
        public ICommand ValidateUserName { get; set; }

        string Fullname = "";
        string Id = "";
        string Visa = "";
        string UserName = "";
        string Avatar = "";

        bool isFullNameCorrect = true;
        bool isIdentificationCorrect = true;
        bool isVisaCorrect = true;

        bool isUserNameCorrect = true;

        public EditProfileViewModel()
        {
            LoadProfile = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                if (!AccountStore.Instance.Avatar.Equals(""))
                {
                    ImageBrush img = (ImageBrush)p.FindName("AvatarProfile");
                    img.ImageSource = new ImageSourceConverter().ConvertFromString(AccountStore.Instance.Avatar) as ImageSource;
                }

                TextBox fullName = p.FindName("FullName") as TextBox;
                TextBox id = p.FindName("ID") as TextBox;
                TextBox visa = p.FindName("VISA") as TextBox;
                TextBox username = p.FindName("Username") as TextBox;

                fullName.Text = Fullname = AccountStore.Instance.Name;
                id.Text = Id = AccountStore.Instance.Identification;
                visa.Text = Visa = AccountStore.Instance.Visa;
                username.Text = UserName = AccountStore.Instance.Username;

            });

            SelectPicture = new RelayCommand<ImageBrush>((p) => { return true; }, (p) =>
            {
                OpenFileDialog dialog = new OpenFileDialog
                {
                    Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*",
                    CheckFileExists = true,
                    Multiselect = false
                };
                if (dialog.ShowDialog() == true)
                {
                    Avatar = dialog.FileName;
                    BitmapImage bitmap = new BitmapImage(new Uri(dialog.FileName));
                    p.ImageSource = bitmap;
                }

            });

            FullNameChanged = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                Fullname = Validate.Instance.TextChanged(p, 5);

            });
            ValidateFullName = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isFullNameCorrect = Validate.Instance.Required(p, Fullname, "Full Name", 5);
            });

            IdentificationChanged = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                Id= Validate.Instance.TextChanged(p);

            });
            ValidateIdentification = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                if (Visa.Equals("") || !Id.Equals(""))
                {
                    isIdentificationCorrect = Validate.Instance.Required(p, Id, "Identification");
                    if (isIdentificationCorrect)
                    {
                        isIdentificationCorrect = Validate.Instance.Number(p, Id, "Identification", 9);
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
                Visa = Validate.Instance.TextChanged(p);
            });
            ValidateVisa = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                if (Id.Equals("") || !Visa.Equals(""))
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
                UserName = Validate.Instance.TextChanged(p, 5);

            });
            ValidateUserName = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                isUserNameCorrect = Validate.Instance.Required(p, UserName, "Username", 5);
            });

            OpenChangePassword = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                ChangePasswordWindow FChangePass = new ChangePasswordWindow();
                FChangePass.ShowDialog();
            });

            SavePersonalInfomation = new RelayCommand<Page>((p) => { return isFullNameCorrect && isIdentificationCorrect && isVisaCorrect; }, (p) =>
            {
                if(!Avatar.Equals(""))
                {
                    Window w = Window.GetWindow(p);
                    if( w != null)
                    {
                        ImageBrush img = w.FindName("Avatar") as ImageBrush;
                        BitmapImage bitmap = new BitmapImage(new Uri(Avatar));
                        img.ImageSource = bitmap;
                    }
                }

                if(AccountStore.Instance.UpdateProfile(Fullname,Id,Visa))
                {
                    AccountStore.Instance.Name = Fullname;
                    AccountStore.Instance.Identification = Id;
                    AccountStore.Instance.Visa = Visa;
                    MessageBox.Show("Success");
                }
            });

            SaveUsername = new RelayCommand<Page>((p) => { return isUserNameCorrect; }, (p) =>
            {
                if (AccountStore.Instance.UpdateUserName(UserName))
                {
                    AccountStore.Instance.Username = UserName;
                    MessageBox.Show("Success");
                }
            });
        }
    }
}
