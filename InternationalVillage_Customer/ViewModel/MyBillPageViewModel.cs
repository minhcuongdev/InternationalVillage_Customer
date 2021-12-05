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
    class MyBillPageViewModel:BaseViewModel
    {
        public ICommand LoadNotification { get; set; }
      

        public MyBillPageViewModel()
        {
            LoadNotification = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                
                List<Bill> bills = BillStore.Instance.GetBillList();
                int lenght = bills.Count;
                
                for (int i = 0; i < lenght; i++)
                {
                    BillInforUC BillInforUC = new BillInforUC(bills[i].IdBill, bills[i].CheckInDate, bills[i].CheckOutDate, bills[i].TotalMoney);
                    p.Children.Add(BillInforUC);
                }

            });
            
        }
    }
}
