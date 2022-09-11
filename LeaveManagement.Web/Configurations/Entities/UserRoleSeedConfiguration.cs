using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "bc611ca9-706a-3214-8003-1021b1c8aef8",
                    RoleId = "bc181ad9-73d4-4114-8277-1059f8a8aaf8"
                },
                new IdentityUserRole<string>
                {
                    UserId = "bc61a1a9-136a-3214-1103-1021b1c8abcd",
                    RoleId = "bc654ba9-71d4-4114-8123-1000a1c8aaf8"
                });
        }
    }
}