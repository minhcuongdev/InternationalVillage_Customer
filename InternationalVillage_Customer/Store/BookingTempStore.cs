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

        public int InsertBooking(string id_Cus, string id_Apart, DateTime checkin, DateTime checkout, int quantity, string state, DateTime time)
        {
            
            string query = string.Format("insert into BookingApartmentTemp values ('{0}','{1}','{2}','{3}',{4},'{5}','{6}');",
                                                                         id_Cus,id_Apart,checkin.ToString("yyyy-MM-dd H:mm:ss"),checkout.ToString("yyyy-MM-dd H:mm:ss"),quantity,state,time.ToString("yyyy-MM-dd H:mm:ss"));
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

    }
}
