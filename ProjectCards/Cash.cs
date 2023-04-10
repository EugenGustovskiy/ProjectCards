using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards
{
    internal class Cash : IPayment
    {
        public float AccountAmount { get; set; }

        public Cash(float accountAmount)
        {
            AccountAmount = accountAmount;
        }

        public string MakePayment()
        {
            return $"\nCASH --- Unable to process transaction!\n";
        }

        public string TopUp()
        {
            return $"\nCASH --- Unable to process transaction!\n";
        }

        public string GetFullInformation()
        {
            return String.Format("CASH --- ACCOUNT AMOUNT: {0}", AccountAmount);
        }
    }
}
