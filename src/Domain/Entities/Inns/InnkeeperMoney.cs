using TheBloodyInn.Domain.Entities.Inns.InnAggregate;

namespace TheBloodyInn.Domain.Entities.Inns;

public class InnkeeperMoney
{
    #region Constructor
    InnkeeperMoney() { }
    #endregion

    #region Properties
    public Guid Id { get; set; }
    public FrancCash Cash { get; set; }
    public Franc10CheckMoney CheckMoney { get; set; }
    public DateTime CreatedAt { get; set; }
    #endregion

    #region Relations
    public Guid OwnerId { get; set; }
    public Innkeeper Owner { get; set; }

    public Guid InnId { get; set; }
    public Inn Inn { get; set; }
    #endregion
}