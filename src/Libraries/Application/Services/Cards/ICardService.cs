using TheBloodyInn.Domain.Entities.Guests;

namespace TheBloodyInn.Application.Services.Cards;

public interface ICardService
{
    List<GuestEntity> GetAllGuestPatterns();
}