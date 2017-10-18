using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entity = HanaSpa.Data.Entities;

namespace HanaSpa.Data.Map.EntityWithDb
{
    public class Account
    {
        public Account(EntityTypeBuilder<Entity.Account> entityBuilder)
        {
            entityBuilder.HasKey(s => s.Id);

            entityBuilder.Property(s => s.Email).IsRequired();
            entityBuilder.Property(s => s.PhoneNumber).IsRequired();
            entityBuilder.Property(s => s.Password).IsRequired();

            entityBuilder.Property(s => s.CreatedBy).IsRequired();
            entityBuilder.Property(s => s.CreatedDate).IsRequired();
            entityBuilder.Property(s => s.UpdatedBy).IsRequired();
            entityBuilder.Property(s => s.UpdatedDate).IsRequired();
        }
    }
}
