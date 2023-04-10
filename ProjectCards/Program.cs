namespace ProjectCards
{
    internal class Program
    {
        static bool WithdrawMoney(List<IPayment> methods)
        {
            foreach (IPayment i in methods)
            {
                string message = i.MakePayment();
                Console.WriteLine(message);
            }
            return true;
        }

        static bool PutMoney(List<IPayment> methods)
        {
            foreach (IPayment i in methods)
            {
                string message = i.TopUp();
                Console.WriteLine(message);
            }
            return true;
        }

        static bool InformationAboutPaymentMethods(List<IPayment> methods)
        {
            foreach (IPayment i in methods)
            {
                string message = i.GetFullInformation();
                Console.WriteLine(message);
            }
            return true;
        }


        static void Main(string[] args)
        { 
            Validity validity1 = new(4, 26);
            Validity validity2 = new(11, 25);
            Validity validity3 = new(7, 12);

            DebetCard method1 = new("2541 5687 3561 6247", validity1, 374, 47.67f);
            CashBackCard method2 = new("6752 3258 1298 3654", validity2, 657, 15.02f, 4);
            CreditCard method3 = new("3674 2596 3295 1244", validity3, 736, 350f, 12);
            Cash method4 = new(137.67f);
            BitCoin method5 = new("05SDdfs064asdd4", 709.46f); //0.01 BitCoin = 709.46 BYN

            List<IPayment> methods = new List<IPayment>() { method4, method2, method1, method3, method5 };


            Goods item1 = new("Front brake disc STELLOX", 19.2f);
            Goods item2 = new("Brake pads STELLOX", 7.7f);
            Goods item3 = new("Brake caliper STELLOX", 72.1f);

            List<Goods> items = new List<Goods>() { item1, item2, item3 };


            Address address1 = new("BY", "Minsk", "Odintsova", 11, 32);

            BankClient Person1 = new("Maria", "Gruzinova", address1, methods, items);


            InformationAboutPaymentMethods(methods);
            WithdrawMoney(methods);
            PutMoney(methods);
            InformationAboutPaymentMethods(methods);
        }
        
    }
}