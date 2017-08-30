using System;
using System.Collections.Generic;
using System.Text;

namespace RivonHouse.Infrastructure.Business
{
    public interface IBase<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        void Create();
    }
}
