using ProjectCards.Interfaces;

namespace ProjectCards.PaymentMethods;
internal class Cash : IPayment, IGetFullInformation, IPay
{
    public float AccountAmount { get; set; } 

    public Cash(float accountAmount)
    {
        AccountAmount = accountAmount;
    }

    public bool MakePayment(float sum)
    { 
        if (sum <= 0)
        {
            return false;
        }
        AccountAmount += sum;
        return true;
    }


    public bool TopUp(float sum)
    {
        if (sum > 0 && sum <= AccountAmount)
        {
            AccountAmount -= sum;
            return true;
        }
        return false;
    }


    public bool PayProduct(float sumProduct)
    {
        if (sumProduct <= AccountAmount)
        {
            AccountAmount -= sumProduct;
            return true;
        }
        return false;
    }


    public float AllMoney()
    {
        float allMoney = 0;
        allMoney += AccountAmount;
        return allMoney;
    }


    public string GetFullInformation()
    {
        return $"All information about: CASH\nCASH: {AccountAmount};";
    }
}