using System;
using System.Collections.Generic;
using System.Text;

namespace RivonHouse.Infrastructure.Repository
{
    public interface IUnitOfWorkFactory<out TUnitOfWork> where TUnitOfWork : IUnitOfWork
    {
        TUnitOfWork Create();
    }
}
