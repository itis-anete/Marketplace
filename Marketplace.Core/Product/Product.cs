using System;
using System.Collections.Generic;
using System.Linq;
using Marketplace.Core.Discounts;
using Marketplace.Infrastructure;

namespace Marketplace.Core
{
    public class Product
    {
        private Product()
        {
        }

        public Product(string name, 
            string description,
            string marketName,
            IEnumerable<ProductCategory> associatedCategories)
        {
            Id = Guid.NewGuid();
            Name = name.CheckValue();
            Description = description.CheckValue();
            MarketName = marketName.CheckValue();
            AssociatedCategories = associatedCategories.ToList();

            Reviews = new List<Review>();
            Discounts = new List<DiscountBase>();
        }
        
        public Guid Id { get; set; }
      
        public string Name { get; set; }
        
        public string Description { get; set; }

        public List<ProductCategory> AssociatedCategories { get; private set; }
        
        public List<Review> Reviews { get; private set; }
        
        public List<DiscountBase> Discounts { get; private set; }

        public double Rating => Reviews.Sum(review => review.Rate) / Reviews.Count;
        
        public string MarketName { get; private set; }
        
        public double BasePriceInUsDollars { get; private set; }

        public uint Quantity { get; set; }
    }
}