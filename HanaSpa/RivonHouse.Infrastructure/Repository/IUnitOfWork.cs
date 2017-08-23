using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RivonHouse.Infrastructure.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void Save();
        //Task<SaveResultModel> SaveAsync();
        //DbContext GetContext();
    }
}
