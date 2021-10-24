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
    class BookServiceViewModel:BaseViewModel
    {
        public ICommand ClearFocus { get; set; }

        public BookServiceViewModel()
        {
            ClearFocus = new RelayCommand<Page>((p) => { return true; }, (p) =>
            {
                Keyboard.ClearFocus();
            });
        }
    }
}
