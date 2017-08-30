using System;
using System.Collections.Generic;
using System.Text;
using RhRepo = RivonHouse.Data.Repository;
using Microsoft.AspNetCore.Http;

namespace HanaSpa.Data.Repository
{
    public class UnitOfWork : RhRepo.UnitOfWork
    {
        public UnitOfWork(DbContext.HanaSpaContext hanaSpaContext, IHttpContextAccessor httpContextAccessor) : base(hanaSpaContext, httpContextAccessor)
        {

        }
    }
}
