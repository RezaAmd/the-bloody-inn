using TheBloodyInn.Application.Common.Enums.IdentityService;
using TheBloodyInn.Application.Common.Models.ViewModels;
using TheBloodyInn.Domain.Entities.Identity;

namespace TheBloodyInn.Application.Services.Identity;

public interface IIdentityService
{
    Task<(AccessTokenViewModel? Token, SigInStatus Status)?> SignInUserAsync(string username, string password,
        CancellationToken cancellationToken = default);

    Task<UserSignupStatus> SignUpAsync(User newUser,
        CancellationToken cancellationToken);
}