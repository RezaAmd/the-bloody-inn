﻿using TheBloodyInn.Domain.Entities.Identity;
using TheBloodyInn.Domain.Entities.Inns.InnAggregate;
using TheBloodyInn.Domain.ValueObjects;

namespace TheBloodyInn.Domain.Entities.Inns;

public class Innkeeper : BaseEntity
{
    #region Constructor

    #endregion

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