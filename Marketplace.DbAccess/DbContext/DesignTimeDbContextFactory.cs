using Marketplace.Infrastructure;
using Microsoft.EntityFrameworkCore.Design;

namespace Marketplace.DbAccess
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