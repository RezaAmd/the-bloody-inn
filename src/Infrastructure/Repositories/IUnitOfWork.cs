using TheBloodyInn.Infrastructure.Repositories.SQL.Users;

namespace TheBloodyInn.Infrastructure.Repositories;

public interface IUnitOfWork
{
    AppDbContext _context { get; }
    Task SaveAsync(CancellationToken stoppingToken);

    IUserRepository UserRepository { get; }
}