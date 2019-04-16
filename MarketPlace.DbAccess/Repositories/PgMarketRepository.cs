using System;
using System.Collections.Generic;
using MarketPlace.Core;

namespace MarketPlace.DbAccess
{
    internal class PgMarketRepository : PgRepositoryBase, IMarketRepository
    {
        public PgMarketRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {
        }
        
        public IEnumerable<Market> GetAllMarkets()
        {
            return applicationContext.Markets;
        }

        public void AddMarket(Market newMarket)
        {
            applicationContext.Markets.Add(newMarket);
            applicationContext.SaveChanges();
        }
    }
}