using ProjectCards.BankClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards.BankClientComparers
{
    internal class NumberOfCardsComparer : IComparer<BankClient>
    {
        //Sorting is in descending order(largest to smallest).
        public int Compare(BankClient x, BankClient y)
        {
            return y.NumberOfCards().CompareTo(x.NumberOfCards());
        }
    }
}
