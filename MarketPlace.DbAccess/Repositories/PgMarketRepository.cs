using System;
using System.Collections.Generic;
using System.Linq;
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

        public Market GetMarketByName(string marketName)
        {
            return applicationContext.Markets
                .FirstOrDefault(market =>
                    string.Equals(market.Name, marketName, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<Market> GetMarketsByCategory(string categoryName)
        {
            bool IsMarketContainsRequiredCategory(Market market)
            {
                return market.ProductsCategories.Any(category =>
                    string.Equals(category.Name, categoryName, StringComparison.InvariantCultureIgnoreCase));
            }
            
            return applicationContext.Markets
                .Where(IsMarketContainsRequiredCategory);
        }
    }
}