namespace TheBloodyInn.Application.Common.Enums.User;

public class SignInStatus : Enumeration
{
    #region Ctors
    public SignInStatus() { }

    public SignInStatus(int id, string name)
        : base(id, name)
    { }
    #endregion

    public static readonly SignInStatus NotFound = new(1, nameof(NotFound));
    public static readonly SignInStatus WrongInformations = new(2, nameof(WrongInformations));
    public static readonly SignInStatus Banned = new(3, nameof(Banned));
    public static readonly SignInStatus WrongPassowrd = new(4, nameof(WrongPassowrd));
    public static readonly SignInStatus Succeeded = new(5, nameof(Succeeded));
    public static readonly SignInStatus Error = new(7, nameof(Error));
}