using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InternationalVillage_Customer.Model;

namespace InternationalVillage_Customer.Store
{
    class AccountStore
    {
        private static AccountStore instance;
        internal static AccountStore Instance { get { if (instance == null) instance = new AccountStore(); return instance; } set => instance = value; }

        

        private AccountStore() { }

        string role = "";
        string idUser = "";
        string name = "";
        string avatar = "";
        public string Role { get { return role; } }
        public string IdUser { get { return idUser; } }
        public string Name { get => name; set => name = value; }
        public string Avatar { get => avatar; set => avatar = value; }

        public bool Authentication(string username, string password)
        {
            string query = "select* from Account where Username = '" + username + "' and Password = '" + password + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public int InsertAccount(string user, string pass, string role, string id_user)
        {
            string id = CreateIDAccount();
            string query = string.Format("insert into Account values ('{0}','{1}','{2}','{3}','{4}');", id, user, pass, role, id_user);
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public string CreateIDAccount()
        {
            string query = string.Format("select * from Account;");
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            int count = dt.Rows.Count;

            return "A_" + (count + 1).ToString();
        }

        // Test get data
        public Account GetAccount(string username,string password)
        {
            string query = "select * from Account,Customer where Account.Id_User = Customer.Id_Customer and  Username = '" + username + "' and Password = '" + password + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                role = account.Role;
                idUser = account.IdUser;
                name = account.FullName;
                avatar = account.Avatar;
                return account;
            }
            return null;
        }
    }
}
