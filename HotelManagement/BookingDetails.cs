using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
   
    public class BookingDetails
    {
        private static int s_bookingID=100;
        public string BookingID { get;  }
        public string UserID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateOfBooking { get; set; }
        public BookingStatus BookingStatus { get; set; }

        public BookingDetails(string userID, double totalPrice, DateTime dateOfBooking, BookingStatus bookingStatus)
        {
            s_bookingID++;
            BookingID="BID"+s_bookingID;
            UserID=userID;
            TotalPrice=totalPrice;
            DateOfBooking=dateOfBooking;
            BookingStatus=bookingStatus;
        }

        public BookingDetails(string element)
        {
            string[] array=element.Split(',');

            BookingID=array[0];
            s_bookingID=int.Parse(array[0].Remove(0,3));
            UserID=array[1];
            TotalPrice=double.Parse(array[2]);
            DateOfBooking=DateTime.ParseExact(array[3],"dd/MM/yyyy", null);
            BookingStatus=Enum.Parse<BookingStatus>(array[4], true);
        }
    }
}