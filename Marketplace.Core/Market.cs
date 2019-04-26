using System;
using System.Collections.Generic;
using System.Linq;
using Marketplace.Infrastructure;

namespace Marketplace.Core
{
    public class Market
    {
        private List<ProductCategory> productsCategories;
        private List<Product> products;
    
        private Market()
        {
        }

        public Market(string name, List<ProductCategory> initialCategories = null)
        {           
            Name = name.CheckValue();
            
            productsCategories = initialCategories ?? new List<ProductCategory>();

            products = new List<Product>();
        }
        
        public string Name { get; set; }

        public IEnumerable<ProductCategory> ProductsCategories => productsCategories.AsEnumerable();

        public IEnumerable<Product> ProductInfos => products;
    }
}