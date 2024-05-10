using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    public static class Operations
    {
        public static CustomList<UserDetails> userDetailsList = new CustomList<UserDetails>();
        public static CustomList<PersonalDetails> personalDetailsList = new CustomList<PersonalDetails>();
        public static CustomList<TravelDetails> travelDetailsList = new CustomList<TravelDetails>();
        public static CustomList<TicketFairDetails> ticketFairDetailsList = new CustomList<TicketFairDetails>();
        static UserDetails currentUserLogin;

        public static void AddDefaultData()
        {
            UserDetails user1 = new UserDetails("Ravi", 99454369, 1000);
            UserDetails user2 = new UserDetails("Ravi", 99454369, 1000);
            userDetailsList.Add(user1);
            userDetailsList.Add(user2);

            TravelDetails travel1 = new TravelDetails("CMRL1001", "Airport", "Egmore", new DateTime(2023, 10, 10), 55);
            TravelDetails travel2 = new TravelDetails("CMRL1001", "Egmore", "Koyambedu", new DateTime(2023, 10, 10), 55);
            TravelDetails travel3 = new TravelDetails("CMRL1002", "Alandur", "Koyambedu", new DateTime(2023, 11, 10), 55);
            TravelDetails travel4 = new TravelDetails("CMRL1002", "Egmore", "Thirumangalam", new DateTime(2023, 11, 10), 55);
            travelDetailsList.Add(travel1);
            travelDetailsList.Add(travel2);
            travelDetailsList.Add(travel3);
            travelDetailsList.Add(travel4);

            TicketFairDetails ticket1 = new TicketFairDetails("Airport", "Egmore", 55);
            TicketFairDetails ticket2 = new TicketFairDetails("Airport", "Koyambedu", 25);
            TicketFairDetails ticket3 = new TicketFairDetails("Alandur", "Koyambedu", 25);
            TicketFairDetails ticket4 = new TicketFairDetails("Koyambedu", "Egmore", 32);
            TicketFairDetails ticket5 = new TicketFairDetails("Vadapalani", "Egmore", 45);
            TicketFairDetails ticket6 = new TicketFairDetails("Arumbakkamt", "Egmore", 25);
            TicketFairDetails ticket7 = new TicketFairDetails("Vadapalani", "Koyambedu", 25);
            TicketFairDetails ticket8 = new TicketFairDetails("Arumbakkam", "Koyambedu", 16);
            ticketFairDetailsList.Add(ticket1);
            ticketFairDetailsList.Add(ticket2);
            ticketFairDetailsList.Add(ticket3);
            ticketFairDetailsList.Add(ticket4);
            ticketFairDetailsList.Add(ticket5);
            ticketFairDetailsList.Add(ticket6);
            ticketFairDetailsList.Add(ticket7);
            ticketFairDetailsList.Add(ticket8);

            Console.WriteLine("User Available Details");
            foreach (UserDetails user in userDetailsList)
            {
                Console.WriteLine($"{user.CardNumber} | {user.UserName} | {user.MobileNumber} | {user.Balance}");
            }

            Console.WriteLine("User Travel History Details");
            foreach (TravelDetails travel in travelDetailsList)
            {
                Console.WriteLine($"{travel.TravelID} | {travel.CardNumber} | {travel.FromLocation} | {travel.ToLocation} | {travel.Date.ToString("dd/MM/yyyy")} | {travel.TravelCost}");
            }

            Console.WriteLine("Ticket Fair Details");
            foreach (TicketFairDetails ticket in ticketFairDetailsList)
            {
                Console.WriteLine($"{ticket.TicketID} | {ticket.FromLocation} | {ticket.ToLocation} | {ticket.TicketPrice}");
            }
        }

        public static void MainMenu()
        {
            bool IsFlag = true;
            do
            {
                Console.WriteLine();
                System.Console.WriteLine("Select  1.New User Registration       2.Login User         3.Exit");
                int toChoose = int.Parse(Console.ReadLine());
                switch (toChoose)
                {
                    case 1:
                        {
                            NewUserRegistration();
                            break;
                        }
                    case 2:
                        {
                            UserLOgin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("--Application Exited--");
                            IsFlag = false;
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void NewUserRegistration()
        {
            Console.WriteLine("--Welcome to User Registration:");
            Console.WriteLine("Enter your UserName: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter your Mobile Number: ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Balance: ");
            double balance = double.Parse(Console.ReadLine());
            UserDetails users = new UserDetails(userName, mobileNumber, balance);
            userDetailsList.Add(users);
            System.Console.WriteLine("Registered Successfully & your Card number is: " + users.CardNumber);
        }

        public static void UserLOgin()
        {
            Console.WriteLine("Welcome to User Login");
            Console.WriteLine("Enter your card Number: ");
            string userCN = Console.ReadLine().ToUpper();
            UserDetails currentLoginUser = BinarySearch.BinarySearchLogin(userCN);
            if (currentLoginUser != null)
            {
                Console.WriteLine("Successfully Login");
                currentUserLogin = currentLoginUser;
                SubMenu();
            }
            else
            {
                Console.WriteLine("Invalid ID!");
            }
        }
        public static void SubMenu()
        {
            bool IsFlag = true;
            do
            {
                Console.WriteLine("Select       1.Balance Check      2.Rechange     3.View Travel History	 4.Travel       5.Exit  ");
                int toChoose = int.Parse(Console.ReadLine());
                switch (toChoose)
                {
                    case 1:
                    {
                        BalanceCheck();
                        break;
                    }
                    case 2:
                    {
                        Recharge();
                        break;
                    }
                    case 3:
                    {
                        ViewTravelHistory();
                        break;
                    }
                    case 4:
                    {
                        Travel();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("--Login Exited--");
                        IsFlag=false;
                        break;
                    }
                }
            } while (IsFlag);
        }

        public static void BalanceCheck()
        {
            //Display the balance amount of the user object which is related to the card number.
            Console.WriteLine("Balance: "+ currentUserLogin.Balance);
        }

        public static void Recharge()
        {
            //Get the amount to be recharged and add the recharged amount to the balance amount of the user object which is related to the card number.
            Console.WriteLine(" Enter Yes-- If You want to Reacharge:");
            string recharge = Console.ReadLine().ToLower();
            if (recharge == "yes")
            {
                Console.WriteLine("Enter Amount to Recharge: ");
                int toRecharge = int.Parse(Console.ReadLine());
                if (toRecharge > 0)
                {
                    currentUserLogin.WalletRecharge(toRecharge);
                    Console.WriteLine("--- Recharge Successful--- Balance: " + currentUserLogin.Balance);
                }
                else
                {
                    Console.WriteLine("Invalid Amount");
                }
            }
        }

        public static void ViewTravelHistory()
        {
            //Display list of the travel history objects which is related to the card number.
            bool IsFlag=true;
            foreach(TravelDetails travel in travelDetailsList)
            {
                if(currentUserLogin.CardNumber==travel.CardNumber)
                {
                    IsFlag=false;
                    Console.WriteLine($"{travel.TravelID} | {travel.CardNumber} | {travel.FromLocation} | {travel.ToLocation} | {travel.Date.ToString("dd/MM/yyyy")} | {travel.TravelCost}");
                }
            }
            if(IsFlag)
            {
                Console.WriteLine("No Travel History");
            }
        }

        public static void Travel()
        {
            //1.	Show the Ticket fair details where the user wishes to travel by getting TicketID.
            Console.WriteLine("Ticket Fair Details");
            foreach (TicketFairDetails ticket in ticketFairDetailsList)
            {
                Console.WriteLine($"{ticket.TicketID} | {ticket.FromLocation} | {ticket.ToLocation} | {ticket.TicketPrice}");
            }
            //2.	Check the ticketID is valid. Else show “Invalid user id”.
            bool IsFlag=true;
            Console.WriteLine("Enter ticket ID to travel: ");
            string ticketID=Console.ReadLine().ToUpper();
            foreach (TicketFairDetails ticket in ticketFairDetailsList)
            {
                if(ticketID==ticket.TicketID)
                {
                    IsFlag=false;
                    //3.	IF ticket is valid then, Check the balance from the user object whether it has sufficient balance to travel
                    if(currentUserLogin.Balance>=ticket.TicketPrice)
                    {
                        //4.	If “Yes” deduct the respective amount from the balance and add the travel details like
                        // Card number, From and ToLocation, Travel Date, Travel cost, Travel ID (auto generation) in his travel history.
                        currentUserLogin.DeductBalance(ticket.TicketPrice);
                        TravelDetails travel=new TravelDetails(currentUserLogin.CardNumber,ticket.FromLocation,ticket.ToLocation,DateTime.Today,ticket.TicketPrice);
                        travelDetailsList.Add(travel);
                        Console.WriteLine("Enjoy Your travel &  travel ID:" + travel.TravelID);
                    }
                    else
                    {
                        System.Console.WriteLine("If “No” ask him to recharge and go to the “Existing User Service” menu.");
                    }
                }
            }
            if(IsFlag)
            {
                System.Console.WriteLine("Invalid ID");
            }
        }

    }
}