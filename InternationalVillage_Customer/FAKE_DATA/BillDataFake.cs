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

           
            return list;
        }
    }
}
