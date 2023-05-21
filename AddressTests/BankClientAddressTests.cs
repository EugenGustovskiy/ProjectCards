using ProjectCards.BankClients;

namespace ProjectCardsTests
{
    [TestClass]
    public class BankClientAddressTests
    {
        [TestMethod]
        public void AddressToStringMethodFormatTest()
        {
            var address = new Address("BY", "Minsk", "Central", 1, 1);

            var expectedResult = "State: BY, City: Minsk, Street: Central, HouseNumber: 1, FlatNumber: 1";
            var actualResult = address.ToString();

            Assert.IsTrue(expectedResult == actualResult);
        }

        [TestMethod]
        public void AddressEqualsTestPositive()
        {
            var address1 = new Address("BY", "Minsk", "Central", 1, 1);
            var address2 = new Address("BY", "Minsk", "Central", 1, 1);

            Assert.AreEqual(address1, address2);
        }

        [TestMethod]
        [DataRow("By", "Minsk", "Central", 1, 1)]
        [DataRow("BY", "Mins", "Central", 1, 1)]
        [DataRow("BY", "Minsk", "Centra", 1, 1)]
        [DataRow("BY", "Minsk", "Central", 2, 1)]
        [DataRow("BY", "Minsk", "Central", 1, 2)]
        public void AddressEqualsTestNegative(string state, string city, string street, int houseNumber, int flatNumber)
        {
            var address1 = new Address("BY", "Minsk", "Central", 1, 1);
            var address2 = new Address(city, state, street, houseNumber, flatNumber);

            Assert.AreNotEqual(address1, address2);
        }
    }
}