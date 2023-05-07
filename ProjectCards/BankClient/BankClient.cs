using ProjectCards.Interfaces;
using ProjectCards.PaymentMethods.PaymentCards;

namespace ProjectCards.BankClients;
internal class BankClient : IComparable<BankClient>
{
    protected string _firstName;
    public string FirstName 
    {
        get => _firstName;
        set
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            _firstName = value;
        }
    }
    protected string _lastName;
    public string LastName
    {
        get => _lastName;
        set
        {
            if (string.IsNullOrEmpty(value))
            { 
                throw new ArgumentNullException(nameof(value));
            }
            _lastName = value;
        }
    }
    public Address Address { get; set; }
    public List<IPayment> PaymentMethods { get; set; }

    public BankClient(string firstName, string lastName, Address address, List<IPayment> paymentMethods)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        PaymentMethods = paymentMethods;
    }


    public bool Pay(float sumProduct)
    {
        foreach (IPayment payment in PaymentMethods)
        {
            if (payment is IPay payMethod)
            {
                if (payMethod.PayProduct(sumProduct))
                {
                    return true;
                }
            }
        }
        return false;
    }


    //Sorting method by FirstName.
    public int CompareTo(BankClient? other)
    {
        return this.FirstName.CompareTo(other?.FirstName);
    }


    //This method counts the number of payment cards
    public int NumberOfCards()
    {
        int sumCards = 0;
        foreach (IPayment i in PaymentMethods)
        {
            if (i is CashBackCard || i is CreditCard || i is DebetCard)
            {
                sumCards++;
            }
        }
        return sumCards;
    }

    //The method calculates the total amount(the amount from all means of payment)
    public float AllMoneyBankClient()
    {
        float sumMoneyBankClient = 0;
        foreach (IPayment i in PaymentMethods)
        {
            if (i.AllMoney() > 0)
            {
                sumMoneyBankClient += i.AllMoney();
            }
        }
        return sumMoneyBankClient;
    }


    public float MaxMoneyBankClient()
    {
        float maxMoneyClientBank = 0;
        foreach (IPayment i in PaymentMethods)
        {
            if (i.AllMoney() > 0 && i.AllMoney() > maxMoneyClientBank)
            {
                maxMoneyClientBank = i.AllMoney();
            }
        }
        return maxMoneyClientBank;
    }

    public string InformationAboutPaymentMethods()
    {
        string info = "";
        foreach (IPayment i in PaymentMethods)
        {
            if (i is IGetFullInformation fullInfo)
            {
                info += fullInfo.GetFullInformation() + "\n";
            }
        }
        return info;
    }


    public string AllInformation()
    {
        return $"Last Name: {LastName};\nAddress: {Address};\n{InformationAboutPaymentMethods()}";
    }
}