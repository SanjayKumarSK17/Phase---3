using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class UserRegistration:PersonalDetails,IWalletManager
    {
        private double _balance;
        private static int s_userID=1000;
        public string UserID { get; }
        public double WalletBalance { get {return _balance;}}
        public UserRegistration(string userName, long mobileNumber, long aadharNumber, string address, FoodType foodType, Gender gender,double walletBalaance)
        :base( userName,  mobileNumber,  aadharNumber,  address,  foodType,  gender)
        {
            s_userID++;
            UserID="SF"+s_userID;
            _balance=walletBalaance;
        }

        public UserRegistration(string user)
        {
            string[] array=user.Split(',');

            UserID=array[0];
            s_userID=int.Parse(array[0].Remove(0,2));
            UserName=array[1];
            MobileNumber=long.Parse(array[2]);
            AadharNumber=long.Parse(array[3]);
            Address=array[4];
            FoodType=Enum.Parse<FoodType>(array[5], true);
            Gender=Enum.Parse<Gender>(array[6],true);
            _balance=double.Parse(array[7]);
        }
        public void WalletRecharge(double rechargeAmount)
        {
            _balance+=rechargeAmount;
        }
        public void DeductBalance(double deductAmount)
        {
            _balance-=deductAmount;
        }
    }
}