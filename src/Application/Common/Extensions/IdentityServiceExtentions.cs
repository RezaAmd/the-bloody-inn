using TheBloodyInn.Application.Common.Enums.IdentityService;
using TheBloodyInn.Domain.Entities.Identity;

namespace TheBloodyInn.Application.Common.Extensions;

public static class IdentityServiceExtentions
{
    #region common messages
    const string NotFound = "Not found user !";
    const string WrongInformations = "Username or password is wrong!";
    const string LockUser = "user is locked !";
    const string WrongPassowrd = "password is wrong!";
    const string SucceededValidations = "Welcome !";
    #endregion

    public static (SigInStatus Status, string message) GetUserSignInStatusResultWithMessage(this User user, string password = "")
    {
        if (user == null)
            return (SigInStatus.NotFound, NotFound);
        //else if (user.IsBaned is true)
        //    return (SigInStatus.WrongInformations, WrongInformations);
        //else if (user.LockOutDateTime != null)
        //    return (SigInStatus.LockUser, LockUser);
        else if (!string.IsNullOrWhiteSpace(password))
        {
            if (!user.PasswordHash.VerifyPasswordHash(password))
                return (SigInStatus.WrongPassowrd, WrongPassowrd);
        }

        return (SigInStatus.Succeeded, SucceededValidations);
    }

    public static bool IsSucceeded(this SigInStatus status)
    => status == SigInStatus.Succeeded ? true : false;
}