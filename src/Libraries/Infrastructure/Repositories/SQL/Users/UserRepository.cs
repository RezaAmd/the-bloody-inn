using TheBloodyInn.Domain.Entities.Identity;

namespace TheBloodyInn.Infrastructure.Repositories.SQL.Users;

internal sealed class UserRepository : IUserRepository
{
    #region Ctor
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    #endregion

    public async Task<UserEntity?> FindByIdentityWithRolesAsync(string identity, CancellationToken stoppingToken = default)
        => await _context.Users
    .Where(u => u.Email == identity.Trim().ToLower() || u.Username == identity.Trim().ToLower())
    //.Include(u => u.UserRoles)
    //.ThenInclude(ur => ur.Role)
    .AsNoTracking()
    .FirstOrDefaultAsync(stoppingToken);

}