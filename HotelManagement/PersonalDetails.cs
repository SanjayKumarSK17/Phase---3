using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace HotelManagement
{
    public enum FoodType{Select, Veg, NonVeg}
    public enum Gender { Select, Male, Female, Transgender }
    public class PersonalDetails
    {
        public string UserName { get; set; }
        public long MobileNumber { get; set; }
        public long AadharNumber { get; set; }
        public string Address { get; set; }
        public FoodType FoodType { get; set; }
        public Gender Gender { get; set; }

        public PersonalDetails(string userName, long mobileNumber, long aadharNumber, string address, FoodType foodType, Gender gender)
        {
            UserName=userName;
            MobileNumber=mobileNumber;
            AadharNumber=aadharNumber;
            Address=address;
            FoodType=foodType;
            Gender=gender;
        }

        public PersonalDetails()
        {
            
        }

    }
}