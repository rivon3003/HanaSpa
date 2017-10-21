using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entity = HanaSpa.Data.Entities;

namespace HanaSpa.Data.Map.EntityWithDb
{
    public class User
    {
        public User(EntityTypeBuilder<Entity.User> entityBuilder)
        {
            entityBuilder.Property(s => s.Email).IsRequired();
            entityBuilder.Property(s => s.PhoneNumber).IsRequired();
            entityBuilder.Property(s => s.Password).IsRequired();
        }
    }
}
