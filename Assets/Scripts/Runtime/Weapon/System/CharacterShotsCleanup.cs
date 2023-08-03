using System.Linq;
using Scellecs.Morpeh;

namespace Shooter.Gameplay
{
    public class CharacterShotsCleanup : ILateSystem
    {
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<CharacterShotComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < _filter.Count(); i++)
            {
                _filter.ElementAt(i).RemoveComponent<CharacterShotComponent>();
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}