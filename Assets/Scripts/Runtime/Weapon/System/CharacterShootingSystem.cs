using System;
using Scellecs.Morpeh;
using Shooter.Tools;

namespace Shooter.Gameplay
{
    public sealed class CharacterShootingSystem : ISystem
    {
        private readonly ICharacterShootingInput _input;
        private readonly IWeaponry _weaponry;

        private Filter _filter;

        public CharacterShootingSystem(ICharacterShootingInput input, IWeaponry weaponry)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
            _weaponry = weaponry ?? throw new ArgumentNullException(nameof(weaponry));
        }

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<WeaponComponent>().With<DamageComponent>().With<WeaponTypeComponent>().With<ClipComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            TryShoot();
        }

        private void TryShoot()
        {
            foreach (Entity entity in _filter)
            {
                ref WeaponComponent weaponComponent = ref entity.GetComponent<WeaponComponent>();
                ref DamageComponent damageComponent = ref entity.GetComponent<DamageComponent>();
                ref ClipComponent clipComponent = ref entity.GetComponent<ClipComponent>();
                ref WeaponTypeComponent typeComponent = ref entity.GetComponent<WeaponTypeComponent>();
                
                if (clipComponent.Bullets == 0 || clipComponent.IsReloading)
                    return;

                if (typeComponent.GeneralType.IsStandard() == false)
                    return;
                
                if (weaponComponent.IsSelected == false)
                    return;

                if ((weaponComponent.IsBurst && _input.IsShootingBurst) || (!weaponComponent.IsBurst && _input.IsShooting))
                {
                    IBullet bullet = weaponComponent.BulletFactory.Create(damageComponent.Damage);
                    bullet.Throw();
                    clipComponent.Bullets--;
                    _weaponry.Remove(bullets: 1, typeComponent.GeneralType);
                }
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}