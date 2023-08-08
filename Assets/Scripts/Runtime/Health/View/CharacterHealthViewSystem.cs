using System;
using Scellecs.Morpeh;

namespace Shooter.Gameplay
{
    public class CharacterHealthViewSystem : ISystem
    {
        private readonly IHealthView _healthView;

        private Filter _filter;

        public CharacterHealthViewSystem(IHealthView healthView)
        {
            _healthView = healthView ?? throw new ArgumentNullException(nameof(healthView));
        }

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<CharacterComponent>().With<HealthComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref HealthComponent healthComponent = ref entity.GetComponent<HealthComponent>();
                _healthView.Show(healthComponent.Health, healthComponent.MaxHealth);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}