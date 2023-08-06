using Scellecs.Morpeh;
using Zenject;

namespace Shooter.Core
{
    public class EcsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            World world = World.Default;
            var gameLoop = new GameLoop(world);
            
            Container.BindInstance(world).AsSingle();
            Container.BindInterfacesAndSelfTo<GameLoop>().FromInstance(gameLoop).AsSingle();
        }
    }
}