using ProjectCards.Interfaces;
namespace ProjectCards.PaymentMethods.PaymentCards;
public class CashBackCard : PaymentCards, IPay
{
    public float _returnPercentage;
    public float ReturnPercentage 
    { 
        get => _returnPercentage; 
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0 and 100 (inclusive).");
            }
        }
    }
    public float _sumCashBack;
    public float SumCashBack
    { 
        get => _sumCashBack; 
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Account amount cannot be negative.");
            }
            _sumCashBack = value;
        }
    }

    public CashBackCard(long cardNumber, Validity validity, int ccv, float accountAmount, float returnPercentage,
                        float sumCashBack) : base(cardNumber, validity, ccv, accountAmount)
    {
        ReturnPercentage = returnPercentage;
        SumCashBack = sumCashBack;
    }


    public override float MakePayment(float sum)
    {
        if (sum <= SumCashBack)
        {
            SumCashBack -= sum;
        }
        else if (sum <= AccountAmount)
        {
            AccountAmount -= sum;
        }
        else if (sum <= AccountAmount + SumCashBack)
        {
            AccountAmount += SumCashBack;
            SumCashBack = 0;
            AccountAmount -= sum;
        }
        return AccountAmount;
    }

    
    public override float TopUp(float sum)
    {
        if (sum < 0)
        {
            return AccountAmount;
        }
        AccountAmount += sum;
        return AccountAmount;  
    }


    public override float PayProduct(float sumProduct)
    {
        if (sumProduct <= SumCashBack)
        {
            SumCashBack -= sumProduct;
        }
        else if (sumProduct <= AccountAmount)
        {
            AccountAmount -= sumProduct;
        }
        else if (sumProduct <= AccountAmount + SumCashBack)
        {
            AccountAmount += SumCashBack;
            SumCashBack = 0;
            AccountAmount -= sumProduct;
        }
        return AccountAmount;
    }


    public override float AllMoney()
    {
        float allMoney = 0;
        allMoney += AccountAmount + SumCashBack;
        return allMoney;
    }


    public override string ToString()
    {
        return $"All information about: CASHBACK CARD\nCARD NUMBER: {CardNumber};\nVALIDITY: {Validity};\nCVV: {CVV};" +
               $"\nACCOUNT AMOUNT: {AccountAmount};\nRETURN  PERCENTAGE: {ReturnPercentage};\nSUM CASNBACK: {SumCashBack};";
    }


    public override bool Equals(object? obj)
    {
        if (obj is CashBackCard)
        {
            CashBackCard cashBackCard = obj as CashBackCard;
            return cashBackCard.CardNumber == CardNumber &&
                   cashBackCard.Validity == Validity &&
                   cashBackCard.CVV == CVV &&
                   cashBackCard.AccountAmount == AccountAmount &&
                   cashBackCard.ReturnPercentage == ReturnPercentage &&
                   cashBackCard.SumCashBack == SumCashBack;
        }
        return false;
    }
}