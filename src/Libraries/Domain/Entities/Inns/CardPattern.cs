using TheBloodyInn.Domain.Enum.Cards;
using TheBloodyInn.Domain.Enum.Guests;

namespace TheBloodyInn.Domain.Entities.Inns;

public class CardPattern
{
    #region Ctor's

    #endregion

    public Guid Id { get; set; } = Guid.NewGuid();
    public GuestCategory Category { get; set; }
    public RankType Rank { get; set; }
    public BuildItemType? BuildItem { get; set; }

    #region Relations

    #endregion
}