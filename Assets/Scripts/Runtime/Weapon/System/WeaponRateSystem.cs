using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;

namespace Shooter.Gameplay
{
    public class WeaponRateSystem : ISystem
    {
        private readonly Dictionary<Entity, float> _rateSeconds = new();

        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<CharacterShotComponent>().With<WeaponRateComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < _rateSeconds.Keys.Count; i++)
            {
                Entity entity = _rateSeconds.Keys.ElementAt(i);
                _rateSeconds[entity] -= deltaTime;

                if (_rateSeconds[entity] <= 0)
                {
                    _rateSeconds.Remove(entity);
                    entity.RemoveComponent<WeaponRateBlockComponent>();
                }
            }

            foreach (var entity in _filter.Where(entity => entity.GetComponent<CharacterShotComponent>().HasThrewBullet))
            {
                entity.AddComponent<WeaponRateBlockComponent>();
                ref WeaponRateComponent rateComponent = ref entity.GetComponent<WeaponRateComponent>();
                _rateSeconds.Add(entity, rateComponent.RateInSeconds);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}