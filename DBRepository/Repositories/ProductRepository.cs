using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DBRepository.Repositories
{
    public class ProductRepository: BaseRepository, IProductRepository
    {
        public ProductRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }

        public async Task<List<Product>> GetProducts()
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString)) // 1
            {
                return await context.Products.ToListAsync(); ;
            }
        }
    }
}
