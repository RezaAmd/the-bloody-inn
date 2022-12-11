namespace TheBloodyInn.Domain.Entity.Inns.InnAggregate;

public class Inn
{
    #region Constructors
    Inn() { }

    /// <summary>
    /// Create a new Inn.
    /// </summary>
    /// <param name="InkeeperId">Creator is owner of inn.</param>
    public Inn(Guid InkeeperId, List<InnRoom> rooms = null)
    {
        if (rooms.Count < 3)
            throw new ArgumentOutOfRangeException("At least 4 rooms should be built.");

        GenerateNewId();
        SetCreator(InkeeperId);
        SetState(InnState.Pending);

        CreatedAt = DateTime.Now;

        // Create rooms list.
        Rooms = new List<InnRoom>();
    }
    #endregion

    public Guid Id { get; private set; }
    public InnState State { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string? Setting { get; private set; } // Object model: InnSetting

    #region Relations
    public Guid CreatorId { get; set; }
    public virtual Innkeeper Creator { get; private set; }

    public virtual ICollection<InnRoom> Rooms { get; private set; }
    #endregion

    #region Methods
    /// <summary>
    /// Generate a new id.
    /// </summary>
    void GenerateNewId()
    {
        Id = Guid.NewGuid();
    }

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
    /// <param name="state"></param>
    void SetState(InnState state)
    {
        State = state;
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
        => !string.IsNullOrEmpty(Setting) ?
        InnSetting.MapToObject(Setting) : null;

    public void AddRoom(InnRoom room)
    {
        if (room == null)
            throw new ArgumentNullException("Room cannot be null.");
        if (Rooms.Count >= 8)
            throw new ArgumentOutOfRangeException("More than 8 rooms are not possible.");
        Rooms.Add(room);
    }
    public void AddRoomRange(List<InnRoom> rooms)
    {
        if (Rooms.Count + rooms.Count > 8)
            throw new ArgumentOutOfRangeException("More than 8 rooms are not possible.");
        rooms.ForEach(room => AddRoom(room));
    }
    #endregion
}