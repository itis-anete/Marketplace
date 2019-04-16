using System;

namespace MarketPlace.DbAccess
{
    internal abstract class PgRepositoryBase
    {
        protected readonly ApplicationContext applicationContext;

        protected PgRepositoryBase(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext
                ?? throw new ArgumentNullException(nameof(applicationContext));
        }
    }
}