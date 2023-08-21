using System;
using System.Linq;
using Scellecs.Morpeh;

namespace Shooter.Gameplay
{
    public class WaveSystem : ISystem
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly Random _random;
        
        private Filter _filter;

        public WaveSystem(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory ? enemyFactory : throw new ArgumentNullException(nameof(enemyFactory));
            _random = new Random();
        }

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<EnemyComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            if (!_filter.Any())
            {
                int enemiesCount = _random.Next(2, 4);
                _enemyFactory.Create(enemiesCount);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}