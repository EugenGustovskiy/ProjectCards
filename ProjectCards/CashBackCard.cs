using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards
{
    internal class CashBackCard : IPayment
    {
        public string Number { get; set; }
        public Validity Validity { get; set; }
        public int CCV { get; set; }
        public float AccountAmount { get; set; }
        public byte ReturnPercentage { get; set; }

        public CashBackCard(string number, Validity validity, int ccv, float accountAmount, byte returnPercentage)
        {
            Number = number;
            Validity = validity;
            CCV = ccv;
            AccountAmount = accountAmount;
            ReturnPercentage = returnPercentage;
        }

        public string MakePayment()
        {
            Console.WriteLine("\nCashBackCard");
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
            Console.WriteLine("\nCashBackCard");
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
            return String.Format("CASHBACK CARD --- CARD NUMBER: {0}; VALIDITY: {1}; CCV: {2}; ACCOUNT AMOUNT: {3}; RETURN PERCENTAGE: {4}", Number, Validity, CCV, AccountAmount, ReturnPercentage);
        }
    }
}
