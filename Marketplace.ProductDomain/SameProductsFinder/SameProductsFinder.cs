using System.Collections.Generic;
using System.Linq;
using Marketplace.Core;
using Marketplace.DbAccess;

namespace Marketplace.ProductDomain
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

        public IEnumerable<Product> GetSameProducts(Product product)
        {
            var marketsWithSameCategories = unitOfWork.MarketRepository.GetAllMarkets()
                .Where(market => MarketCategoriesPredicate(market, product.AssociatedCategories));

            return marketsWithSameCategories
                .SelectMany(GetMarketProducts)
                .Where(marketProduct => productSimilarityCalculator.AreProductsSame(marketProduct, product));
        }
        
        private static bool MarketCategoriesPredicate(Market market,
            IEnumerable<ProductCategory> productCategories)
        {
            return market.ProductsCategories.Any(productCategories.Contains);
        }

        private IEnumerable<Product> GetMarketProducts(Market market)
        {
            return unitOfWork.ProductRepository.GetAllMarketProducts(market.Name);
        }
    }
}