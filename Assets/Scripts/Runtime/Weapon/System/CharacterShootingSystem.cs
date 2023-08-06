using System;
using Scellecs.Morpeh;
using Shooter.Tools;

namespace Shooter.Gameplay
{
    public sealed class CharacterShootingSystem : ISystem
    {
        private readonly ICharacterShootingInput _input;

        private Filter _filter;

        public CharacterShootingSystem(ICharacterShootingInput input)
        {
            _input = input ?? throw new ArgumentNullException(nameof(input));
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

                if (weaponComponent.IsSelected == false || typeComponent.GeneralType.IsStandard() == false)
                    continue;

                if (clipComponent.IsReloading)
                    return;

                if ((weaponComponent.IsBurst && _input.IsShootingBurst) || (!weaponComponent.IsBurst && _input.IsShooting))
                {
                    ref CharacterShotComponent shotComponent = ref entity.AddComponent<CharacterShotComponent>();
                   
                    if (clipComponent.Bullets > 0)
                    {
                        IBullet bullet = weaponComponent.BulletFactory.Create(damageComponent.Damage);
                        bullet.Throw();
                        clipComponent.Bullets--;
                        shotComponent.HasThrewBullet = true;
                    }
                }
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}