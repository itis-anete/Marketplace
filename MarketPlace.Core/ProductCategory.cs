using System;
using MarketPlace.Infrastructure;

namespace MarketPlace.Core
{
    public class ProductCategory : IEquatable<ProductCategory>
    {
        private ProductCategory()
        {
        }

        public ProductCategory(string categoryName)
        {
            Id = Guid.NewGuid();
            
            CategoryName = categoryName.CheckValue();
        }
         
        public Guid Id { get; private set; }
        
        public string CategoryName { get; private set; }

        #region Comparison
        public bool Equals(ProductCategory other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(CategoryName, other.CategoryName, StringComparison.InvariantCultureIgnoreCase);
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
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(CategoryName);
        }
        #endregion
    }
}