using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

using InternationalVillage_Customer.Store;
using InternationalVillage_Customer.Model;

namespace InternationalVillage_Customer.ViewModel
{
    class BillPageViewModel : BaseViewModel
    {
        public ICommand LoadBillTable { get; set; }
        public ICommand LoadIDBill { get; set; }
        public ICommand LoadCheckInDate { get; set; }
        public ICommand LoadCheckOutDate { get; set; }
        public ICommand LoadPayDate { get; set; }
        public ICommand LoadCustomer { get; set; }
        public ICommand LoadReceptionist { get; set; }
        public ICommand LoadTotalMoney { get; set; }
        public ICommand LoadPaymentApproach { get; set; }
        public ICommand LoadStatus { get; set; }

        public BillPageViewModel()
        {
            LoadBillTable = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                p.ItemsSource = DetailBillStore.Instance.ListDetailBookings;

            });
            LoadIDBill = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                p.Text = DetailBillStore.Instance.IdBill;

            });
            LoadCustomer = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                p.Text = DetailBillStore.Instance.NameCustomer;


            });
            LoadReceptionist = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                p.Text = DetailBillStore.Instance.NameReceptionist;


            });
            LoadCheckInDate = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                p.Text = DateTime.Parse(DetailBillStore.Instance.Checkin).ToShortDateString();


            });
            LoadCheckOutDate = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                p.Text = DateTime.Parse(DetailBillStore.Instance.Checkout).ToShortDateString();


            });
            LoadPayDate = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                if (DetailBillStore.Instance.PaydDate.Equals("")) p.Text = "";
                else p.Text = DateTime.Parse(DetailBillStore.Instance.PaydDate).ToString("dd/MM/yyyy H:mm:ss");

            });
            LoadTotalMoney = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                p.Text = DetailBillStore.Instance.TotalMoney + "$";
  

            });
            LoadStatus = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                if (DetailBillStore.Instance.Status.Equals("Not accepted yet"))
                    p.Text = "Unpaid";
              

            });
            LoadPaymentApproach = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                if (!DetailBillStore.Instance.Status.Equals("Not accepted yet"))
                    p.Text = DetailBillStore.Instance.Status;
                else p.Text = "";

            });
        }
    }
}
