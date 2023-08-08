using UniRx;
using UnityEngine;
using Zenject;

namespace Shooter.Gameplay
{
    public class Score : IScore, ITickable
    {
        private readonly ReactiveProperty<int> _count = new();

        private float _time;

        public IReadOnlyReactiveProperty<int> Count => _count;

        public void Add(int count)
        {
            _count.Value += count;
        }

        public void Tick()
        {
            _time += Time.deltaTime;

            if (_time >= 0.1f)
            {
                Add(1);
                _time = 0f;
            }
        }
    }
}

