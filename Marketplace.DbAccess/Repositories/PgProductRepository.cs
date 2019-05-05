using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Marketplace.Core;
using Marketplace.Infrastructure;

namespace Marketplace.DbAccess
{
    internal class PgProductRepository : PgRepositoryBase, IProductRepository
    {
        public PgProductRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {
        }

        public IEnumerable<Product> GetAllMarketProducts(string marketName)
        {
            return applicationContext.Products
                .Where(product => string.Equals(product.MarketName, marketName,
                    StringComparison.InvariantCultureIgnoreCase));
        }

        public Product GetProductById(Guid productId)
        {
            return applicationContext.Products.Find(productId);
        }

        public void AddProduct(Product newProduct)
        {
            applicationContext.Products.Add(newProduct);
            applicationContext.SaveChanges();
        }

        public void UpdateProduct(Product updatedProduct)
        {
            applicationContext.Products.Update(updatedProduct);
            applicationContext.SaveChanges();
        }

        public void RemoveProduct(Product productToRemove)
        {
            applicationContext.Products.Remove(productToRemove);
            applicationContext.SaveChanges();
        }
    }
}