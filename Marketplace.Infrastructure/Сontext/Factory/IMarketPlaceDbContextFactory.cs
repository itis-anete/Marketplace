namespace Marketplace.Infrastructure.Сontext.Factory
{
    public interface IMarketPlaceDbContextFactory
    {
        MarketPlaceDbContext CreateDbContext(string connectionString);
    }
}