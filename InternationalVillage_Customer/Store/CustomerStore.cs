using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalVillage_Customer.Store
{
    class CustomerStore
    {
        private static CustomerStore instance;
        internal static CustomerStore Instance { get { if (instance == null) instance = new CustomerStore(); return instance; } set => instance = value; }

        CustomerStore() { }

        public string ID = "";

        public int InsertCustomer(string fullname, string iden, string visa, string avar)
        {
            ID = CreateIDCustomer();
            string query = string.Format("insert into Customer values ('{0}','{1}','{2}','{3}','{4}');",ID,fullname,iden,visa,avar);
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public string CreateIDCustomer()
        {
            string query = string.Format("select * from Account;");
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            int count = dt.Rows.Count;

            return "C_" + (count + 1).ToString();
        }
    }
}
