using System;
using System.Collections.Generic;
using System.Text;
using RivonHouse.Infrastructure.Business;
using RivonHouse.Infrastructure.Repository;

namespace RivonHouse.Business
{
    public class Base<TEntity> : IBase<TEntity> where TEntity : class
    {
        protected IUnitOfWorkFactory<IUnitOfWork> UowFac { get; set; }

        public IEnumerable<TEntity> GetAll()
        {
            using (var uow = UowFac.Create())
            {
                return uow.Repository<TEntity>().Get();
            }
        }

        public void Create( TEntity entity)
        {
            using (var uow = UowFac.Create())
            {
                uow.Repository<TEntity>().Insert(entity);
                uow.Save();
            }
        }
    }
}
