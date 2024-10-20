using TheBloodyInn.Domain.Entities.Guests;

namespace TheBloodyInn.Application.Players.Strategies
{
    public interface IBotStrategy
    {
        Task PerformActionAsync(BotPlayer bot, List<GuestEntity> availableGuests);
    }
}