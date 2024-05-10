using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class BinarySearch
    {
        public string UserID { get; set; }
        public static UserRegistration BinarySearchLogin(string element)
        {
            CustomList<UserRegistration> userRegistrationsList=Operations.userRegistrationsList;

            int start=0;
            int end=userRegistrationsList.Count-1;

            while(start<=end)
            {
                int middle=start + ((end-start)/2);
                if(userRegistrationsList[middle].UserID==element)
                {
                    return userRegistrationsList[middle];
                }
                else if(string.Compare(userRegistrationsList[middle].UserID,element)<0)
                {
                    start=middle+1;
                }
                else
                {
                    end=middle-1;
                }
            }
            return null;
        }
    }
}