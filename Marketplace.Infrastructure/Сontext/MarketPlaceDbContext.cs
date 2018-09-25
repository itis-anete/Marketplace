using Marketplace.Models;
using Marketplace.Models.ProductData;
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

        public DbSet<ProductOffer> ProductOffers { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
