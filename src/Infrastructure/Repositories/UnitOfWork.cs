using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

    #region EF Methods
    public async Task SaveAsync(CancellationToken stoppingToken = default)
    {
        await _context.SaveChangesAsync(stoppingToken);
    }
    #endregion
}