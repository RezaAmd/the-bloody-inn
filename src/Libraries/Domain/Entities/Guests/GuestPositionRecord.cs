using TheBloodyInn.Domain.Entities.Inns.InnAggregate;
using TheBloodyInn.Domain.Enum.Guests;

namespace TheBloodyInn.Domain.Entities.Guests;

public class GuestPositionRecord : BaseEntity
{
    #region Ctors

    #endregion

    #region Props
    public GuestPosittionType Type { get; set; }
    public DateTime CreatedAt { get; set; }
    #endregion

    #region Relations
    public Guid GuestId { get; set; }
    //public virtual Guest Guest { get; set; }

    public Guid? RoomId { get; set; }
    public virtual InnRoom? Room { get; set; }
    #endregion
}