using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RivonHouse.Infrastructure.Repository
{
    public interface IGenericRepository
    {

    }

    public interface IGenericRepository<TEntity> : IGenericRepository where TEntity : class
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null, string includeProperties = "");
        // Only for Unit Test
        IQueryable<TEntity> Get();
        TEntity Insert(TEntity entity);
        TEntity GetById(object id);
        void DeleteById(object id);
        void Delete(TEntity entityToDelete);
        void Delete(Expression<Func<TEntity, bool>> deletedEntitiesFilter);
        TEntity Attach(TEntity entity);
    }
}
