using ProjectCards.PaymentMethods.PaymentCards;
namespace ProjectCardsTests
{
    [TestClass]
    public class PaymentMetodCashBackCardTests
    {
        [TestMethod]
        public void CashBackCardToStringFormatMethodTest()
        {
            var validity = new Validity(1, 1);
            var cashBackCard = new CashBackCard(6752325812983654, validity, 657, 5.02f, 0.04f, 30.2f);

            var expectedResult = "All information about: CASHBACK CARD\nCARD NUMBER: 6752325812983654;\nVALIDITY: 1/1;\n" +
                                 "CVV: 657;\nACCOUNT AMOUNT: 5,02;\nRETURN  PERCENTAGE: 0,04;\nSUM CASNBACK: 30,2;";
            var actualResult = cashBackCard.ToString();
            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void CashBackCardEqualsTestPositive()
        {
            var validity = new Validity(1, 1);
            var cashBackCard1 = new CashBackCard(6752325812983654, validity, 657, 5.02f, 0.04f, 30.2f);
            var cashBackCard2= new CashBackCard(6752325812983654, validity, 657, 5.02f, 0.04f, 30.2f);

            Assert.AreEqual(cashBackCard1, cashBackCard2);
        }

        [TestMethod]
        public void CashBackCardEqualsTestCardNumberNegative()
        {
            var validity = new Validity(1, 1);
            var cashBackCard1 = new CashBackCard(6752325812983654, validity, 657, 5.02f, 0.04f, 30.2f);
            var cashBackCard2 = new CashBackCard(6752325812983653, validity, 657, 5.02f, 0.04f, 30.2f);

            Assert.AreNotEqual(cashBackCard1, cashBackCard2);
        }

        [TestMethod]
        public void CashBackCardEqualsTestValidityNegative()
        {
            var validity = new Validity(1, 1);
            var validity1 = new Validity(2, 1);
            var cashBackCard1 = new CashBackCard(6752325812983654, validity, 657, 5.02f, 0.04f, 30.2f);
            var cashBackCard2 = new CashBackCard(6752325812983654, validity1, 657, 5.02f, 0.04f, 30.2f);

            Assert.AreNotEqual(cashBackCard1, cashBackCard2);
        }

        [TestMethod]
        public void CashBackCardEqualsTestCVVNegative()
        {
            var validity = new Validity(1, 1);
            var cashBackCard1 = new CashBackCard(6752325812983654, validity, 657, 5.02f, 0.04f, 30.2f);
            var cashBackCard2 = new CashBackCard(6752325812983654, validity, 656, 5.02f, 0.04f, 30.2f);

            Assert.AreNotEqual(cashBackCard1, cashBackCard2);
        }

        [TestMethod]
        public void CashBackCardEqualsTestAccountAmountNegative()
        {
            var validity = new Validity(1, 1);
            var cashBackCard1 = new CashBackCard(6752325812983654, validity, 657, 5.02f, 0.04f, 30.2f);
            var cashBackCard2 = new CashBackCard(6752325812983654, validity, 657, 5.01f, 0.04f, 30.2f);

            Assert.AreNotEqual(cashBackCard1, cashBackCard2);
        }

        [TestMethod]
        public void CashBackCardEqualsTestReturnPercentageNegative()
        {
            var validity = new Validity(1, 1);
            var cashBackCard1 = new CashBackCard(6752325812983654, validity, 657, 5.02f, 0.04f, 30.2f);
            var cashBackCard2 = new CashBackCard(6752325812983654, validity, 657, 5.02f, 0.03f, 30.2f);

            Assert.AreNotEqual(cashBackCard1, cashBackCard2);
        }

        [TestMethod]
        public void CashBackCardEqualsTestSumCashBackNegative()
        {
            var validity = new Validity(1, 1);
            var cashBackCard1 = new CashBackCard(6752325812983654, validity, 657, 5.02f, 0.04f, 30.2f);
            var cashBackCard2 = new CashBackCard(6752325812983654, validity, 657, 5.02f, 0.04f, 30.1f);

            Assert.AreNotEqual(cashBackCard1, cashBackCard2);
        }

        [TestMethod]
        public void CashBackCardMakePaymentTest()
        {
            var validity = new Validity(1, 1);
            var cashBackCardCard = new CashBackCard(6752325812983654, validity, 657, 5.02f, 0.04f, 30.2f);
            var expectedResult = 5.02f;
            var actualResult = cashBackCardCard.MakePayment(10f);

            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void CashBackCardTopUpTest()
        {
            var validity = new Validity(1, 1);
            var cashBackCardCard = new CashBackCard(6752325812983654, validity, 657, 5.02f, 0.04f, 30.2f);
            var expectedResult = 15.02f;
            var actualResult = cashBackCardCard.TopUp(10f);

            Assert.IsTrue(expectedResult == actualResult);
        }
    }
}