using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketPlace.Core
{
    public class Order
    {
        private readonly List<Product> products;
        
        private Order()
        {
        }

        public Order(Customer customer, IEnumerable<Product> products, DateTime orderDateTime, Address deliveryAddress)
        {
            Id = Guid.NewGuid();
            
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));

            if (products == null || products.Any(product => product == null))
            {
                throw new ArgumentException(nameof(products));
            }
            this.products = products.ToList();
            
            OrderDateTime = orderDateTime;

            DeliveryAddress = deliveryAddress;
        }
        
        public Guid Id { get; private set; }
        
        public Customer Customer { get; private set; }
        
        public Address DeliveryAddress { get; private set; }

        public bool WillBePickedUpByCustomer => DeliveryAddress == null;

        public IEnumerable<Product> Products => products.AsEnumerable();
        
        public DateTime OrderDateTime { get; private set; }
    }
}