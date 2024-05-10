using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardApplication
{
    public interface IBalance
    {
        double Balance{get; set;}
        void WalletRecharge(double amount);
        void DeductBalance(double amount);
    }
}