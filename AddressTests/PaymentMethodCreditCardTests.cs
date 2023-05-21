using Microsoft.VisualBasic;
using ProjectCards.PaymentMethods.PaymentCards;
using System.Security.Principal;

namespace ProjectCardsTests
{
    [TestClass]
    public class PaymentMethodCreditCardTests
    {
        [TestMethod]
        public void CreditCardToStringFormatMethodTest()
        {
            var validity = new Validity(1, 23);
            var creditCard = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.12f, 1245.73f, 2000f);

            var expectedResult = "All information about: CREDIT CARD\nCARD NUMBER: 3674259632951244;\nVALIDITY: 1/23;\nCVV: 736;" +
                                 "\nACCOUNT AMOUNT: 13,02;\nCREDIT PERCENTAGE: 0,12;\nCREDIT MONEY: 1245,73;\nCREDIT LIMIT: 2000;";
            var actualResult = creditCard.ToString();
            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void CreditCardEqualsTestPositive()
        {
            var validity = new Validity(1, 23);
            var creditCard1 = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.12f, 1245.73f, 2000f);
            var creditCard2 = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.12f, 1245.73f, 2000f);

            Assert.AreEqual(creditCard1, creditCard2);
        }

        [TestMethod]
        public void CreditCardEqualsTestCardNumberNegative()
        {
            var validity = new Validity(1, 23);
            var creditCard1 = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.12f, 1245.73f, 2000f);
            var creditCard2 = new CreditCard(3674259632951243, validity, 736, 13.02f, 0.12f, 1245.73f, 2000f);

            Assert.AreNotEqual(creditCard1, creditCard2);
        }

        [TestMethod]
        public void CreditCardEqualsTestValidityNegative()
        {
            var validity = new Validity(1, 23);
            var validity1 = new Validity(2, 23);
            var creditCard1 = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.12f, 1245.73f, 2000f);
            var creditCard2 = new CreditCard(3674259632951244, validity1, 736, 13.02f, 0.12f, 1245.73f, 2000f);

            Assert.AreNotEqual(creditCard1, creditCard2);
        }

        [TestMethod]
        public void CreditCardEqualsTestCVVNegative()
        {
            var validity = new Validity(1, 23);
            var creditCard1 = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.12f, 1245.73f, 2000f);
            var creditCard2 = new CreditCard(3674259632951244, validity, 735, 13.02f, 0.12f, 1245.73f, 2000f);

            Assert.AreNotEqual(creditCard1, creditCard2);
        }

        [TestMethod]
        public void CreditCardEqualsTestAccountAmountNegative()
        {
            var validity = new Validity(1, 23);
            var creditCard1 = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.12f, 1245.73f, 2000f);
            var creditCard2 = new CreditCard(3674259632951244, validity, 736, 13.01f, 0.12f, 1245.73f, 2000f);

            Assert.AreNotEqual(creditCard1, creditCard2);
        }

        [TestMethod]
        public void CreditCardEqualsTestCreditPercentageNegative()
        {
            var validity = new Validity(1, 23);
            var creditCard1 = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.12f, 1245.73f, 2000f);
            var creditCard2 = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.11f, 1245.73f, 2000f);

            Assert.AreNotEqual(creditCard1, creditCard2);
        }

        [TestMethod]
        public void CreditCardEqualsTestCreditMoneyNegative()
        {
            var validity = new Validity(1, 23);
            var creditCard1 = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.12f, 1245.73f, 2000f);
            var creditCard2 = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.12f, 1245.72f, 2000f);

            Assert.AreNotEqual(creditCard1, creditCard2);
        }

        [TestMethod]
        public void CreditCardEqualsTestCreditLimitNegative()
        {
            var validity = new Validity(1, 23);
            var creditCard1 = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.12f, 1245.73f, 2000f);
            var creditCard2 = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.12f, 1245.73f, 2001f);

            Assert.AreNotEqual(creditCard1, creditCard2);
        }

        [TestMethod]
        public void CreditCardMakePaymentTest()
        {
            var validity = new Validity(1, 23);
            var creditCard = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.12f, 1245.73f, 2000f);
            var expectedResult = 12.02f;
            var actualResult = creditCard.MakePayment(1f);

            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void CreditCardTopUpTest()
        {
            var validity = new Validity(1, 23);
            var creditCard = new CreditCard(3674259632951244, validity, 736, 13.02f, 0.12f, 1245.73f, 2000f);
            var expectedResult = 13.02f;
            var actualResult = creditCard.TopUp(10f);

            Assert.IsTrue(expectedResult == actualResult);
        }
    }
}