using Microsoft.Extensions.Configuration;

namespace Marketplace.DbAccess
{
    public class PgUnitOfWork : IUnitOfWork
    {
        public PgUnitOfWork(IConfiguration configuration)
        {
            var applicationContext = new ApplicationContext(configuration);
            
            MarketRepository = new PgMarketRepository(applicationContext);
            ProductRepository = new PgProductRepository(applicationContext);
            OrderRepository = new PgOrderRepository(applicationContext);
            CartRepository = new PgCartRepository(applicationContext);
            CustomerRepository = new PgCustomerRepository(applicationContext);
            AuctionRepository = new PgAuctionRepository(applicationContext);
        }
        
        public IMarketRepository MarketRepository { get; }
        
        public IProductRepository ProductRepository { get; }
        
        public IOrderRepository OrderRepository { get; }
        
        public ICartRepository CartRepository { get; }
        
        public ICustomerRepository CustomerRepository { get; }
        
        public IAuctionRepository AuctionRepository { get; }
    }
}