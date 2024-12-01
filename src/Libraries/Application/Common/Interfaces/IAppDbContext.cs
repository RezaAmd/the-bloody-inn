using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using TheBloodyInn.Domain.Entities.Identities;
using TheBloodyInn.Domain.Entities.Innkeepers;
using TheBloodyInn.Domain.Entities.Inns;

namespace TheBloodyInn.Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        #region Tables

        DbSet<UserEntity> Users { get; }

        DbSet<InnEntity> Inns { get; }
        DbSet<InnRoomEntity> InnRooms { get; }
        DbSet<InnkeeperEntity> Innkeepers { get; }

        #endregion

        #region Base Props

        ChangeTracker ChangeTracker { get; }
        DatabaseFacade Database { get; }

        #endregion

        #region Methods

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<Result> SaveChangeAsync(CancellationToken cancellationToken = default);

        #endregion
    }
}