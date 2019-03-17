using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MarketPlace.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("");
        }
    }
}