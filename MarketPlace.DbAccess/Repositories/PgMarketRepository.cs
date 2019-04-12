using System;
using System.Collections.Generic;
using MarketPlace.Core;

namespace MarketPlace.DbAccess
{
    internal class PgMarketRepository : IMarketRepository
    {
        private readonly ApplicationContext applicationContext;

        internal PgMarketRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext
                ?? throw new ArgumentNullException(nameof(applicationContext));
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