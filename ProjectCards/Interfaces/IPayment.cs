namespace ProjectCards.Interfaces;
internal interface IPayment
{
    bool MakePayment(float sum);
    bool TopUp(float sum);
    float AllMoney();
}