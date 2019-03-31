using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketPlace.Core
{
    public class Market
    {
        private List<ProductsCategory> productsCategories;
        private List<Product> products;
    
        private Market()
        {
        }

        public Market(string name, List<ProductsCategory> initialCategories = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }
            productsCategories = initialCategories ?? new List<ProductsCategory>();

            products = new List<Product>();
        }
        
        public string Name { get; private set; }

        public IEnumerable<ProductsCategory> ProductsCategories => productsCategories.AsEnumerable();

        public IEnumerable<Product> Products => products.AsEnumerable();
    }
}