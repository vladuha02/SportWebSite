using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportWebSite.Domain.Entities;
using SportWebSite.Domain.Enums;

namespace SportWebSite.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasData(new User
            {
                Email = "admin@admin.com",
                Name = "Admin",
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN@ADMIN.COM",
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
                Role = UserRole.Admin,
                PasswordHash = "AQAAAAEAACcQAAAAEMT2LgNzkycCUpVpcwCcT7ZqUxHe/YxBQiEV1vgGEemuvAkOm2ggdxIQwPQI9Jvepg==",
                Gender = Gender.Male,
                Location = "Mykolayiv",
                BirthDate = DateTime.Today,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                TwoFactorEnabled = false
            });
        }
    }
}