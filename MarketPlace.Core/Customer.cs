using System;

namespace MarketPlace.Core
{
    public class Customer
    {
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
        }
        
        public Guid Id { get; private set; }
        
        public string Login { get; private set; }
        
        public int PasswordHash { get; private set; }
    }
}