using System.Threading.Tasks;
using Marketplace.Infrastructure.Repositories;
using Marketplace.Models;

namespace Marketplace.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        BaseRepository<MarketProduct> MarketProductRepository { get; }
        BaseRepository<Market> MarketRepository { get; }
        BaseRepository<Product> ProductRepository { get; }
        BaseRepository<User> UserRepository { get; }

        void Dispose();
        Task<int> Save();
    }
}