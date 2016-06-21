namespace Aggregate.App.Events
{
    public class CustomerDepositedMoney
    {
        public CustomerDepositedMoney(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; private set; }
    }
}