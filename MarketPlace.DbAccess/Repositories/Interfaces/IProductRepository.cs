using System.Collections.Generic;
using MarketPlace.Core;

namespace MarketPlace.DbAccess
{
    public interface IProductRepository
    {
        IEnumerable<ProductInfo> GetAllMarketProductInfos(string marketName);

        void AddProductInfo(ProductInfo newProductInfo);
    }
}