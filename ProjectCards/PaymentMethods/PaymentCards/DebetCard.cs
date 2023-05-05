using ProjectCards.Interfaces;

namespace ProjectCards.PaymentMethods.PaymentCards;
internal class DebetCard : PaymentCards, IGetFullInformation, IPay
{
    public DebetCard(string cardNumber, Validity validity, int cvv, float accountAmount) :
                base(cardNumber, validity, cvv, accountAmount)
    {
    }


    public override bool MakePayment(float sum)
    {
        if (sum <= AccountAmount)
        {
            AccountAmount -= sum;
            return true;
        }
        return false;
    }


    public override bool TopUp(float sum)
    {
        if (sum <= 0)
        {
            return false;
        }
        AccountAmount += sum;
        return true;
    }


    public override bool PayProduct(float sumProduct)
    {
        if (sumProduct <= AccountAmount)
        {
            AccountAmount -= sumProduct;
            return true;
        }
        return false;
    }


    public override float AllMoney()
    {
        float allMoney = 0;
        allMoney += AccountAmount;
        return allMoney;
    }


    public override string GetFullInformation()
    {
        return $"All information about: DEBET CARD\nCARD NUMBER: {CardNumber};\nVALIDITY: {Validity};\nCCV: {CVV};" +
                            "\nACCOUNT AMOUNT: {AccountAmount};";
    }
}