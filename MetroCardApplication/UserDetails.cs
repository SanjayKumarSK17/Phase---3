using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    public class UserDetails:PersonalDetails,IBalance
    {
        private static int s_cardNumber=1000;
        public string CardNumber { get;  }
        public double Balance { get; set; }

        public UserDetails(string userName, long mobileNumber,double balance)
        :base( userName,  mobileNumber)
        {
            s_cardNumber++;
            CardNumber="CMRL"+s_cardNumber;
            Balance=balance;
        }
        public UserDetails(string user)
        {
            string[] array=user.Split(',');

            CardNumber=array[0];
            s_cardNumber=int.Parse(array[0].Remove(0,4));
            UserName=array[1];
            MobileNumber=long.Parse(array[2]);
            Balance=double.Parse(array[3]);
        }
        public void WalletRecharge(double amount)
        {
            Balance+=amount;
            
        }
        public void DeductBalance(double amount)
        {
            Balance-=amount;
        }
    }
}