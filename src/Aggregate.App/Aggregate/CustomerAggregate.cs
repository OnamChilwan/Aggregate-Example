using Aggregate.App.Events;
using Aggregate.App.ValueTypes;

namespace Aggregate.App.Aggregate
{
    using System.Collections.Generic;

    public class CustomerAggregate
    {
        public CustomerAggregate(IEnumerable<dynamic> events)
        {
            this.Events = new List<object>();

            foreach (var @event in events)
            {
                this.Apply(@event);
            }
        }

        public void ChangeName(string forename, string surname)
        {
            var e = new CustomerNameChanged(forename, surname);
            this.Apply(e);
            this.Events.Add(e);
        }

        public void Withdraw(Money money)
        {
            var e = new CustomerWithdrawnMoney(money.Amount);
            this.Apply(e);
            this.Events.Add(e);
        }

        public void Deposit(Money money)
        {
            var e = new CustomerDepositedMoney(money.Amount);
            this.Apply(e);
            this.Events.Add(e);
        }

        private void Apply(CustomerNameChanged e)
        {
            this.Forename = e.Forename;
            this.Surname = e.Surname;
        }

        private void Apply(CustomerWithdrawnMoney e)
        {
            this.AccountBalance -= e.Amount;
        }

        private void Apply(CustomerDepositedMoney e)
        {
            this.AccountBalance += e.Amount;
        }

        public decimal AccountBalance { get; private set; }

        public string Forename { get; private set; }

        public string Surname { get; private set; }

        public List<object> Events { get; private set; }
    }
}