namespace TheBloodyInn.Application.Players
{
    public class HumanPlayer : IPlayerAction
    {
        #region Ctor

        public HumanPlayer()
        {

        }

        #endregion

        public Task BribeGuestAsync(Guid guestId, CancellationToken cancellationToken = default)
        {
            // TODO: Call SignalR or game logic
            throw new NotImplementedException();
        }

        public Task BuildAnnexAsync(Guid annexId, CancellationToken cancellationToken = default)
        {
            // TODO: Call SignalR or game logic
            throw new NotImplementedException();
        }

        public Task BuryBodyAsync(Guid guestId, CancellationToken cancellationToken = default)
        {
            // TODO: Call SignalR or game logic
            throw new NotImplementedException();
        }

        public Task KillGuestAsync(Guid guestId, CancellationToken cancellationToken = default)
        {
            // TODO: Call SignalR or game logic
            throw new NotImplementedException();
        }

        public Task PassTurnAsync(CancellationToken cancellationToken = default)
        {
            // TODO: Call SignalR or game logic
            throw new NotImplementedException();
        }
    }
}
