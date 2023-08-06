using System;
using Scellecs.Morpeh;
using Shooter.Tools;
using StarterAssets;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class WeaponMoveAnimationSystem : ISystem
    {
        private readonly FirstPersonController _personController;
        private readonly ICharacterShootingInput _shootingInput;

        private readonly int _moving = Animator.StringToHash("Moving");
        private readonly int _idle = Animator.StringToHash("Idle");

        private Filter _filter;
        private Animator _lastAnimator;

        public WeaponMoveAnimationSystem(FirstPersonController personController, ICharacterShootingInput shootingInput)
        {
            _personController = personController ?? throw new ArgumentNullException(nameof(personController));
            _shootingInput = shootingInput ?? throw new ArgumentNullException(nameof(shootingInput));
        }

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<WeaponComponent>().With<AnimatorComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            if (_shootingInput.IsShooting || (_lastAnimator != null && _lastAnimator.GetCurrentAnimatorStateInfo(0).IsName("Recharge")))
            {
                SetStates(false, false);
                return;
            }

            foreach (Entity entity in _filter)
            {
                ref WeaponComponent weaponComponent = ref entity.GetComponent<WeaponComponent>();

                if (weaponComponent.IsSelected == false)
                    continue;

                ref AnimatorComponent animatorComponent = ref entity.GetComponent<AnimatorComponent>();
                _lastAnimator = animatorComponent.Animator;
                SetStates(_personController.IsSprinting, !_personController.IsSprinting);
            }
        }

        private void SetStates(bool moving, bool idle)
        {
            _lastAnimator?.SetBool(_moving, moving);
            _lastAnimator?.SetBool(_idle, idle);
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}