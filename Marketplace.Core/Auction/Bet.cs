using System;

namespace Marketplace.Core
{
    public class Bet
    {
        private Bet()
        {
        }

        public Bet(Customer bettor, Product product, double amountInUsDollars)
        {
            Id = Guid.NewGuid();
            Bettor = bettor ?? throw new ArgumentNullException(nameof(bettor));
            Product = product ?? throw new ArgumentNullException(nameof(product));
            AmountInUsDollars = amountInUsDollars;
            CreationDateTime = DateTimeOffset.Now;
        }

        public Guid Id { get; private set; }

        public Customer Bettor { get; private set; }

        public Product Product { get; private set; }

        public double AmountInUsDollars { get; private set; }

        public DateTimeOffset CreationDateTime { get; private set; }
    }
}