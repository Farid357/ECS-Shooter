using System;
using Scellecs.Morpeh;
using Shooter.Gameplay;
using Zenject;

namespace Shooter.Core
{
    public class WeaponInstaller : Installer<WeaponFactory, SystemsGroup, WeaponInstaller>
    {
        private readonly WeaponFactory _weaponFactory;
        private readonly SystemsGroup _systemsGroup;

        public WeaponInstaller(WeaponFactory weaponFactory, SystemsGroup systemsGroup)
        {
            _weaponFactory = weaponFactory ?? throw new ArgumentNullException(nameof(weaponFactory));
            _systemsGroup = systemsGroup ?? throw new ArgumentNullException(nameof(systemsGroup));
        }

        public override void InstallBindings()
        {
            ICharacterShootingInput shootingInput = new CharacterShootingInput();
            Entity entity = _weaponFactory.Create();
            ref WeaponComponent weaponComponent = ref entity.GetComponent<WeaponComponent>();
            weaponComponent.IsSelected = true;

            _systemsGroup.AddSystem(new CharacterShootingSystem(_weaponFactory.BulletFactory, shootingInput, true));
        }
    }
}