namespace ProjectCards.Interfaces;
public interface IPayment
{
    float MakePayment(float sum);
    float TopUp(float sum);
    float AllMoney();
}