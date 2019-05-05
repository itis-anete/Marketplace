using System.Collections.Generic;
using Marketplace.Core;

namespace Marketplace.DbAccess
{
    public interface IMarketRepository
    {
        IEnumerable<Market> GetAllMarkets();

        Market GetMarketByName(string marketName);

        IEnumerable<Market> GetMarketsByCategory(ProductCategory productCategory);
        
        void AddMarket(Market newMarket);

        void UpdateMarket(Market updatedMarket);

        void RemoveMarket(string marketToRemoveName);
    }
}