using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entity = HanaSpa.Data.Entities;

namespace HanaSpa.Data.Map.EntityWithDb
{
    public class Service
    {
        public Service(EntityTypeBuilder<Entity.Service> entityBuilder)
        {
            entityBuilder.Property(s => s.Name).IsRequired();
            entityBuilder.Property(s => s.Description).IsRequired();
            entityBuilder.Property(s => s.Image).IsRequired();
        }
    }
}
