namespace TheBloodyInn.Domain.Entities.Players
{
    public class BotEntity : BaseEntity
    {
        public required string Name { get; set; }

        public virtual ICollection<PlayerEntity>? Players { get; set; }
    }
}