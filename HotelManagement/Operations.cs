using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace HotelManagement
{
    public  static partial class Operations
    {
        public static CustomList<UserRegistration> userRegistrationsList=new CustomList<UserRegistration>();
        public static CustomList<RoomDetails> roomDetailsList=new CustomList<RoomDetails>();
        public static CustomList<RoomSelection> roomSelectionsList=new CustomList<RoomSelection>();
        public static CustomList<BookingDetails> bookingDetailsList=new CustomList<BookingDetails>();
        public static UserRegistration currentLoginUser;

        public static void AddDefaultData()
        {
            System.Console.WriteLine("Adding Default Details");

            UserRegistration user1=new UserRegistration("Ravichandran",995875777,347777378383,"Chennai",FoodType.Veg,Gender.Male,5000);
            UserRegistration user2=new UserRegistration("Baskaran",448844848,474777477477,"Chennai",FoodType.NonVeg,Gender.Male,6000);
            userRegistrationsList.Add(user1);
            userRegistrationsList.Add(user2);

            RoomDetails room1=new RoomDetails(RoomType.Standard,2,500);
            RoomDetails room2=new RoomDetails(RoomType.Standard,4,500);
            RoomDetails room3=new RoomDetails(RoomType.Standard,2,500);
            RoomDetails room4=new RoomDetails(RoomType.Standard,2,500);
            RoomDetails room5=new RoomDetails(RoomType.Standard,2,1000);
            RoomDetails room6=new RoomDetails(RoomType.Delux,2,2000);
            RoomDetails room7=new RoomDetails(RoomType.Delux,2,1500);
            RoomDetails room8=new RoomDetails(RoomType.Delux,4,1500);
            RoomDetails room9=new RoomDetails(RoomType.Delux,4,2000);
            RoomDetails room10=new RoomDetails(RoomType.Suit,2,2000);
            RoomDetails room11=new RoomDetails(RoomType.Suit,2,2000);
            RoomDetails room12=new RoomDetails(RoomType.Suit,2,1500);
            RoomDetails room13=new RoomDetails(RoomType.Suit,4,2000);
            roomDetailsList.Add(room1);
            roomDetailsList.Add(room2);
            roomDetailsList.Add(room3);
            roomDetailsList.Add(room4);
            roomDetailsList.Add(room5);
            roomDetailsList.Add(room6);
            roomDetailsList.Add(room7);
            roomDetailsList.Add(room8);
            roomDetailsList.Add(room9);
            roomDetailsList.Add(room10);
            roomDetailsList.Add(room11);
            roomDetailsList.Add(room12);
            roomDetailsList.Add(room13);
            

            RoomSelection roomSelection1=new RoomSelection("BID101","RID101",new DateTime(2022, 11, 11, 06,00,00),new DateTime(2022,11,12,02,00,00),750,1.5,BookingStatus.Booked);
            RoomSelection roomSelection2=new RoomSelection("BID101","RID102",new DateTime(2022, 11, 11, 10,00,00),new DateTime(2022,11,12,09,00,00),700,1,BookingStatus.Booked);
            RoomSelection roomSelection3=new RoomSelection("BID102","RID103",new DateTime(2022, 11, 12, 09,00,00),new DateTime(2022,11,13,09,00,00),500,1,BookingStatus.Cancelled);
            RoomSelection roomSelection4=new RoomSelection("BID102","RID106",new DateTime(2022, 11, 12, 06,00,00),new DateTime(2022,11,13,12,30,00),1500,1.5,BookingStatus.Cancelled);
            roomSelectionsList.Add(roomSelection1);
            roomSelectionsList.Add(roomSelection2);
            roomSelectionsList.Add(roomSelection3);
            roomSelectionsList.Add(roomSelection4);

            BookingDetails booking1=new BookingDetails("SF1001",1450,new DateTime(2022, 11, 10),BookingStatus.Booked);
            BookingDetails booking2=new BookingDetails("SF1002",2000,new DateTime(2022, 11, 10),BookingStatus.Cancelled);
            bookingDetailsList.Add(booking1);
            bookingDetailsList.Add(booking2);

            System.Console.WriteLine("---Default User Details---");
            foreach(UserRegistration users in userRegistrationsList)
            {
                System.Console.WriteLine($"{users.UserID} | {users.UserName} | {users.MobileNumber} | {users.AadharNumber} | {users.Address} | {users.FoodType} | {users.Gender} | {users.WalletBalance}");
            }

            System.Console.WriteLine("---Default Room Details---");
            foreach(RoomDetails rooms in roomDetailsList)
            {
                System.Console.WriteLine($"{rooms.RoomID} | {rooms.RoomType} | {rooms.NumberOfBeds} | {rooms.PricePerDay}");
            }

            System.Console.WriteLine("---Default Room Selection Details---");
            foreach(RoomSelection roomSelections in roomSelectionsList)
            {
                System.Console.WriteLine($"{roomSelections.SelectionID} | {roomSelections.BookingID} | {roomSelections.RoomID} |  | {roomSelections.StayingDateFrom} | {roomSelections.StayingDateTo} | {roomSelections.Price} | {roomSelections.NumberOfDays} | {roomSelections.BookingStatus}");
            }
            
            System.Console.WriteLine("Default Book Details");
            foreach(BookingDetails booking in bookingDetailsList)
            {
                System.Console.WriteLine($"{booking.BookingID} | {booking.UserID} | {booking.TotalPrice} | {booking.DateOfBooking.ToString("dd/MM/yyyy")} | {booking.BookingStatus}");
            }
        }

        public static void MainMenu()
        {
            bool IsFlag=true;
            do
            {
                System.Console.WriteLine("--- Welcome to SYNCSTAYS Hotel Managament Application ---");
                System.Console.WriteLine();
                System.Console.WriteLine(" Select Options:  1.User Registration         2.User Login           3.Exit");
                int toChoose=int.Parse(Console.ReadLine());
                switch(toChoose)
                {
                    case 1:
                    {
                        UserRegistration();
                        break;
                    }
                    case 2:
                    {
                        UserLogin();
                        break;
                    }
                    case 3:
                    {
                        System.Console.WriteLine("--- Application Exited---");
                        IsFlag=false;
                        break;
                    }
                    default:
                    {
                        System.Console.WriteLine("Select Given Option Correctly !!!");
                        break;
                    }
                }
            }while(IsFlag);
        }

        public static void UserRegistration()
        {
            System.Console.WriteLine("-- Welcome to User Registration");
            System.Console.WriteLine(" Enter Your Name: ");
            string userName=Console.ReadLine();
            System.Console.WriteLine(" Enter Your Mobile Number: ");
            long mobileNumber=long.Parse(Console.ReadLine());
            System.Console.WriteLine(" Enter Your Aadhar Number: ");
            long aadharNumber=long.Parse(Console.ReadLine());
            System.Console.WriteLine(" Enter Your Address: ");
            string address=Console.ReadLine();
            System.Console.WriteLine("Enter Your Food Type(Veg, NonVeg): ");
            FoodType foodType=Enum.Parse<FoodType>(Console.ReadLine(), true);
            System.Console.WriteLine(" Enter Your Gender(Male, Female, Transgender): ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(), true);
            System.Console.WriteLine(" Enter Your Waallet Balance: ");
            double walletBalance=long.Parse(Console.ReadLine());
            
            UserRegistration user=new UserRegistration(userName,mobileNumber,aadharNumber,address,foodType,gender,walletBalance);
            userRegistrationsList.Add(user);
            System.Console.WriteLine($" Registration SUCCESSFUL & Your User ID: {user.UserID}");
        }


        public static void UserLogin()
        {
            //bool IsFlag=true;
            System.Console.WriteLine(" -- Welcome to User Login --");
            System.Console.WriteLine("Enter Your User ID: ");
            string userID=Console.ReadLine().ToUpper();
            UserRegistration userRegistration1=BinarySearch.BinarySearchLogin(userID);
            if(userRegistration1!=null)
            {
                System.Console.WriteLine("!! Welcome You !!");
                currentLoginUser=userRegistration1;
                SubMenu();
                //IsFlag=false;
            }
            else
            {
                System.Console.WriteLine("Invalid ID !!!");
            }
        }


        public static void SubMenu()
        {
            bool IsFlag=true;
            do
            {
                System.Console.WriteLine("Select Options    1.View Customer Profile         2.Book Room         3.Modify Booking        4.Cancel Booking        5.	Booking History         6.Wallet Recharge           7.Show WalletBalance          8.Exit ");
                int toChoose=int.Parse(Console.ReadLine());
                switch(toChoose)
                {
                    case 1:
                    {
                        ViewCustomerProfile();
                        break;
                    }
                    case 2:
                    {
                        BookRoom();
                        break;
                    }
                    case 3:
                    {
                        ModifyBooking();
                        break;
                    }
                    case 4:
                    {
                        CancelBooking();
                        break;
                    }
                    case 5:
                    {
                        BookingHistory();
                        break;
                    }
                    case 6:
                    {
                        WalletRecharge();
                        break;
                    }
                    case 7:
                    {
                        ShowWalletBalance();
                        break;
                    }
                    case 8:
                    {
                        System.Console.WriteLine("-- Login Exited --");
                        IsFlag=false;
                        break;
                    }
                    default:
                    {
                        System.Console.WriteLine(" Select Given Options Correctly !!");
                        break;
                    }
                }
                
            }while(IsFlag);
        }


    }
}

