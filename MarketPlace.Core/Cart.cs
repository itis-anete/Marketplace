using System.Collections.Generic;
using System.Linq;

namespace MarketPlace.Core
{
    public class Cart
    {
        private Cart()
        {
        }
        
        public Customer Customer { get; private set; }
        
        public IEnumerable<ProductInfo> ProductInfos { get; private set; }

        public double GetTotalInUsDollarsWithoutDiscounts()
            =>ProductInfos.Sum(productInfo => productInfo.PriceInUsDollars * productInfo.Quantity);
        
        public double TotalInUsDollarsWithDiscounts { get; private set; }
    }
}