using System;

namespace MarketPlace.Core
{
    public class ProductInfo
    {
        private ProductInfo()
        {
        }

        public ProductInfo(Market market, Product product,
            double priceInUsDollars, uint quantity)
        {
            Id = Guid.NewGuid();
            
            Market = market ?? throw new ArgumentNullException(nameof(market));
            Product = product ?? throw new ArgumentNullException(nameof(product));
            PriceInUsDollars = priceInUsDollars;
            Quantity = quantity;
        }
        
        public Guid Id { get; private set; }
        
        public Market Market { get; private set; }
        
        public Product Product { get; private set; }
        
        public double PriceInUsDollars { get; set; }
        
        public byte RatingInStars { get; set; }
        
        public uint Quantity { get; set; }
    }
}