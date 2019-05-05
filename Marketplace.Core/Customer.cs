using System;
using System.Collections.Generic;
using Marketplace.Infrastructure;

namespace Marketplace.Core
{
    public class Customer : IEquatable<Customer>
    {    
        private Customer()
        {
        }

        public Customer(string login, int passwordHash, DateTime dateOfBirth)
        {
            Login = login.CheckValue();
            
            PasswordHash = passwordHash;

            DateOfBirth = dateOfBirth;
        }
        
        public string Login { get; private set; }
        
        public int PasswordHash { get; private set; }
        
        public DateTime DateOfBirth { get; private set; }

        #region Comparison
        public bool Equals(Customer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Login, other.Login);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Customer) obj);
        }

        public override int GetHashCode()
        {
            return (Login != null ? Login.GetHashCode() : 0);
        }
        #endregion
    }
}