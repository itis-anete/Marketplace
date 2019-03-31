using System;
using System.Collections.Generic;
using MarketPlace.Core;

namespace MarketPlace.DbAccess
{
    public class PgMarketRepository : IMarketRepository
    {
        private readonly ApplicationContext applicationContext;

        public PgMarketRepository(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext
                ?? throw new ArgumentNullException(nameof(applicationContext));
        }
        
        public IEnumerable<Market> GetAllMarkets()
        {
            return applicationContext.Markets;
        }
    }
}