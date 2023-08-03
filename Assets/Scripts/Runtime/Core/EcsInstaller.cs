using Scellecs.Morpeh;
using Zenject;

namespace Shooter.Core
{
    public class EcsInstaller : MonoInstaller
    {
        private World _world;
        private GameLoop _gameLoop;

        public override void InstallBindings()
        {
            _world = World.Default;
            _gameLoop = new GameLoop(_world);
            
            Container.BindInstance(_world).AsSingle();
            Container.BindInterfacesAndSelfTo<GameLoop>().FromInstance(_gameLoop).AsSingle();
        }

        private void OnDestroy()
        {
            _gameLoop.Dispose();
            _world.Dispose();
        }
    }
}