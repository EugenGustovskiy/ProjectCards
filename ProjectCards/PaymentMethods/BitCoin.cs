using ProjectCards.Interfaces;

namespace ProjectCards.PaymentMethods;
internal class BitCoin : IPayment, IGetFullInformation, IPay
{
    protected string _walletNumber;
    public string WalletNumber
    { 
        get => _walletNumber;
        init
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.Length > 16)
            {
                throw new ArgumentException(nameof(value));
            }
            string walletNumberString = value.ToString().PadLeft(16, '0');
            if (walletNumberString != value.ToString())
            {
                throw new ArgumentException("Wallet number should be a 16-digit number", nameof(value));
            }
            _walletNumber = value;
        }
    }
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