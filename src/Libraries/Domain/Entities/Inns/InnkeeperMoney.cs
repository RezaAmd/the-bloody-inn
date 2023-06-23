using TheBloodyInn.Domain.Entities.Inns.InnAggregate;
using TheBloodyInn.Domain.ValueObjects;

namespace TheBloodyInn.Domain.Entities.Inns;

public class InnkeeperMoney : BaseEntity
{
    #region Constructor

    InnkeeperMoney() { }

    #endregion

    #region Properties

    public FrancCash Cash { get; set; }
    public Franc10CheckMoney CheckMoney { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;

    #endregion

    #region Relations

    public Guid OwnerId { get; set; }
    public Innkeeper Owner { get; set; }

    public Guid InnId { get; set; }
    public Inn Inn { get; set; }

    #endregion
}