using ProjectCards.PaymentMethods.PaymentCards;
namespace ProjectCardsTests
{
    [TestClass]
    public class PaymentMethodDebetCardTests
    {
        [TestMethod]
        public void DebetCardToStringFormatMethodTest()
        {
            var validity = new Validity(4, 26);
            var debetCard = new DebetCard(6478214468421689, validity, 374, 47.67f);

            var expectedResult = "All information about: DEBET CARD\nCARD NUMBER: 6478214468421689;\nVALIDITY: 4/26;\nCVV: 374;" +
                                 "\nACCOUNT AMOUNT: 47,67;";
            var actualResult = debetCard.ToString();
            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void DebetCardEqualsTestPositive()
        {
            var validity = new Validity(1, 23);
            var debetCard1 = new DebetCard(6478214468421689, validity, 374, 47.67f);
            var debetCard2 = new DebetCard(6478214468421689, validity, 374, 47.67f);

            Assert.AreEqual(debetCard1, debetCard2);
        }


        //How can I combine these tests???
        [TestMethod]
        public void DebetCardEqualsTestCardNumberNegative()
        {
            var validity = new Validity(1, 23);
            var debetCard1 = new DebetCard(6478214468421689, validity, 374, 47.67f);
            var debetCard2 = new DebetCard(6478214468421681, validity, 374, 47.67f);

            Assert.AreNotEqual(debetCard1, debetCard2);
        }

        [TestMethod]
        public void DebetCardEqualsTestValidityNegative()
        {
            var validity = new Validity(1, 23);
            var validity1 = new Validity(2, 23);
            var debetCard1 = new DebetCard(6478214468421689, validity, 374, 47.67f);
            var debetCard2 = new DebetCard(6478214468421681, validity1, 374, 47.67f);

            Assert.AreNotEqual(debetCard1, debetCard2);
        }

        [TestMethod]
        public void DebetCardEqualsTestCVVNegative()
        {
            var validity = new Validity(1, 23);
            var debetCard1 = new DebetCard(6478214468421689, validity, 374, 47.67f);
            var debetCard2 = new DebetCard(6478214468421681, validity, 375, 47.67f);

            Assert.AreNotEqual(debetCard1, debetCard2);
        }

        [TestMethod]
        public void DebetCardEqualsTestAccountAmountNegative()
        {
            var validity = new Validity(1, 23);
            var debetCard1 = new DebetCard(6478214468421689, validity, 374, 47.67f);
            var debetCard2 = new DebetCard(6478214468421681, validity, 375, 47.68f);

            Assert.AreNotEqual(debetCard1, debetCard2);
        }

        [TestMethod]
        public void DebetCardMakePaymentTest()
        {
            var validity = new Validity(1, 23);
            var debetCard = new DebetCard(6478214468421689, validity, 374, 47.67f);
            var expectedResult = 37.67f;
            var actualResult = debetCard.MakePayment(10f);

            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void DebetCardTopUpTest()
        {
            var validity = new Validity(1, 23);
            var debetCard1 = new DebetCard(6478214468421689, validity, 374, 47.67f);
            var expectedResult = 57.67f;
            var actualResult = debetCard1.TopUp(10f);

            Assert.IsTrue(expectedResult == actualResult);
        }
    }
}