using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards
{
    internal class DebetCard : IPayment
    {
        public string Number { get; set; }
        public Validity Validity { get; set; }
        public int CCV { get; set; }
        public float AccountAmount { get; set; }

        public DebetCard (string number, Validity validity, int ccv, float accountAmount)
        {
            Number = number;
            Validity = validity;
            CCV = ccv;
            AccountAmount = accountAmount;
        }

        public string MakePayment()
        {
            Console.WriteLine("\nDebetCard");
            Console.WriteLine($"Account amount: {AccountAmount}.\nEnter amount to withdraw (Entering a decimal number with ','!): ");
            string input = Console.ReadLine();
            float sum;
            if (float.TryParse(input, out sum))
            {
                if (sum <= AccountAmount)
                {
                    AccountAmount -= sum;
                    return $"Account balance after withdrawal: {AccountAmount}. Withdrawal amount: {sum}\n";
                }
                else
                {
                    return $"Insufficient funds";
                }
            }
            else
            {
                return $"Invalid input.";
            }
        }

        public string TopUp()
        {
            Console.WriteLine("\nDebetCard");
            Console.WriteLine($"Account amount: {AccountAmount}.\nEnter the amount you want to put on the card (Entering a decimal number with ','!): ");
            string input = Console.ReadLine();
            float sum;
            if (float.TryParse(input, out sum))
            {
                if (sum > 0)
                {
                    AccountAmount += sum;
                }
                return $"Account balance after top-up: {AccountAmount}. Top-up amount: {sum}";
            }
            else
            {
                return $"Invalid input.";
            }
        }

        public string GetFullInformation()
        {
            return String.Format("DEBET CARD --- CARD NUMBER: {0}; VALIDITY: {1}; CCV: {2}; ACCOUNT AMOUNT: {3}", Number, Validity, CCV, AccountAmount);
        }
    }
}
