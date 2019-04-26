using Marketplace.Core;

namespace Marketplace.ProductDomain
{
    public interface IProductSimilarityCalculator
    {
        bool AreProductsSame(Product firstProduct, Product secondProduct);
    }
}