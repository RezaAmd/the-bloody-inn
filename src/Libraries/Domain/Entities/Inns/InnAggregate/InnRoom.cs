namespace TheBloodyInn.Domain.Entities.Inns.InnAggregate;

public class InnRoom : BaseEntity
{
    #region Constructors
    InnRoom() { }

    public InnRoom(InnRoomNumber roomNumber)
    {
        SetRoomNumber(roomNumber);
    }
    #endregion

    public InnRoomNumber Number { get; private set; }

    #region Relations
    public Guid InnId { get; set; }
    public virtual Inn Inn { get; set; }

    public Guid? OwnerId { get; set; }
    public virtual Innkeeper Owner { get; set; }
    #endregion

    #region Methods

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