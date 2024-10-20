using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBloodyInn.Domain.Entities.Guests;

namespace TheBloodyInn.Application.Players.Strategies
{
    public class EasyBotStrategy : IBotStrategy
    {
        public async Task PerformActionAsync(BotPlayer bot, List<GuestEntity> availableGuests)
        {
            // Easy bot logic (random simple actions)
            var targetGuest = availableGuests.First();  // Randomly select guest
            await bot.KillGuestAsync(targetGuest.Id);
        }
    }
}
