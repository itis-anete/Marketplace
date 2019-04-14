namespace MarketPlace.DbAccess
{
    public interface IUnitOfWork
    {
        IMarketRepository MarketRepository { get; }
        
        IProductRepository ProductRepository { get; }
        
        IOrderRepository OrderRepository { get; }
    }
}