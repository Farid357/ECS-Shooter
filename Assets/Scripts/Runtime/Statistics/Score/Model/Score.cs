using UniRx;

namespace Shooter.Gameplay
{
    public class Score : IScore
    {
        private readonly ReactiveProperty<int> _count = new();

        public IReadOnlyReactiveProperty<int> Count => _count;
        
        public void Add(int count)
        {
            _count.Value += count;
        }
    }
}