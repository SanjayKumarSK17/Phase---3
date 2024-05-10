using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public enum RoomType { Select, Standard, Delux, Suit }
    public class RoomDetails
    {
        private static int s_roomID=100;
        public string RoomID { get; }
        public RoomType RoomType { get; set; }
        public int NumberOfBeds { get; set; }
        public double PricePerDay { get; set; }
        public RoomDetails(RoomType roomType, int numberOfBeds, double pricePerDay)
        {
            s_roomID++;
            RoomID="RID"+s_roomID;
            RoomType=roomType;
            NumberOfBeds=numberOfBeds;
            PricePerDay=pricePerDay;
        }

        public RoomDetails(string element)
        {
            string[] array=element.Split(',');

            RoomID=array[0];
            s_roomID=int.Parse(array[0].Remove(0,3));
            RoomType=Enum.Parse<RoomType>(array[1],true);
            NumberOfBeds=int.Parse(array[2]);
            PricePerDay=double.Parse(array[3]);
        }
    }
}