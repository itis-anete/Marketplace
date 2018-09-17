using System.Collections.Generic;

namespace Marketplace.Models
{
    public class Market : Identity
    {
        public string Name { get; set; }

        public List<MarketProduct> Products { get; set; }
    }
}