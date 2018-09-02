using Marketplace.App.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.App.DataBase.Context
{
    public class MarketPlaceDbContext : DbContext
    {
        public MarketPlaceDbContext(DbContextOptions opt) :base(opt)
        {

        }

        public DbSet<Market> Markets { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Marketplace.App.DataBase.Entities.MarketProduct> MarketProduct { get; set; }
    }
}