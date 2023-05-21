using ProjectCards.PaymentMethods;
namespace ProjectCardsTests
{
    [TestClass]
    public class PaymentMethodBitCoinTests
    {
        [TestMethod]
        public void BitCoinToStringFormatMethodTest()
        {
            var bitCoin = new BitCoin("45sdBES674kcpe62", 1f);

            var expectedResult = "All information about: BITCOIN\nBITCOIN: 1;";
            var actualResult = bitCoin.ToString();

            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void BitCoinEqualsTestPositive()
        {
            var bitCoin1 = new BitCoin("45sdBES674kcpe62", 1f);
            var bitCoin2 = new BitCoin("45sdBES674kcpe62", 1f);

            Assert.AreEqual(bitCoin1, bitCoin2);
        }

        [TestMethod]
        [DataRow("45sdBES674kcpe61", 1f)]
        [DataRow("45sdBES674kcpe62", 2f)]
        public void BitCoinEqualsTestNegative(string walletNumber, float accountAmount)
        {
            var bitCoin1 = new BitCoin("45sdBES674kcpe62", 1f);
            var bitCoin2 = new BitCoin(walletNumber, accountAmount);

            Assert.AreNotEqual(bitCoin1, bitCoin2);
        }

        [TestMethod]
        public void BitCoinMakePaymentTest()
        {
            var bitCoin = new BitCoin("45sdBES674kcpe62", 2f);

            var expectedResult = 1f;
            var actualResult = bitCoin.MakePayment(77735.16f);

            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void CashTopUpTest()
        {
            var bitCoin = new BitCoin("45sdBES674kcpe62", 2f);

            var expectedResult = 3f;
            var actualResult = bitCoin.TopUp(77735.16f);

            Assert.IsTrue(expectedResult == actualResult);
        }
    }
}
