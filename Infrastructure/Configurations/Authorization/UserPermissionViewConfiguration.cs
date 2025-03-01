using InfosecLearningSystem_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfosecLearningSystem_Backend.Infrastructure.Configurations
{
    public class UserPermissionViewConfiguration : IEntityTypeConfiguration<UserPermissionView>
    {
        public void Configure(EntityTypeBuilder<UserPermissionView> builder)
        {
            builder.HasNoKey();
            builder.ToView("user_permissions_view");
        }
    }
}
