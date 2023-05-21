using ProjectCards.BankClients;
using ProjectCards.PaymentMethods;
namespace ProjectCardsTests
{
    [TestClass]
    public class PaymentMethodCashTests
    {
        [TestMethod]
        public void CashToStringMethodFormatTest()
        {
            var cash = new Cash(1f);

            var expectedResult = "All information about: CASH\nCASH: 1;";
            var actualResult = cash.ToString();

            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void CashEqualsTestPositive()
        {
            var cash1 = new Cash(1f);
            var cash2 = new Cash(1f);

            Assert.AreEqual(cash1, cash2);
        }

        [TestMethod]
        public void CashEqualsTestNegative()
        {
            var cash1 = new Cash(1f);
            var cash2 = new Cash(2f);

            Assert.AreNotEqual(cash1, cash2);
        }

        [TestMethod]
        public void CashMakePaymentTest()
        {
            var cash = new Cash(100f);

            var expectedResult = 110f;
            var actualResult = cash.MakePayment(10f);

            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void CashTopUpTest()
        {
            var cash = new Cash(100f);

            var expectedResult = 90f;
            var actualResult = cash.TopUp(10f);

            Assert.IsTrue(expectedResult == actualResult);
        }
    }
}
