using ProjectCards.BankClients;
using ProjectCards.Interfaces;
using ProjectCards.PaymentMethods;
using ProjectCards.PaymentMethods.PaymentCards;

namespace ProjectCards;
internal class Program
{
    static bool MakePayment(List<IPayment> methods, float sum)
    {
        foreach (IPayment i in methods)
        {
            bool message = i.MakePayment(sum);
            Console.WriteLine(message);
        }
        return true;
    }

    static bool TopUp(List<IPayment> methods, float sum)
    {
        foreach (IPayment i in methods)
        {
            bool message = i.TopUp(sum);
            Console.WriteLine(message);
        }
        return true;
    }

    static bool GetFullInformation(List<IPayment> methods)
    {
        foreach (IPayment i in methods)
        {
            if (i is IGetFullInformation fullInfo)
            {
                string message = fullInfo.GetFullInformation();
                Console.WriteLine(message);
            }
        }
        return true;
    }


    static void Main(string[] args)
    {
        //First BankClient
        var validity1 = new Validity(4, 26);
        var validity2 = new Validity(11, 25);
        var validity3 = new Validity(7, 29);
        var validity4 = new Validity(8, 24);

        var DebetCard1 = new DebetCard(6478214468421689, validity1, 374, 47.67f);
        var DebetCard2 = new DebetCard(5147365121459854, validity2, 647, 123.85f);
        var CashBackCard1 = new CashBackCard(6752325812983654, validity3, 657, 5.02f, 0.04f, 30.2f);
        var CreditCard1 = new CreditCard(3674259632951244, validity4, 736, 13.02f, 0.12f, 1245.73f, 2000f);
        var Cash1 = new Cash(137.67f);
        var BitCoin1 = new BitCoin("98asHTI652ljvf1", 0.01f);

        List<IPayment> methodsPerson1 = new List<IPayment>() { DebetCard1, DebetCard2, CashBackCard1, CreditCard1, Cash1, BitCoin1 };

        var address1 = new Address("BY", "Fanipol", "Shulgi", 0, 26);
        var Person1 = new BankClient("Eugen", "Gustovskiy", address1, methodsPerson1);


        //Second BankClient
        var validity5 = new Validity(1, 28);
        var validity6 = new Validity(10, 24);

        var DebetCard3 = new DebetCard(34751369521453265, validity5, 671, 137.66f);
        var CashBackCard2 = new CashBackCard(6514214536987532, validity6, 965, 12.14f, 0.03f, 29.12f);
        var Cash2 = new Cash(100.55f);

        List<IPayment> methodsPerson2 = new List<IPayment>() { DebetCard3, CashBackCard2, Cash2 };

        var address2 = new Address("BY", "Minsk", "Odintsova", 11, 32);
        var Person2 = new BankClient("Ivan", "Turchin", address2, methodsPerson2);


        //Third BankClient
        var validity7 = new Validity(8, 25);
        var validity8 = new Validity(4, 27);

        var DebetCard4 = new DebetCard(6741112374223654, validity7, 547, 574.01f);
        var CreditCard3 = new CreditCard(9514753685214347, validity8, 347, 24.75f, 0.15f, 851.63f, 1500f);
        var Cash3 = new Cash(80.1f);
        var BitCoin3 = new BitCoin("45sdBES674kcpe6", 1f);

        List<IPayment> methodsPerson3 = new List<IPayment>() { DebetCard4, CreditCard3, Cash3, BitCoin3 };

        var address3 = new Address("BY", "Gomel", "Kozhara", 41, 39);
        var Person3 = new BankClient("Ilya", "Zruzinov", address3, methodsPerson3);


        //BankClient collection
        List<BankClient> BankClients = new List<BankClient> { Person1, Person2, Person3 };
        
        
        var manager = new BankManager(BankClients);


        //The default sort is ascending (OrderBy).
        //Write "true" as the second argument to use descending sort (OrderByDescending).
        manager.InformationAboutBankClient("Last Name");  //Send "Last Name", "City", "Cards", "All money" or "Max money"


        //This method lists all debit cards for the customer.
        manager.NewAllDebetCard();

        //This method displays the sum of all available funds for the client.
        manager.AllMoneyBankClient();

        //This method outputs to the console the clients who have BTC,
        //sorted in descending order by the aggregate of all available funds.
        manager.OnlyBTC();


        //float sumProduct1 = 20f;
        //float sumProduct2 = 1000f;
        //float sumProduct3 = 278f;

        //Person1.Pay(sumProduct1);
        //Person1.Pay(sumProduct2);
        //Person1.Pay(sumProduct3);

        //MakePayment(methodsPerson1, 50f);
        //TopUp(methodsPerson2, 100f);
        //GetFullInformation(methodsPerson3);
    }
}