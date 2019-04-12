using System.Collections.Generic;
using MarketPlace.Infrastructure;
using MarketPlace.Core;

namespace MarketPlace.DbAccess
{
    internal class PgProductRepository : IProductRepository
    {
        private readonly ApplicationContext applicationContext;

        public PgProductRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public IEnumerable<Product> GetAllMarketProducts(string marketName)
        {
            var marketToGetProductsFrom = applicationContext.Markets
                .Find(marketName);

            if (marketToGetProductsFrom == null)
            {
                throw new MarketNotFoundException(marketName);
            }

            return marketToGetProductsFrom.Products;
        }

        public void AddProduct(Product newProduct)
        {
            applicationContext.Products.Add(newProduct);
            applicationContext.SaveChanges();
        }
    }
}