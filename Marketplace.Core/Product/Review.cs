using System;
using System.Security.Cryptography;
using Marketplace.Infrastructure;

namespace Marketplace.Core
{
    public class Review : IEquatable<Review>
    {
        private Review()
        {
        }
        
        public Review(string customerLogin, double rate, string text = null)
        {
            Id = Guid.NewGuid();
            CustomerLogin = customerLogin.CheckValue();
            Rate = rate;
            Text = text;
        }
        
        public Guid Id { get; private set; }

        public string CustomerLogin { get; private set; }
        
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

        #region Comparison
        public bool Equals(Review other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Review) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion
    }
}