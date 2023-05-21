using ProjectCards.Interfaces;
namespace ProjectCards.PaymentMethods;
public class Cash : IPayment, IPay
{
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

    public Cash(float accountAmount)
    {
        AccountAmount = accountAmount;
    }

    public float MakePayment(float sum)
    { 
        if (sum <= 0)
        {
            return AccountAmount;
        }
        AccountAmount += sum;
        return AccountAmount;
    }


    public float TopUp(float sum)
    {
        if (sum > 0 && sum <= AccountAmount)
        {
            AccountAmount -= sum;
        }
        return AccountAmount;
    }


    public float PayProduct(float sumProduct)
    {
        if (sumProduct <= AccountAmount)
        {
            AccountAmount -= sumProduct;
        }
        return AccountAmount;
    }


    public float AllMoney()
    {
        float allMoney = 0;
        allMoney += AccountAmount;
        return allMoney;
    }


    public override string ToString()
    {
        return $"All information about: CASH\nCASH: {AccountAmount};";
    }

    public override bool Equals(object? obj)
    {
        if(obj is Cash)
        {
            Cash cash = obj as Cash;
            return cash.AccountAmount == AccountAmount;
        }
        return false;
    }
}