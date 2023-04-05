using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheBloodyInn.Domain.Entities.Identity;
using TheBloodyInn.Infrastructure.Common.Consts;

namespace TheBloodyInn.Infrastructure.Persistence.Configurations.Identities;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id); // primary key
        builder.Property(u => u.Id).ValueGeneratedNever();
        builder.HasIndex(b => b.Email).IsUnique();

        builder.OwnsOne(u => u.PasswordHash);

        #region column types
        builder.Property(a => a.IsEmailConfirmed).HasColumnType(DataTypes.boolean);
        builder.Property(a => a.IsBanned).HasColumnType(DataTypes.boolean);

        builder.Property(a => a.Username).HasColumnType(DataTypes.nvarchar50);
        builder.Property(a => a.Email).HasColumnType(DataTypes.nvarchar50);
        #endregion
    }
}
