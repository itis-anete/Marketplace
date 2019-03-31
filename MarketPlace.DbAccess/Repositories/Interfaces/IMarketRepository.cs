using System.Collections.Generic;
using MarketPlace.Core;

namespace MarketPlace.DbAccess
{
    public interface IMarketRepository
    {
        IEnumerable<Market> GetAllMarkets();
    }
}