using TheBloodyInn.Domain.Entities.Identity;

namespace TheBloodyInn.Application.Players
{
    public interface IPlayerAction
    {
        void Execute(UserEntity player);
    }
    public interface IBribeAction : IPlayerAction { }
    public interface IKillAction : IPlayerAction { }
    public interface IBuildAnnexAction : IPlayerAction { }
    public interface IBuryAction : IPlayerAction { }
}