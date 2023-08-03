using Scellecs.Morpeh;
using UnityEngine;
using Zenject;

namespace Shooter.Core
{
    public class GameLoop : IGameLoop, IInitializable, ITickable, IFixedTickable, ILateTickable
    {
        private readonly SystemsGroup _systemsGroup;
        
        public GameLoop(World world)
        {
            _systemsGroup = world.CreateSystemsGroup();
        }

        public void AddInitializer(IInitializer initializer)
        {
            _systemsGroup.AddInitializer(initializer);
        }

        public void AddSystem(ISystem system)
        {
            _systemsGroup.AddSystem(system);
        }

        public void Initialize()
        {
            _systemsGroup.Initialize();
        }

        public void Tick()
        {
            _systemsGroup.Update(Time.deltaTime);
        }

        public void FixedTick()
        {
            _systemsGroup.FixedUpdate(Time.fixedDeltaTime);
        }

        public void LateTick()
        {
            _systemsGroup.LateUpdate(Time.deltaTime);
        }

        public void Dispose()
        {
            _systemsGroup.Dispose();
        }
    }
}