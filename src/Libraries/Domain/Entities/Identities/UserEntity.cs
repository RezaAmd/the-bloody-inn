namespace TheBloodyInn.Domain.Entities.Identities;

public class UserEntity : BaseEntity
{
    #region Ctor

    UserEntity() { }
    public UserEntity(string username)
    {
        SetUsername(username);
    }

    #endregion

    #region Properties

    public string Username { get; private set; } = string.Empty;
    public PasswordHash? PasswordHash { get; private set; }
    public string? Nickname { get; set; }
    public DateTime RegisteredAt { get; private set; } = DateTime.UtcNow;

    #endregion

    #region Relations



    #endregion

    #region Methods

    /// <summary>
    /// Set username for user account.
    /// </summary>
    /// <param name="username">Unique username.</param>
    public void SetUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
            throw new ArgumentNullException("Username cannot be null.");

        if (username.Length < 3)
            throw new ArgumentOutOfRangeException("The 'Username' cannot be less than 3 characters!");

        Username = username;
    }

    /// <summary>
    /// Set password for user account.
    /// </summary>
    public void SetPassword(PasswordHash password)
    {
        PasswordHash = password;
    }

    /// <summary>
    /// Set display name for user.
    /// </summary>
    /// <param name="name">User display name.</param>
    public void SetNickname(string nickName)
    {
        if (Nickname == null) throw new ArgumentNullException("Nickname cannot be null.");

        Nickname = nickName;
    }

    #endregion
}