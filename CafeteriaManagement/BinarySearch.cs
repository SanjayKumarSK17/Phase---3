using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public class BinarySearch
    {
        public string UserID { get; set; }
        public static UserDetails BinarySearchLogin( string element)
        {
            List<UserDetails> userDetailsList=Operations.userDetailsList;

            int start = 0;
            int end = userDetailsList.Count - 1;

            while (start <= end)
            {
                int middle = start + ((end - start) / 2);
                if (userDetailsList[middle].UserID == element)
                {
                    return userDetailsList[middle];
                }
                else if (string.Compare(userDetailsList[middle].UserID,element)<0)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }
            return null;
        }

        
        public static int BinarySearchCancel(List<OrderDetails> orderDetailsList, string element)
        {
            int start = 0;
            int end = orderDetailsList.Count - 1;
            while (start <= end)
            {
                int middle = start + ((end - start) / 2);
                if (orderDetailsList[middle].UserID == element)
                {
                    return middle;
                }
                else if (string.Compare(orderDetailsList[middle].UserID,element)<0)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }
            return -1;
        }

        
    }
}