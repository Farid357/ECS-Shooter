using Scellecs.Morpeh;
using Zenject;

namespace Shooter.Core
{
    public class EcsInstaller : MonoInstaller
    {
        private World _world;

        public override void InstallBindings()
        {
            _world = World.Default;
            IGameLoop gameLoop = Container.Instantiate<GameLoop>();
            
            Container.BindInstance(_world).AsSingle();
            Container.BindInstance(gameLoop).AsSingle();
        }

        private void OnDestroy()
        {
            _world.Dispose();
        }
    }
}