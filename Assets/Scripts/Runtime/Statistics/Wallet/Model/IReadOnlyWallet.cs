using UniRx;

namespace Shooter.Gameplay
{
    public interface IReadOnlyWallet
    {
        IReactiveProperty<int> Money { get; }
        
        bool CanTake(int money);
    }
}