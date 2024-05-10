using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public class UserDetails:PersonalDetails, IBalance
    {
        private static int s_userID=1000;
        public string UserID { get;  }
        public string WorkStationNumber { get; set; }
        private double _balance{get; set;}
        public double WalletBalance { get{return _balance;}}
        

        public UserDetails(string name, string fatherName, long mobileNumber, string mailID, Gender gender,string workStationNumber,double walletBalance)
        :base(name,  fatherName, gender,  mobileNumber, mailID )
        {
            s_userID++;
            UserID="SF"+s_userID;
            WorkStationNumber=workStationNumber;
            _balance=walletBalance;
        }
        public UserDetails(string user)
        {
            string[] array=user.Split(',');

               
                s_userID=int.Parse(array[0].Remove(0,2));
                 UserID=array[0];
                Name=array[1];
                FatherName=array[2];
                MobileNumber=long.Parse(array[3]);
                MailID=array[4];
                Gender=Enum.Parse<Gender>(array[5],true);
                WorkStationNumber=array[6];
               _balance=double.Parse(array[7]);
        }
        public void WalletRecharge(double rechargeAmount)
        {
            _balance+=rechargeAmount;
        }

        public void DeductAmount(double deductAmount)
        {
            _balance-=deductAmount;
        }


    }
}