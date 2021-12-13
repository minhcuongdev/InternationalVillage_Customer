using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using InternationalVillage_Customer.Model;
namespace InternationalVillage_Customer.Store
{
    class DetailBillStore
    {
        private static DetailBillStore instance;
        internal static DetailBillStore Instance { get { if (instance == null) instance = new DetailBillStore(); return instance; } set => instance = value; }
        private DetailBillStore() { }
        string idCustomer;
        string nameCustomer;
        string nameReceptionist;
        string idBill;
        string checkin;
        string checkout;
        string totalMoney;
        string status;
        string paydDate;
        List<DetailBooking> listDetailBookings;

        public string IdCustomer { get => idCustomer; set => idCustomer = value; }
        public string IdBill { get => idBill; set => idBill = value; }
        public string NameCustomer { get => nameCustomer; set => nameCustomer = value; }
        public string Checkin { get => checkin; set => checkin = value; }
        public string Checkout { get => checkout; set => checkout = value; }
        public string NameReceptionist { get => nameReceptionist; set => nameReceptionist = value; }
        public string TotalMoney { get => totalMoney; set => totalMoney = value; }
        public string Status { get => status; set => status = value; }
        internal List<DetailBooking> ListDetailBookings { get => listDetailBookings; set => listDetailBookings = value; }
        public string PaydDate { get => paydDate; set => paydDate = value; }

        public void FindBill(string idB)
        {
            string query = "select * from Customer,Bill where Bill.Id_Customer = Customer.Id_Customer and (Id_Bill = '" + idB + "')";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                idCustomer = item["Id_Customer"].ToString();
                idBill = item["Id_Bill"].ToString();
                nameCustomer = item["FullName"].ToString();
                nameReceptionist = AccountStore.Instance.Name;
                checkin = item["CheckInDate"].ToString();
                checkout = item["CheckOutDate"].ToString();
                totalMoney = item["TotalMoney"].ToString();
                status = item["Status"].ToString();
                if (item["PayDate"] == null) PaydDate = "";
                else PaydDate = item["PayDate"].ToString();
            }

            ListDetailBookings = new List<DetailBooking>();
            string query2 = "select * from DetailApartmentBill where ID_Bill = '" + idBill + "'";
            DataTable data2 = DataProvider.Instance.ExecuteQuery(query2);
            foreach (DataRow item in data2.Rows)
            {
                DetailBooking detailBooking = new DetailBooking(item["Id_Apartment"].ToString(), 1, Int32.Parse(item["Price"].ToString()));
                ListDetailBookings.Add(detailBooking);
            }

            string query3 = "select DetailServiceBill.Price , ServiceName, Quantity from Service, DetailServiceBill where Service.ID_Service = DetailServiceBill.ID_Service and ID_Bill = '" + idBill + "'";
            DataTable data3 = DataProvider.Instance.ExecuteQuery(query3);
            foreach (DataRow item in data3.Rows)
            {
                DetailBooking detailBooking = new DetailBooking(item["ServiceName"].ToString(), Int32.Parse(item["Quantity"].ToString()), Int32.Parse(item["Price"].ToString()));
                ListDetailBookings.Add(detailBooking);
            }

        }
        public List<DetailApartmentBill> GetDetailApartmentBills(string idCustomer)
        {
            List<DetailApartmentBill> list = new List<DetailApartmentBill>();
            string query = "select Id_Apartment, DetailApartmentBill.CheckInDate, DetailApartmentBill.CheckOutDate " +
                            "from Bill, DetailApartmentBill where Bill.Id_Bill = DetailApartmentBill.Id_Bill and Status = 'Not accepted yet' and Id_Customer = '" + idCustomer + "'";
;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DetailApartmentBill detail = new DetailApartmentBill(item["Id_Apartment"].ToString(), DateTime.Parse(item["CheckInDate"].ToString()).ToString("dd/MM/yyyy"), DateTime.Parse(item["CheckOutDate"].ToString()).ToString("dd/MM/yyyy"));
                list.Add(detail);
            }
            
            return list;
        }
    }
}
