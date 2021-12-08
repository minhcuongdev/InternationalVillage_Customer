using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using InternationalVillage_Customer.Component;
using InternationalVillage_Customer.Store;
using InternationalVillage_Customer.Model;
using System.Windows;

namespace InternationalVillage_Customer.ViewModel
{
    class BillInforViewModel : BaseViewModel
    {
        public ICommand ViewDetailBill { get; set; }
        public ICommand LoadIDBill { get; set; }
        public string IdBill { get => idBill; set => idBill = value; }


        string idBill;

        public BillInforViewModel()
        {
            LoadIDBill = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                idBill = p.Text;
                MessageBox.Show(idBill);

            });
            ViewDetailBill = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                // p.NavigationService.Navigate(new Uri("Pages/BillPage.xaml", UriKind.RelativeOrAbsolute));
                MessageBox.Show(idBill);
                DetailBillStore.Instance.FindBill(idBill);
             
            });
        }
    }
}
