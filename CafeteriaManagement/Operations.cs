using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public static class Operations
    {
        public static List<PersonalDetails> personalDetailsList = new List<PersonalDetails>();
        public static List<IBalance> balanceList = new List<IBalance>();
        public static List<UserDetails> userDetailsList = new List<UserDetails>();
        public static List<FoodDetails> foodDetailsList = new List<FoodDetails>();
        public static List<CartItem> cartItemsList = new List<CartItem>();
        public static List<OrderDetails> orderDetailsList = new List<OrderDetails>();
        static UserDetails currentLoginUser;

        public static void AddDefaultData()
        {
            //User Details
            UserDetails user1 = new UserDetails("Ravichandran", "Ettapparajan", 8857777575, "ravi@gmail.com", Gender.Male, "WS101", 400);
            UserDetails user2 = new UserDetails("Baskaran", "Sethurajan", 9577747744, "baskaran@gmail.com", Gender.Male, "WS105", 500);
            userDetailsList.Add(user1);
            userDetailsList.Add(user2);

            // Order Details
            OrderDetails order1 = new OrderDetails("SF1001", new DateTime(2022, 06, 15), 70, OrderStatus.Ordered);
            OrderDetails order2 = new OrderDetails("SF1002", new DateTime(2022, 06, 15), 100, OrderStatus.Ordered);
            orderDetailsList.Add(order1);
            orderDetailsList.Add(order2);

            //CartItems
            CartItem cart1 = new CartItem("OID1001", "FID101", 20, 1);
            CartItem cart2 = new CartItem("OID1001", "FID103", 10, 1);
            CartItem cart3 = new CartItem("OID1001", "FID105", 40, 1);
            CartItem cart4 = new CartItem("OID1002", "FID103", 10, 1);
            CartItem cart5 = new CartItem("OID1002", "FID104", 50, 1);
            CartItem cart6 = new CartItem("OID1002", "FID105", 40, 1);
            cartItemsList.Add(cart1);
            cartItemsList.Add(cart2);
            cartItemsList.Add(cart3);
            cartItemsList.Add(cart4);
            cartItemsList.Add(cart5);
            cartItemsList.Add(cart6);

            // Dood Details
            FoodDetails food1 = new FoodDetails("Coffee", 20, 100);
            FoodDetails food2 = new FoodDetails("Tea", 15, 100);
            FoodDetails food3 = new FoodDetails("Biscuit", 10, 100);
            FoodDetails food4 = new FoodDetails("Coffee", 50, 100);
            FoodDetails food5 = new FoodDetails("Coffee", 40, 100);
            FoodDetails food6 = new FoodDetails("Coffee", 10, 100);
            FoodDetails food7 = new FoodDetails("Coffee", 20, 20);
            foodDetailsList.Add(food1);
            foodDetailsList.Add(food2);
            foodDetailsList.Add(food3);
            foodDetailsList.Add(food4);
            foodDetailsList.Add(food5);
            foodDetailsList.Add(food6);
            foodDetailsList.Add(food7);

            Console.WriteLine("User Details");
            foreach (UserDetails users in userDetailsList)
            {
                Console.WriteLine($"{users.UserID} | {users.Name} | {users.FatherName} | {users.MobileNumber} | {users.MailID} | {users.Gender} | {users.WorkStationNumber} | {users.WalletBalance}");
            }

            Console.WriteLine("Order Details");
            foreach (OrderDetails orders in orderDetailsList)
            {
                Console.WriteLine($"{orders.OrderID} | {orders.UserID} | {orders.OrderDate.ToString("dd/MM/yyyy")} | {orders.TotalPrice} | {orders.OrderStatus}");
            }

            Console.WriteLine("Cart Item Details");
            foreach (CartItem carts in cartItemsList)
            {
                Console.WriteLine($"{carts.ItemID} | {carts.OrderID} | {carts.FoodID} | {carts.OrderPrice} | {carts.OrderQuantity} ");
            }

            Console.WriteLine("Food Details");
            foreach (FoodDetails foods in foodDetailsList)
            {
                Console.WriteLine($"{foods.FoodID} | {foods.FoodName} | {foods.FoodPrice} | {foods.AvailableQuantity}");
            }
        }

        public static void MainMenu()
        {
            bool IsFlag = true;
            do
            {
                Console.WriteLine("--- Welcome to Online Cafeteria Management ---");
                Console.WriteLine("Select  1.User Registration    2.User Login      3.Exit");
                int toChoose = int.Parse(Console.ReadLine());
                switch (toChoose)
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
                            Console.WriteLine("--Application Exited--");
                            IsFlag = false;
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void UserRegistration()
        {
            Console.WriteLine("--- Welcome to User Regfistration--");
            Console.WriteLine("Enter Your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Your Father Name: ");
            string fatherName = Console.ReadLine();
            Console.WriteLine("Enter Your Mobile Number: ");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your E-Mail ID: ");
            string mailID = Console.ReadLine();
            Console.WriteLine("Enter Your Gender(Male, Female, Transgender): ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.WriteLine("Enter Your Work-Station Number(WS100,...): ");
            string workStationNumber = Console.ReadLine();
            Console.WriteLine("Enter Your Balance: ");
            double balance = double.Parse(Console.ReadLine());
            UserDetails user = new UserDetails(name, fatherName, mobileNumber, mailID, gender, workStationNumber, balance);
            userDetailsList.Add(user);
            Console.WriteLine("User Registerd Successully & your User ID: " + user.UserID);
        }

        public static void UserLogin()
        {
            // bool IsFlag = true;
            Console.WriteLine("Welcome to User Login");
            Console.WriteLine("Enter Your User ID: ");
            string userID = Console.ReadLine().ToUpper();
            currentLoginUser = BinarySearch.BinarySearchLogin(userID);
            if (currentLoginUser != null)
            {
                Console.WriteLine("Welcome You---");
               
                SubMenu();
            }
            else { System.Console.WriteLine("Invalid ID"); }

        }

        public static void SubMenu()
        {
            bool IsFlag = true;
            do
            {
                Console.WriteLine("Select  1.Show My Profile    2. Food Order       3. Modify Order      4.Cancel Order      5. Order History       6. Wallet Recharge      7.Show WalletBalance    8.Exit");
                int toChoose = int.Parse(Console.ReadLine());
                switch (toChoose)
                {
                    case 1:
                        {
                            ShowMyProfile();
                            break;
                        }
                    case 2:
                        {
                            FoodOrder();
                            break;
                        }
                    case 3:
                        {
                            ModifyOrder();
                            break;
                        }
                    case 4:
                        {
                            CancelOrder();
                            break;
                        }
                    case 5:
                        {
                            OrderHistory();
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
                            Console.WriteLine("-- Login Exited--");
                            IsFlag = false;
                            break;
                        }
                }
            } while (IsFlag);
        }

        public static void ShowMyProfile()
        {
            //Show the current logged in user’s personal details in console.
            Console.WriteLine("Your Profile");
            UserDetails users = BinarySearch.BinarySearchLogin(currentLoginUser.UserID);
            if (currentLoginUser.UserID == users.UserID)
            {
                Console.WriteLine($"{users.UserID} | {users.Name} | {users.FatherName} | {users.MobileNumber} | {users.MailID} | {users.Gender} | {users.WorkStationNumber} | {users.WalletBalance}");
            }

        }

        public static void FoodOrder()
        {

            //1.	Create a temporary local carItemtList.
            List<CartItem> localCarts = new List<CartItem>();
            //2.	Create an Order object with current UserID, Order date as current DateTime, total price as 0, Order status as “Initiated”.
            OrderDetails order = new OrderDetails(currentLoginUser.UserID, DateTime.Today, 0, OrderStatus.Initiated);
            //3.	Ask the user to pick a product using FoodID, quantity required and calculate price of food.
            //Show the below items where the user wishes to order and get the option.
            Console.WriteLine("Food Details");
            foreach (FoodDetails foods in foodDetailsList)
            {
                Console.WriteLine($"{foods.FoodID} | {foods.FoodName} | {foods.FoodPrice} | {foods.AvailableQuantity}");
            }
            double totalPrice = 0;
            string toChoose;
            do
            {
                Console.WriteLine("Enter the Food ID: ");
                string foodID = Console.ReadLine().ToUpper();
                Console.WriteLine("Enter the Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                //4.	If the food and quantity available, reduce the quantity from the food object’s “AvailableQuantity” then create CartItems object using the available data.
                bool flag = true;
                foreach (FoodDetails food in foodDetailsList)
                {
                    if (foodID == food.FoodID)
                    {
                        flag = false;
                        if (food.AvailableQuantity >= quantity)
                        {
                            double price = food.FoodPrice * quantity;
                            food.AvailableQuantity -= quantity;
                            totalPrice += price;
                            // 5.	Add that object it to local CartItemsList to add it to cart wish list.
                            CartItem item = new CartItem(order.OrderID, foodID, price, quantity);
                            localCarts.Add(item);
                        }
                        else
                        {
                            Console.WriteLine("Qunatity unavailble");
                        }
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Invalid Food ID ");
                }
                //6.	Ask the user whether he want to pick another product. 
                //7.	If “Yes” then show the updated Food Details and repeat from step “3”.
                Console.WriteLine("Do you add products: yes/no ");
                toChoose = Console.ReadLine().ToLower();
                //8.	Repeat the process until the user enters “No”.
            } while (toChoose == "yes");

            //9.	If He says No then, 
            //10.	Ask the user whether he confirm the wish list to purchase. 
            //   If he says “No” then traverse the local CartItemList and
            //    get the Items one by one and reverse the quantity to the FoodItem’s objects in the foodList.
            Console.WriteLine("user whether he confirm the wish list to purchase: ");
            string option = Console.ReadLine().ToLower();
            if (option == "yes")
            {
                //11.	If he says “Yes” then, 
                //Calculate the total price of the food items selected using the local CartItemList information and
                // check the balance from the user details whether it has sufficient balance to purchase.
                bool IsFlag = false;
                do
                {
                    if (currentLoginUser.WalletBalance >= totalPrice)
                    {
                        IsFlag = false;
                        //12.	If he has enough balance, then deduct the respective amount from the user’s balance.
                        //13.	Append the local CartItemList to global CartItemList.
                        cartItemsList.AddRange(localCarts);
                        //14.	Modify Order object created at step 1’s total price as total OrderPrice and OrderStatus as “Ordered”. 
                        order.OrderStatus = OrderStatus.Ordered;
                        order.TotalPrice = totalPrice;
                        currentLoginUser.DeductAmount(totalPrice);
                        //15.	Then add the Order object to the Order list.
                        orderDetailsList.Add(order);
                        Console.WriteLine("Order Placed Succesfully: " + order.OrderID);

                    }
                    //17.	If he doesn’t have enough balance show “In sufficient balance to purchase.” Ask him “Are you willing to recharge.”
                    else
                    {
                        Console.WriteLine("Insufficient Recharge: Are you willing to recharge ");
                        string toRecharge = Console.ReadLine().ToLower();
                        if (toRecharge == "yes")
                        {
                            //19.	If he says “Yes”. Then ask him to Recharge with the total price of Order. If he recharged with that amount means continue from step 12 to continue purchase. 
                            IsFlag = true;
                            System.Console.WriteLine("Enter Amount to recharge: ");
                            int rechargeAmount = int.Parse(Console.ReadLine());
                            currentLoginUser.WalletRecharge(rechargeAmount);
                            Console.WriteLine("Current Balnce:" + currentLoginUser.WalletBalance);
                        }
                        else
                        {
                            IsFlag = false;
                            //18.	 If he says “No” then show “Exiting without Order due to insufficient balance”. Then need to return the localCartList items to foodItemsList.
                            foreach (CartItem item in localCarts)
                            {
                                foreach (FoodDetails food in foodDetailsList)
                                {
                                    if (item.FoodID == food.FoodID)
                                    {
                                        food.AvailableQuantity += item.OrderQuantity; // again restored to food
                                        break;
                                    }
                                }
                            }
                        }

                    }
                } while (IsFlag);
            }
            else
            {
                foreach (CartItem item in localCarts)
                {
                    foreach (FoodDetails food in foodDetailsList)
                    {
                        if (item.FoodID == food.FoodID)
                        {
                            food.AvailableQuantity += item.OrderQuantity; // again restored to food
                            break;
                        }
                    }
                }
            }



        }

        public static void ModifyOrder()
        {
            //1.	Show the Order details of current logged in user to pick an Order detail by using OrderID and whose status is “Ordered”.
            // Check whether the order details is present.
            bool IsFlag = true;
            foreach (OrderDetails orders in orderDetailsList)
            {
                if (orders.OrderStatus == OrderStatus.Ordered && orders.UserID == currentLoginUser.UserID)
                {
                    IsFlag = false;
                    Console.WriteLine($"{orders.OrderID} | {orders.UserID} | {orders.OrderDate.ToString("dd/MM/yyyy")} | {orders.TotalPrice} | {orders.OrderStatus}");
                }
            }
            if (IsFlag)
            {
                Console.WriteLine("No Cancel Order");
            }
            if (!IsFlag)
            {
                bool IsFlag1 = true;
                System.Console.WriteLine("Enter Order ID to modify: ");
                string modifyOrder = Console.ReadLine().ToUpper();
                foreach (OrderDetails orders in orderDetailsList)
                {
                    if (modifyOrder == orders.OrderID && orders.OrderStatus == OrderStatus.Ordered)
                    {
                        IsFlag1 = false;
                        //2.	Show list of Cart Item details and ask the user to pick an Item id.
                        foreach (CartItem carts in cartItemsList)
                        {
                            if (carts.OrderID == modifyOrder)
                            {
                                Console.WriteLine($"{carts.ItemID} | {carts.OrderID} | {carts.FoodID} | {carts.OrderPrice} | {carts.OrderQuantity} ");
                            }
                        }
                        // and ask the user to pick an Item id.
                        Console.WriteLine("Enter the Item ID to modify: ");
                        string itemID = Console.ReadLine().ToUpper();
                        bool IsFlag11 = true;
                        //3.	Ensure the ItemID is available 
                        foreach (CartItem carts in cartItemsList)
                        {
                            if (itemID == carts.ItemID)
                            {
                                IsFlag11 = false;
                                //and ask the user to enter the new quantity of the food. 
                                Console.WriteLine("Enter the qauantity of food: ");
                                int newQuantity = int.Parse(Console.ReadLine());
                                foreach (FoodDetails food in foodDetailsList)
                                {
                                    if (carts.FoodID == food.FoodID)
                                    {
                                        if (food.AvailableQuantity >= newQuantity)
                                        {
                                            // Calculate the Item price and update in the OrderPrice.
                                            int finalQuantityCheck = newQuantity - carts.OrderQuantity;
                                            if (finalQuantityCheck == 0)
                                            {
                                                System.Console.WriteLine("Same Food Quantity Entered");
                                            }
                                            else if (finalQuantityCheck < 0)
                                            {
                                                // reduce item quality
                                                carts.OrderQuantity += finalQuantityCheck;
                                                // calculate returning price
                                                double returnAmount = -finalQuantityCheck * food.FoodPrice;
                                                // recharge to usert
                                                currentLoginUser.WalletRecharge(returnAmount);
                                                orders.TotalPrice-=returnAmount;
                                                // increase food item to stock count
                                                food.AvailableQuantity += -finalQuantityCheck;
                                                System.Console.WriteLine("Order Modified Successfully");
                                            }
                                            else
                                            {
                                                // calculate subtracting price
                                                double returnAmount = finalQuantityCheck * food.FoodPrice;
                                                if (currentLoginUser.WalletBalance >= returnAmount)
                                                    // increase item quality
                                                    carts.OrderQuantity += finalQuantityCheck;
                                                // deduct  from user
                                                currentLoginUser.DeductAmount(returnAmount);
                                                orders.TotalPrice+=returnAmount;
                                                // decrease food item to stock count
                                                food.AvailableQuantity -= finalQuantityCheck;
                                                System.Console.WriteLine("Order Modified Successfully");
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Quantity insufficient");
                                        }
                                    }
                                }
                            }
                        }
                        if (IsFlag11)
                        {
                            Console.WriteLine("Invalid Item ID: ");
                        }
                    }
                }
                if (IsFlag1)
                {
                    System.Console.WriteLine("Invalid Order ID");
                }
            }

        }

        public static void CancelOrder()
        {
            //1.	Show the Order details of the current user who’s Order status is “Ordered”.
            bool IsFlag = true;
            foreach (OrderDetails orders in orderDetailsList)
            {
                if (orders.OrderStatus == OrderStatus.Ordered && orders.UserID == currentLoginUser.UserID && orders.OrderDate == DateTime.Today)
                {
                    IsFlag = false;
                    Console.WriteLine($"{orders.OrderID} | {orders.UserID} | {orders.OrderDate.ToString("dd/MM/yyyy")} | {orders.TotalPrice} | {orders.OrderStatus}");
                }
            }
            if (IsFlag)
            {
                Console.WriteLine("No Cancel Order");
            }

            if (!IsFlag)
            {
                //2.	Ask the user to pick an OrderID to cancel.
                Console.WriteLine("Ennter Order ID to cancel: ");
                string cancelID = Console.ReadLine().ToUpper();
                bool IsFlag1 = true;
                foreach (OrderDetails order in orderDetailsList)
                {
                    //3.	Check the OrderID is valid. If not, then show “Invalid OrderID”.
                    if (cancelID == order.OrderID && order.UserID == currentLoginUser.UserID && order.OrderStatus == OrderStatus.Ordered)
                    {
                        IsFlag1 = false;
                        //4.	If valid, then Return the Order total amount to current user. 
                        currentLoginUser.WalletRecharge(order.TotalPrice);
                        //5.	Return product orderQuantity to Foodtem list’s FoodQuantity. 
                        // traverse cart list
                        foreach (CartItem item in cartItemsList)
                        {
                            if (item.OrderID == order.OrderID)
                            {
                                foreach (FoodDetails food in foodDetailsList)
                                {
                                    if (item.FoodID == food.FoodID)
                                    {
                                        food.AvailableQuantity += item.OrderQuantity;
                                        break;
                                    }
                                }
                            }
                        }
                        //6.	Change the OrderStatus as Cancelled.
                        order.OrderStatus = OrderStatus.Cancelled;
                        //7.	Show “Order cancelled successfully” and product returned to cart.
                        Console.WriteLine("Order cancelled successfully");

                    }
                }
                if (IsFlag1)
                {
                    Console.WriteLine("Invalid ID");
                }
            }
        }

        public static void OrderHistory()
        {
            bool IsFlag = true;
            Console.WriteLine("Your Order History");
            foreach (OrderDetails orders in orderDetailsList)
            {
                if (orders.UserID == currentLoginUser.UserID)
                {
                    IsFlag = false;
                    Console.WriteLine($"{orders.OrderID} | {orders.UserID} | {orders.OrderDate.ToString("dd/MM/yyyy")} | {orders.TotalPrice} | {orders.OrderStatus}");
                }
            }
            if (IsFlag)
            {
                Console.WriteLine("-- No History Found --");
            }
        }

        public static void WalletRecharge()
        {
            //Ask the user whether he want to recharge. If yes then, Get the amount to be recharged and add the recharged amount to the balance of the user.
            Console.WriteLine(" Enter Yes-- If You want to Reacharge:");
            string recharge = Console.ReadLine().ToLower();
            if (recharge == "yes")
            {
                Console.WriteLine("Enter Amount to Recharge: ");
                int toRecharge = int.Parse(Console.ReadLine());
                if (toRecharge > 0)
                {
                    currentLoginUser.WalletRecharge(toRecharge);
                    Console.WriteLine("--- Recharge Successful--- Balance: " + currentLoginUser.WalletBalance);
                }
                else
                {
                    Console.WriteLine("Invalid Amount");
                }
            }
        }

        public static void ShowWalletBalance()
        {
            //Display the user’s wallet balance in console.
            Console.WriteLine("--- Your Balance is: " + currentLoginUser.WalletBalance);
        }

    }
}