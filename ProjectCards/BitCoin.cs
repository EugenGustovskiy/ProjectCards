using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ProjectCards
{

    internal class BitCoin : IPayment
    {
        public string WalletNumber { get; set; }
        public float AccountAmount { get; set; }

        public BitCoin(string walletNumber, float accountAmount)
        {
            WalletNumber = walletNumber;
            AccountAmount = accountAmount;
        }

        public string MakePayment()
        {
            return $"\nBITCOIN --- Unable to process transaction!\n";
        }

        public string TopUp()
        {
            return $"\nBITCOIN --- Unable to process transaction!\n";
        }

        public string GetFullInformation()
        {
            return String.Format("BITCOIN --- ACCOUNT AMOUNT: {0}", AccountAmount);
        }
    }
}
