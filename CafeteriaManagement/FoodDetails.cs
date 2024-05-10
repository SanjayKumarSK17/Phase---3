using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public class FoodDetails
    {
        private static int s_foodID=100;
        public string FoodID { get; }
        public string FoodName { get; set; }
        public int  FoodPrice { get; set; }
        public double AvailableQuantity { get; set; }

        public FoodDetails(string foodName, int foodPrice, double availableQuantity)
        {
            s_foodID++;
            FoodID="FID"+s_foodID;
            FoodName=foodName;
            FoodPrice=foodPrice;
            AvailableQuantity=availableQuantity;
        }

        public FoodDetails(string food)
        {
            string[] array=food.Split(',');

            FoodID=array[0];
            s_foodID=int.Parse(array[0].Remove(0,3));
            FoodName=array[1];
            FoodPrice=int.Parse(array[2]);
            AvailableQuantity=double.Parse(array[3]);
         }
    }
}