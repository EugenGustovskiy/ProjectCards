﻿using ProjectCards.BankClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards.BankClientComparers
{
    internal class MaxMoneyBankClientComparers : IComparer<BankClient>
    {
        public int Compare(BankClient x, BankClient y)
        {
            return y.MaxMoneyBankClient().CompareTo(x.MaxMoneyBankClient());
        }
    }
}
