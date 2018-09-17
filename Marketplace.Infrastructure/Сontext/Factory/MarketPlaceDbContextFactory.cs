using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Сontext.Factory
{
    public class MarketPlaceDbContextFactory : IMarketPlaceDbContextFactory
    {
        public MarketPlaceDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MarketPlaceDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new MarketPlaceDbContext(optionsBuilder.Options);
        }
    }
}
