using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheBloodyInn.Domain.Entities.Inns;
using TheBloodyInn.Domain.Enum.Inns;

namespace TheBloodyInn.Infrastructure.Persistence.Configurations.Inns
{
    internal class InnConfiguration : IEntityTypeConfiguration<InnEntity>
    {
        public void Configure(EntityTypeBuilder<InnEntity> builder)
        {
            builder.ToTable("Inns", TableSchema.Game);

            // MaxPlayerCount
            builder.Property(i => i.MaxPlayerCount)
                .IsRequired()
                .HasDefaultValue(1);

            // StateId
            builder.Property(i => i.StateId)
                .IsRequired()
                .HasDefaultValue(InnState.Preparing);

            // CreatedAt
            builder.Property(i => i.CreatedAt)
                .ValueGeneratedOnAddOrUpdate();

            // Setting
            builder.Property(i => i.Setting)
                .IsRequired(false)
                .HasMaxLength(500);
        }
    }
}