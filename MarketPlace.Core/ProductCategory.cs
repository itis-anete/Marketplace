using System;
using MarketPlace.Infrastructure;

namespace MarketPlace.Core
{
    public class ProductCategory
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
    }
}