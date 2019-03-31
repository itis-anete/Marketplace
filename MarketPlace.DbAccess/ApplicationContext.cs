using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MarketPlace.Core;
using MarketPlace.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace MarketPlace.DbAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers { get; private set; }
        
        public DbSet<Address> Addresses { get; private set; }
        
        public DbSet<Market> Markets { get; private set; }
        
        public DbSet<ProductsCategory> ProductsCategories { get; private set; }
        
        public DbSet<Product> Products { get; private set; }
        
        public DbSet<Order> Orders { get; private set; }

        public static void OptionsAction(IServiceProvider serviceProvider, DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = serviceProvider.GetService<IConfiguration>();
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