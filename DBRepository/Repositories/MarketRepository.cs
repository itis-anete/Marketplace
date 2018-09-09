using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DBRepository.Repositories
{
    public class MarketRepository: BaseRepository, IMarketRepository
    {
        public MarketRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }

        public async Task<List<Market>> GetMarkets()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Markets.ToListAsync(); ;
            }
        }
    }
}

