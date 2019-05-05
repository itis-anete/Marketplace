using System;
using System.Collections.Generic;
using System.Linq;
using Marketplace.Infrastructure;

namespace Marketplace.Core
{
    public class Market : IEquatable<Market>
    { 
        private Market()
        {
        }

        public Market(string name, IEnumerable<ProductCategory> initialCategories = null)
        {           
            Name = name.CheckValue();
            
            ProductsCategories = initialCategories?.ToList() ?? new List<ProductCategory>();
        }
        
        public string Name { get; set; }

        public List<ProductCategory> ProductsCategories { get; private set; }

        #region Comparison
        public bool Equals(Market other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Market) obj);
        }

        public override int GetHashCode()
        {
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(Name);
        }
        #endregion
    }
}