using System;
using MarketPlace.Infrastructure;

namespace MarketPlace.Core
{
    public class ProductsCategory
    {
        private ProductsCategory()
        {
        }

        public ProductsCategory(string categoryName)
        {
            Id = Guid.NewGuid();
            
            CategoryName = categoryName.CheckValue();
        }
         
        public Guid Id { get; private set; }
        
        public string CategoryName { get; private set; }
    }
}