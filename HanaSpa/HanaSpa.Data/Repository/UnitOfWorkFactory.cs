using System;
using System.Collections.Generic;
using System.Text;
using RhRepo = RivonHouse.Data.Repository;
using HsRepo = HanaSpa.Data.Repository;
using Microsoft.AspNetCore.Http;
using RivonHouse.Infrastructure.Repository;
using HanaSpa.Data.DbContext;

namespace HanaSpa.Data.Repository
{
    public class UnitOfWorkFactory<TUnitOfWork, TDbContext> : IUnitOfWorkFactory<TUnitOfWork>
    where TUnitOfWork : UnitOfWork
    where TDbContext : HanaSpaContext
    {
        private HanaSpaContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnitOfWorkFactory(HanaSpaContext context, IHttpContextAccessor httpContextAccessor)
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
