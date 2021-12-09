using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InternationalVillage_Customer.Model;

namespace InternationalVillage_Customer.Store
{
    class BookingTempStore
    {
        
        private static BookingTempStore instance;
        internal static BookingTempStore Instance { get { if (instance == null) instance = new BookingTempStore(); return instance; } set => instance = value; }

        private string typeOfApartment = "";
        public string TypeOfApartment { get => typeOfApartment; set => typeOfApartment = value; }

        private int indexTypeOfApartment = 0;
        public int IndexTypeOfApartment { get => indexTypeOfApartment; set => indexTypeOfApartment = value; }

        private string typeOfService = "";
        public string TypeOfService { get => typeOfService; set => typeOfService = value; }

        private int indexTypeOfService = 0;
        public int IndexTypeOfService { get => indexTypeOfService; set => indexTypeOfService = value; }

        public List<BookingApartmentTemp> bookingApartmentTemps = new List<BookingApartmentTemp>();
        public BookingApartmentTemp MyBookingSelected = null;

        public List<BookingApartmentTemp> GetMyBooking()
        {
            List<BookingApartmentTemp> list = new List<BookingApartmentTemp>();

            string query = "select b.*,c.FullName,a.TypeOfApartment from BookingApartmentTable as b, Customer as c,Apartment a where b.Id_Customer = c.Id_Customer and b.Id_Apartment = a.Id_Apartment and b.Id_Customer = '" + AccountStore.Instance.IdUser + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow r in dt.Rows)
            {
                BookingApartmentTemp b = new BookingApartmentTemp(r);
                list.Add(b);
            }

            bookingApartmentTemps = list;

            return list;
        }

        public int InsertBooking(string id_Cus, string id_Apart, DateTime checkin, DateTime checkout, int quantity, string state, DateTime time)
        {
            
            string query = string.Format("insert into BookingApartmentTemp values ('{0}','{1}','{2}','{3}',{4},'{5}','{6}');",
                                                                         id_Cus,id_Apart,checkin.ToString("yyyy-MM-dd H:mm:ss"),checkout.ToString("yyyy-MM-dd H:mm:ss"),quantity,state,time.ToString("yyyy-MM-dd H:mm:ss"));
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public int InsertService(string id_Cus, string id_Service, DateTime checkin, DateTime checkout, DateTime time,int quantity,string idApartment,int numberPeople,int unitPrice)
        {
            string query = string.Format("insert into OderingServiceTable values ('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}',{8},{9});",
                                                                         id_Cus, id_Service, checkin.ToString("yyyy-MM-dd H:mm:ss"), checkout.ToString("yyyy-MM-dd H:mm:ss"), time.ToString("yyyy-MM-dd H:mm:ss"), quantity, "No Accept",idApartment,numberPeople,unitPrice);

            return DataProvider.Instance.ExecuteNonQuery(query);
        }
        public int InsertIncident(string id_In, string id_Cus,string id_Receptionist, string id_Apart, string type, string content, string level, string status)
        {
            string query = string.Format("insert into Incident values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');",
                                                                        id_In, id_Cus,id_Receptionist,id_Apart,type,content,level,status );

            return DataProvider.Instance.ExecuteNonQuery(query);
        }

        public bool CheckIdApartment (string id)
        {
            string query = "Select * from Apartment where Id_Apartment = '" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }
    }
}
