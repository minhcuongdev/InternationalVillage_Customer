using InternationalVillage_Customer.Store;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public EditProfileViewModel()
        {
            LoadProfile = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                if (!AccountStore.Instance.Avatar.Equals(""))
                {
                    ImageBrush img = (ImageBrush)p.FindName("Avatar");
                    img.ImageSource = new ImageSourceConverter().ConvertFromString(AccountStore.Instance.Avatar) as ImageSource;
                }
                    

            });

            SelectPicture = new RelayCommand<ImageBrush>((p) => { return true; }, (p) =>
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";
                dialog.CheckFileExists = true;
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == true)
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(dialog.FileName));
                    p.ImageSource = bitmap;
                }

            });
        }
    }
}
