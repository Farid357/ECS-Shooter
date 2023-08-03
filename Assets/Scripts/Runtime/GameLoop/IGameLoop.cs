using Scellecs.Morpeh;

namespace Shooter.Core
{
    public interface IGameLoop
    {
        void AddInitializer(IInitializer initializer);
        
        void AddSystem(ISystem system);
    }
}