using ProjectCards.Interfaces;
namespace ProjectCards.PaymentMethods.PaymentCards;
public abstract class PaymentCards : IPayment, IPay
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
    public float _accountAmount;
    public float AccountAmount 
    { 
        get => _accountAmount; 
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Account amount cannot be negative.");
            }
            _accountAmount = value;
        }
    }

    public PaymentCards(long cardNumber, Validity validity, int cvv, float accountAmount)
    {
        CardNumber = cardNumber;
        Validity = validity;
        CVV = cvv;
        AccountAmount = accountAmount;
    }

    public abstract float MakePayment(float sum);
    public abstract float TopUp(float sum);
    public abstract float PayProduct(float sumProduct);
    public abstract float AllMoney();
}