namespace TheBloodyInn.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    #region constructor
    public Context _context { get; }

    public UnitOfWork(Context context)
    {
        _context = context;
    }
    #endregion

    public async Task SaveAsync(CancellationToken stoppingToken = default)
    {
        await _context.SaveChangesAsync(stoppingToken);
    }

    public ISqlRepository<TEntity> SqlRepository<TEntity>() where TEntity : class
    {
        ISqlRepository<TEntity> repository = new SqlRepository<TEntity, Context>(_context);
        return repository;
    }
}