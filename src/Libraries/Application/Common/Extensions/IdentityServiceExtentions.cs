using TheBloodyInn.Application.Common.Enums.User;
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

    public static (SignInStatus Status, string message) GetUserSignInStatusResultWithMessage(this User user, string password = "")
    {
        if (user == null)
            return (SignInStatus.NotFound, NotFound);
        //else if (user.IsBaned is true)
        //    return (SigInStatus.WrongInformations, WrongInformations);
        //else if (user.LockOutDateTime != null)
        //    return (SigInStatus.LockUser, LockUser);
        else if (!string.IsNullOrWhiteSpace(password))
        {
            if (!user.PasswordHash.VerifyPasswordHash(password))
                return (SignInStatus.WrongPassowrd, WrongPassowrd);
        }

        return (SignInStatus.Succeeded, SucceededValidations);
    }

    public static bool IsSucceeded(this SignInStatus status)
    => status == SignInStatus.Succeeded ? true : false;
}