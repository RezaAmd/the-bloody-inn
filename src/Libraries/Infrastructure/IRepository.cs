
using System.Linq.Expressions;

namespace TheBloodyInn.Infrastructure;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    #region Properties

    /// <summary>
    /// Gets a table
    /// </summary>
    IQueryable<TEntity> Table { get; }
    IQueryable<TEntity> TableNoTracking { get; }

    #endregion
}