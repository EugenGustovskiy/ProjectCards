namespace ProjectCards.PaymentMethods.PaymentCards;
public class Validity
{
    public byte _month;
    public byte Month
    {
        get => _month;
        init
        {
            if (value < 0 || value > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0 and 12 (inclusive).");
            }
        }
    }
    public byte _year;
    public byte Year
    { 
        get => _year;
        init
        {
            if (value < 20 || value > 99)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 22 and 99 (inclusive).");
            }
        }
    }

    public Validity(byte month, byte year)
    {
        Month = month;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Month}/{Year}";
    }


    public override bool Equals(object? obj)
    {
        if (obj is Validity)
        {
            Validity validity = obj as Validity;
            return validity.Month == Month && validity.Year == Year;
        }
        return false;
    }
}