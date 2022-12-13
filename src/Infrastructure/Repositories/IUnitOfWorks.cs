namespace TheBloodyInn.Infrastructure.Repositories;

public interface IUnitOfWorks
{
    Task SaveAsync(CancellationToken stoppingToken = default);
    Context _context { get; }
}