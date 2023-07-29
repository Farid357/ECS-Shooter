using Scellecs.Morpeh;
using Shooter.Gameplay;
using UnityEngine;
using Zenject;

namespace Shooter.Core
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private WeaponFactory _startWeaponFactory;
        [SerializeField] private EnemyFactory _enemyFactory;
        
        private SystemsGroup _systemsGroup;
        private World _world;

        public override void InstallBindings()
        {
            _world = World.Default;
            _systemsGroup = _world.CreateSystemsGroup();
            _enemyFactory.Create();
            
            Container.BindInstance(_world).AsSingle();
            Container.BindInstance(_startWeaponFactory).AsSingle();
            
            WeaponInstaller.Install(Container, _startWeaponFactory, _systemsGroup);
        }

        public override void Start()
        {
            _systemsGroup.Initialize();
        }

        private void Update()
        {
            _systemsGroup.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _systemsGroup.FixedUpdate(Time.fixedDeltaTime);
        }

        private void LateUpdate()
        {
            _systemsGroup.LateUpdate(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _systemsGroup.Dispose();
            _world.Dispose();
        }
    }
}