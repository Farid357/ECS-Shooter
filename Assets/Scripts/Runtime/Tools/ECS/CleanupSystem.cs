using System.Linq;
using Scellecs.Morpeh;

namespace Shooter.Tools
{
    public class CleanupSystem<T> : ILateSystem where T : struct, IComponent
    {
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<T>();
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < _filter.Count(); i++)
            {
                _filter.ElementAt(i).RemoveComponent<T>();
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}