using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards
{
    internal interface IPayment
    {
        string GetFullInformation();
        bool MakePayment();
        bool TopUp();
        bool PayProduct(float sumProduct);
    }
}
