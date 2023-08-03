using System;
using Scellecs.Morpeh;
using Shooter.Tools;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class CharacterReloadingSystem : ISystem
    {
        private readonly ICharacterShootingInput _shootingInput;
        private readonly IWeaponry _weaponry;
        private readonly int _recharge = Animator.StringToHash("Recharge");

        private Filter _filter;
        private float _playAnimationSeconds;

        public CharacterReloadingSystem(ICharacterShootingInput shootingInput, IWeaponry weaponry)
        {
            _shootingInput = shootingInput ?? throw new ArgumentNullException(nameof(shootingInput));
            _weaponry = weaponry ?? throw new ArgumentNullException(nameof(weaponry));
        }

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<ClipComponent>().With<AnimatorComponent>().With<WeaponTypeComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref ClipComponent clipComponent = ref entity.GetComponent<ClipComponent>();
                ref AnimatorComponent animatorComponent = ref entity.GetComponent<AnimatorComponent>();
                ref WeaponTypeComponent typeComponent = ref entity.GetComponent<WeaponTypeComponent>();
                int bulletsInWeaponry = _weaponry.GetBullets(typeComponent.GeneralType);

                if (bulletsInWeaponry == 0)
                    return;

                if (_playAnimationSeconds > 0)
                {
                    _playAnimationSeconds = Math.Max(0, _playAnimationSeconds - deltaTime);

                    if (_playAnimationSeconds == 0)
                    {
                        int difference = clipComponent.MaxBullets - clipComponent.Bullets;
                        int reloadBullets = bulletsInWeaponry >= difference ? difference : bulletsInWeaponry;

                        clipComponent.Bullets += reloadBullets;
                        _weaponry.Remove(reloadBullets, typeComponent.GeneralType);
                    }
                }

                if ((clipComponent.Bullets == 0 && _shootingInput.IsShooting) || _shootingInput.IsReloading)
                {
                    clipComponent.IsReloading = true;
                    animatorComponent.Animator.Play(_recharge);
                    _playAnimationSeconds = animatorComponent.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
                }
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}