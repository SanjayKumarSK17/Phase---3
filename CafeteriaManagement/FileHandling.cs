using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public static  class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("CafeteriaManagementApplication"))
            {
                Console.WriteLine("Folder Created");
                Directory.CreateDirectory("CafeteriaManagementApplication");
            }
            //User Details
            if(!File.Exists("CafeteriaManagementApplication/UserDetails.csv"))
            {
                Console.WriteLine("File Creating -User Details");
                File.Create("CafeteriaManagementApplication/UserDetails.csv").Close();
            }
            //OrderDetails
            if(!File.Exists("CafeteriaManagementApplication/OrderDetails.csv"))
            {
                Console.WriteLine("File Createdd- OrderDetails");
                File.Create("CafeteriaManagementApplication/OrderDetails.csv").Close();
            }
            //FoodDetails
            if(!File.Exists("CafeteriaManagementApplication/FoodDetails.csv"))
            {
                Console.WriteLine("File Createdd- FoodDetails");
                File.Create("CafeteriaManagementApplication/FoodDetails.csv").Close();
            }
            //CartItem
            if(!File.Exists("CafeteriaManagementApplication/CartItem.csv"))
            {
                Console.WriteLine("File Createdd- CartItem");
                File.Create("CafeteriaManagementApplication/CartItem.csv").Close();
            }
        }

        public static void WriteToCSV()
        {
            //UserDetails
            string[] user=new string[Operations.userDetailsList.Count];
            for(int i=0;i<Operations.userDetailsList.Count;i++)
            {
                user[i]=Operations.userDetailsList[i].UserID+","+Operations.userDetailsList[i].Name+","+Operations.userDetailsList[i].FatherName+","+Operations.userDetailsList[i].MobileNumber+","+Operations.userDetailsList[i].MailID+","+Operations.userDetailsList[i].Gender+","+Operations.userDetailsList[i].WorkStationNumber+","+Operations.userDetailsList[i].WalletBalance;
            }
            File.WriteAllLines("CafeteriaManagementApplication/UserDetails.csv",user);
            //OrderDetails
            string[] order=new string[Operations.orderDetailsList.Count];
            for(int i=0;i<Operations.orderDetailsList.Count;i++)
            {
                order[i]=Operations.orderDetailsList[i].OrderID+","+Operations.orderDetailsList[i].UserID+","+Operations.orderDetailsList[i].OrderDate.ToString("dd/MM/yyyy")+","+Operations.orderDetailsList[i].TotalPrice+","+Operations.orderDetailsList[i].OrderStatus;
            }
            File.WriteAllLines("CafeteriaManagementApplication/OrderDetails.csv",order);
            //Food Details
            string[] food=new string[Operations.foodDetailsList.Count];
            for(int i=0;i<Operations.foodDetailsList.Count;i++)
            {
                food[i]=Operations.foodDetailsList[i].FoodID+","+Operations.foodDetailsList[i].FoodName+","+Operations.foodDetailsList[i].FoodPrice+","+Operations.foodDetailsList[i].AvailableQuantity;
            }
            File.WriteAllLines("CafeteriaManagementApplication/FoodDetails.csv",food);
            //CartItem
            string[] cart=new string[Operations.cartItemsList.Count];
            for(int i=0;i<Operations.cartItemsList.Count;i++)
            {
                cart[i]=Operations.cartItemsList[i].ItemID+","+Operations.cartItemsList[i].OrderID+","+Operations.cartItemsList[i].FoodID+","+Operations.cartItemsList[i].OrderPrice+","+Operations.cartItemsList[i].OrderQuantity;
            }
            File.WriteAllLines("CafeteriaManagementApplication/CartItem.csv",cart);
        } 

        public static void ReadFromCSV()
        {
            //UserDetails
            string[] users=File.ReadAllLines("CafeteriaManagementApplication/UserDetails.csv");
            foreach(string user in users)
            {
                UserDetails user1=new UserDetails(user);
                Operations.userDetailsList.Add(user1);
            }
            //FoodDetails
            string[] foods=File.ReadAllLines("CafeteriaManagementApplication/FoodDetails.csv");
            foreach(string food in foods)
            {
                FoodDetails food1=new FoodDetails(food);
                Operations.foodDetailsList.Add(food1);
            }
            //OrderDetails
            string[] orders=File.ReadAllLines("CafeteriaManagementApplication/OrderDetails.csv");
            foreach(string order in orders)
            {
                OrderDetails order1=new OrderDetails(order);
                Operations.orderDetailsList.Add(order1);
            }
            //CartItem
            string[] carts=File.ReadAllLines("CafeteriaManagementApplication/CartItem.csv");
            foreach(string cart in carts)
            {
                CartItem cart1=new CartItem(cart);
                Operations.cartItemsList.Add(cart1);
            }
        }



    }
}