using System;

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
            if (string.IsNullOrEmpty(categoryName))
            {
                throw new ArgumentException(nameof(categoryName));
            }
        }
         
        public Guid Id { get; private set; }
        
        public string CategoryName { get; private set; }
    }
}