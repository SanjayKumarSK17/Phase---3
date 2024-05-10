using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace HotelManagement
{
    public static partial class Operations
    {
        public static void ViewCustomerProfile()
        {
            //Show all the details of the current user using the method.
            foreach (UserRegistration user in userRegistrationsList)
            {
                if (currentLoginUser.UserID == user.UserID)
                {
                    System.Console.WriteLine($"{user.UserID} | {user.UserName} | {user.MobileNumber} | {user.AadharNumber} | {user.Address} | {user.FoodType} | {user.Gender} | {user.WalletBalance}");
                }
            }
        }

        public static void BookRoom()
        {
            //1.	Create temporary booking object whose UserID is currentUserID, TotalAmount 0, Bookingdate Now, Status as initiated.
            BookingDetails booking = new BookingDetails(currentLoginUser.UserID, 0, DateTime.Now, BookingStatus.Initiated);

            //2.	Create temporary local room selection list to hold the room selection objects up to booking completion.
            CustomList<RoomSelection> localRoomSelectionList = new CustomList<RoomSelection>();

            double totalPrice = 0;
            string toContinue;

            do
            {
                //3.	Need to show the list of available room types by traversing the Room Details list.
                System.Console.WriteLine("---Available Room Details---");
                foreach (RoomDetails rooms in roomDetailsList)
                {
                    System.Console.WriteLine($"{rooms.RoomID} | {rooms.RoomType} | {rooms.NumberOfBeds} | {rooms.PricePerDay}");
                }

                //4.	Need to ask the user to enter DateFrom (Date and Time) and DateTo (Date and Time), RoomID & no. Of Days of booking.
                System.Console.WriteLine("Enter the Starting Date & Time(From)-- dd/MM/yyyy hh:mm:ss tt: ");
                DateTime dateFrom = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm:ss tt", null);

                System.Console.WriteLine("Enter the End Date & Time(Last End)-- dd/MM/yyyy hh:MM:ss tt: ");
                DateTime dateTo = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm:ss tt", null);

                System.Console.WriteLine("Enter Room ID to BOOK Room: ");
                string roomID = Console.ReadLine().ToUpper();
                System.Console.WriteLine("Enter, How many days for Room you need? ");
                double noOfDays = double.Parse(Console.ReadLine());

                //5.	Based on the data need to check the room is already booked or not by traversing room selection list.
                foreach (RoomSelection room in roomSelectionsList)
                {
                    if (room.RoomID != roomID || (room.RoomID == roomID && room.BookingStatus == BookingStatus.Cancelled))
                    {
                        // If it is not booked means Create Room Selection object and add it to local room selection list.
                        foreach (RoomDetails roomDetails in roomDetailsList)
                        {
                            double price = noOfDays * roomDetails.PricePerDay;
                            totalPrice += price;
                            break;
                        }
                        RoomSelection roomSelection = new RoomSelection(booking.BookingID, roomID, dateFrom, dateTo, totalPrice, noOfDays, BookingStatus.Initiated);
                        localRoomSelectionList.Add(roomSelection);
                    }
                    else
                    {
                        System.Console.WriteLine("Selected Room Not Available !!!");
                    }
                }
                //6.	Ask the user whether he want to book another room. If “yes” means repeat step 3 to 5 to create new selection object and add it to local list.
                System.Console.WriteLine("If You want to book another Room, Enter (Yes or No): ");
                toContinue = Console.ReadLine().ToLower();

            } while (toContinue == "yes");


            if (toContinue == "no")
            {
                //IsFlag = false;
                //7.	If user says “No” means calculate the total rent amount of that selected rooms modify the booking object details and status as booked.
                //8.	Check the user has enough balance. If he has enough balance Add the local temp room selection to global list.
                // Add the booking object to booking list. And show rooms successfully booked Your booking ID – BID101. 
                if (currentLoginUser.WalletBalance >= totalPrice)
                {
                    currentLoginUser.DeductBalance(totalPrice);
                    booking.BookingStatus = BookingStatus.Booked;
                    roomSelectionsList.AddRange(localRoomSelectionList);
                    System.Console.WriteLine("Room Successfully Booked: " + booking.BookingID);
                }
                else
                {
                    //9.	If user don’t have enough balance, ask the user whether he want to proceed booking after recharge.
                    System.Console.WriteLine("Don't Have Enough Balance -- Enter Yes or No to Proceed Recharge: ");
                    string toRecharge = Console.ReadLine().ToLower();
                    if (toRecharge == "yes")
                    {
                        //10.	If he says yes means show the amount to be recharged for continue booking (Total Booking Amount).
                        System.Console.WriteLine("Required Amount to Book Room is: " + totalPrice + " ");
                        currentLoginUser.WalletRecharge(totalPrice);
                        System.Console.WriteLine("Nou you can proceed ---");
                        // Recharge with user provided amount and go to step 8 to proceed booking.
                        currentLoginUser.DeductBalance(totalPrice);
                        booking.BookingStatus = BookingStatus.Booked;
                        roomSelectionsList.AddRange(localRoomSelectionList);
                        System.Console.WriteLine("Room Successfully Booked: " + booking.BookingID);

                    }
                }
            }

        }

        public static void ModifyBooking()
        {
            double totalPrice = 0;
            //•	Need to show the current user’s booking history whose booking status is Booked by traversing the booking details list and 
            bool IsFlag = true;
            foreach (BookingDetails booking in bookingDetailsList)
            {
                if (currentLoginUser.UserID == booking.UserID && booking.BookingStatus == BookingStatus.Booked)
                {
                    IsFlag = false;
                    System.Console.WriteLine($"{booking.BookingID} | {booking.UserID} | {booking.TotalPrice} | {booking.DateOfBooking.ToString("dd/MM/yyyy")} | {booking.BookingStatus}");
                }
            }
            if (IsFlag)
            {
                System.Console.WriteLine(" No Order to Modify --- !");
            }
            if (!IsFlag)
            {
                //need to ask the user to pick a bookingID. 
                System.Console.WriteLine("Enter a Book ID to Modify Room: ");
                string modifyID = Console.ReadLine().ToUpper();
                //•	Check whether the booking ID present in booking details and its status is Booked.
                bool IsFlag1 = true;
                foreach (BookingDetails booking in bookingDetailsList)
                {
                    if (modifyID == booking.BookingID && booking.BookingStatus == BookingStatus.Booked)
                    {
                        IsFlag1 = false;
                        //•	Traverse the selection list and check the Booking ID present in selection list and the selection status is Booked.
                        foreach (RoomSelection selection in roomSelectionsList)
                        {
                            if (modifyID == selection.BookingID && selection.BookingStatus == BookingStatus.Booked)
                            {
                                //•	Show the selection list details of that booking ID 
                                System.Console.WriteLine($"{selection.SelectionID} | {selection.BookingID} | {selection.RoomID} |  | {selection.StayingDateFrom} | {selection.StayingDateTo} | {selection.Price} | {selection.NumberOfDays} | {selection.BookingStatus}");
                            }
                        }
                        //and ask the user to enter selection ID.
                        System.Console.WriteLine(" Enter the Selection ID to Modify: ");
                        string selectID = Console.ReadLine().ToUpper();
                        //•	Validate the selection ID present in the selection list and its belong to current user and current booking ID.
                        bool IsFlag11 = true;
                        foreach (RoomSelection roomSelection in roomSelectionsList)
                        {
                            if (selectID == roomSelection.SelectionID && currentLoginUser.UserID == booking.BookingID)
                            {
                                IsFlag11 = false;
                                System.Console.WriteLine(" Select Options:   1.Cancel selected room         2.Add new room");
                                int toChoose = int.Parse(Console.ReadLine());
                                switch (toChoose)
                                {
                                    case 1:
                                        {
                                            //1.	If the user enter this option means
                                            // return the selected room amount to user,
                                            currentLoginUser.WalletRecharge(booking.TotalPrice);
                                            //deduct the amount from booking and 
                                            roomSelection.BookingStatus = BookingStatus.Cancelled;
                                            //change the status of selection entry to Cancelled.
                                            break;
                                        }
                                    case 2:
                                        {
                                            //1.	Show the list of available rooms in from the room details 
                                            System.Console.WriteLine("---Available Room Details---");
                                            foreach (RoomDetails rooms in roomDetailsList)
                                            {
                                                System.Console.WriteLine($"{rooms.RoomID} | {rooms.RoomType} | {rooms.NumberOfBeds} | {rooms.PricePerDay}");
                                            }
                                            //and ask the user to enter room ID and check in and out date and time.
                                            System.Console.WriteLine("Enter the Starting Date & Time(From)-- dd/MM/yyyy hh:mm:ss tt: ");
                                            DateTime dateFrom = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm:ss tt", null);

                                            System.Console.WriteLine("Enter the End Date & Time(Last End)-- dd/MM/yyyy hh:MM:ss tt: ");
                                            DateTime dateTo = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy hh:mm:ss tt", null);

                                            System.Console.WriteLine("Enter Room ID to BOOK Room: ");
                                            string roomID = Console.ReadLine().ToUpper();
                                            System.Console.WriteLine("Enter, How many days for Room you need? ");
                                            double noOfDays = double.Parse(Console.ReadLine());
                                            //3.	Check the selected room is available on that date and time by checking in the room selection list.
                                            if (roomSelection.RoomID != roomID || (roomSelection.RoomID == roomID && roomSelection.BookingStatus == BookingStatus.Cancelled))
                                            {
                                                // If it is not booked means Create Room Selection object and add it to local room selection list.
                                                foreach (RoomDetails roomDetails in roomDetailsList)
                                                {
                                                    //4.	If the room is available means then calculate amount.
                                                    double price = noOfDays * roomDetails.PricePerDay;
                                                    totalPrice += price;
                                                    break;
                                                }
                                                //5.	Check the user has enough balance. If he has means deduct the amount from user.
                                                if (currentLoginUser.WalletBalance >= totalPrice)
                                                {
                                                    currentLoginUser.DeductBalance(totalPrice);
                                                    booking.BookingStatus = BookingStatus.Booked;
                                                    System.Console.WriteLine("Room Successfully Booked: " + booking.BookingID);
                                                }
                                                else
                                                {
                                                    //9.	If user don’t have enough balance, ask the user whether he want to proceed booking after recharge.
                                                    System.Console.WriteLine("Don't Have Enough Balance --   Recharge and Proceed: ");
                                                }
                                            }
                                            else
                                            {
                                                System.Console.WriteLine("Selected Room Not Available !!!");
                                            }
                                            break;
                                        }
                                    default:
                                        {
                                            System.Console.WriteLine("Select Given Options Correctly !!");
                                            break;
                                        }
                                }
                            }
                        }
                        if (IsFlag11)
                        {
                            System.Console.WriteLine("Invalid Selection ID !!!");
                        }

                    }
                }
                if (IsFlag1)
                {
                    System.Console.WriteLine("Invalid ID !!");
                }
            }
        }

        public static void CancelBooking()
        {
            //•	Need to show the current user’s booking history whose booking status is Booked by traversing the booking details list 
            bool IsFlag = true;
            foreach (BookingDetails booking in bookingDetailsList)
            {
                if (currentLoginUser.UserID == booking.UserID && booking.BookingStatus == BookingStatus.Booked)
                {
                    IsFlag = false;
                    System.Console.WriteLine($"{booking.BookingID} | {booking.UserID} | {booking.TotalPrice} | {booking.DateOfBooking} | {booking.BookingStatus}");
                }
            }
            if (IsFlag)
            {
                System.Console.WriteLine("No Order to Cance!!!");
            }
            if (!IsFlag)
            {
                //and need to ask the user to pick a bookingID. 
                bool IsFlag1 = true;
                System.Console.WriteLine("Enter the Book ID to Cancel: ");
                string cancelID = Console.ReadLine().ToUpper();
                //•	Need to validate the id is present and
                foreach (BookingDetails booking in bookingDetailsList)
                {
                    if (cancelID == booking.BookingID && booking.BookingStatus == BookingStatus.Booked)
                    {
                        IsFlag1 = false;
                        // need to change the status of booking to Cancelled and return the booking amount to current user’s wallet.
                        booking.BookingStatus = BookingStatus.Cancelled;
                        currentLoginUser.WalletRecharge(booking.TotalPrice);
                        //•	Change the booking status of selection list details of that corresponding bookingID from Booked to cancelled.
                        foreach (RoomSelection roomSelection in roomSelectionsList)
                        {
                            if (cancelID == roomSelection.BookingID)
                            {
                                roomSelection.BookingStatus = BookingStatus.Cancelled;
                            }
                        }
                        System.Console.WriteLine("Room Cancelled Successfully !!!");
                    }
                }
                if (IsFlag1)
                {
                    System.Console.WriteLine("Invalid Booking ID !!!");
                }
            }
        }

        public static void BookingHistory()
        {
            // Need to show the current user’s booking history by traversing the booking details list
            bool IsFlag = true;
            foreach (BookingDetails book in bookingDetailsList)
            {
                if (currentLoginUser.UserID == book.UserID)
                {
                    IsFlag = false;
                    System.Console.WriteLine($"{book.BookingID} | {book.UserID} | {book.TotalPrice} | {book.DateOfBooking.ToString("dd/MM/yyyy")} | {book.BookingStatus}");
                }
            }
            if (IsFlag)
            {
                System.Console.WriteLine("No Booking History---");
            }
            if (!IsFlag)
            {
                bool IsFlag1 = true;
                // and need to ask the user to pick a booking ID and based on that show the details of rooms booked by traversing room selection list. 
                System.Console.WriteLine("Enter Booking ID to see Details: ");
                string toChoose = Console.ReadLine().ToUpper();
                foreach (RoomSelection room in roomSelectionsList)
                {
                    if (toChoose == room.BookingID)
                    {
                        System.Console.WriteLine($"{room.SelectionID} | {room.BookingID} | {room.RoomID} | {room.StayingDateFrom} | {room.StayingDateTo} | {room.Price} | {room.NumberOfDays} | {room.BookingStatus}");
                        IsFlag1 = false;
                    }
                }
                if (IsFlag1)
                {
                    System.Console.WriteLine("Invalid Book ID");
                }
            }

        }

        public static void WalletRecharge()
        {
            System.Console.WriteLine(" Enter Yes, if you want to recharge: ");
            string toChoose = Console.ReadLine().ToUpper();
            if (toChoose == "YES")
            {
                System.Console.WriteLine(" Enter The Amount to Recharge: ");
                double rechargeAmount = double.Parse(Console.ReadLine());
                if (rechargeAmount > 0)
                {
                    currentLoginUser.WalletRecharge(rechargeAmount);
                    System.Console.WriteLine("Recharge Succesful & Current Balance: " + currentLoginUser.WalletBalance);
                }
                else
                {
                    System.Console.WriteLine("Amount Invalid !!");
                }
            }

        }

        public static void ShowWalletBalance()
        {
            System.Console.WriteLine(" Your Current Wallet Balance: " + currentLoginUser.WalletBalance);
        }



    }
}