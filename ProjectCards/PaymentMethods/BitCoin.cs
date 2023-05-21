using ProjectCards.Interfaces;
namespace ProjectCards.PaymentMethods;
public class BitCoin : IPayment, IPay
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
            string walletNumberString = value.ToString().PadLeft(16, '0');
            if (walletNumberString != value.ToString())
            {
                throw new ArgumentException("Wallet number should be a 16-digit number", nameof(value));
            }
            _walletNumber = walletNumberString;
        }
    }
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


    public float MakePayment(float sum)
    {
        ConvertBTCToBYN();
        if (sum <= AccountAmount)
        {
            AccountAmount -= sum;
        }
        ConvertBYNToBTC();
        return AccountAmount;
    }
    

    public float TopUp(float sum)
    {
        ConvertBTCToBYN();
        if (sum <= 0)
        {
            ConvertBYNToBTC();
        }
        AccountAmount += sum;
        ConvertBYNToBTC();
        return AccountAmount;
    }


    public float PayProduct(float sumProduct)
    {
        ConvertBTCToBYN();
        if (sumProduct <= AccountAmount)
        {
            AccountAmount -= sumProduct;
            ConvertBYNToBTC();
        }
        ConvertBYNToBTC();
        return AccountAmount;
    }


    public float AllMoney()
    {
        float allMoney = 0;
        float convert = AccountAmount * 77735.16f;
        allMoney += convert;
        return allMoney;
    }


    public override string ToString()
    {
        return $"All information about: BITCOIN\nBITCOIN: {AccountAmount};";
    }


    public override bool Equals(object? obj)
    {
        if(obj is BitCoin)
        {
            BitCoin bitCoin = obj as BitCoin;
            return bitCoin.WalletNumber == WalletNumber && bitCoin.AccountAmount == AccountAmount;
        }
        return false;
    }
}