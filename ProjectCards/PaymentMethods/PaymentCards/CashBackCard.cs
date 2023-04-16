using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards.PaymentMethods.PaymentCards
{
    internal class CashBackCard : PaymentCards
    {
        public float ReturnPercentage { get; set; }
        public float SumCashBack { get; set; }

        public CashBackCard(string cardNumber, Validity validity, int ccv, float accountAmount, float returnPercentage,
                            float sumCashBack) : base(cardNumber, validity, ccv, accountAmount)
        {
            ReturnPercentage = returnPercentage;
            SumCashBack = sumCashBack;
        }

        //The two methods below deal with withdrawing money from the account.
        //MakePayment() - offers a choice (to withdraw money or not). It also implements the InputWithdrawal() method.
        public override bool MakePayment()
        {
            Console.WriteLine("This is a Cashback Card.\nDo you want to withdraw money from it? (Y/N)");
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

        //This method checks a number of conditions for withdrawing money from a card of this class.
        public void InputWithdrawal()
        {
            Console.WriteLine($"The account balance is {AccountAmount}. The cashback amount is {SumCashBack}." +
                              $"\nThe total amount is {AccountAmount + SumCashBack}.\nEnter amount to withdraw:");
            string inputSum = Console.ReadLine();
            float sum;
            if (float.TryParse(inputSum, out sum))
            {
                if (sum <= SumCashBack)
                {
                    SumCashBack -= sum;
                    Console.WriteLine($"Operation was successfully completed.\nThe account balance is {AccountAmount}. " +
                                      $"The cashback amount is {SumCashBack}.\nThe total amount is " +
                                      $"{AccountAmount + SumCashBack}.\nThe withdrawal amount is {sum}.");
                }
                else if (sum <= AccountAmount)
                {
                    AccountAmount -= sum;
                    Console.WriteLine($"Operation was successfully completed.\nThe account balance is {AccountAmount}." +
                                      $"The cashback amount is {SumCashBack}.\nThe total amount is " +
                                      $"{AccountAmount + SumCashBack}.\nThe withdrawal amount is {sum}.");
                }
                else if (sum <= AccountAmount + SumCashBack)
                {
                    AccountAmount += SumCashBack;
                    SumCashBack = 0;
                    AccountAmount -= sum;
                    Console.WriteLine($"Operation was successfully completed.\nThe account balance is {AccountAmount}." +
                                      $"The cashback amount is {SumCashBack}.\nThe total amount is " +
                                      $"{AccountAmount + SumCashBack}.\nThe withdrawal amount is {sum}.");
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


        //The two methods at the bottom relate to account replenishment.
        //TopUp() - offers a choice (to replenish the account or not). It also implements the InputReplenishment() method.
        //InputReplenishment() - takes the replenishment amount and changes the amount we have before the method executes
        public override bool TopUp()
        {
            Console.WriteLine("This is a Cashback Card.\nDo you want to deposit money? (Y/N)");
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
            Console.WriteLine($"The account balance is {AccountAmount}.\nEnter the amount to replenish:");
            string inputSum = Console.ReadLine();
            float sum;
            if (float.TryParse(inputSum, out sum))
            {
                if (sum > 0)
                {
                    AccountAmount += sum;
                    Console.WriteLine($"Operation was successfully completed.\nThe account balance is {AccountAmount}." +
                                      $"\nThe replenishment amount is {sum}.");
                }
            }
            else
            {
                Console.WriteLine("Input Error. The transaction was completed by the bank.");
            }
        }


        //Implementation method for purchasing a product.
        public override bool PayProduct(float sumProduct)
        {
            Console.WriteLine($"The purchase amount is {sumProduct}. Would you like to purchase?");
            string inputY_N = Console.ReadLine();
            if (inputY_N == "y" || inputY_N == "Y")
            {
                if (sumProduct <= SumCashBack)
                {
                    SumCashBack -= sumProduct;
                    Console.WriteLine("Operation was successfully completed.");
                    return true;
                }
                else if (sumProduct <= AccountAmount)
                {
                    AccountAmount -= sumProduct;
                    Console.WriteLine("Operation was successfully completed.");
                    return true;
                }
                else if (sumProduct <= AccountAmount + SumCashBack)
                {
                    AccountAmount += SumCashBack;
                    SumCashBack = 0;
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


        //This method prints all information on cards to the console.
        public override string GetFullInformation()
        {
            return string.Format("All information about: CASHBACK CARD\nCARD NUMBER: {0};\nVALIDITY: {1};\nCCV: {2};" +
                                 "\nACCOUNT AMOUNT: {3};\nRETURN  PERCENTAGE: {4};\nSUM CASNBACK: {5};",
                                 CardNumber, Validity, CCV, AccountAmount, ReturnPercentage, SumCashBack);
        }
    }
}
