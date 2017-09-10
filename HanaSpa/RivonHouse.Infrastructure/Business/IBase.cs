using System;
using System.Collections.Generic;
using System.Text;
using RivonHouse.Infrastructure.Repository;

namespace RivonHouse.Infrastructure.Business
{
    public interface IBase<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        void Create(TEntity entity);
    }
}
