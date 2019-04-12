using Microsoft.Extensions.Configuration;

namespace MarketPlace.DbAccess
{
    public class PgUnitOfWork : IUnitOfWork
    {
        public PgUnitOfWork(IConfiguration configuration)
        {
            var applicationContext = new ApplicationContext(configuration);
            
            MarketRepository = new PgMarketRepository(applicationContext);
            ProductRepository = new PgProductRepository(applicationContext);
        }
        
        public IMarketRepository MarketRepository { get; }
        
        public IProductRepository ProductRepository { get; }
    }
}