using System;
using System.Collections.Generic;
using MarketPlace.Core;

namespace MarketPlace.DbAccess
{
    public class PgUnitOfWork : IUnitOfWork
    {
        public PgUnitOfWork(ApplicationContext applicationContext)
        {
            if (applicationContext == null)
            {
                throw new ArgumentNullException(nameof(applicationContext));
            }
            
            MarketRepository = new PgMarketRepository(applicationContext);
            ProductRepository = new PgProductRepository(applicationContext);
        }
        
        public IMarketRepository MarketRepository { get; }
        
        public IProductRepository ProductRepository { get; }
    }
}