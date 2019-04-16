using MarketPlace.Infrastructure;
using Microsoft.EntityFrameworkCore.Design;

namespace MarketPlace.DbAccess
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var configuration = ConfigurationFactory.CreateConfiguration();
            return new ApplicationContext(configuration);
        }
    }
}