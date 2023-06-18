using Microsoft.EntityFrameworkCore;
using TheBloodyInn.Application.Common.Enums.IdentityService;
using TheBloodyInn.Application.Common.Models.ViewModels;
using TheBloodyInn.Application.Common.Security.JwtBearer;
using TheBloodyInn.Application.Services.AssemblyServices;
using TheBloodyInn.Domain.Entities.Identity;
using TheBloodyInn.Infrastructure.Persistence.Context;
using TheBloodyInn.Infrastructure.Repositories;

namespace TheBloodyInn.Application.Services.Identity;

public class IdentityService : IIdentityService
{
    #region DI & Ctor
    private readonly AppDbContext _context;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;
    private readonly IAppSettingsService<AppSettingDto> _appSetting;

    public IdentityService(AppDbContext context,
        IUnitOfWork unitOfWork,
        IJwtService jwtService,
        IAppSettingsService<AppSettingDto> appSetting)
    {
        _context = context;
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
        _appSetting = appSetting;
    }
    #endregion

    #region Sign-In
    public async Task<(AccessTokenViewModel? Token, SigInStatus Status)?> SignInUserAsync(string username, string password,
        CancellationToken cancellationToken = default)
    {
        AccessTokenViewModel? accessToken = new();

        var user = await _unitOfWork.UserRepository.FindByIdentityWithRolesAsync(username, cancellationToken);
        if (user is null)
            return (accessToken, SigInStatus.NotFound);

        var status = user.GetUserSignInStatusResultWithMessage(password);

        if (!status.Status.IsSucceeded())
            return (accessToken, SigInStatus.WrongInformations);

        accessToken = await GetUserAccessToken(user, cancellationToken);
        if (accessToken is null)
            status.message = "user is not authenticated";

        return (accessToken, SigInStatus.Succeeded);
    }
    #endregion

    #region Sign-Up
    public async Task<UserSignupStatus> SignUpAsync(User newUser,
        CancellationToken cancellationToken)
    {
        // Check user is exist?
        User? user = await _context.Users
            .Where(u => u.Username == newUser.Username || u.Email == newUser.Email)
            .FirstOrDefaultAsync(cancellationToken);

        if (user is not null)
            return UserSignupStatus.AlreadyExist;

        // Create new account.
        await _context.Users.AddAsync(newUser);
        if (await SaveChangeAsync(cancellationToken))
            return UserSignupStatus.Succeded;

        return UserSignupStatus.Failed;
    }
    #endregion

    #region Privates
    private async Task<AccessTokenViewModel?> GetUserAccessToken(User user, CancellationToken cancellationToken)
    {
        AccessTokenViewModel accessToken = new();
        try
        {
            #region Token
            var getUserClaimsWithRoles = await user.GetClaims();
            DateTime tokenExpiresAt = DateTime.Now.AddMinutes(5);
#if DEBUG
            // In debug mode token life is longer.
            tokenExpiresAt = tokenExpiresAt.AddMinutes(15);
#endif
            // Generate token with expiration date & time.
            accessToken.Token = await _jwtService.GenerateTokenAsync(claims: getUserClaimsWithRoles,
                expiresAt: tokenExpiresAt, cancellationToken);
            accessToken.TokenExpireAt = tokenExpiresAt.ToString("yyyy/MM/dd HH:mm:ss");
            #endregion

            #region Refresh Token
            var getUserClaims = await user.GetIdAsClaim();
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

    private async Task<bool> SaveChangeAsync(CancellationToken cancellationToken) =>
        Convert.ToBoolean(await _context.SaveChangesAsync(cancellationToken));
    #endregion
}