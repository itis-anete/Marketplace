using System;
using System.Collections.Generic;
using System.Linq;
using MarketPlace.Infrastructure;
using MarketPlace.Core;

namespace MarketPlace.DbAccess
{
    internal class PgProductRepository : PgRepositoryBase, IProductRepository
    {
        public PgProductRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {
        }

        public IEnumerable<ProductInfo> GetAllMarketProductInfos(string marketName)
        {
            var marketToGetProductsFrom = applicationContext.Markets
                .Find(marketName);

            if (marketToGetProductsFrom == null)
            {
                throw new ArgumentException($"Market '{marketName}' is not found.");
            }

            return marketToGetProductsFrom.ProductInfos;
        }

        public void AddProductInfo(ProductInfo newProductInfo)
        {
            applicationContext.ProductInfos.Add(newProductInfo);
            applicationContext.SaveChanges();
        }

        public IEnumerable<ProductInfo> GetSameProducts(Product product)
        {
            bool ProductInfoPredicate(ProductInfo productInfo)
            {
                var counterpartProduct = productInfo.Product as ICounterpart<Product>;
                return counterpartProduct.GetSimilarityCoefficient(product) >= 0.5;
            }
            
            return applicationContext.ProductInfos
                .Where(ProductInfoPredicate);
        }
    }
}