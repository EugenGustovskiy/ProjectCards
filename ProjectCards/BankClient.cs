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
        public List<Goods> Goods { get; set; }

        public BankClient(string firstName, string lastName, Address address, List<IPayment> paymentMethods, List<Goods> goods)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PaymentMethods = paymentMethods;
            Goods = goods;
        }

        /*public bool Pay()
        {

            if()
            {
                return true;
            }
            else
            {
                Console.WriteLine("Insufficient funds");
                return false;
            }
        }*/
    }
}
