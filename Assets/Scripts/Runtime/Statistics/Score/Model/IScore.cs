using UniRx;

namespace Shooter.Gameplay
{
    public interface IScore
    {
        IReadOnlyReactiveProperty<int> Count { get; }

        void Add(int count);
    }
}