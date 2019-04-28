using System;
using System.Collections.Generic;
using System.Linq;
using Marketplace.Infrastructure;

namespace Marketplace.Core
{
    public class Market
    { 
        private Market()
        {
        }

        public Market(string name, IEnumerable<ProductCategory> initialCategories = null)
        {           
            Name = name.CheckValue();
            
            ProductsCategories = initialCategories?.ToList() ?? new List<ProductCategory>();

            Products = new List<Product>();
        }
        
        public string Name { get; set; }

        public List<ProductCategory> ProductsCategories { get; private set; }
        public List<Product> Products { get; private set; }
    }
}