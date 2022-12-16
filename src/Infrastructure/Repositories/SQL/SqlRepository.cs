namespace TheBloodyInn.Infrastructure.Repositories.SQL;

public class SqlRepository<TEntity, TContext> : ISqlRepository<TEntity>
        where TEntity : class where TContext : DbContext
{
    #region DI & Ctor
    protected readonly TContext _context;
    public DbSet<TEntity> Entities { get; }
    public virtual IQueryable<TEntity> Table => Entities;
    public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

    public SqlRepository(TContext context)
    {
        _context = context;
        Entities = _context.Set<TEntity>();
    }
    #endregion

    #region Async Method
    public async virtual Task<TEntity?> GetByIdAsync(CancellationToken cancellationToken, params object[] ids) =>
        await Entities.FindAsync(ids, cancellationToken);
    public virtual async Task<List<TEntity>> GetAllAsync(bool asNoTracking, CancellationToken cancellationToken = default) =>
        await (asNoTracking ? TableNoTracking : Entities).ToListAsync(cancellationToken);
    public async Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken stoppingToken = default)
    {
        return await Entities.AsNoTracking().AnyAsync(expression, stoppingToken);
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Assert.NotNull(entity, nameof(entity));
        await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);
    }
    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        Assert.NotNull(entities, nameof(entities));
        await Entities.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Assert.NotNull(entity, nameof(entity));
        Entities.Update(entity);
        await Task.CompletedTask;
    }
    public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        Assert.NotNull(entities, nameof(entities));
        Entities.UpdateRange(entities);
        await Task.CompletedTask;
    }

    public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Assert.NotNull(entity, nameof(entity));
        Entities.Remove(entity);
        await Task.CompletedTask;
    }
    public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        Assert.NotNull(entities, nameof(entities));
        Entities.RemoveRange(entities);
        await Task.CompletedTask;
    }
    #endregion
}