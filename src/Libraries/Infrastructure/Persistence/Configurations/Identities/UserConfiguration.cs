using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheBloodyInn.Domain.Entities.Identity;
using TheBloodyInn.Infrastructure.Common.Consts;

namespace TheBloodyInn.Infrastructure.Persistence.Configurations.Identities;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users", TableSchema.Identity);

        // Id
        builder.HasKey(u => u.Id); // primary key
        builder.Property(u => u.Id).HasColumnType(DataTypes.guid)
            .ValueGeneratedNever();

        // Username
        builder.Property(a => a.Username).HasColumnType(DataTypes.nvarchar50);
        
        // Name
        builder.Property(a => a.Name).HasColumnType(DataTypes.nvarchar50).IsRequired(false);

        // Email
        builder.Property(a => a.Email).HasColumnType(DataTypes.nvarchar50);
        builder.HasIndex(b => b.Email).IsUnique();

        // IsEmailConfirmed
        builder.Property(a => a.IsEmailConfirmed).HasColumnType(DataTypes.boolean);

        // Password
        builder.OwnsOne(u => u.PasswordHash, ph =>
        {
            ph.Property(u => u.Value)
            .HasColumnName("PasswordHashed")
            .HasColumnType(DataTypes.nvarchar500)
            .IsRequired(false);
        });

        // IsBanned
        builder.Property(a => a.IsBanned).HasColumnType(DataTypes.boolean);

        // RegisteredAt
        builder.Property(u => u.RegisteredAt).HasColumnType(DataTypes.datetime2);
    }
}