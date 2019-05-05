using System;
using System.Collections.Generic;
using System.Linq;
using Marketplace.Core;

namespace Marketplace.DbAccess
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

        public Market GetMarketByName(string marketName)
        {
            return applicationContext.Markets
                .FirstOrDefault(market =>
                    string.Equals(market.Name, marketName, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<Market> GetMarketsByCategory(ProductCategory productCategory)
        {
            bool IsMarketContainsRequiredCategory(Market market)
                => market.ProductsCategories.Any(category => category.Equals(productCategory));
            
            return applicationContext.Markets
                .Where(IsMarketContainsRequiredCategory);
        }
        
        public void AddMarket(Market newMarket)
        {            
            applicationContext.Markets.Add(newMarket);
            applicationContext.SaveChanges();
        }

        public void UpdateMarket(Market updatedMarket)
        {
            applicationContext.Markets.Update(updatedMarket);
            applicationContext.SaveChanges();
        }

        public void RemoveMarket(string marketToRemoveName)
        {
            var marketToRemove = applicationContext.Markets.Find(marketToRemoveName);

            if (marketToRemove == null)
            {
                return;
            }
            
            applicationContext.Markets.Remove(marketToRemove);
            applicationContext.SaveChanges();
        }
    }
}