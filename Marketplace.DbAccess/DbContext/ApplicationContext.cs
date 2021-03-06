using Marketplace.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Marketplace.Infrastructure;

namespace Marketplace.DbAccess
{
    internal class ApplicationContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public DbSet<Customer> Customers { get; private set; }
        
        public DbSet<Cart> Carts { get; private set; }
        
        public DbSet<Market> Markets { get; private set; }
        
        public DbSet<ProductCategory> ProductsCategories { get; private set; }
        
        public DbSet<Product> Products { get; private set; }
        
        public DbSet<Order> Orders { get; private set; }
        
        public DbSet<Auction> Auctions { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetLocalDbConnectionString();
            optionsBuilder.UseNpgsql(connectionString);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
//            modelBuilder.Entity<Product>()
//                .HasOne<Auction>()
//                .WithOne("ProductLotId");
//            
//            modelBuilder.Entity<Market>()
//                .HasMany<Auction>()
//                .WithOne("MarketName");
//
//            modelBuilder.Entity<Customer>()
//                .HasOne<Auction>()
//                .WithOne("WinnerLogin");
//
//            modelBuilder.Entity<Market>()
//                .HasMany<Product>()
//                .WithOne("MarketName");
//
//            modelBuilder.Entity<Customer>()
//                .HasMany<Order>()
//                .WithOne("CustomerLogin");
            
            modelBuilder.Entity<Customer>()
                .HasKey(customer => customer.Login);
            
            modelBuilder.Entity<Market>()
                .HasKey(market => market.Name);
        }
    }
}