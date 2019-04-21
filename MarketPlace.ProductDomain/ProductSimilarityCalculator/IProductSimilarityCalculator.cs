using MarketPlace.Core;

namespace MarketPlace.ProductDomain
{
    public interface IProductSimilarityCalculator
    {
        bool AreProductsSame(Product firstProduct, Product secondProduct);
    }
}