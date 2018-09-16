using Marketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Сontext
{
    public class MarketPlaceDbContext : DbContext
    {
        public MarketPlaceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Market> Markets { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<MarketProduct> MarketProducts { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
