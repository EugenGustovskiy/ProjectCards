using ProjectCards.BankClients;
using ProjectCards.PaymentMethods;
using ProjectCards.PaymentMethods.PaymentCards;
namespace ProjectCards;
internal class BankManager
{
    public List<BankClient> BankClients { get; set; }

    public BankManager(List<BankClient> bankClients)
    {
        BankClients = bankClients;
    }


    public void InformationAboutBankClient(string sortingСriterion, bool descendingOrder = false)
    {
        var sortedClients = new List<BankClient>();
        if (descendingOrder)
        {
            sortedClients = BankClients.OrderByDescending(GetComparer(sortingСriterion)).ToList();
        }
        else
        {
            sortedClients = BankClients.OrderBy(GetComparer(sortingСriterion)).ToList();
        }

        foreach (BankClient i in sortedClients)
        {
            string infoClients = i.ToString();
            Console.WriteLine(infoClients);
        }
    }


    private Func<BankClient, object> GetComparer(string sortingCriterion)
    {
        Func<BankClient, object> result = sortingCriterion switch
        {
            "City" => x => x.Address.City,
            "Last Name" => x => x.LastName,
            "Cards" => x => x.NumberOfCards(),
            "All money" => x => x.AllMoneyBankClient(),
            "Max money" => x => x.MaxMoneyBankClient(),
            _ => null
        };
        return result;
    }


    //Two methods to list all debit cards for a BankClient
    public void AllDebetCard()
    {
        var allDebetCard = BankClients.SelectMany(x => x.PaymentMethods.OfType<DebetCard>()).Select(x => x.ToString());
        foreach (var i in allDebetCard)
        {
            Console.WriteLine(i);
        }
    }


    public void NewAllDebetCard()
    {
        foreach (var i in BankClients)
        {
            foreach (var card in i.PaymentMethods.OfType<DebetCard>())
            {
                Console.WriteLine($"Client: {i.LastName}\n{card.ToString()}\n");
            }
        }
    }


    public void AllMoneyBankClient()
    {
        var clientFunds = BankClients.Select(x => 
            new
            {
                BankClientName = x.LastName,
                TotalFunds = x.PaymentMethods.Sum(payment => payment.AllMoney())
            });
        foreach (var i in clientFunds)
        {
            Console.WriteLine($"Total available funds for {i.BankClientName}: {i.TotalFunds}");
        }
    }


    public void OnlyBTC()
    {
        var clientsWithBitcoin = BankClients.Where(x => x.PaymentMethods.OfType<BitCoin>().Any()).
                                 OrderByDescending(x => x.PaymentMethods.Sum(x => x.AllMoney()));

        foreach (var i in clientsWithBitcoin)
        {
            Console.WriteLine($"Name: {i.LastName}, Total available funds: {i.PaymentMethods.Sum(p => p.AllMoney())}");
        }
    }
}