using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards.PaymentMethods
{
    internal class Cash : IPayment
    {
        public float AccountAmount { get; set; } //The money we have on hand.
        public float CashAccount { get; set; } //The account to which we will replenish with AccountAmount.

        public Cash(float accountAmount, float cashAccount)
        {
            AccountAmount = accountAmount;
            CashAccount = cashAccount;
        }

        public bool MakePayment()
        {
            Console.WriteLine("Do you want to withdraw money to your account? (Y/N)");
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

        //This method withdraws money from an existing account and adds it to the available cash.
        public void InputWithdrawal()
        {
            Console.WriteLine($"There are {CashAccount} rubles on your account. You have {AccountAmount} rubles in cash." +
                              $"\nEnter amount to withdraw:");
            string inputSum = Console.ReadLine();
            float sum;
            if (float.TryParse(inputSum, out sum))
            {
                if (sum <= CashAccount)
                {
                    CashAccount -= sum;
                    AccountAmount += sum;
                    Console.WriteLine($"Operation was successfully completed.\nThere are {CashAccount} rubles on your " +
                        $"account. You have {AccountAmount} rubles in cash.\nThe withdrawal amount is {sum}.");
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

        public bool TopUp()
        {
            Console.WriteLine("Do you want to deposit money? (Y/N)");
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

        public void InputReplenishment()
        {
            Console.WriteLine($"You have {AccountAmount} rubles in cash. There are {CashAccount} rubles on your account." +
                              $"\nEnter the amount to replenish:");
            string inputSum = Console.ReadLine();
            float sum;
            if (float.TryParse(inputSum, out sum))
            {
                if (sum > 0 & sum <= AccountAmount)
                {
                    CashAccount += sum;
                    AccountAmount -= sum;
                    Console.WriteLine($"Operation was successfully completed.\nYou have {AccountAmount} rubles in cash. " +
                                      $"There are {CashAccount} rubles on your account.\nThe withdrawal amount is {sum}.");
                }
            }
            else
            {
                Console.WriteLine("Input Error. The transaction was completed by the bank.");
            }
        }


        public bool PayProduct(float sumProduct)
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


        public float AllMoney()
        {
            float allMoney = 0;
            allMoney += AccountAmount;
            return allMoney;
        }


        public string GetFullInformation()
        {
            return string.Format("All information about: CASH\nCASH: {0};\nMONEY ON THE CARD: {1};", AccountAmount, CashAccount);
        }
    }
}