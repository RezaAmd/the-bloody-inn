using TheBloodyInn.Domain.Enum.Cards;
using TheBloodyInn.Domain.Enum.Guests;

namespace TheBloodyInn.Domain.Entities.Guests;

public class GuestEntity : BaseEntity
{
    #region Ctor's

    GuestEntity() { }

    public GuestEntity(string systemName, GuestCategory category, RankType rank = RankType.Zero,
        AmountOfMoneyInPocket moneyInPocket = AmountOfMoneyInPocket.Eight, BuildItemType buildItem = BuildItemType.None)
    {
        SystemName = systemName;
        Category = category;
        Rank = rank;
        MoneyInPocket = moneyInPocket;
        BuildItem = buildItem;
    }

    #endregion

    #region Fields

    public string SystemName { get; set; } = "Unknown";
    public GuestCategory Category { get; set; }
    public RankType Rank { get; set; } = RankType.Zero;
    public BuildItemType BuildItem { get; set; } = BuildItemType.None;
    public AmountOfMoneyInPocket MoneyInPocket { get; set; } = AmountOfMoneyInPocket.Eight;


    #endregion

    #region Relations

    #endregion
}