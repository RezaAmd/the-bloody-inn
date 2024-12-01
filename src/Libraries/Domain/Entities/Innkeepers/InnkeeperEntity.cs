using TheBloodyInn.Domain.Entities.Inns;
using TheBloodyInn.Domain.Entities.Players;

namespace TheBloodyInn.Domain.Entities.Innkeepers;

public class InnkeeperEntity : BaseEntity
{
    public InnkeeperColor? ColorId { get; set; }
    public FrancCash Cash { get; set; } = FrancCash.CreateNew(0); // must between 0 - 40
    public Franc10CheckMoney CheckMoney { get; set; } = Franc10CheckMoney.CreateNewInstance(0); // x10
    public PlayerType PlayerTypeId { get; set; } = PlayerType.User;
    public Guid PlayerId { get; set; }

    #region Relations

    public Guid InnId { get; set; }
    public virtual InnEntity? Inn { get; set; }
    #endregion

    #region Ctor

    InnkeeperEntity() { }
    public InnkeeperEntity(Guid playerId, PlayerType playerTypeId)
    {
        PlayerId = playerId;
        PlayerTypeId = playerTypeId;
    }

    #endregion

    #region Methods

    public void SetColor(InnkeeperColor colorId, byte cash, byte checkMoney)
    {
        ColorId = colorId;

        if (cash < 0)
            throw new ArgumentOutOfRangeException("Cash cannot be less than 0.");
        Cash = FrancCash.CreateNew(cash);

        if (checkMoney < 0)
            throw new ArgumentOutOfRangeException("Check money cannot be less than 0.");
        CheckMoney = Franc10CheckMoney.CreateNewInstance(checkMoney);
    }

    #endregion
}