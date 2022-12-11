using TheBloodyInn.Domain.Enum.Cards;
using TheBloodyInn.Domain.Enum.Guests;

namespace TheBloodyInn.Domain.Entity.Inns.CardAggregate;

public class CardPattern
{
    #region Ctor's

    #endregion

    #region Props
    public Guid Id { get; set; }
    public GuestCategory Category { get; set; }
    public RankType Rank { get; set; }
    public BuildItemType? BuildItem { get; set; }
    #endregion

    #region Relations

    #endregion
}