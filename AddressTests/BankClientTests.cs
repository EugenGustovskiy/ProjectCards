using ProjectCards.BankClients;
using ProjectCards.Interfaces;
using ProjectCards.PaymentMethods;
using ProjectCards.PaymentMethods.PaymentCards;
namespace ProjectCardsTests
{
    [TestClass]
    public class BankClientTests
    {
        [TestMethod]
        public void BanlClientToStringFormatMethodTest()
        {
            var validity = new Validity(1, 1);

            var DebetCard = new DebetCard(1111111111111111, validity, 111, 10f);
            var CashBackCard = new CashBackCard(2222222222222222, validity, 222, 2f, 0.2f, 20f);
            var CreditCard = new CreditCard(3333333333333333, validity, 333, 3f, 0.3f, 2000f, 3000f);
            var Cash = new Cash(444f);
            var BitCoin = new BitCoin("98asHTI652ljvf12", 1f);
            List<IPayment> methodsPerson = new List<IPayment>() { DebetCard, CashBackCard, CreditCard, Cash, BitCoin };

            var address = new Address("BY", "Minsk", "Nezavisimosti", 1, 1);
            var person = new BankClient("Eugen", "Gustovskiy", address, methodsPerson);


            var expectedResult = "Last Name: Gustovskiy;\nAddress: State: BY, City: Minsk, Street: Nezavisimosti, HouseNumber: 1, FlatNumber: 1;\n" +
                                 "All information about: DEBET CARD\nCARD NUMBER: 1111111111111111;\nVALIDITY: 1/1;\nCVV: 111;\nACCOUNT AMOUNT: 10;\n" +
                                 "All information about: CASHBACK CARD\nCARD NUMBER: 2222222222222222;\nVALIDITY: 1/1;\nCVV: 222;\nACCOUNT AMOUNT: 2;\nRETURN  PERCENTAGE: 0,2;\nSUM CASNBACK: 20;\n" +
                                 "All information about: CREDIT CARD\nCARD NUMBER: 3333333333333333;\nVALIDITY: 1/1;\nCVV: 333;\nACCOUNT AMOUNT: 3;\nCREDIT PERCENTAGE: 0,3;\nCREDIT MONEY: 2000;\nCREDIT LIMIT: 3000;\n" +
                                 "All information about: CASH\nCASH: 444;\n" +
                                 "All information about: BITCOIN\nBITCOIN: 1;\n";
            var actualResult = person.ToString();
            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void BankClientPay()
        {
            var validity = new Validity(1, 1);

            var DebetCard = new DebetCard(1111111111111111, validity, 111, 10f);
            var CashBackCard = new CashBackCard(2222222222222222, validity, 222, 2f, 0.2f, 20f);
            var CreditCard = new CreditCard(3333333333333333, validity, 333, 3f, 0.3f, 2000f, 3000f);
            var Cash = new Cash(444f);
            var BitCoin = new BitCoin("98asHTI652ljvf12", 1f);
            List<IPayment> methodsPerson = new List<IPayment>() { DebetCard, CashBackCard, CreditCard, Cash, BitCoin };

            var address = new Address("BY", "Minsk", "Nezavisimosti", 1, 1);
            var person = new BankClient("Eugen", "Gustovskiy", address, methodsPerson);

            var expectedResult = new[] { 9f, 1f, 2f, 443f, 1f };
            var actualResult = person.Pay(1);
            Assert.IsTrue(expectedResult.Contains(actualResult));
        }
    }
}