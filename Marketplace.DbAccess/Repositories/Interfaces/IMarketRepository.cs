using System.Collections.Generic;
using Marketplace.Core;

namespace Marketplace.DbAccess
{
    public interface IMarketRepository
    {
        IEnumerable<Market> GetAllMarkets();

        Market GetMarketByName(string marketName);

        IEnumerable<Market> GetMarketsByCategory(string categoryName);
        
        void AddMarket(Market newMarket);

        void UpdateMarket(Market updatedMarket);

        void RemoveMarket(Market marketToRemove);
    }
}