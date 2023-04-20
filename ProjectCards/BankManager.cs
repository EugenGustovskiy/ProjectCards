using ProjectCards.BankClientComparers;
using ProjectCards.BankClients;
using ProjectCards.Comparers;
using ProjectCards.PaymentMethods.PaymentCards;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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


        public void InformationAboutBankClient(string sortingСriterion)
        {
            BankClients.Sort(GetComparer(sortingСriterion));
            foreach (BankClient i in BankClients)
            {
                string infoClients = i.AllInformation();
                Console.WriteLine(infoClients);
            }
        }


        private IComparer<BankClient> GetComparer(string sortingCriterion)
        {
            if (sortingCriterion == "City")
            {
                return new AddressCityComparers();
            }
            else if (sortingCriterion == "Last Name")
            {
                return new LastNameComparers();
            }
            else if (sortingCriterion == "Cards")
            {
                return new NumberOfCardsComparer();
            }
            else if (sortingCriterion == "All money")
            {
                return new AllMoneyBankClientComparers();
            }
            else if (sortingCriterion == "Max money")
            {
                return new MaxMoneyBankClientComparers();
            }
            else return null;
        }
    }
}