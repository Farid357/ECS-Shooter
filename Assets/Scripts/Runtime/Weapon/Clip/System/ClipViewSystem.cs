using System;
using Scellecs.Morpeh;

namespace Shooter.Gameplay
{
    public class ClipViewSystem : ISystem
    {
        private readonly ClipView _view;
        private readonly IReadOnlyWeaponry _weaponry;

        private Filter _filter;
        
        public ClipViewSystem(ClipView view, IReadOnlyWeaponry weaponry)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _weaponry = weaponry ?? throw new ArgumentNullException(nameof(weaponry));
        }

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<ClipComponent>().With<WeaponComponent>().With<WeaponTypeComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref WeaponComponent weaponComponent = ref entity.GetComponent<WeaponComponent>();
                ref ClipComponent clipComponent = ref entity.GetComponent<ClipComponent>();
                ref WeaponTypeComponent typeComponent = ref entity.GetComponent<WeaponTypeComponent>();
                
                if (weaponComponent.IsSelected == false)
                    continue;
                
                _view.Show(clipComponent.Bullets, _weaponry.GetBullets(typeComponent.GeneralType));
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}