using TheBloodyInn.Application.Common.Enums.IdentityService;
using TheBloodyInn.Application.Common.Models.ViewModels;
using TheBloodyInn.Application.Common.Security.JwtBearer;
using TheBloodyInn.Application.Services.AssemblyServices;
using TheBloodyInn.Domain.Entities.Identity;
using TheBloodyInn.Infrastructure.Repositories;

namespace TheBloodyInn.Application.Services.Identity;

public class IdentityService : IIdentityService
{
    #region DI & Ctor
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;
    private readonly IAppSettingsService<AppSettingDto> _appSetting;

    public IdentityService(IUnitOfWork unitOfWork,
        IJwtService jwtService,
        IAppSettingsService<AppSettingDto> appSetting)
    {
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
    #endregion
}