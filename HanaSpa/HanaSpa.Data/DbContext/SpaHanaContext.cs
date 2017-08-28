using System;
using System.Collections.Generic;
using System.Text;
using EfCore = Microsoft.EntityFrameworkCore;

namespace HanaSpa.Data.DbContext
{
    public class SpaHanaContext : EfCore.DbContext
    {
        public SpaHanaContext(EfCore.DbContextOptions<SpaHanaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(EfCore.ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new Map.Service(modelBuilder.Entity<Entities.Service>());
        }
    }
}
