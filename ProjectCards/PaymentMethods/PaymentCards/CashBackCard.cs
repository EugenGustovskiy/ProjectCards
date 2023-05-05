using ProjectCards.Interfaces;

namespace ProjectCards.PaymentMethods.PaymentCards;

internal class CashBackCard : PaymentCards, IGetFullInformation, IPay
{
    public float ReturnPercentage { get; set; }
    public float SumCashBack { get; set; }

    public CashBackCard(string cardNumber, Validity validity, int ccv, float accountAmount, float returnPercentage,
                        float sumCashBack) : base(cardNumber, validity, ccv, accountAmount)
    {
        ReturnPercentage = returnPercentage;
        SumCashBack = sumCashBack;
    }


    public override bool MakePayment(float sum)
    {
        if (sum <= SumCashBack)
        {
            SumCashBack -= sum;
            return true;
        }
        else if (sum <= AccountAmount)
        {
            AccountAmount -= sum;
            return true;
        }
        else if (sum <= AccountAmount + SumCashBack)
        {
            AccountAmount += SumCashBack;
            SumCashBack = 0;
            AccountAmount -= sum;
            return true;
        }
        else { return false; }
    }

    
    public override bool TopUp(float sum)
    {
        if (sum < 0)
        {
            return false;
        }
        AccountAmount += sum;
        return true;  
    }


    public override bool PayProduct(float sumProduct)
    {
        if (sumProduct <= SumCashBack)
        {
            SumCashBack -= sumProduct;
            return true;
        }
        else if (sumProduct <= AccountAmount)
        {
            AccountAmount -= sumProduct;
            return true;
        }
        else if (sumProduct <= AccountAmount + SumCashBack)
        {
            AccountAmount += SumCashBack;
            SumCashBack = 0;
            AccountAmount -= sumProduct;
            return true;
        }
        else
        { return false; }
    }


    public override float AllMoney()
    {
        float allMoney = 0;
        allMoney += AccountAmount + SumCashBack;
        return allMoney;
    }


    public override string GetFullInformation()
    {
        return $"All information about: CASHBACK CARD\nCARD NUMBER: {CardNumber};\nVALIDITY: {Validity};\nCVV: {CVV};" +
               $"\nACCOUNT AMOUNT: {AccountAmount};\nRETURN  PERCENTAGE: {ReturnPercentage};\nSUM CASNBACK: {SumCashBack};";
    }
}
