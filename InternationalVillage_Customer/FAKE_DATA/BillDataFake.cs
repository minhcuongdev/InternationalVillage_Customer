using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InternationalVillage_Customer.Model;

namespace InternationalVillage_Customer.FAKE_DATA
{
    class BillDataFake
    {
        private static BillDataFake instance;

        internal static BillDataFake Instance { get { if (instance == null) instance = new BillDataFake(); return instance; } set => instance = value; }

        BillDataFake() { }

        public List<Bill> GetListBill()
        {
            List<Bill> list = new List<Bill>();

            Bill bill1 = new Bill("1", "Minh Cuong", "Khanh Quynh", "19/10/2021", "23/10/2021", "5,33$");
            ApartmentBill apartmentBill1 = new ApartmentBill("Luxury", "1", "1$");
            ApartmentBill apartmentBill2 = new ApartmentBill("Standard", "2", "1$");
            ApartmentBill apartmentBill3 = new ApartmentBill("Normal", "3", "1$");

            ServiceBill serviceBill1 = new ServiceBill("Golf", "1", "1$");
            ServiceBill serviceBill2 = new ServiceBill("Tennis", "2", "1$");

            bill1.DetailBills.Add(apartmentBill1);
            bill1.DetailBills.Add(apartmentBill2);
            bill1.DetailBills.Add(apartmentBill3);

            bill1.DetailBills.Add(serviceBill1);
            bill1.DetailBills.Add(serviceBill2);


            Bill bill2 = new Bill("2", "Minh Cuong", "Khanh Quynh", "20/10/2021", "24/10/2021", "6,33$");
            Bill bill3 = new Bill("3", "Minh Cuong", "Khanh Quynh", "21/10/2021", "25/10/2021", "7,33$");
            Bill bill4 = new Bill("4", "Minh Cuong", "Khanh Quynh", "22/10/2021", "26/10/2021", "8,33$");
            Bill bill5 = new Bill("5", "Minh Cuong", "Khanh Quynh", "23/10/2021", "27/10/2021", "9,33$");

            list.Add(bill1);
            list.Add(bill2);
            list.Add(bill3);
            list.Add(bill4);
            list.Add(bill5);

            return list;
        }
    }
}
