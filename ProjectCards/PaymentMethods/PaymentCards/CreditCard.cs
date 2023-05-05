using ProjectCards.Interfaces;

namespace ProjectCards.PaymentMethods.PaymentCards;
internal class CreditCard : PaymentCards, IGetFullInformation, IPay
{
    public float CreditPercentage { get; set; }
    public float CreditMoney { get; set; }
    public float CreditLimit { get; set; }


    public CreditCard(string number, Validity validity, int cvv, float accountAmount, float creditPercentage,
                      float creditMoney, float creditLimit) : base(number, validity, cvv, accountAmount)
    {
        CreditPercentage = creditPercentage;
        CreditMoney = creditMoney;
        CreditLimit = creditLimit;
    }


    public override bool MakePayment(float sum)
    {
        if (sum <= AccountAmount)
        {
            AccountAmount -= sum;
            return true;
        }
        else if (sum * CreditPercentage + sum <= CreditMoney)
        {
            CreditMoney -= sum * CreditPercentage + sum;
            return true;
        }
        else if ((sum - AccountAmount) * CreditPercentage + sum <= AccountAmount + CreditMoney)
        {
            CreditMoney -= (sum - AccountAmount) * CreditPercentage + sum - AccountAmount;
            AccountAmount = 0;
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
        float difference = CreditLimit - CreditMoney;
        CreditMoney += difference;
        AccountAmount = sum - difference + AccountAmount;
        return true;
    }


    public override bool PayProduct(float sumProduct)
    {
        if (sumProduct <= AccountAmount)
        {
            AccountAmount -= sumProduct;
            return true;
        }
        else if (sumProduct <= CreditMoney)
        {
            CreditMoney -= sumProduct;
            return true;
        }
        else if ((sumProduct - AccountAmount) * CreditPercentage + sumProduct <= AccountAmount + CreditMoney)
        {
            CreditMoney -= (sumProduct - AccountAmount) * CreditPercentage + sumProduct - AccountAmount;
            AccountAmount = 0;
            return true;
        }
        return false;
    }


    public override float AllMoney()
    {
        float allMoney = 0;
        allMoney += AccountAmount + CreditMoney;
        return allMoney;
    }


    public override string GetFullInformation()
    {
        return $"All information about: CREDIT CARD\nCARD NUMBER: {CardNumber};\nVALIDITY: {Validity};\nCVV: {CVV};\n" +
               $"ACCOUNT AMOUNT: {AccountAmount};\nCREDIT PERCENTAGE: {CreditPercentage};\nCREDIT MONEY: {CreditMoney};\n" +
               $"CREDIT LIMIT: {CreditLimit};";
    }
}