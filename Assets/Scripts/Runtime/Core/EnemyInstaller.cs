using System;
using Shooter.Gameplay;
using UnityEngine;
using Zenject;

namespace Shooter.Core
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private int _startEnemiesCount = 3;
       
        private IGameLoop _gameLoop;

        [Inject]
        public void Initialize(IGameLoop gameLoop)
        {
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }
        
        public override void InstallBindings()
        {
            _enemyFactory.Create(_startEnemiesCount);
            
            _gameLoop.AddSystem(new WaveSystem(_enemyFactory));
        }
    }
}