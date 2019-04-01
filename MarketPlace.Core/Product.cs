using System;
using System.Collections.Generic;

namespace MarketPlace.Core
{
    public class Product : IEquatable<Product>
    {
        private Product()
        {
        }

        public Product(string name)
        {
            Id = Guid.NewGuid();
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }
            Name = name;
        }
        
        public Guid Id { get; private set; }
        
        public string Name { get; private set; }
        
        public byte[] Image { get; private set; }
        //свойства товара
        public List<Properties> Properties { get; private set; }

        public Point Ball { get; private set; }
        B
        #region Comparison
        public bool Equals(Product other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id) && string.Equals(Name, other.Name) && Equals(Image, other.Image);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Image != null ? Image.GetHashCode() : 0);
                return hashCode;
            }
        }
        #endregion
    }
}