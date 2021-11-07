using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using InternationalVillage_Customer.ViewModel;

namespace InternationalVillage_Customer.Component
{
    /// <summary>
    /// Interaction logic for BillInforUC.xaml
    /// </summary>
    public partial class BillInforUC : UserControl
    {
        public BillInfoViewModel BillInfo { get; set; }

        public BillInforUC(string id, string checkin, string checkout, string total)
        {
            InitializeComponent();
            this.IDBill.Text = id;
            this.CheckInDate.Text = checkin;
            this.CheckOutDate.Text = checkout;
            this.TotalMoney.Text = total;

            this.DataContext = BillInfo = new BillInfoViewModel();
        }
    }
}
