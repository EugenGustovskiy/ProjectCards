using ProjectCards.Interfaces;

namespace ProjectCards.PaymentMethods.PaymentCards;

internal abstract class PaymentCards : IPayment, IGetFullInformation, IPay
{
    public string CardNumber { get; init; }
    public Validity Validity { get; init; }
    public int CVV { get; init; }
    public float AccountAmount { get; set; }

    public PaymentCards(string cardNumber, Validity validity, int cvv, float accountAmount)
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