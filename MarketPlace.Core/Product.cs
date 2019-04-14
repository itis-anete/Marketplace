using System;
using System.Collections.Generic;
using System.Linq;
using MarketPlace.Infrastructure;

namespace MarketPlace.Core
{
    public class Product : ICounterpart<Product>
    {
        private List<ProductCategory> associatedCategories;
        
        private Product()
        {
        }

        public Product(string name, string description, IEnumerable<ProductCategory> associatedCategories)
        {
            Id = Guid.NewGuid();
            
            Name = name.CheckValue();
            
            Description = description.CheckValue();

            this.associatedCategories = associatedCategories?.ToList()
                ?? throw new ArgumentNullException(nameof(associatedCategories));
        }
        
        public Guid Id { get; private set; }
        
        public string Name { get; private set; }
        
        public string Description { get; private set; }

        public IEnumerable<ProductCategory> AssociatedCategories => associatedCategories;

        double ICounterpart<Product>.GetSimilarityCoefficient(Product other)
        {
            return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase)
                ? 1.0
                : 0.0;
        }
    }
}