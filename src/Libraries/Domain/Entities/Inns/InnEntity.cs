using TheBloodyInn.Domain.Entities.Guests;
using TheBloodyInn.Domain.Entities.Innkeepers;

namespace TheBloodyInn.Domain.Entities.Inns;

public class InnEntity : BaseEntity
{
    public byte MaxPlayerCount { get; set; }
    public InnState StateId { get; private set; } = InnState.Preparing;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public string? Setting { get; private set; } // Object model: InnSetting

    #region Relations

    public Guid CreatorId { get; set; }
    public virtual InnkeeperEntity? Creator { get; private set; }
    public List<GuestCardEntity> IncomingGuests { get; set; }
    public virtual ICollection<InnRoomEntity>? Rooms { get; private set; } = new List<InnRoomEntity>();

    #endregion

    #region Ctor

    InnEntity() { }
    /// <summary>
    /// Create a new Inn.
    /// </summary>
    /// <param name="creatorId">Creator is owner of inn.</param>
    public InnEntity(Guid creatorId)
    {
        SetCreator(creatorId);
        SetState(InnState.Preparing);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Set a creator by innkeeper id.
    /// </summary>
    /// <param name="creatorId">Innkeeper id</param>
    void SetCreator(Guid creatorId)
    {
        CreatorId = creatorId;
    }

    /// <summary>
    /// Set new state for inn.
    /// </summary>
    /// <param name="stateId"></param>
    void SetState(InnState stateId)
    {
        StateId = stateId;
    }

    /// <summary>
    /// Update inn setting.
    /// </summary>
    /// <param name="setting"></param>
    public void UpdateSetting(InnSetting setting)
    {
        Setting = setting.ToString();
    }

    /// <summary>
    /// Read inn setting and map to object.
    /// </summary>
    public InnSetting? GetSettingObject()
        => string.IsNullOrEmpty(Setting) ? null :
        InnSetting.MapToObject(Setting);

    public void AddRoom(InnRoomEntity room)
    {
        if (Rooms == null)
            Rooms = new List<InnRoomEntity>();

        if (Rooms.Count >= 8)
            throw new ArgumentOutOfRangeException("More than 8 rooms are not possible.");

        Rooms.Add(room);
    }
    public void AddRoomRange(List<InnRoomEntity> rooms)
    {
        if (Rooms == null)
            Rooms = new List<InnRoomEntity>();

        if (Rooms.Count + rooms.Count > 8)
            throw new ArgumentOutOfRangeException("More than 8 rooms are not possible.");
        Rooms = rooms;
    }

    #endregion
}