namespace Aggregate.App.Events
{
    public class CustomerWithdrawnMoney
    {
        public CustomerWithdrawnMoney(decimal amount)
        {
            this.Amount = amount;
        }

        public decimal Amount { get; private set; }
    }
}