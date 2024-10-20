namespace TheBloodyInn.Domain.Entities.Players
{
    public class PlayerEntity : BaseEntity
    {
        public Guid? UserId { get; set; }
        public Guid? BotId { get; set; }

        #region Relations
        
        public virtual UserEntity? User { get; set; }
        public virtual BotEntity? Bot { get; set; }

        #endregion
    }
}