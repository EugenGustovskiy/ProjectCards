using ProjectCards.PaymentMethods;
using ProjectCards.PaymentMethods.PaymentCards;
using System.Collections.Generic;

namespace ProjectCards
{
    internal class Program
    {
        static bool MakePayment(List<IPayment> methods)
        {
            foreach (IPayment i in methods)
            {
                bool message = i.MakePayment();
                Console.WriteLine(message);
            }
            return true;
        }

        static bool TopUp(List<IPayment> methods)
        {
            foreach (IPayment i in methods)
            {
                bool message = i.TopUp();
                Console.WriteLine(message);
            }
            return true;
        }

        static bool GetFullInformation(List<IPayment> methods)
        {
            foreach (IPayment i in methods)
            {
                string message = i.GetFullInformation();
                Console.WriteLine(message);
            }
            return true;
        }


        static void Main(string[] args)
        { 
            Validity validity1 = new(4, 26);
            Validity validity2 = new(11, 25);
            Validity validity3 = new(7, 12);

            DebetCard method1 = new("6478 2144 6842 1689", validity1, 374, 47.67f);
            CashBackCard method2 = new("6752 3258 1298 3654", validity2, 657, 5.02f, 0.04f, 30.2f);
            CreditCard method3 = new("3674 2596 3295 1244", validity3, 736, 13.02f, 0.12f, 1245.73f, 2000f);
            Cash method4 = new(137.67f, 10.25f);
            BitCoin method5 = new("05SDdfs064asdd4", 0.01f, 242.36f);

            List<IPayment> methods = new List<IPayment>() { method4, method2, method1, method3, method5 };

           
            Address address1 = new("BY", "Fanipol", "Shulgi", 8, 26);

            BankClient Person1 = new("Eugen", "Gustovskiy", address1, methods);


            float sumProduct1 = 20f;
            float sumProduct2 = 1000f;
            float sumProduct3 = 278f;
            
            Person1.Pay(sumProduct1);
            Person1.Pay(sumProduct2);
            Person1.Pay(sumProduct3);

            MakePayment(methods);
            TopUp(methods);
            GetFullInformation(methods);
        }
    }
}