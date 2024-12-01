using TheBloodyInn.Domain.Entities.Identities;

namespace TheBloodyInn.Domain.Entities.Players
{
    public class PlayerEntity : BaseEntity
    {
        public Guid? UserId { get; set; }
        public Guid? BotId { get; set; }

        #region Relations
        
        public virtual UserEntity? User { get; set; }
        public virtual BotPlayerEntity? Bot { get; set; }

        #endregion
    }
}