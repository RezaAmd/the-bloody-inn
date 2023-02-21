namespace TheBloodyInn.Domain.Entities.Identity;

public class User
{
    #region Constructors
    User() { }
    public User(string email)
    {
        GenerateNewId();
        SetNewEmail(email);
        UnBan();
    }
    #endregion

    #region Properties
    public Guid Id { get; private set; }
    public string Username { get; private set; }
    public string? Name { get; private set; }
    public string Email { get; private set; }
    public string ConcurrencyStamp { get; private set; }
    public bool IsEmailConfirmed { get; private set; }
    public bool IsBanned { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    #endregion

    #region Methods
    private void GenerateNewId()
    {
        // Id must be null.
        if (!string.IsNullOrEmpty(Id.ToString()))
            throw new ArgumentException("Id already exist.");
        Id = Guid.NewGuid();
    }

    private void GenerateNewConcurrencyStamp()
    {
        ConcurrencyStamp = Guid.NewGuid().ToString();
    }

    public void SetNewEmail(string email, bool isEmailConfirmed = false)
    {
        // Check null value.
        if (string.IsNullOrEmpty(email))
            throw new ArgumentNullException("Email cannot be null.");

        Email = email.ToLower();
        Username = email;
        IsEmailConfirmed = isEmailConfirmed;
        // Refresh concurrency stamp.
        GenerateNewConcurrencyStamp();
    }

    public void ConfirmEmail()
    {
        IsEmailConfirmed = true;
        // Refresh concurrency stamp.
        GenerateNewConcurrencyStamp();
    }

    public void Ban()
    {
        IsBanned = true;
        // Refresh concurrency stamp.
        GenerateNewConcurrencyStamp();
    }

    public void UnBan()
    {
        IsBanned = false;
        // Refresh concurrency stamp.
        GenerateNewConcurrencyStamp();
    }
    #endregion

    #region Relations
    #endregion
}