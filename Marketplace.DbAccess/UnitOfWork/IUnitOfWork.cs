namespace Marketplace.DbAccess
{
    public interface IUnitOfWork
    {
        IMarketRepository MarketRepository { get; }
        
        IProductRepository ProductRepository { get; }
        
        IOrderRepository OrderRepository { get; }
    }
}