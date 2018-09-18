using System.Collections.Generic;

namespace Marketplace.Models
{
    public class Product : Identity
    {
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public List<MarketProduct> InMarkets { get; set; }
    }
}