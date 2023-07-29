using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Shooter.Gameplay
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class CharacterShootingSystem : ISystem
    {
        private readonly IBulletFactory _bulletFactory;
        private readonly ICharacterShootingInput _input;
        private readonly bool _isBurst;
      
        private Filter _filter;

        public CharacterShootingSystem(IBulletFactory bulletFactory, ICharacterShootingInput input, bool isBurst)
        {
            _bulletFactory = bulletFactory ?? throw new ArgumentNullException(nameof(bulletFactory));
            _input = input ?? throw new ArgumentNullException(nameof(input));
            _isBurst = isBurst;
        }

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<WeaponComponent>().With<DamageComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isBurst && _input.IsShootingBurst)
                Shoot();
            
            if(!_isBurst && _input.IsShooting)
                Shoot();
        }

        private void Shoot()
        {
            foreach (Entity entity in _filter)
            {
                ref WeaponComponent weaponComponent = ref entity.GetComponent<WeaponComponent>();
                ref DamageComponent damageComponent = ref entity.GetComponent<DamageComponent>();

                IBullet bullet = _bulletFactory.Create(damageComponent.Damage, weaponComponent.BulletSpawnPoint.position);
                bullet.Throw(weaponComponent.BulletSpawnPoint.forward);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}