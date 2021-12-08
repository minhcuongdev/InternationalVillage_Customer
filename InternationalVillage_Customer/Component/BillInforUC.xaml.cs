﻿using System;
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
using InternationalVillage_Customer.Store;
using InternationalVillage_Customer.ViewModel;
using InternationalVillage_Customer.Pages;

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
            this.CheckInDate.Text = DateTime.Parse(checkin).ToShortDateString();
            this.CheckOutDate.Text = DateTime.Parse(checkout).ToShortDateString();
            this.TotalMoney.Text = total + "$";
            

            this.DataContext = BillInfo = new BillInfoViewModel();
        }

        private void ViewDetailBill_Click(object sender, RoutedEventArgs e)
        {
            DetailBillStore.Instance.FindBill(this.IDBill.Text);
        }
    }
}
