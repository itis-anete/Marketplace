using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MarketPlace.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfigurationRoot configurationRoot;

        public ApplicationContext(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configurationRoot.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ConfigurationException("Database connection string is not configured.");
            }
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}