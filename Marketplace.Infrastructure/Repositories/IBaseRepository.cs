﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Marketplace.Models;

namespace Marketplace.Infrastructure.Repositories
{
    interface IBaseRepository<TEntity> where TEntity : class
    {
        void Delete(TEntity entityToDelete);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}