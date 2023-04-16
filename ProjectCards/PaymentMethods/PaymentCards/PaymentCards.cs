using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards.PaymentMethods.PaymentCards
{
    internal abstract class PaymentCards : IPayment
    {
        public string CardNumber { get; set; }
        public Validity Validity { get; set; }
        public int CCV { get; set; }
        public float AccountAmount { get; set; }

        public PaymentCards(string cardNumber, Validity validity, int ccv, float accountAmount)
        {
            CardNumber = cardNumber;
            Validity = validity;
            CCV = ccv;
            AccountAmount = accountAmount;
        }

        public abstract bool MakePayment();
        public abstract bool TopUp();
        public abstract bool PayProduct(float sumProduct);
        public abstract string GetFullInformation();

    }
}
