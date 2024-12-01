using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheBloodyInn.Domain.Entities.Inns;

namespace TheBloodyInn.Infrastructure.Persistence.Configurations.Inns
{
    internal class InnRoomConfiguration : IEntityTypeConfiguration<InnRoomEntity>
    {
        public void Configure(EntityTypeBuilder<InnRoomEntity> builder)
        {
            builder.ToTable("InnRooms", TableSchema.Game);

            // Number
            builder.Property(ir => ir.Number);

            #region Relations

            // InnKeeper - FK
            builder.HasOne(ir => ir.InnKeeper)
                .WithMany(ik => ik.Rooms)
                .HasForeignKey(ir => ir.InnKeeperId);

            // Inn - FK
            builder.HasOne(ir => ir.Inn)
                .WithMany(i => i.Rooms)
                .HasForeignKey(ir => ir.InnId);

            #endregion
        }
    }
}