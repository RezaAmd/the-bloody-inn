
using TheBloodyInn.Domain.Enum;

namespace TheBloodyInn.Domain.Entities.Inns;

public class InnkeeperAction : BaseEntity
{
    #region Constructors
    InnkeeperAction() { }
    #endregion

    public InnkeeperActionType Type { get; private set; }
    public DateTime CreatedAt { get; private set; }
}
