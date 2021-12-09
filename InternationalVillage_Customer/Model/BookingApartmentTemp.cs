using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalVillage_Customer.Model
{
    class BookingApartmentTemp
    {
        public BookingApartmentTemp(string idC, string idA, DateTime checkin, DateTime checkout, int quan, string sta, DateTime time)
        {
            typeOfApartment = idA;
            id_Customer = idC;
            checkInDate = checkin;
            checkOutDate = checkout;
            quantity = quan;
            state = sta;
            bookingTime = time;
        }

        public BookingApartmentTemp(DataRow row)
        {
            Id_Customer = row["Id_Customer"].ToString();
            FullName = row["FullName"].ToString();
            TypeOfApartment = row["TypeOfApartment"].ToString();
            CheckInDate = (DateTime)row["CheckInDate"];
            CheckOutDate = (DateTime)row["CheckOutDate"];
            Price = (int)row["Price"];
            IdApartment = row["Id_Apartment"].ToString();
        }
        

        private string id_Customer ;
        private string fullName;
        private string typeOfApartment;
        private DateTime checkInDate ;
        private DateTime checkOutDate ;
        private int quantity ;
        private string state ;
        private DateTime bookingTime;
        private int price;
        private string idApartment;

        public string Id_Customer { get => id_Customer; set => id_Customer = value; }
        public string TypeOfApartment { get => typeOfApartment; set => typeOfApartment = value; }
        public DateTime CheckInDate { get => checkInDate; set => checkInDate = value; }
        public DateTime CheckOutDate { get => checkOutDate; set => checkOutDate = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string State { get => state; set => state = value; }
        public DateTime BookingTime { get => bookingTime; set => bookingTime = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public int Price { get => price; set => price = value; }
        public string IdApartment { get => idApartment; set => idApartment = value; }
    }
}
