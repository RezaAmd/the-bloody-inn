namespace TheBloodyInn.Domain.Entities.Inns.InnAggregate;

public class InnRoom
{
    #region Constructors
    InnRoom() { }

    public InnRoom(InnRoomNumber roomNumber)
    {
        GenerateNewId();
        SetRoomNumber(roomNumber);
    }
    #endregion

    public Guid Id { get; private set; }
    public InnRoomNumber Number { get; private set; }

    #region Relations
    public Guid InnId { get; set; }
    public virtual Inn Inn { get; set; }

    public Guid OwnerId { get; set; }
    public virtual Innkeeper Owner { get; set; }
    #endregion

    #region Methods
    /// <summary>
    /// Generate new id.
    /// </summary>
    private void GenerateNewId()
    {
        Id = Guid.NewGuid();
    }

    /// <summary>
    /// Set a new room number.
    /// </summary>
    /// <param name="roomNumber"></param>
    public void SetRoomNumber(InnRoomNumber roomNumber)
    {
        Number = roomNumber;
    }
    #endregion
}