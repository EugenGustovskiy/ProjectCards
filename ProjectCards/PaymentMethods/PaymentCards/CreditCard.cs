using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards.PaymentMethods.PaymentCards
{
    internal class CreditCard : PaymentCards
    {
        public float CreditPercentage { get; set; }
        public float CreditMoney { get; set; }
        public float CreditLimit { get; set; }


        public CreditCard(string number, Validity validity, int ccv, float accountAmount, float creditPercentage,
                          float creditMoney, float creditLimit) : base(number, validity, ccv, accountAmount)
        {
            CreditPercentage = creditPercentage;
            CreditMoney = creditMoney;
            CreditLimit = creditLimit;
        }


        public override bool MakePayment()
        {
            Console.WriteLine("This is a Credit card.\nDo you want to withdraw money from it? (Y/N)");
            string inputY_N = Console.ReadLine();
            if (inputY_N == "y" || inputY_N == "Y")
            {
                InputWithdrawal();
                return true;
            }
            else if (inputY_N == "N" || inputY_N == "n")
            {
                Console.WriteLine("The operation was completed by the user.");
                return false;
            }
            else
            {
                Console.WriteLine("Input Error. The transaction was completed by the bank.");
                return false;
            }
        }

        //Conditions for withdrawing money from a credit card, taking into account the percentage of the loan.
        public void InputWithdrawal()
        {
            Console.WriteLine($"The account balance is {AccountAmount}. The credit money is {CreditMoney}." +
                              $"\nThe total amount is {AccountAmount + CreditMoney}." +
                              $"\nThe credit limit is {CreditLimit}.\nEnter amount to withdraw:");
            string inputSum = Console.ReadLine();
            float sum;
            if (float.TryParse(inputSum, out sum))
            {
                if (sum <= AccountAmount)
                {
                    AccountAmount -= sum;
                    Console.WriteLine($"Operation was successfully completed.\nThe account balance is {AccountAmount}. " +
                                      $"The credit money is {CreditMoney}." +
                                      $"\nThe total amount is {AccountAmount + CreditMoney}." +
                                      $"\nThe credit limit is {CreditLimit}.\nThe withdrawal amount is {sum}.");
                }
                else if (sum * CreditPercentage + sum <= CreditMoney)
                {
                    CreditMoney -= sum * CreditPercentage + sum;
                    Console.WriteLine($"Operation was successfully completed.\nThe account balance is {AccountAmount}. " +
                                      $"The credit money is {CreditMoney}." +
                                      $"\nThe total amount is {AccountAmount + CreditMoney}." +
                                      $"\nThe credit limit is {CreditLimit}.\nThe withdrawal amount is {sum}.");
                }
                else if ((sum - AccountAmount) * CreditPercentage + sum <= AccountAmount + CreditMoney)
                {
                    CreditMoney -= (sum - AccountAmount) * CreditPercentage + sum - AccountAmount;
                    AccountAmount = 0;
                    Console.WriteLine($"Operation was successfully completed.\nThe account balance is {AccountAmount}. " +
                                      $"The credit money is {CreditMoney}." +
                                      $"\nThe total amount is {AccountAmount + CreditMoney}." +
                                      $"\nThe credit limit is {CreditLimit}.\nThe withdrawal amount is {sum}.");
                }
                else
                {
                    Console.WriteLine("Insufficient funds to withdraw. The transaction was completed by the bank.");
                }
            }
            else
            {
                Console.WriteLine("Input Error. The transaction was completed by the bank.");
            }
        }


        public override bool TopUp()
        {
            Console.WriteLine("This is a Credit Card.\nDo you want to deposit money? (Y/N)");
            string inputY_N = Console.ReadLine();
            if (inputY_N == "y" || inputY_N == "Y")
            {
                InputReplenishment();
                return true;
            }
            else if (inputY_N == "N" || inputY_N == "n")
            {
                Console.WriteLine("The operation was completed by the user.");
                return false;
            }
            else
            {
                Console.WriteLine("Input Error. The transaction was completed by the bank.");
                return false;
            }
        }

        //Conditions for replenishing the card, taking into account the credit limit.
        public void InputReplenishment()
        {
            Console.WriteLine($"The account balance is {AccountAmount}. The credit money is {CreditMoney}." +
                              $"\nThe credit limit is {CreditLimit}.\nEnter the amount to replenish:");
            string inputSum = Console.ReadLine();
            float sum;
            if (float.TryParse(inputSum, out sum))
            {
                if (sum > 0)
                {
                    float difference = CreditLimit - CreditMoney;
                    CreditMoney += difference;
                    AccountAmount = sum - difference + AccountAmount;
                    Console.WriteLine($"Operation was successfully completed.\nThe account balance is {AccountAmount}. " +
                        $"The credit money is {CreditMoney}.\nThe credit limit is {CreditLimit}.");
                }
            }
            else
            {
                Console.WriteLine("Input Error. The transaction was completed by the bank.");
            }
        }


        public override bool PayProduct(float sumProduct)
        {
            Console.WriteLine($"The purchase amount is {sumProduct}. Would you like to purchase?");
            string inputY_N = Console.ReadLine();
            if (inputY_N == "y" || inputY_N == "Y")
            {
                if (sumProduct <= AccountAmount)
                {
                    AccountAmount -= sumProduct;
                    Console.WriteLine("Operation was successfully completed.");
                    return true;
                }
                else if (sumProduct <= CreditMoney)
                {
                    CreditMoney -= sumProduct;
                    Console.WriteLine("Operation was successfully completed.");
                    return true;
                }
                else if ((sumProduct - AccountAmount) * CreditPercentage + sumProduct <= AccountAmount + CreditMoney)
                {
                    CreditMoney -= (sumProduct - AccountAmount) * CreditPercentage + sumProduct - AccountAmount;
                    AccountAmount = 0;
                    Console.WriteLine("Operation was successfully completed.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                    return false;
                }
            }
            else if (inputY_N == "N" || inputY_N == "n")
            {
                Console.WriteLine("The operation was completed by the user.");
                return false;
            }
            else
            {
                Console.WriteLine("Input Error.");
                return false;
            }
        }


        //The method calculates the amount of all available money
        public override float AllMoney()
        {
            float allMoney = 0;
            allMoney += AccountAmount + CreditMoney;
            return allMoney;
        }


        //This method prints all information on cards to the console.
        public override string GetFullInformation()
        {
            return string.Format("All information about: CREDIT CARD\nCARD NUMBER: {0};\nVALIDITY: {1};\nCCV: {2};" +
                                 "\nACCOUNT AMOUNT: {3};\nCREDIT PERCENTAGE: {4};\nCREDIT MONEY: {5};\nCREDIT LIMIT: {6};",
                                 CardNumber, Validity, CCV, AccountAmount, CreditPercentage, CreditMoney, CreditLimit);
        }
    }
}