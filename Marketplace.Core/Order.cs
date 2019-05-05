using System;
using System.Collections.Generic;
using System.Linq;
using Marketplace.Infrastructure;

namespace Marketplace.Core
{
    public class Order
    {private Order()
        {
        }

        public Order(string customerLogin, IEnumerable<Product> products, double totalInUsDollars,
            DateTimeOffset? orderDateTime = null)
        {
            Id = Guid.NewGuid();

            CustomerLogin = customerLogin.CheckValue();

            Products = products?.ToList() ?? throw new ArgumentNullException(nameof(products));

            TotalInUsDollars = totalInUsDollars;
            
            OrderDateTime = orderDateTime ?? DateTimeOffset.Now;
        }
        
        public Guid Id { get; private set; }
        
        public string CustomerLogin { get; private set; }

        public List<Product> Products { get; private set; }
        
        public double TotalInUsDollars { get; private set; }
        
        public DateTimeOffset OrderDateTime { get; private set; }
    }
}