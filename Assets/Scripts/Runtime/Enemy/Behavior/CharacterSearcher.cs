using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Shooter.Gameplay
{
    public class CharacterSearcher : ICharacterSearcher
    {
        private readonly ICharacter _character;
        private readonly Transform _transform;
        private readonly float _distanceToBeNear;

        public CharacterSearcher(Transform transform, float distanceToBeNear)
        {
            _transform = transform ? transform : throw new ArgumentNullException(nameof(transform));
            _distanceToBeNear = distanceToBeNear;
            _character = Object.FindObjectOfType<Character>();
        }

        public bool HasFoundCharacter => SearchedCharacter != null;
        
        public ICharacter SearchedCharacter { get; private set; }
        
        public void Search()
        {
            float distance = (_character.Position - _transform.position).sqrMagnitude;
            SearchedCharacter = distance <= _distanceToBeNear * _distanceToBeNear ? _character : null;
        }
    }
}