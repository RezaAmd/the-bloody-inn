using TheBloodyInn.Domain.Enum;

namespace TheBloodyInn.Domain.Entities.Innkeepers;

public class InnkeeperActionEntity : BaseEntity
{
    #region Constructors
    InnkeeperActionEntity() { }
    #endregion

    public InnkeeperActionType Type { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
