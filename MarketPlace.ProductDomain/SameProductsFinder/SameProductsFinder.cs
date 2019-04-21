using System.Collections.Generic;
using System.Linq;
using MarketPlace.Core;
using MarketPlace.DbAccess;

namespace MarketPlace.ProductDomain
{
    public class SameProductsFinder : ISameProductsFinder
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductSimilarityCalculator productSimilarityCalculator;
        
        public SameProductsFinder(IUnitOfWork unitOfWork, IProductSimilarityCalculator productSimilarityCalculator)
        {
            this.unitOfWork = unitOfWork;
            this.productSimilarityCalculator = productSimilarityCalculator;
        }

        public IEnumerable<ProductInfo> GetSameProducts(Product product)
        {
            var marketsWithSameCategories = unitOfWork.MarketRepository.GetAllMarkets()
                .Where(market => MarketCategoriesPredicate(market, product.AssociatedCategories));

            return marketsWithSameCategories
                .SelectMany(GetProductInfos)
                .Where(productInfo => productSimilarityCalculator.AreProductsSame(productInfo.Product, product));
        }
        
        private static bool MarketCategoriesPredicate(Market market,
            IEnumerable<ProductCategory> productCategories)
        {
            return market.ProductsCategories.Any(productCategories.Contains);
        }

        private IEnumerable<ProductInfo> GetProductInfos(Market market)
        {
            return unitOfWork.ProductRepository.GetAllMarketProductInfos(market.Name);
        }
    }
}