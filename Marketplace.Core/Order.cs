using System;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace.Core
{
    public class Order
    {
        private readonly List<Product> products;
        
        private Order()
        {
        }

        public Order(Customer customer, IEnumerable<Product> products, double totalInUsDollars,
            DateTimeOffset? orderDateTime = null)
        {
            Id = Guid.NewGuid();
            
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));

            this.products = products?.ToList() ?? throw new ArgumentNullException(nameof(products));

            TotalInUsDollars = totalInUsDollars;
            
            OrderDateTime = orderDateTime ?? DateTimeOffset.Now;
        }
        
        public Guid Id { get; private set; }
        
        public Customer Customer { get; private set; }

        public IEnumerable<Product> Products => products.AsEnumerable();
        
        public double TotalInUsDollars { get; private set; }
        
        public DateTimeOffset OrderDateTime { get; private set; }
    }
}