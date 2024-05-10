using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    public  static class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("MetroCardManagement"))
            {
                Console.WriteLine("Folder Created");
                Directory.CreateDirectory("MetroCardManagement");
            }
            //UserDetails
            if(!File.Exists("MetroCardManagement/UserDetails.csv"))
            {
                System.Console.WriteLine("File Created-UD");
                File.Create("MetroCardManagement/UserDetails.csv").Close();
            }
            //Travel Details
            if(!File.Exists("MetroCardManagement/TravelDetails.csv"))
            {
                System.Console.WriteLine("File Created-TD");
                File.Create("MetroCardManagement/TravelDetails.csv").Close();
            }
            //Ticket Fair 
            if(!File.Exists("MetroCardManagement/TicketFairDetails.csv"))
            {
                System.Console.WriteLine("File Created-TD");
                File.Create("MetroCardManagement/TicketFairDetails.csv").Close();
            }
            
            
        }

        public static void WriteToCSV()
        {
            //UserDetails
            string[] user=new string[Operations.userDetailsList.Count];
            for(int i=0;i<Operations.userDetailsList.Count;i++)
            {
                user[i]=Operations.userDetailsList[i].CardNumber+","+Operations.userDetailsList[i].UserName+","+Operations.userDetailsList[i].MobileNumber+","+Operations.userDetailsList[i].Balance;
            }
            File.WriteAllLines("MetroCardManagement/UserDetails.csv",user);
            //TravelDetails
            string[] travel=new string[Operations.travelDetailsList.Count];
            for(int i=0;i<Operations.travelDetailsList.Count;i++)
            {
                travel[i]=Operations.travelDetailsList[i].TravelID +","+Operations.travelDetailsList[i].CardNumber+","+Operations.travelDetailsList[i].FromLocation+","+Operations.travelDetailsList[i].ToLocation+","+Operations.travelDetailsList[i].Date.ToString("dd/MM/yyyy")+","+Operations.travelDetailsList[i].TravelCost;
            }
            File.WriteAllLines("MetroCardManagement/TravelDetails.csv",travel);
            //TicketFair
            string[] ticket=new string[Operations.ticketFairDetailsList.Count];
            for(int i=0;i<Operations.ticketFairDetailsList.Count;i++)
            {
                ticket[i]=Operations.ticketFairDetailsList[i].TicketID+","+Operations.ticketFairDetailsList[i].FromLocation+","+Operations.ticketFairDetailsList[i].ToLocation+","+Operations.ticketFairDetailsList[i].TicketPrice;
            }
            File.WriteAllLines("MetroCardManagement/TicketFairDetails.csv",ticket);
        }

        public static void ReadFromCSV()
        {
            //user details
            string[] users=File.ReadAllLines("MetroCardManagement/UserDetails.csv");
            foreach(string user in users)
            {
                UserDetails user1=new UserDetails(user);
                Operations.userDetailsList.Add(user1);
            }
            //Travel details
            string[] travels=File.ReadAllLines("MetroCardManagement/TravelDetails.csv");
            foreach(string travel in travels)
            {
                TravelDetails travel1=new TravelDetails(travel);
                Operations.travelDetailsList.Add(travel1);
            }
            //Ticket fair
            string[] tickets=File.ReadAllLines("MetroCardManagement/TicketFairDetails.csv");
            foreach(string ticket in tickets)
            {
                TicketFairDetails ticket1=new TicketFairDetails(ticket);
                Operations.ticketFairDetailsList.Add(ticket1);
            }
        }
    }
}