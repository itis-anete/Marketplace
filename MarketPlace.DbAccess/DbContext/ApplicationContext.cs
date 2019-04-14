using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MarketPlace.Core;
using MarketPlace.Infrastructure;

namespace MarketPlace.DbAccess
{
    internal class ApplicationContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public DbSet<Customer> Customers { get; private set; }
        
        public DbSet<Address> Addresses { get; private set; }
        
        public DbSet<Market> Markets { get; private set; }
        
        public DbSet<ProductInfo> ProductInfos { get; private set; }
        
        public DbSet<ProductCategory> ProductsCategories { get; private set; }
        
        public DbSet<Product> Products { get; private set; }
        
        public DbSet<Order> Orders { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetLocalDbConnectionString();
            optionsBuilder.UseNpgsql(connectionString);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Market>()
                .HasKey(market => market.Name);
        }
    }
}