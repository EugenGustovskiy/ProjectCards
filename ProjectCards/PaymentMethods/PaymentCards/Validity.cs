using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards.PaymentMethods.PaymentCards
{
    internal class Validity
    {
        public byte Month { get; set; }
        public byte Year { get; set; }

        public Validity(byte month, byte year)
        {
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return Month + "/" + Year;
        }
    }
}