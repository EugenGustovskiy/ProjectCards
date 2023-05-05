namespace ProjectCards.PaymentMethods.PaymentCards;
internal class Validity
{
    public byte Month { get; init; }
    public byte Year { get; init; }

    public Validity(byte month, byte year)
    {
        Month = month;
        Year = year;
    }

    public override string ToString()
    {
        return Month + "/" + Year;
    }
}