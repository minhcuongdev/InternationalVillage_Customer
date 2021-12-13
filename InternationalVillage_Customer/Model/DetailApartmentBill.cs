using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalVillage_Customer.Model
{
    class DetailApartmentBill
    {
        string id;
        string checkindate;
        string checkoutdate;

        public DetailApartmentBill(string idd, string checkin, string checkout)
        {
            Id = idd;
            Checkindate = checkin;
            Checkoutdate = checkout;
        }

        public DetailApartmentBill()
        {

        }
        
        public string Checkindate { get => checkindate; set => checkindate = value; }
        public string Checkoutdate { get => checkoutdate; set => checkoutdate = value; }
        public string Id { get => id; set => id = value; }
    }
}
