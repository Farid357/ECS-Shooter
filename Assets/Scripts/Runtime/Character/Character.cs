using Scellecs.Morpeh.Providers;
using UniRx;
using UnityEngine;

namespace Shooter.Gameplay
{
    [RequireComponent(typeof(HealthProvider))]
    public class Character : MonoProvider<CharacterComponent>, ICharacter
    {
        private readonly ReactiveProperty<bool> _isAlive = new(true);

        public Vector3 Position => transform.position;

        public IReadOnlyReactiveProperty<bool> IsAlive => _isAlive;

        protected override void OnDisable()
        {
            base.OnDisable();
            _isAlive.Value = false;
        }
    }
}