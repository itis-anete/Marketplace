using System.Collections.Generic;
using MarketPlace.Core;

namespace MarketPlace.DbAccess
{
    public interface IMarketRepository
    {
        IEnumerable<Market> GetAllMarkets();

        void AddMarket(Market newMarket);

        Market GetMarketByName(string marketName);

        IEnumerable<Market> GetMarketsByCategory(string categoryName);
    }
}