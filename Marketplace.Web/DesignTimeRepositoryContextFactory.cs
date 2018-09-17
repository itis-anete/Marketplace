using System.IO;
using Marketplace.Infrastructure.Сontext;
using Marketplace.Infrastructure.Сontext.Factory;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Web
{
    public class DesignTimeRepositoryContextFactory : IDesignTimeDbContextFactory<MarketPlaceDbContext>
    {
        public MarketPlaceDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            var repositoryFactory = new MarketPlaceDbContextFactory();
            return repositoryFactory.CreateDbContext(connectionString);
        }
    }
}
