using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    public class TicketFairDetails
    {
        private static int s_ticketID = 3000;
        public string TicketID { get; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public double TicketPrice { get; set; }
        public TicketFairDetails(string fromLocation,string toLocation,double ticketPrice)
        {
            s_ticketID++;
            TicketID = "MR" + s_ticketID;
            FromLocation=fromLocation;
            ToLocation=toLocation;
            TicketPrice=ticketPrice;
        }
        public TicketFairDetails(string ticket)
        {
            string[] array=ticket.Split(',');

            TicketID=array[0];
            s_ticketID=int.Parse(array[0].Remove(0,2));
            FromLocation=array[1];
            ToLocation=array[2];
            TicketPrice=double.Parse(array[3]);
        }
    }
}