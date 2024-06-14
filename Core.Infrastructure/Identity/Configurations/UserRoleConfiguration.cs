using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "995d5439-2b54-458a-b08d-e0f289255a96",
                UserId = "42df1250-85ef-4683-9046-6f2e5405ee3a"
            },
            new IdentityUserRole<string>
            {
                RoleId = "dd70f100-6753-494a-9382-1dd5ef51d4b6",
                UserId = "2499bc5a-0f33-4f67-b521-5829679ee7ff"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2ed7c2e3-d4ad-4222-9439-1700379ea772",
                UserId = "306627f3-c902-4d48-a6f3-d83db48df2c6"
            }
        );
    }
}