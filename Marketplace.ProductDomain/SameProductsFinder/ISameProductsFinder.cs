using System.Collections.Generic;
using Marketplace.Core;

namespace Marketplace.ProductDomain
{
    public interface ISameProductsFinder
    {
        IEnumerable<Product> GetSameProducts(Product product);
    }
}