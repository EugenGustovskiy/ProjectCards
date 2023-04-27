using ProjectCards.BankClients;
using ProjectCards.PaymentMethods;
using ProjectCards.PaymentMethods.PaymentCards;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards
{
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
                string infoClients = i.AllInformation();
                Console.WriteLine(infoClients);
            }
        }


        private Func<BankClient, object> GetComparer(string sortingCriterion)
        {
            if (sortingCriterion == "City")
            {
               return x => x.Address.City; //Sort by address (city).
            }
            else if (sortingCriterion == "Last Name")
            {
                return x => x.LastName; //Sort by name.
            }
            else if (sortingCriterion == "Cards")
            {
                return x => x.NumberOfCards(); //Sorting by the number of plastic cards.
            }
            else if (sortingCriterion == "All money")
            {
                return x => x.AllMoneyBankClient(); //Sort by total amount of money available.
            }
            else if (sortingCriterion == "Max money")
            {
                return x => x.MaxMoneyBankClient(); //By the maximum amount of money on one payment instrument.
            }
            else return null;
        }


        //Two methods to list all debit cards for a BankClient
        public void AllDebetCard()
        {
            var allDebetCard = BankClients.SelectMany(x => x.PaymentMethods.OfType<DebetCard>()).Select(x => x.GetFullInformation());
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
                    Console.WriteLine($"Client: {i.LastName}\n{card.GetFullInformation()}\n");
                }
            }
        }


        public void AllMoneyBankClient()
        {
            var clientFunds = BankClients.Select(x => new
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
}