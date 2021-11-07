using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalVillage_Customer.Model
{
    class Bill
    {
        public Bill(string id, string customer, string receptionist, string checkin, string checkout, string totalmoney)
        {
            IdBill = id;
            CustomerName = customer;
            ReceptionistName = receptionist;
            CheckInDate = checkin;
            CheckOutDate = checkout;
            TotalMoney = totalmoney;
        }

        public Bill(DataRow row)
        {
            
        }

        private string idBill;
        private string customerName;
        private string receptionistName;
        private string checkInDate;
        private string checkOutDate;
        private string totalMoney;

        public string IdBill { get => idBill; set => idBill = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string CheckInDate { get => checkInDate; set => checkInDate = value; }
        public string CheckOutDate { get => checkOutDate; set => checkOutDate = value; }
        public string TotalMoney { get => totalMoney; set => totalMoney = value; }
        public string ReceptionistName { get => receptionistName; set => receptionistName = value; }
    }
}
