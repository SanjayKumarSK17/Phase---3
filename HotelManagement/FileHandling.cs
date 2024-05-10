using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public static class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("SyncstaysHotel"))
            {
                System.Console.WriteLine("Folder Created !");
                Directory.CreateDirectory("SyncstaysHotel");
            }
            if (!File.Exists("SyncstaysHotel/UserRegistration.csv"))
            {
                System.Console.WriteLine("File Created-- UR");
                File.Create("SyncstaysHotel/UserRegistration.csv").Close();
            }
            if (!File.Exists("SyncstaysHotel/RoomDetails.csv"))
            {
                System.Console.WriteLine("File Created-- RD");
                File.Create("SyncstaysHotel/RoomDetails.csv").Close();
            }
            if (!File.Exists("SyncstaysHotel/RoomSelection.csv"))
            {
                System.Console.WriteLine("File Created-- RD");
                File.Create("SyncstaysHotel/RoomSelection.csv").Close();
            }
            if (!File.Exists("SyncstaysHotel/BookingDetails.csv"))
            {
                System.Console.WriteLine("File Created-- RD");
                File.Create("SyncstaysHotel/BookingDetails.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            //userregistration
            string[] users = new string[Operations.userRegistrationsList.Count];
            for (int i = 0; i < Operations.userRegistrationsList.Count; i++)
            {
                users[i] = Operations.userRegistrationsList[i].UserID + "," + Operations.userRegistrationsList[i].UserName + "," + Operations.userRegistrationsList[i].MobileNumber + "," + Operations.userRegistrationsList[i].AadharNumber + "," + Operations.userRegistrationsList[i].Address + "," + Operations.userRegistrationsList[i].FoodType + "," + Operations.userRegistrationsList[i].Gender + "," + Operations.userRegistrationsList[i].WalletBalance;
            }
            File.WriteAllLines("SyncstaysHotel/UserRegistration.csv", users);
            //RoomDetails
            string[] rooms = new string[Operations.roomDetailsList.Count];
            for (int i = 0; i < Operations.roomDetailsList.Count; i++)
            {
                rooms[i] = Operations.roomDetailsList[i].RoomID + "," + Operations.roomDetailsList[i].RoomType + "," + Operations.roomDetailsList[i].NumberOfBeds + "," + Operations.roomDetailsList[i].PricePerDay;
            }
            File.WriteAllLines("SyncstaysHotel/RoomDetails.csv", rooms);
            //roomselection
            string[] selections = new string[Operations.roomSelectionsList.Count];
            for (int i = 0; i < Operations.roomSelectionsList.Count; i++)
            {
                selections[i] = Operations.roomSelectionsList[i].SelectionID + "," + Operations.roomSelectionsList[i].BookingID + "," + Operations.roomSelectionsList[i].RoomID + "," + Operations.roomSelectionsList[i].StayingDateFrom.ToString("dd/MM/yyyy hh:mm:ss tt") + "," + Operations.roomSelectionsList[i].StayingDateTo.ToString("dd/MM/yyyy hh:mm:ss tt")+","+ Operations.roomSelectionsList[i].NumberOfDays + "," + Operations.roomSelectionsList[i].BookingStatus;
            }
            File.WriteAllLines("SyncstaysHotel/RoomSelection.csv", selections);
            //bookingdet
            string[] bookings = new string[Operations.bookingDetailsList.Count];
            for (int i = 0; i < Operations.bookingDetailsList.Count; i++)
            {
                bookings[i] = Operations.bookingDetailsList[i].BookingID + "," + Operations.bookingDetailsList[i].UserID + "," + Operations.bookingDetailsList[i].TotalPrice + "," + Operations.bookingDetailsList[i].DateOfBooking.ToString("dd/MM/yyyy");
            }
            File.WriteAllLines("SyncstaysHotel/BookingDetails.csv", bookings);
        }

        public static void ReadFromCSV()
        {
            string[] users = File.ReadAllLines("SyncstaysHotel/UserRegistration.csv");
            foreach (string user in users)
            {
                UserRegistration user1 = new UserRegistration(user);
                Operations.userRegistrationsList.Add(user1);
            }
            //room details
            string[] rooms = File.ReadAllLines("SyncstaysHotel/RoomDetails.csv");
            foreach (string room in rooms)
            {
                RoomDetails room1 = new RoomDetails(room);
                Operations.roomDetailsList.Add(room1);
            }
            //room selesction
            string[] selections = File.ReadAllLines("SyncstaysHotel/RoomSelection.csv");
            foreach (string selection in selections)
            {
                RoomSelection selection1 = new RoomSelection(selection);
                Operations.roomSelectionsList.Add(selection1);
            }
            //booking
            string[] bookings = File.ReadAllLines("SyncstaysHotel/BookingDetails.csv");
            foreach (string booking in bookings)
            {
                BookingDetails booking1 = new BookingDetails(booking);
                Operations.bookingDetailsList.Add(booking1);
            }


        }


    }
}