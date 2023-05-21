using ProjectCards.Interfaces;
namespace ProjectCards.PaymentMethods.PaymentCards;
public class DebetCard : PaymentCards, IPay
{
    public DebetCard(long cardNumber, Validity validity, int cvv, float accountAmount) :
                base(cardNumber, validity, cvv, accountAmount)
    {
    }


    public override float MakePayment(float sum)
    {
        if (sum <= AccountAmount)
        {
            AccountAmount -= sum;
            return AccountAmount;
        }
        return AccountAmount;
    }


    public override float TopUp(float sum)
    {
        if (sum <= 0)
        {
            return AccountAmount;
        }
        AccountAmount += sum;
        return AccountAmount;
    }


    public override float PayProduct(float sumProduct)
    {
        if (sumProduct <= AccountAmount)
        {
            AccountAmount -= sumProduct;
        }
        return AccountAmount;
    }


    public override float AllMoney()
    {
        float allMoney = 0;
        allMoney += AccountAmount;
        return allMoney;
    }


    public override string ToString()
    {
        return $"All information about: DEBET CARD\nCARD NUMBER: {CardNumber};\nVALIDITY: {Validity};\nCVV: {CVV};" +
               $"\nACCOUNT AMOUNT: {AccountAmount};";
    }


    public override bool Equals(object? obj)
    {
        if (obj is DebetCard)
        {
            DebetCard debetCard = obj as DebetCard;
            return debetCard.CardNumber == CardNumber &&
                   debetCard.Validity == Validity &&
                   debetCard.CVV == CVV &&
                   debetCard.AccountAmount == AccountAmount;
        }
        return false;
    }
}