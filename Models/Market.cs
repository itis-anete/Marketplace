using System.Collections.Generic;

namespace Models
{
    public class Market : Identity
    {
        public string Name { get; set; }

        public List<MarketProduct> Products { get; set; }
    }
}