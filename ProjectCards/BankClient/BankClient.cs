using ProjectCards.Interfaces;
using ProjectCards.PaymentMethods.PaymentCards;
namespace ProjectCards.BankClients;
public class BankClient : IComparable<BankClient>
{
    protected string _firstName;
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.Length > 50)
            {
                throw new ArgumentException("First name cannot be longer than 50 characters.", nameof(value));
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
            if (value.Length > 50)
            {
                throw new ArgumentException("Last name cannot be longer than 50 characters.", nameof(value));
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


    public float Pay(float sumProduct)
    {
        foreach (IPayment payment in PaymentMethods)
        {
            if (payment is IPay payMethod)
            {
                return payMethod.PayProduct(sumProduct);
            }
        }
        return 0;
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
            info += i.ToString() + "\n";
        }
        return info;
    }


    public override string ToString()
    {
        return $"Last Name: {LastName};\nAddress: {Address};\n{InformationAboutPaymentMethods()}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is BankClient)
        {
            BankClient bankClient = obj as BankClient;
            return bankClient.FirstName == FirstName &&
                   bankClient.LastName == LastName &&
                   bankClient.Address == Address &&
                   bankClient.MaxMoneyBankClient() == MaxMoneyBankClient();
        }
        return false;
    }
}