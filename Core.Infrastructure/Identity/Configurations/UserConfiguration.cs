using Core.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(
             new ApplicationUser
             {
                 Id = "42df1250-85ef-4683-9046-6f2e5405ee3a",
                 Email = "admin@localhost.com",
                 NormalizedEmail = "ADMIN@LOCALHOST.COM",
                 FirstName = "System",
                 LastName = "Admin",
                 UserName = "admin@localhost.com",
                 NormalizedUserName = "ADMIN@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             },
             new ApplicationUser
             {
                 Id = "2499bc5a-0f33-4f67-b521-5829679ee7ff",
                 Email = "user@localhost.com",
                 NormalizedEmail = "USER@LOCALHOST.COM",
                 FirstName = "System",
                 LastName = "User",
                 UserName = "user@localhost.com",
                 NormalizedUserName = "USER@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             },
             new ApplicationUser
             {
                 Id = "306627f3-c902-4d48-a6f3-d83db48df2c6",
                 Email = "hr@localhost.com",
                 NormalizedEmail = "HR@LOCALHOST.COM",
                 FirstName = "Hr",
                 LastName = "Hr",
                 UserName = "hr@localhost.com",
                 NormalizedUserName = "HR@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             }
        );
    }
}
