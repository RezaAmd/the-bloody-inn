using TheBloodyInn.Domain.Entities.Identity;
using TheBloodyInn.Domain.Entities.Inns.InnAggregate;

namespace TheBloodyInn.Domain.Entities.Inns;

public class Innkeeper
{
    #region Constructor

    #endregion

    public Guid Id { get; set; }
    public RoomKeyColor KeyColor { get; set; }
    public FrancCash Cash { get; set; } // must between 0 - 40
    public byte CheckMoney { get; set; } // x10

    #region Relations
    public Guid PlayerId { get; set; }
    public virtual User Player { get; set; }

    public Guid InnId { get; set; }
    public virtual Inn Inn { get; set; }
    #endregion
}