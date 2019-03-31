using System.Collections.Generic;
using MarketPlace.Core;

namespace MarketPlace.DbAccess
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllMarketProducts(string marketName);

        void AddProduct(Product newProduct);
    }
}