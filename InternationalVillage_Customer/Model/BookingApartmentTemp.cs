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

        

        private string id_Customer ;
        private string typeOfApartment;
        private DateTime checkInDate ;
        private DateTime checkOutDate ;
        private int quantity ;
        private string state ;
        private DateTime bookingTime;

        public string Id_Customer { get => id_Customer; set => id_Customer = value; }
        public string TypeOfApartment { get => typeOfApartment; set => typeOfApartment = value; }
        public DateTime CheckInDate { get => checkInDate; set => checkInDate = value; }
        public DateTime CheckOutDate { get => checkOutDate; set => checkOutDate = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string State { get => state; set => state = value; }
        public DateTime BookingTime { get => bookingTime; set => bookingTime = value; }
    }
}
