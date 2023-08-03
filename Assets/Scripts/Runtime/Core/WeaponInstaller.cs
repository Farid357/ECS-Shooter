using System;
using Scellecs.Morpeh;
using Shooter.Gameplay;
using UnityEngine;
using Zenject;

namespace Shooter.Core
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private WeaponFactory _weaponFactory;
        
        private IGameLoop _gameLoop;

        [Inject]
        public void Initialize(IGameLoop gameLoop)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }
        
        public override void InstallBindings()
        {
            IWeaponry weaponry = new Weaponry();
            ICharacterShootingInput shootingInput = new CharacterShootingInput();

            Container.BindInstance(shootingInput).AsSingle();
            Container.BindInstance(weaponry).AsSingle();
            
            Entity entity = _weaponFactory.Create();
            ref WeaponComponent weaponComponent = ref entity.GetComponent<WeaponComponent>();
            ref WeaponTypeComponent typeComponent = ref entity.GetComponent<WeaponTypeComponent>();
            ref ClipComponent clipComponent = ref entity.GetComponent<ClipComponent>();
            
            weaponComponent.IsSelected = true;
            weaponry.Add(clipComponent.MaxBullets, typeComponent.GeneralType);
            
            ISystem shootingSystem = Container.Instantiate<CharacterShootingSystem>();
            ISystem reloadingSystem = Container.Instantiate<CharacterReloadingSystem>();
            
            _gameLoop.AddSystem(shootingSystem);
            _gameLoop.AddSystem(reloadingSystem);
        }
    }
}