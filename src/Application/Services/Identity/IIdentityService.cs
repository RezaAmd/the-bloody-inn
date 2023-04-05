using TheBloodyInn.Application.Common.Enums.IdentityService;
using TheBloodyInn.Application.Common.Models.ViewModels;

namespace TheBloodyInn.Application.Services.Identity;

public interface IIdentityService
{
    Task<(AccessTokenViewModel? Token, SigInStatus Status)?> SignInUserAsync(string username, string password,
        CancellationToken cancellationToken = default);
}