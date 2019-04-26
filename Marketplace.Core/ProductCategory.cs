using System;
using Marketplace.Infrastructure;

namespace Marketplace.Core
{
    public class ProductCategory : IEquatable<ProductCategory>
    {
        private ProductCategory()
        {
        }

        public ProductCategory(string categoryName)
        {
            Id = Guid.NewGuid();
            
            Name = categoryName.CheckValue();
        }
         
        public Guid Id { get; private set; }
        
        public string Name { get; private set; }

        #region Comparison
        public bool Equals(ProductCategory other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ProductCategory) obj);
        }

        public override int GetHashCode()
        {
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(Name);
        }
        #endregion
    }
}