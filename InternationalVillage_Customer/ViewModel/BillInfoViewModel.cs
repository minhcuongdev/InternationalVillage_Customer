using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

using InternationalVillage_Customer.Store;

namespace InternationalVillage_Customer.ViewModel
{
    public class BillInfoViewModel : BaseViewModel
    {
        public ICommand OpenDetailBill { get; set; }

        public BillInfoViewModel()
        {
            OpenDetailBill = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                BillStore.Instance.IdDetailBill = p.Text;
            });
        }
    }
}
