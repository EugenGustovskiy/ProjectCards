using ProjectCards.Interfaces;
namespace ProjectCards.PaymentMethods.PaymentCards;
public class CreditCard : PaymentCards, IPay
{
    public float _creditPercentage;
    public float CreditPercentage 
    { 
        get => _creditPercentage;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0 and 100 (inclusive).");
            }
            _creditPercentage = value;
        }
    }
    public float _creditMoney;
    public float CreditMoney
    { 
        get => _creditMoney;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Account amount cannot be negative.");
            }
            _creditMoney = value;
        }
    }
    public float _creditLimit;
    public float CreditLimit
    {
        get => _creditLimit;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Account amount cannot be negative.");
            }
            _creditLimit = value;
        }
    }


    public CreditCard(long cardNumber, Validity validity, int cvv, float accountAmount, float creditPercentage,
                      float creditMoney, float creditLimit) : base(cardNumber, validity, cvv, accountAmount)
    {
        CreditPercentage = creditPercentage;
        CreditMoney = creditMoney;
        CreditLimit = creditLimit;
    }


    public override float MakePayment(float sum)
    {
        if (sum <= AccountAmount)
        {
            AccountAmount -= sum;
        }
        else if (sum * CreditPercentage + sum <= CreditMoney)
        {
            CreditMoney -= sum * CreditPercentage + sum;
        }
        else if ((sum - AccountAmount) * CreditPercentage + sum <= AccountAmount + CreditMoney)
        {
            CreditMoney -= (sum - AccountAmount) * CreditPercentage + sum - AccountAmount;
            AccountAmount = 0;
        }
        return AccountAmount;
    }


    public override float TopUp(float sum)
    {
        if (sum <= 0)
        {
            return AccountAmount;
        }
        else if (CreditMoney < CreditLimit)
        {
            CreditMoney += sum;
            if (CreditMoney > CreditLimit)
            {
                float difference = CreditMoney - CreditLimit;
                AccountAmount += difference;
            }
        }
        return AccountAmount;
    }


    public override float PayProduct(float sumProduct)
    {
        if (sumProduct <= AccountAmount)
        {
            AccountAmount -= sumProduct;
        }
        else if (sumProduct <= CreditMoney)
        {
            CreditMoney -= sumProduct;
        }
        else if ((sumProduct - AccountAmount) * CreditPercentage + sumProduct <= AccountAmount + CreditMoney)
        {
            CreditMoney -= (sumProduct - AccountAmount) * CreditPercentage + sumProduct - AccountAmount;
            AccountAmount = 0;
        }
        return AccountAmount;
    }


    public override float AllMoney()
    {
        float allMoney = 0;
        allMoney += AccountAmount + CreditMoney;
        return allMoney;
    }


    public override string ToString()
    {
        return $"All information about: CREDIT CARD\nCARD NUMBER: {CardNumber};\nVALIDITY: {Validity};\nCVV: {CVV};\n" +
               $"ACCOUNT AMOUNT: {AccountAmount};\nCREDIT PERCENTAGE: {CreditPercentage};\nCREDIT MONEY: {CreditMoney};\n" +
               $"CREDIT LIMIT: {CreditLimit};";
    }


    public override bool Equals(object? obj)
    {
        if (obj is CreditCard)
        {
            CreditCard creditCard = obj as CreditCard;
            return creditCard.CardNumber == CardNumber &&
                   creditCard.Validity == Validity &&
                   creditCard.CVV == CVV &&
                   creditCard.AccountAmount == AccountAmount &&
                   creditCard.CreditPercentage == CreditPercentage &&
                   creditCard.CreditMoney == CreditMoney &&
                   creditCard.CreditLimit == CreditLimit;
        }
        return false;
    }
}