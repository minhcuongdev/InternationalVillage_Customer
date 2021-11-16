using System;
using System.Collections.Generic;
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

        List<Bill> billList = FAKE_DATA.BillDataFake.Instance.GetListBill();

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
