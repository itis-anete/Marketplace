using System;
using System.Threading.Tasks;
using Marketplace.Infrastructure.Repositories;
using Marketplace.Infrastructure.Сontext;
using Marketplace.Infrastructure.Сontext.Factory;
using Marketplace.Models;
using Marketplace.Models.ProductData;

namespace Marketplace.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly MarketPlaceDbContext _context;

        public UnitOfWork(string connectionString, IMarketPlaceDbContextFactory context)
        {
            _context = context.CreateDbContext(connectionString);
        }

        private BaseRepository<Product> _productRepository;
        private BaseRepository<Market> _marketRepository;
        private BaseRepository<ProductOffer> _productOfferRepository;
        private BaseRepository<User> _userRepository;

        public BaseRepository<Product> ProductRepository =>
            _productRepository ?? (_productRepository = new BaseRepository<Product>(_context));

        public BaseRepository<Market> MarketRepository =>
            _marketRepository ?? (_marketRepository = new BaseRepository<Market>(_context));

        public BaseRepository<ProductOffer> ProductOfferRepository =>
            _productOfferRepository ?? (_productOfferRepository = new BaseRepository<ProductOffer>(_context));

        public BaseRepository<User> UserRepository =>
            _userRepository ?? (_userRepository = new BaseRepository<User>(_context));

        public Task<int> Save() => _context.SaveChangesAsync();

        public void Dispose()
        {
            _context?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
