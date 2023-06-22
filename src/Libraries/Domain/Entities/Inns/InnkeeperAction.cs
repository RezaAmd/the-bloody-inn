
using TheBloodyInn.Domain.Enum;

namespace TheBloodyInn.Domain.Entities.Inns;

public class InnkeeperAction
{
    #region Constructors
    InnkeeperAction() { }
    #endregion

    public Guid Id { get; set; }
    public InnkeeperActionType Type { get; private set; }
    public DateTime CreatedAt { get; private set; }
}
