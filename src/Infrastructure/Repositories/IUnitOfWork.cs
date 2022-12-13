namespace TheBloodyInn.Infrastructure.Repositories;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken stoppingToken = default);
    Context _context { get; }
}