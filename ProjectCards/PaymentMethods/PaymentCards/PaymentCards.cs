using ProjectCards.Interfaces;

namespace ProjectCards.PaymentMethods.PaymentCards;

internal abstract class PaymentCards : IPayment, IGetFullInformation, IPay
{
    protected long _cardNumber;
    public long CardNumber
    { 
        get => _cardNumber; 
        init
        {
            if (value == 0 || value > 9999999999999999) 
            { 
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            string cardNumberString = value.ToString().PadLeft(16, '0');
            if (cardNumberString != value.ToString())
            {
                throw new ArgumentException("Card number should be a 16-digit number", nameof(value));
            }
            _cardNumber = value;
        }
    }
    public Validity Validity { get; init; }
    protected int _CVV;
    public int CVV
    {
        get => _CVV;
        init
        {
            if (value < 0 || value > 999)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "The CVV value is out of scope.");
            }
            string cvvString = value.ToString().PadLeft(3, '0');
            if (cvvString != value.ToString())
            {
                throw new ArgumentException("CVV should be a 3-digit number", nameof(value));
            }
            _CVV = value;
        }
    }
    public float AccountAmount { get; set; }

    public PaymentCards(long cardNumber, Validity validity, int cvv, float accountAmount)
    {
        CardNumber = cardNumber;
        Validity = validity;
        CVV = cvv;
        AccountAmount = accountAmount;
    }

    public abstract bool MakePayment(float sum);
    public abstract bool TopUp(float sum);
    public abstract bool PayProduct(float sumProduct);
    public abstract float AllMoney();
    public abstract string GetFullInformation();
}