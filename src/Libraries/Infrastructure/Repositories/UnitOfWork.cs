using TheBloodyInn.Infrastructure.Repositories.SQL.Users;

namespace TheBloodyInn.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    #region constructor
    public AppDbContext _context { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    #endregion

    #region Identity
    private IUserRepository? _userRepository;
    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UserRepository(_context);
            }
            return _userRepository;
        }
    }
    #endregion

    public async Task SaveAsync(CancellationToken stoppingToken)
    {
        await _context.SaveChangesAsync(stoppingToken);
    }
}