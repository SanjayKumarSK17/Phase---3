using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    
    public class BinarySearch
    {
        public string CardNumber{get; set;}
        public static UserDetails BinarySearchLogin(string element)
        {
            
            CustomList<UserDetails> userDetailsList=Operations.userDetailsList;
            int start=0;
            int end=userDetailsList.Count-1;
            while(start<=end)
            {
                int middle=start + ((end-start)/2);
                if(userDetailsList[middle].CardNumber==element)
                {
                    return userDetailsList[middle];
                }
                else if(string.Compare(userDetailsList[middle].CardNumber,element)<0)
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