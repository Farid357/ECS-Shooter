using System;
using Shooter.Gameplay;
using UnityEngine;
using Zenject;

namespace Shooter.Core
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private CharacterHealthView _healthView;
        [SerializeField] private Character _character;
        
        private IGameLoop _gameLoop;

        [Inject]
        public void Initialize(IGameLoop gameLoop)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GamePause>().FromInstance(new GamePause(_character)).AsSingle();
            _gameLoop.AddSystem(new CharacterHealthViewSystem(_healthView));
        }
    }
}