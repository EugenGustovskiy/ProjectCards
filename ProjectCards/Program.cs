using ProjectCards.BankClients;
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
            //First BankClient
            Validity validity1 = new(4, 26);
            Validity validity2 = new(11, 25);
            Validity validity3 = new(7, 29);

            DebetCard DebetCard1 = new("6478 2144 6842 1689", validity1, 374, 47.67f);
            CashBackCard CashBackCard1 = new("6752 3258 1298 3654", validity2, 657, 5.02f, 0.04f, 30.2f);
            CreditCard CreditCard1 = new("3674 2596 3295 1244", validity3, 736, 13.02f, 0.12f, 1245.73f, 2000f);
            Cash Cash1 = new(137.67f, 10.25f);
            BitCoin BitCoin1 = new("05SDdfs064asdd4", 0.01f, 242.36f);

            List<IPayment> methodsPerson1 = new List<IPayment>() { DebetCard1, CashBackCard1, CreditCard1, Cash1, BitCoin1 };

            Address address1 = new("BY", "Fanipol", "Shulgi", 8, 26);
            BankClient Person1 = new("Eugen", "Gustovskiy", address1, methodsPerson1);


            //Second BankClient
            Validity validity4 = new(1, 28);
            Validity validity5 = new(10, 24);

            DebetCard DebetCard2 = new("34751 3695 2145 3265", validity4, 671, 137.66f);
            Cash Cash2 = new(100.55f, 10.25f);

            List<IPayment> methodsPerson2 = new List<IPayment>() { DebetCard2, Cash2 };

            Address address2 = new("BY", "Minsk", "Odintsova", 11, 32);
            BankClient Person2 = new("Ivan", "Turchin", address2, methodsPerson2);


            //Third BankClient
            Validity validity6 = new(8, 25);
            Validity validity7 = new(4, 27);

            DebetCard DebetCard3 = new("6741 1123 7422 3654", validity6, 547, 574.01f);
            CreditCard CreditCard3 = new("9514 7536 8521 4347", validity7, 347, 24.75f, 0.15f, 851.63f, 1500f);
            Cash Cash3 = new(80.1f, 32.1f);
            BitCoin BitCoin3 = new("45sdBES674kcpe6", 1f, 47.69f);

            List<IPayment> methodsPerson3 = new List<IPayment>() { DebetCard3, CreditCard3, Cash3, BitCoin3 };

            Address address3 = new("BY", "Gomel", "Kozhara", 41, 39);
            BankClient Person3 = new("Ilya", "Zruzinov", address3, methodsPerson3);


            //BankClient collection
            List<BankClient> BankClients = new List<BankClient> { Person1, Person2, Person3 };

            BankManager manager = new BankManager(BankClients);
            manager.InformationAboutBankClient("City");  //Send "Last Name","City", "Cards", "All money" or "Max money"

            //float sumProduct1 = 20f;
            //float sumProduct2 = 1000f;
            //float sumProduct3 = 278f;

            //Person1.Pay(sumProduct1);
            //Person1.Pay(sumProduct2);
            //Person1.Pay(sumProduct3);

            //MakePayment(methods);
            //TopUp(methods);
            //GetFullInformation(methods);
        }
    }
}