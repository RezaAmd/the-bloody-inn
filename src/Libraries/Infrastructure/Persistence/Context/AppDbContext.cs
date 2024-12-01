using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;
using TheBloodyInn.Application.Common.Interfaces;
using TheBloodyInn.Application.Common.Models;
using TheBloodyInn.Domain.Entities.Identities;
using TheBloodyInn.Domain.Entities.Innkeepers;
using TheBloodyInn.Domain.Entities.Inns;

namespace TheBloodyInn.Infrastructure.Persistence.Context;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    #region DbSets

    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<InnEntity> Inns => Set<InnEntity>();
    public DbSet<InnRoomEntity> InnRooms => Set<InnRoomEntity>();
    public DbSet<InnkeeperEntity> Innkeepers => Set<InnkeeperEntity>();

    #endregion

    #region Methods

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //In this case, the predicate will scan the types and for each type, will check if it implements the IEntityTypeConfiguration<T> interface and if T inherits BaseEntity.
        //https://stackoverflow.com/questions/61430833/applyconfigurationsfromassembly-with-filter-entityframework-core
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Database"), options =>
        {
            options.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
        });
    }

    public override DbSet<TEntity> Set<TEntity>() where TEntity : class => base.Set<TEntity>();
    public override EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
    {
        return base.Entry(entity);
    }
    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await Database.BeginTransactionAsync();
    }

    // Generic method for executing raw SQL
    public IQueryable<TEntity> PrepareSqlQuery<TEntity>(string sql, params object[] parameters)
        where TEntity : BaseEntity
    {
        return Set<TEntity>().FromSqlRaw(sql, parameters);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var saveChangesResult = await base.SaveChangesAsync(cancellationToken);

        // Track entities that were added, modified, or deleted
        var entries = ChangeTracker.Entries<BaseEntity>();

        // TODO: Raise domain events (Inserted, Deleted, Updated).
        // Here... !

        return saveChangesResult;
    }
    public async Task<Result> SaveChangeAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            if (Convert.ToBoolean(await SaveChangesAsync(cancellationToken)))
                return Result.Ok();
            return Result.Fail();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            return Result.Fail(ex.Message, ex);
        }
        catch (DuplicateNameException ex)
        {
            return Result.Fail(ex.Message);
        }
        catch (DuplicateWaitObjectException ex)
        {
            return Result.Fail(ex.Message);
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
                return Result.Fail(ex.InnerException.Message);
            return Result.Fail(ex.Message);
        }
    }

    #endregion
}