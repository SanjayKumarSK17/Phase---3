using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    public class TravelDetails
    {
        private static int s_travelID=2000;
        public string TravelID { get;  }

        public string CardNumber { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public DateTime Date { get; set; }
        public double TravelCost { get; set; }

        public TravelDetails(string cardNumber, string fromLocation,string toLocation,DateTime date,double travelCost )
        {
            s_travelID++;
            TravelID="TID"+ s_travelID;
            CardNumber=cardNumber;
            FromLocation=fromLocation;
            ToLocation=toLocation;
            Date=date;
            TravelCost=travelCost;
        }
        public TravelDetails(string travel)
        {
            string[] array=travel.Split(',');

            TravelID=array[0];
            s_travelID=int.Parse(array[0].Remove(0,3));
            CardNumber=array[1];
            FromLocation=array[2];
            ToLocation=array[3];
            Date=DateTime.ParseExact(array[4],("dd/MM/yyyy"),null);
            TravelCost=double.Parse(array[5]);
        }
    }
}