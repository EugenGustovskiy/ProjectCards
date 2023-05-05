using ProjectCards.Interfaces;

namespace ProjectCards.PaymentMethods;
internal class BitCoin : IPayment, IGetFullInformation, IPay
{
    public string WalletNumber { get; init; }
    public float AccountAmount { get; set; }


    public BitCoin(string walletNumber, float accountAmount)
    {
        WalletNumber = walletNumber;
        AccountAmount = accountAmount;
    }

    //Method to convert Bitcoin to BYN.
    public void ConvertBTCToBYN()
    {
        AccountAmount *= 77735.16f;
        //Next, we call a method that rounds the result to two decimal places, and the updated value is saved.
        AccountAmount = (float)Math.Round(AccountAmount, 2);
    }

    //Method to conver BYN to Bitcoin.
    public void ConvertBYNToBTC()
    {
        AccountAmount /= 77735.16f;
        AccountAmount = (float)Math.Round(AccountAmount, 2);
    }


    public bool MakePayment(float sum)
    {
        ConvertBTCToBYN();
        if (sum <= AccountAmount)
        {
            AccountAmount -= sum;
            ConvertBYNToBTC();
            return true;
        }
        ConvertBYNToBTC();
        return false;
    }
    

    public bool TopUp(float sum)
    {
        ConvertBTCToBYN();
        if (sum <= 0)
        {
            ConvertBYNToBTC();
            return false;
        }
        AccountAmount += sum;
        ConvertBYNToBTC();
        return true;
    }


    public bool PayProduct(float sumProduct)
    {
        ConvertBTCToBYN();
        if (sumProduct <= AccountAmount)
        {
            AccountAmount -= sumProduct;
            ConvertBYNToBTC();
            return true;
        }
        ConvertBYNToBTC();
        return false;
    }


    public float AllMoney()
    {
        float allMoney = 0;
        float convert = AccountAmount * 77735.16f;
        allMoney += convert;
        return allMoney;
    }


    public string GetFullInformation()
    {
        return $"All information about: BITCOIN\nBITCOIN: {AccountAmount};";
    }
}