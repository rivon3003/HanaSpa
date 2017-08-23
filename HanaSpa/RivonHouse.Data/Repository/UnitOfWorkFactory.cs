using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RivonHouse.Infrastructure.Repository;

namespace RivonHouse.Data.Repository
{
    public class UnitOfWorkFactory<TUnitOfWork, TDbContext> : IUnitOfWorkFactory<TUnitOfWork>
        where TUnitOfWork : UnitOfWork
        where TDbContext : DbContext
    {
        private DbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnitOfWorkFactory(DbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public virtual TUnitOfWork Create()
        {
            return Activator.CreateInstance(typeof(TUnitOfWork), _context, _httpContextAccessor) as TUnitOfWork;
        }
    }
}
