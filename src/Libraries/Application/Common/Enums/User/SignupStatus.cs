namespace TheBloodyInn.Application.Common.Enums.IdentityService;

public class SignupStatus : Enumeration
{
    #region Ctors

    public SignupStatus()
    { }

    public SignupStatus(int id, string name)
        : base(id, name)
    { }

    #endregion

    public static readonly SignupStatus Succeded = new(1, nameof(Succeded));
    public static readonly SignupStatus AlreadyExist = new(3, nameof(AlreadyExist));
    public static readonly SignupStatus Failed = new(4, nameof(Failed));
}
