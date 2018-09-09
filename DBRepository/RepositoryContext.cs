using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DBRepository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        public DbSet<Market> Markets { get; set; }
        public DbSet<MarketProduct> MarketProducts { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
