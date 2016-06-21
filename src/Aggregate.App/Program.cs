using Aggregate.App.Aggregate;
using Aggregate.App.ValueTypes;

namespace Aggregate.App
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var customer = new CustomerAggregate(Enumerable.Empty<dynamic>());
            customer.Deposit(new Money(20));

            Console.WriteLine("Customer account balance is {0}", customer.AccountBalance);
        }
    }
}