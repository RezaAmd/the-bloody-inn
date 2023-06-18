namespace TheBloodyInn.Application.Common.Enums.IdentityService;

public class UserSignupStatus : Enumeration
{
    #region Ctors

    public UserSignupStatus()
    { }

    public UserSignupStatus(int id, string name)
        : base(id, name)
    { }

    #endregion

    public static readonly UserSignupStatus Succeded = new(1, nameof(Succeded));
    public static readonly UserSignupStatus AlreadyExist = new(3, nameof(AlreadyExist));
    public static readonly UserSignupStatus Failed = new(4, nameof(Failed));
}
