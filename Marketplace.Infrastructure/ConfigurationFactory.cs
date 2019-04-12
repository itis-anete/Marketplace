using System.IO;
using Microsoft.Extensions.Configuration;

namespace MarketPlace.Infrastructure
{
    public static class ConfigurationFactory
    {
        public static IConfiguration CreateConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}