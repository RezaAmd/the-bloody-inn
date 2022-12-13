using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TheBloodyInn.Infrastructure.Repositories.SQL;

public interface ISqlRepository<TEntity> where TEntity : class
{
    DbSet<TEntity> Entities { get; }
    IQueryable<TEntity> Table { get; }
    IQueryable<TEntity> TableNoTracking { get; }

    Task<TEntity?> GetByIdAsync(CancellationToken stoppingToken = default, params object[] id);
    Task<List<TEntity>> GetAllAsync(bool asNoTracking, CancellationToken stoppingToken = default);

    Task AddAsync(TEntity entity, CancellationToken stoppingToken = default);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken stoppingToken = default);

    Task UpdateAsync(TEntity entity, CancellationToken stoppingToken = default);
    Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken stoppingToken = default);

    Task DeleteAsync(TEntity entity, CancellationToken stoppingToken = default);
    Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken stoppingToken = default);

    Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken stoppingToken = default);
}