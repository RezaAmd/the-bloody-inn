using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBloodyInn.Application.Players
{
    public class HumanPlayer : IPlayerAction
    {
        #region Ctor

        public HumanPlayer()
        {
            
        }

        #endregion

        public Task BribeGuestAsync(Guid guestId)
        {
            // TODO: Call SignalR or game logic
            throw new NotImplementedException();
        }

        public Task BuildAnnexAsync(Guid annexId)
        {
            // TODO: Call SignalR or game logic
            throw new NotImplementedException();
        }

        public Task BuryBodyAsync(Guid guestId)
        {
            // TODO: Call SignalR or game logic
            throw new NotImplementedException();
        }

        public Task KillGuestAsync(Guid guestId)
        {
            // TODO: Call SignalR or game logic
            throw new NotImplementedException();
        }

        public Task PassTurnAsync()
        {
            // TODO: Call SignalR or game logic
            throw new NotImplementedException();
        }
    }
}
