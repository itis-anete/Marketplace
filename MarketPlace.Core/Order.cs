using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketPlace.Core
{
    public class Order
    {
        private readonly IList<Product> products;
        
        private Order()
        {
        }

        public Order(Customer customer, List<Product> products, DateTime orderDateTime)
        {
            Id = Guid.NewGuid();
            
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));

            if (products == null || products.Any(product => product == null))
            {
                throw new ArgumentException(nameof(products));
            }
            this.products = products;
            
            OrderDateTime = orderDateTime;
        }
        
        public Guid Id { get; private set; }
        
        public Customer Customer { get; private set; }

        public IEnumerable<Product> Products => products.AsEnumerable();
        
        public DateTime OrderDateTime { get; private set; }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            products.Remove(product);
        }
    }
}