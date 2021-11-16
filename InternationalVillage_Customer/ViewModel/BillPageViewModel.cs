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
        public ICommand LoadIdBill { get; set; }
        public ICommand LoadDate { get; set; }
        public ICommand LoadCheckInDate { get; set; }
        public ICommand LoadCheckOutDate { get; set; }
        public ICommand LoadCustomer { get; set; }
        public ICommand LoadReceptionist { get; set; }
        public ICommand LoadTotalMoney { get; set; }

        public ICommand LoadTable { get; set; }

        public BillPageViewModel()
        {
            LoadTable = new RelayCommand<DataGrid>((p) => { return true; }, (p) =>
            {
                List<DetailBill> detailBills = BillStore.Instance.GetTableById(BillStore.Instance.IdDetailBill);
                p.ItemsSource = detailBills;
            });

            LoadIdBill = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                Bill bill = BillStore.Instance.GetBillById(BillStore.Instance.IdDetailBill);
                p.Text = bill.IdBill;
            });

            LoadDate = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                Bill bill = BillStore.Instance.GetBillById(BillStore.Instance.IdDetailBill);
                p.Text = bill.CheckOutDate;
            });

            LoadCheckInDate = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                Bill bill = BillStore.Instance.GetBillById(BillStore.Instance.IdDetailBill);
                p.Text = bill.CheckInDate;
            });

            LoadCheckOutDate = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                Bill bill = BillStore.Instance.GetBillById(BillStore.Instance.IdDetailBill);
                p.Text = bill.CheckOutDate;
            });

            LoadCustomer = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                Bill bill = BillStore.Instance.GetBillById(BillStore.Instance.IdDetailBill);
                p.Text = bill.CustomerName;
            });

            LoadReceptionist = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                Bill bill = BillStore.Instance.GetBillById(BillStore.Instance.IdDetailBill);
                p.Text = bill.ReceptionistName;
            });

            LoadTotalMoney = new RelayCommand<TextBlock>((p) => { return true; }, (p) =>
            {
                Bill bill = BillStore.Instance.GetBillById(BillStore.Instance.IdDetailBill);
                p.Text = bill.TotalMoney;
            });
        }
    }
}
