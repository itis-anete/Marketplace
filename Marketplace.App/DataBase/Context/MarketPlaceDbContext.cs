using Marketplace.App.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.App.DataBase.Context
{
    public class MarketPlaceDbContext : DbContext
    {
        public MarketPlaceDbContext(DbContextOptions opt) :base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Market> Markets { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Marketplace.App.DataBase.Entities.MarketProduct> MarketProduct { get; set; }
    }
}