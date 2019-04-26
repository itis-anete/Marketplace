using System.IO;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Infrastructure
{
    public static class ConfigurationFactory
    {
        public static IConfiguration CreateConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();
        }
    }
}