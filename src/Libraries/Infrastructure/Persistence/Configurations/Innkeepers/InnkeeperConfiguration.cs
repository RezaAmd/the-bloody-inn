using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheBloodyInn.Domain.Entities.Innkeepers;
using TheBloodyInn.Domain.Entities.Players;

namespace TheBloodyInn.Infrastructure.Persistence.Configurations.Innkeepers
{
    internal class InnkeeperConfiguration : IEntityTypeConfiguration<InnkeeperEntity>
    {
        public void Configure(EntityTypeBuilder<InnkeeperEntity> builder)
        {
            builder.ToTable("Innkeepers", TableSchema.Game);

            // ColorId
            builder.Property(i => i.ColorId)
                .IsRequired(false);

            // Cash
            builder.OwnsOne(u => u.Cash, c =>
            {
                c.Property(u => u.Value)
                .HasColumnName("Cash")
                .HasDefaultValue(0)
                .HasColumnType(DataTypes.tinyint);
            });

            // CheckMoney
            builder.OwnsOne(u => u.CheckMoney, c =>
            {
                c.Property(u => u.Count)
                .HasColumnName("CheckMoney")
                .HasDefaultValue(0)
                .HasColumnType(DataTypes.tinyint);
            });

            // PlayerTypeId
            builder.Property(i => i.PlayerTypeId)
                .IsRequired()
                .HasDefaultValue(PlayerType.User);

            // PlayerId
            builder.Property(i => i.PlayerId)
                .HasColumnType(DataTypes.guid);

            #region Relations

            // Rooms - OneToMany
            builder.HasMany(i => i.Rooms)
                .WithOne(r => r.InnKeeper)
                .HasForeignKey(i => i.InnKeeperId);

            #endregion
        }
    }
}