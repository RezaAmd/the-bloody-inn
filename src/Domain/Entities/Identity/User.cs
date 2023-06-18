using System.Xml.Linq;

namespace TheBloodyInn.Domain.Entities.Identity;

public class User
{
    #region Ctor

    User() { }

    public User(string email)
    {
        GenerateNewId();
        SetNewEmail(email);
        UnBan();
        RegisteredAt = DateTime.Now;
    }

    #endregion

    #region Properties

    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string? Name { get; private set; }
    public string Email { get; private set; }
    public bool IsEmailConfirmed { get; private set; }
    public PasswordHash? PasswordHash { get; set; }
    public bool IsBanned { get; private set; }
    public DateTime RegisteredAt { get; private set; }

    #endregion

    #region Methods

    private void GenerateNewId()
    {
        Id = Guid.NewGuid();
    }

    /// <summary>
    /// Set username for user account.
    /// </summary>
    /// <param name="username">Unique username.</param>
    public void SetUsername(string username)
    {
        username = username.Trim().Replace("  ", " ");

        if (username != null && username.Length > 50)
            throw new ArgumentOutOfRangeException("'Username' cannot be more than 50 characters!");
        if (username == null || username.Length < 3)
            throw new ArgumentOutOfRangeException("'Username' cannot be less than 3 characters!");

        Username = username;
    }

    /// <summary>
    /// Set display name for user.
    /// </summary>
    /// <param name="name">User display name.</param>
    public void SetName(string name)
    {
        name = name.Trim().Replace("  ", " ");

        if (name != null && name.Length > 50)
            throw new ArgumentOutOfRangeException("'Name' cannot be more than 50 characters!");
        if (name != null && name.Length < 3)
            throw new ArgumentOutOfRangeException("'Name' cannot be less than 3 characters!");

        Name = name;
    }
    public void SetNewEmail(string email, bool isEmailConfirmed = false)
    {
        // Check null value.
        if (string.IsNullOrEmpty(email))
            throw new ArgumentNullException("Email cannot be null.");

        Email = email.ToLower();
        Username = email;
        IsEmailConfirmed = isEmailConfirmed;
    }

    public void ConfirmEmail()
    {
        IsEmailConfirmed = true;
    }

    public void Ban()
    {
        IsBanned = true;
    }

    public void UnBan()
    {
        IsBanned = false;
    }

    #endregion

    #region Relations
    #endregion
}