using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public interface IBalance
    {
         double WalletBalance { get;   }
         void WalletRecharge(double rechargeAmount);
         void DeductAmount(double deductAmount);
        
    }
}