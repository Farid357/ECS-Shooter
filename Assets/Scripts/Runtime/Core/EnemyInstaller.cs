using Shooter.Gameplay;
using UnityEngine;
using Zenject;

namespace Shooter.Core
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyFactory _enemyFactory;

        public override void InstallBindings()
        {
            _enemyFactory.Create();
        }
    }
}