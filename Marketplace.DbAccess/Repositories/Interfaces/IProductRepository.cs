using System.Collections.Generic;
using Marketplace.Core;

namespace Marketplace.DbAccess
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllMarketProducts(string marketName);

        void AddProduct(Product newProduct);

        void UpdateProduct(Product updatedProduct);

        void RemoveProduct(Product productToRemove);
    }
}