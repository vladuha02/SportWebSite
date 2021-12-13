using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportWebSite.Domain.Entities;
using SportWebSite.Domain.Enums;
using System;

namespace SportWebSite.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            foreach(var role in Enum.GetNames(typeof(UserRole)))
            {
                builder.HasData(new Role
                {
                    Name = role,
                    NormalizedName = role.ToUpper()
                });
            }
        }
    }
}
