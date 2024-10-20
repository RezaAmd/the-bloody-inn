using System.Security.Claims;
using TheBloodyInn.Domain.Entities.Identity;

namespace TheBloodyInn.Application.Common.Extensions;

public static class AuthorizationExtentions
{
    public static async Task<IEnumerable<Claim>> GetClaims(this UserEntity user)
    {
        IList<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

        if (user.Name is not null)
        {
            if (!string.IsNullOrEmpty(user.Name))
                claims.Add(new Claim(ClaimTypes.GivenName, user.Name));
        }

        // TODO:
        // Uncomment this for fole feature.
        //if (user.UserRoles != null && user.UserRoles.Count > 0)
        //{
        //    foreach (var userRole in user.UserRoles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
        //    }
        //}

        return await Task.FromResult(claims);
    }

    public static async Task<IEnumerable<Claim>> GetIdAsClaim(this UserEntity user)
    {
        IList<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

        return await Task.FromResult(claims);
    }
}