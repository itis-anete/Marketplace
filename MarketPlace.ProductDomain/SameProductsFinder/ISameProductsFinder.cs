using System.Collections.Generic;
using MarketPlace.Core;

namespace MarketPlace.ProductDomain
{
    public interface ISameProductsFinder
    {
        IEnumerable<ProductInfo> GetSameProducts(Product product);
    }
}