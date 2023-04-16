using ProjectCards.PaymentMethods.PaymentCards;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards
{
    internal class BankClient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<IPayment> PaymentMethods { get; set; }

        public BankClient(string firstName, string lastName, Address address, List<IPayment> paymentMethods)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PaymentMethods = paymentMethods;
        }

        public bool Pay(float sumProduct)
        {
            foreach (IPayment i in PaymentMethods)
            {
                if (i.PayProduct(sumProduct) == true)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
