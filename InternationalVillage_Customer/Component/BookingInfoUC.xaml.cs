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
    /// Interaction logic for BookingInfoUC.xaml
    /// </summary>
    public partial class BookingInfoUC : UserControl
    {
        public BookingInfoUCViewModel uc { get; set; }

        public BookingInfoUC()
        {
            InitializeComponent();
            this.DataContext = uc = new BookingInfoUCViewModel();
        }
    }
}
