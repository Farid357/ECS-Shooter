using Scellecs.Morpeh;
using Shooter.Tools;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class WeaponShootingAnimationSystem : ISystem
    {
        private readonly int _shotId = Animator.StringToHash("Shot");
        
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<CharacterShotComponent>().With<AnimatorComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref CharacterShotComponent shotComponent = ref entity.GetComponent<CharacterShotComponent>();

                if (!shotComponent.HasThrewBullet)
                    return;
                
                ref AnimatorComponent animatorComponent = ref entity.GetComponent<AnimatorComponent>();
                animatorComponent.Animator.Play(_shotId);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}