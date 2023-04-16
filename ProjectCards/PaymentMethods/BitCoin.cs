using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ProjectCards.PaymentMethods
{

    internal class BitCoin : IPayment
    {
        public string WalletNumber { get; set; }
        public float AccountAmount { get; set; }
        public float Cash { get; set; } //The money we have on hand.


        public BitCoin(string walletNumber, float accountAmount, float cash)
        {
            WalletNumber = walletNumber;
            AccountAmount = accountAmount;
            Cash = cash;
        }

        //Method to convert Bitcoin to BYN.
        public void ConvertBTCToBYN()
        {
            AccountAmount *= 77735.16f;
            //Next, we call a method that rounds the result to two decimal places, and the updated value is saved.
            AccountAmount = (float)Math.Round(AccountAmount, 2); 
        }

        //Method to conver BYN to Bitcoin.
        public void ConvertBYNToBTC()
        { 
            AccountAmount /= 77735.16f;
            AccountAmount = (float)Math.Round(AccountAmount, 2);
        }


        public bool MakePayment()
        {
            Console.WriteLine($"This is a Bitcoin. You have {AccountAmount} BTC.\nDo you want to withdraw money " +
                              $"to your account? (Y/N)");
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

        public void InputWithdrawal()
        {
            ConvertBTCToBYN();
            Console.WriteLine($"There was an automatic conversion of BTC to BYN. The account balance is {AccountAmount} BYN." +
                              $"\nEnter amount to withdraw:");
            string inputSum = Console.ReadLine();
            float sum;
            if (float.TryParse(inputSum, out sum))
            {
                if (sum <= AccountAmount)
                {
                    AccountAmount -= sum;
                    ConvertBYNToBTC();
                    Console.WriteLine($"Operation was successfully completed.\nThe account balance is {AccountAmount} BTC." +
                                      $"\nThe withdrawal amount is {sum}.");
                }
                else
                {
                    ConvertBYNToBTC();
                    Console.WriteLine("Insufficient funds to withdraw. The transaction was completed by the bank.");
                }
            }
            else
            {
                ConvertBYNToBTC();
                Console.WriteLine("Input Error. The transaction was completed by the bank.");
            }
        }


        public bool TopUp()
        {
            Console.WriteLine($"This is a Bitcoin. You have {AccountAmount} BTC.\nDo you want to deposit money? (Y/N)");
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
            ConvertBTCToBYN();
            Console.WriteLine($"There was an automatic conversion of BTC to BYN. The account balance is {AccountAmount} BYN." +
                              $"\nEnter the amount to replenish:");
            string inputSum = Console.ReadLine();
            float sum;
            if (float.TryParse(inputSum, out sum))
            {
                if (sum > 0)
                {
                    AccountAmount += sum;
                    ConvertBYNToBTC();
                    Console.WriteLine($"Operation was successfully completed.\nThe account balance is {AccountAmount} BTC." +
                                      $"\nThe replenishment amount is {sum}.");
                }
            }
            else
            {
                ConvertBYNToBTC();
                Console.WriteLine("Input Error. The transaction was completed by the bank.");
            }
        }


        public bool PayProduct(float sumProduct)
        {
            ConvertBTCToBYN();
            Console.WriteLine($"The purchase amount is {sumProduct}. Would you like to purchase?");
            string inputY_N = Console.ReadLine();
            if (inputY_N == "y" || inputY_N == "Y")
            {
                if (sumProduct <= AccountAmount)
                {
                    AccountAmount -= sumProduct;
                    ConvertBYNToBTC();
                    Console.WriteLine("Operation was successfully completed.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                    ConvertBYNToBTC();
                    return false;
                }
            }
            else if (inputY_N == "N" || inputY_N == "n")
            {
                Console.WriteLine("The operation was completed by the user.");
                ConvertBYNToBTC();
                return false;
            }
            else
            {
                Console.WriteLine("Input Error.");
                ConvertBYNToBTC();
                return false;
            }
        }


        public string GetFullInformation()
        {
            return string.Format("All information about: BITCOIN\nBITCOIN: {0};", AccountAmount);
        }
    }
}
