using TheBloodyInn.Domain.Entities.Innkeepers;

namespace TheBloodyInn.Domain.Entities.Inns;

public class InnRoomEntity : BaseEntity
{
    public InnRoomNumber Number { get; private set; }

    #region Relations

    public Guid InnId { get; set; }
    public virtual InnEntity? Inn { get; set; }

    public Guid? InnKeeperId { get; set; }
    public virtual InnkeeperEntity? InnKeeper { get; set; }

    #endregion

    #region Ctor

    InnRoomEntity() { }
    public InnRoomEntity(InnRoomNumber roomNumber)
    {
        SetRoomNumber(roomNumber);
    }

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