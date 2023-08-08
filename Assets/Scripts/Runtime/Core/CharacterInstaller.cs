using System;
using Shooter.Gameplay;
using UnityEngine;
using Zenject;

namespace Shooter.Core
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private CharacterHealthView _healthView;
        
        private IGameLoop _gameLoop;

        [Inject]
        public void Initialize(IGameLoop gameLoop)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }
        
        public override void InstallBindings()
        {
            _gameLoop.AddSystem(new CharacterHealthViewSystem(_healthView));
        }
    }
}