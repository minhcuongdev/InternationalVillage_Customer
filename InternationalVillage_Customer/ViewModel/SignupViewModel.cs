using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InternationalVillage_Customer.ViewModel
{
    class SignupViewModel: BaseViewModel
    {
        public ICommand CloseSignupWindow { get; set; }
        public ICommand Signin { get; set; }
        public ICommand Drag { get; set; }
        public ICommand ClearFocus { get; set; }

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
        }
    }
}
