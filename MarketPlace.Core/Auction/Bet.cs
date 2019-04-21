using System;

namespace MarketPlace.Core
{
    public class Bet
    {
        private Bet()
        {
        }

        public Bet(Customer customer, Product product, double amountInUsDollars)
        {
            Id = Guid.NewGuid();
            Customer = customer;
            Product = product;
            AmountInUsDollars = amountInUsDollars;
            CreationDateTime = DateTime.Now;
        }

        public Guid Id { get; private set; }

        public Customer Customer { get; private set; }

        public Product Product { get; private set; }

        public double AmountInUsDollars { get; private set; }

        public DateTime CreationDateTime { get; private set; }
    }
}