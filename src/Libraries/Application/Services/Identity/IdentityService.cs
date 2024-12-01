using TheBloodyInn.Application.Common.Enums.User;
using TheBloodyInn.Application.Common.Interfaces;
using TheBloodyInn.Application.Common.Models.ViewModels;
using TheBloodyInn.Application.Common.Security.JwtBearer;
using TheBloodyInn.Domain.Entities.Identities;

namespace TheBloodyInn.Application.Services.Identity;

public class IdentityService : IIdentityService
{
    #region DI & Ctor

    private readonly IAppDbContext _context;
    private readonly IJwtService _jwtService;
    public IdentityService(IAppDbContext context,
        IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    #endregion

    #region Sign-In

    public async Task<(AccessTokenViewModel? Token, SignInStatus Status)?> SignInUserAsync(string username, string password,
        CancellationToken cancellationToken = default)
    {
        AccessTokenViewModel? accessToken = new();

        // Find user from database.
        var user = await _context.Users.AsNoTracking()
            .Where(u => u.Username == username)
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
            return (accessToken, SignInStatus.NotFound);

        var status = user.GetUserSignInStatusResultWithMessage(password);

        if (!status.Status.IsSucceeded())
            return (accessToken, SignInStatus.WrongInformations);

        accessToken = await GetUserAccessToken(user, cancellationToken);
        if (accessToken is null)
            status.message = "user is not authenticated";

        return (accessToken, SignInStatus.Succeeded);
    }

    public async Task<(UserEntity? user, SignInStatus status)> SignInValidateAsync(string username, string password,
        CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Where(u => (u.Username == username))
            .FirstOrDefaultAsync(cancellationToken);

        // Is user account exist?
        if (user is null)
            return (user, SignInStatus.NotFound);

        // Password validation.
        if (user.PasswordHash == null || user.PasswordHash.VerifyPasswordHash(password) == false)
            return (user, SignInStatus.WrongPassowrd);

        // Account is ban.
        //if (user.IsBanned)
        //    return (user, SignInStatus.Banned);

        return (user, SignInStatus.Succeeded);

    }

    #endregion

    #region Sign-Up

    public async Task<SignupStatus> SignUpAsync(UserEntity newUser,
        CancellationToken cancellationToken)
    {
        // The username already been taken??
        bool isTakenUsername = await _context.Users
            .AnyAsync(u => u.Username == newUser.Username, cancellationToken);

        if (isTakenUsername)
            return SignupStatus.AlreadyExist;

        // Create new account.
        await _context.Users.AddAsync(newUser);

        // Save changes
        var saveResult = await _context.SaveChangeAsync(cancellationToken);
        if (saveResult.IsSuccess == false)
            return SignupStatus.Failed;

        return SignupStatus.Succeded;
    }

    #endregion

    #region Privates

    private async Task<AccessTokenViewModel?> GetUserAccessToken(UserEntity user, CancellationToken cancellationToken)
    {
        AccessTokenViewModel accessToken = new();
        try
        {
            #region Token
            var getUserClaimsWithRoles = await user.GetClaimsAsync();
            DateTime tokenExpiresAt = DateTime.Now.AddMinutes(5);
#if DEBUG
            // In debug mode token life is longer.
            tokenExpiresAt = tokenExpiresAt.AddHours(15);
#endif
            // Generate token with expiration date & time.
            accessToken.Token = await _jwtService.GenerateTokenAsync(claims: getUserClaimsWithRoles,
                expiresAt: tokenExpiresAt, cancellationToken);
            accessToken.TokenExpireAt = tokenExpiresAt.ToString("yyyy/MM/dd HH:mm:ss");
            #endregion

            #region Refresh Token
            var getUserClaims = await user.GetIdAsClaimAsync();
            DateTime refreshTokenExpiresAt = DateTime.Now.AddDays(3);
#if DEBUG
            // In debug mode token life is longer.
            refreshTokenExpiresAt = refreshTokenExpiresAt.AddDays(2);
#endif
            // Generate refresh token with expiration date & time.
            accessToken.RefreshToken = await _jwtService.GenerateTokenAsync(claims: getUserClaims,
                expiresAt: refreshTokenExpiresAt, cancellationToken);
            accessToken.RefreshTokenExpireAt = refreshTokenExpiresAt.ToString("yyyy/MM/dd HH:mm:ss");
            #endregion
        }
        catch
        {
            // TODO:
            // Log error!
        }
        return accessToken;
    }

    #endregion
}