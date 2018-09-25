using System.Threading.Tasks;
using Marketplace.Infrastructure.Repositories;
using Marketplace.Models;
using Marketplace.Models.ProductData;

namespace Marketplace.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        BaseRepository<ProductOffer> ProductOfferRepository { get; }
        BaseRepository<Market> MarketRepository { get; }
        BaseRepository<Product> ProductRepository { get; }
        BaseRepository<User> UserRepository { get; }

        void Dispose();
        Task<int> Save();
    }
}