using System;
using System.Collections.Generic;
using System.Text;
using EfCore = Microsoft.EntityFrameworkCore;

namespace HanaSpa.Data.DbContext
{
    public class HanaSpaContext : EfCore.DbContext
    {
        public HanaSpaContext(EfCore.DbContextOptions<HanaSpaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(EfCore.ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new Map.EntityWithDb.Service(modelBuilder.Entity<Entities.Service>());
        }
    }
}
