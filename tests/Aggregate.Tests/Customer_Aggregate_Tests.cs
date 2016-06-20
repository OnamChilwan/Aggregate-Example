namespace Aggregate.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using Aggregate.App.Aggregate;
    using Aggregate.App.Events;
    using Aggregate.App.ValueTypes;

    [TestFixture]
    public class Customer_Aggregate_Tests
    {
        [Test]
        public void When_Loading_The_Customer()
        {
            var events = new List<dynamic>()
            {
                new CustomerNameChanged("Onam", "Chilwan"),
                new CustomerDepositedMoney(5.50M),
                new CustomerDepositedMoney(5M),
                new CustomerWithdrawnMoney(1.50M)
            };
            var customer = new CustomerAggregate(events);

            Assert.That(customer.Events.ToList(), Is.Empty);
            Assert.That(customer.Forename, Is.EqualTo("Onam"));
            Assert.That(customer.Surname, Is.EqualTo("Chilwan"));
            Assert.That(customer.AccountBalance, Is.EqualTo(9M));
        }

        [Test]
        public void When_Changing_Customers_Name()
        {
            var customer = new CustomerAggregate(Enumerable.Empty<dynamic>());
            customer.ChangeName("Onam", "Chilwan");

            Assert.That(customer.Events.Any(x => x is CustomerNameChanged), Is.True);
            Assert.That(customer.Forename, Is.EqualTo("Onam"));
            Assert.That(customer.Surname, Is.EqualTo("Chilwan"));
        }

        [Test]
        public void When_Making_A_Withdrawal()
        {
            var customer = new CustomerAggregate(Enumerable.Empty<dynamic>());
            customer.Withdraw(new Money(10));

            Assert.That(customer.Events.Any(x => x is CustomerWithdrawnMoney), Is.True);
            Assert.That(customer.AccountBalance, Is.EqualTo(-10));
        }

        [Test]
        public void When_Making_A_Deposit()
        {
            var customer = new CustomerAggregate(Enumerable.Empty<dynamic>());
            customer.Deposit(new Money(10));

            Assert.That(customer.Events.Any(x => x is CustomerDepositedMoney), Is.True);
            Assert.That(customer.AccountBalance, Is.EqualTo(10));
        }
    }
}