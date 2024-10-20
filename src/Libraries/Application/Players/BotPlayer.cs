using TheBloodyInn.Domain.Entities.Guests;

namespace TheBloodyInn.Application.Players
{
    public abstract class BotPlayer : IPlayerAction
    {
        public abstract Task KillGuestAsync(Guid guestId);
        public abstract Task BribeGuestAsync(Guid guestId);
        public abstract Task BuildAnnexAsync(Guid annexId);
        public abstract Task BuryBodyAsync(Guid guestId);
        public abstract Task PassTurnAsync();
        protected GuestEntity SelectTargetGuest(List<GuestEntity> availableGuests)
        {
            // TODO: Base logic for target selection (common to all bots)
            return default;
        }
    }
}
