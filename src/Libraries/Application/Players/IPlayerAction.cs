namespace TheBloodyInn.Application.Players
{
    public interface IPlayerAction : IBribeAction, IKillAction, IBuildAnnexAction, IBuryAction
    {
    }

    public interface IBribeAction
    {
        Task BribeGuestAsync(Guid guestId, CancellationToken cancellationToken = default);
    }

    public interface IKillAction
    {
        Task KillGuestAsync(Guid guestId, CancellationToken cancellationToken = default);
    }

    public interface IBuildAnnexAction
    {
        Task BuildAnnexAsync(Guid annexId, CancellationToken cancellationToken = default);
    }

    public interface IBuryAction
    {
        Task BuryBodyAsync(Guid guestId, CancellationToken cancellationToken = default);
    }

    public interface IPassAction
    {
        Task PassTurnAsync(CancellationToken cancellationToken = default);
    }
}