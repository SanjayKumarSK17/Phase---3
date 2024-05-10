using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    public class PersonalDetails
    {
        public string UserName { get; set; }
        public long MobileNumber { get; set; }
        public PersonalDetails(string userName, long mobileNumber)
        {
            UserName=userName;
            MobileNumber=mobileNumber;
        }
        public PersonalDetails()
        {
            
        }
    }
}