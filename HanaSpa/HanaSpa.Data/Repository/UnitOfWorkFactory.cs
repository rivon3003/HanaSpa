using System;
using System.Collections.Generic;
using System.Text;
using RhRepo = RivonHouse.Data.Repository;
using HsRepo = HanaSpa.Data.Repository;
using Microsoft.AspNetCore.Http;

namespace HanaSpa.Data.Repository
{
    public class UnitOfWorkFactory : RhRepo.UnitOfWorkFactory<HsRepo.UnitOfWork, DbContext.HanaSpaContext>
    {
        public UnitOfWorkFactory(DbContext.HanaSpaContext hsContext, IHttpContextAccessor httpContextAccessor) : base(hsContext, httpContextAccessor)
        {
        }
    }
}
