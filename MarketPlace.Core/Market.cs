using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketPlace.Core
{
    public class Market
    {
        private readonly List<ProductsCategory> productsCategories;
    
        private Market()
        {
        }

        public Market(string name, List<ProductsCategory> initialCategories)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }
            if (initialCategories == null || initialCategories.Any(category => category == null))
            {
                throw new ArgumentException(nameof(initialCategories));
            }
            productsCategories = initialCategories;
        }
        
        public Guid Id { get; private set; }
        
        public string Name { get; private set; }

        public IEnumerable<ProductsCategory> ProductsCategories => productsCategories.AsEnumerable();
    }
}