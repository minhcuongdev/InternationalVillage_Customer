using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InternationalVillage_Customer.Model;

namespace InternationalVillage_Customer.Store
{
    class BillStore
    {
        private static BillStore instance;
        internal static BillStore Instance { get { if (instance == null) instance = new BillStore(); return instance; } set => instance = value; }


        BillStore() { }

        string idDetailBill = "";
        public string IdDetailBill { get => idDetailBill; set => idDetailBill = value; }

        List<Bill> billList = new List<Bill>();

        public List<DetailBill> GetTableById(string id)
        {
            Bill bill = GetBillById(id);
            List<DetailBill> apartmentBills = new List<DetailBill>();
            if (bill.DetailBills.Count != 0)
            {
                apartmentBills = bill.DetailBills;
            }
            return apartmentBills;
        }

        public List<Bill> GetBillList()
        {
            billList.Clear();
            string query = "Select Id_Bill, Receptionist.FullName, CheckInDate, CheckOutDate,TotalMoney, Bill.Status " +
                           "from Bill, Customer,Receptionist where Bill.Id_Customer = Customer.Id_Customer and Receptionist.Id_Receptionist = Bill.Id_Receptionist and Bill.Id_Customer = '" + AccountStore.Instance.IdUser + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Bill bill = new Bill(item);
                billList.Add(bill);
                
            }
            return billList;
        }

        public Bill GetBillById(string id)
        {
            for(int i=0;i< billList.Count;i++)
            {
                if(billList[i].IdBill.Equals(id))
                {
                    return billList[i];
                }
            }
            return null;
        }
    }
}
