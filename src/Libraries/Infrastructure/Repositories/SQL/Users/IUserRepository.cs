using TheBloodyInn.Domain.Entities.Identity;

namespace TheBloodyInn.Infrastructure.Repositories.SQL.Users;

public interface IUserRepository
{
    /// <summary>
    /// Find a specific user by identity.
    /// </summary>
    /// <param name="identity">username or email</param>
    Task<User?> FindByIdentityWithRolesAsync(string identity, CancellationToken stoppingToken);
}