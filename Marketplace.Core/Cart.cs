using System;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace.Core
{
    public class Cart
    {
        private Cart()
        {
        }

        public Cart(Customer customer)
        {
            Id = Guid.NewGuid();
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
            Products = new List<Product>();
        }
        
        public Guid Id { get; private set; } 
        
        public Customer Customer { get; private set; }
        
        public List<Product> Products { get; private set; }

        public double TotalInUsDollarsWithoutDiscounts
            => Products.Sum(product => product.BasePriceInUsDollars * product.Quantity);
        
        public double TotalInUsDollarsWithDiscounts { get; set; }

        public void Reset()
        {
            Products = new List<Product>();
            TotalInUsDollarsWithDiscounts = default;
        }
    }
}