using System;
using System.Collections.Generic;

namespace MarketPlace.Core
{
    public class Customer
    {
        private List<Address> deliveryAddresses;
        
        private Customer()
        {
        }

        public Customer(string login, int passwordHash)
        {
            Id = Guid.NewGuid();
            
            if (string.IsNullOrEmpty(login))
            {
                throw new ArgumentException(nameof(login));
            }
            Login = login;
            
            PasswordHash = passwordHash;
            
            deliveryAddresses = new List<Address>();
        }
        
        public Guid Id { get; private set; }
        
        public string Login { get; private set; }
        
        public int PasswordHash { get; private set; }

        public IEnumerable<Address> DeliveryAddresses => deliveryAddresses;
    }
}