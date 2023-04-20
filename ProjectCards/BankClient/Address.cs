using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCards.BankClients
{
    internal class Address
    {
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int FlatNumber { get; set; }

        public Address(string state, string city, string street, int houseNumber, int flatNumber)
        {
            State = state;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
        }

        public override string ToString()
        {
            return "State: " + State + ", " + "City: " + City + ", " + "Street: " + Street + ", " + "HouseNumber: " + HouseNumber + ", " + "FlatNumber: " + FlatNumber;
        }
    }
}
