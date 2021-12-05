using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternationalVillage_Customer.Store; 

namespace InternationalVillage_Customer.Model
{
    class Bill
    {
        public Bill(string id, string customer, string receptionist, string checkin, string checkout, string totalmoney, string status)
        {
            IdBill = id;
            CustomerName = customer;
            ReceptionistName = receptionist;
            CheckInDate = checkin;
            CheckOutDate = checkout;
            TotalMoney = totalmoney;
            Status = status;
        }

        public Bill(DataRow row)
        {
            IdBill = row["Id_Bill"].ToString(); ;
            CustomerName = AccountStore.Instance.Name;
            ReceptionistName = row["FullName"].ToString(); 
            CheckInDate = row["CheckInDate"].ToString();
            CheckOutDate = row["CheckOutDate"].ToString();
            TotalMoney = row["TotalMoney"].ToString();
            Status = row["Status"].ToString();
        }

        private string idBill;
        private string customerName;
        private string receptionistName;
        private string checkInDate;
        private string checkOutDate;
        private List<DetailBill> detailBills = new List<DetailBill>();
        private string totalMoney;
        private string status;

        public string IdBill { get => idBill; set => idBill = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string CheckInDate { get => checkInDate; set => checkInDate = value; }
        public string CheckOutDate { get => checkOutDate; set => checkOutDate = value; }
        public string TotalMoney { get => totalMoney; set => totalMoney = value; }
        public string ReceptionistName { get => receptionistName; set => receptionistName = value; }
        internal List<DetailBill> DetailBills { get => detailBills; set => detailBills = value; }
        public string Status { get => status; set => status = value; }
    }
}
