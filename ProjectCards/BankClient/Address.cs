namespace ProjectCards.BankClients
{
    public class Address : IComparable<Address>
    {
        protected string _state;
        public string State
        { 
            get => _state; 
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The value is null or empty.");
                }
                _state = value;
            }
        }
        protected string _city;
        public string City 
        { 
            get => _city; 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The value is null or empty.");
                }
                _city = value;
            }
        }
        protected string _street;
        public string Street
        { 
            get => _street; 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The value is null or empty.");
                }
                _street = value;
            }
        }
        protected int _houseNumber;
        public int HouseNumber
        { 
            get => _houseNumber;
            set
            {
                if (value == 0 || value < 0)
                {
                    throw new ArgumentException("The value is invalid.");
                }
                _houseNumber = value;
            }
        }
        protected int _flatNumber;
        public int FlatNumber
        { 
            get => _flatNumber;
            set
            {
                if (value == 0 || value < 0)
                {
                    throw new ArgumentException("The value is invalid.");
                }
                _flatNumber = value;
            }
        }

        public Address(string state, string city, string street, int houseNumber, int flatNumber)
        {
            State = state;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
        }


        public int CompareTo(Address? other)
        {
            return this.City.CompareTo(other.City);
        }


        public override string ToString()
        {
            return $"State: {State}, City: {City}, Street: {Street}, HouseNumber: {HouseNumber}, FlatNumber: {FlatNumber}";
        }

        public override bool Equals(object? obj)
        {
            if(obj is Address)
            {
                Address address = obj as Address;
                return address.State == State &&
                       address.City == City &&
                       address.Street == Street &&
                       address.HouseNumber == HouseNumber &&
                       address.FlatNumber == FlatNumber;
            }
            return false;
        }
    }
}
