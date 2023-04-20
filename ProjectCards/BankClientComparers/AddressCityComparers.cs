using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCards.BankClients;

namespace ProjectCards.Comparers
{
    internal class AddressCityComparers : IComparer<BankClient>
    {
        public int Compare(BankClient? x, BankClient? y)
        {
            return x.Address.City.CompareTo(y.Address.City);
        }
    }
}
