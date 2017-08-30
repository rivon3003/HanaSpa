using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using HanaSpa.Common;

namespace HanaSpa.Data.DbContext
{
    // Cannot create database in normal way if DbContext is in seperate project. So we need to fake.
    public class HanaSpaDbContextFactory : IDesignTimeDbContextFactory<HanaSpaContext>
    {
        public HanaSpaContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HanaSpaContext>();
            builder.UseSqlServer(ConnectionString.HanaSpaConnection);
            return new HanaSpaContext(builder.Options);
        }
    }
}
