using System;
using System.Collections.Generic;
using Marketplace.Core;

namespace Marketplace.DbAccess
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllMarketProducts(string marketName);

        Product GetProductById(Guid productId);
        
        void AddProduct(Product newProduct);

        void UpdateProduct(Product updatedProduct);

        void RemoveProduct(Product productToRemove);
    }
}