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
    public class BillInforViewModel : BaseViewModel
    {
        public ICommand ViewDetailBill { get; set; }


        public BillInforViewModel()
        {
            ViewDetailBill = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
            {
                TextBlock idBill = p.FindName("IDBill") as TextBlock;
                DetailBillStore.Instance.FindBill(idBill.Text);
                Page page = FindPage(p);
                if( page != null)
                {
                    page.NavigationService.Navigate(new Uri("Pages/BillPage.xaml", UriKind.RelativeOrAbsolute));
                }
            });
        }

        Page FindPage(UserControl p)
        {
            FrameworkElement parent = p.Parent as FrameworkElement;
            for(int i = 0; i< 3;i++)
            {
                parent = parent.Parent as FrameworkElement;
            }


            if (parent is Page page)
            {
                return page;
            }

            return null;
        }
    }
}
