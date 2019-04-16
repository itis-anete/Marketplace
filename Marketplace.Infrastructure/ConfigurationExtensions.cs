using Microsoft.Extensions.Configuration;

namespace MarketPlace.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static string GetLocalDbConnectionString(this IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("LocalConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ConfigurationException("Connection string for local database is not configured.");
            }
            return connectionString;
        }
    }
}