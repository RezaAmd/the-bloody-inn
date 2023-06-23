namespace TheBloodyInn.Infrastructure;

public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    #region Fields

    private readonly AppDbContext _dataProvider;
    public DbSet<TEntity> Entities { get; private set; }

    #endregion

    #region Ctor

    public EntityRepository(AppDbContext dataProvider)
    {
        _dataProvider = dataProvider;
        Entities = _dataProvider.Set<TEntity>();
    }

    #endregion


    #region Properties

    /// <summary>
    /// Gets a table
    /// </summary>
    public virtual IQueryable<TEntity> Table => Entities.AsQueryable();

    public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

    #endregion
}