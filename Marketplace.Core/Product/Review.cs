using System;
using System.Security.Cryptography;

namespace Marketplace.Core
{
    public class Review
    {
        private Review()
        {
        }
        
        public Review(Customer customer, double rate, string text = null)
        {
            Id = Guid.NewGuid();
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            Rate = rate;
            Text = text;
        }
        
        public Guid Id { get; private set; }

        public Customer Customer { get; private set; }
        
        private double rate;

        public double Rate
        {
            get => rate;
            private set
            {
                if (value >= 1) rate = 1;
                if (value <= 0) rate = 0;
                rate = value;
            }
        }
        
        public string Text { get; private set; }
    }
}