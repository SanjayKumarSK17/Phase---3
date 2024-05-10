using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public class CartItem
    {
        private static int s_itemID=100;
        public string ItemID { get; }
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public double OrderPrice { get; set; }
        public int OrderQuantity { get; set; }
        
        public CartItem(string orderID, string foodID, double orderPrice, int orderQuantity)
        {
            s_itemID++;
            ItemID="ITID" +s_itemID;
            OrderID=orderID;
            FoodID=foodID;
            OrderPrice=orderPrice;
            OrderQuantity=orderQuantity;
        }
        public CartItem(string cart)
        {
            string[] array=cart.Split(',');

            ItemID=array[0];
            s_itemID=int.Parse(array[0].Remove(0,4));
            OrderID=array[1];
            FoodID=array[2];
            OrderPrice=double.Parse(array[3]);
            OrderQuantity=int.Parse(array[4]);
        }
    }
}