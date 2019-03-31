using System.Collections.Generic;
using MarketPlace.Core;

namespace MarketPlace.DbAccess
{
    public interface IUnitOfWork
    {
        IMarketRepository MarketRepository { get; }
        
        IProductRepository ProductRepository { get; }
    }
}