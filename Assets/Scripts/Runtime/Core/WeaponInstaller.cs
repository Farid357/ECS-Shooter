using System;
using Scellecs.Morpeh;
using Shooter.Gameplay;
using Shooter.Tools;
using StarterAssets;
using UnityEngine;
using Zenject;

namespace Shooter.Core
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private WeaponFactory _weaponFactory;
        [SerializeField] private ClipView _clipView;
        [SerializeField] private FirstPersonController _personController;
        
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

            Entity entity = _weaponFactory.Create();
            ref WeaponComponent weaponComponent = ref entity.GetComponent<WeaponComponent>();
            ref WeaponTypeComponent typeComponent = ref entity.GetComponent<WeaponTypeComponent>();
            ref ClipComponent clipComponent = ref entity.GetComponent<ClipComponent>();
            
            weaponComponent.IsSelected = true;
            weaponry.Add(clipComponent.MaxBullets * 4, typeComponent.GeneralType);
            
            _gameLoop.AddSystem(new CharacterShootingSystem(shootingInput));
            _gameLoop.AddSystem(new ClipViewSystem(_clipView, weaponry));
            
            _gameLoop.AddSystem(new WeaponRateSystem());
            _gameLoop.AddSystem(new CharacterReloadingSystem(shootingInput, weaponry));
            _gameLoop.AddSystem(new WeaponShootingAnimationSystem());
            _gameLoop.AddSystem(new WeaponMoveAnimationSystem(_personController, shootingInput));
         
            _gameLoop.AddSystem(new CleanupSystem<CharacterShotComponent>());
        }
    }
}