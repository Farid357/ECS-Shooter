using System;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class CharacterSearcher : ICharacterSearcher
    {
        private readonly Transform _transform;
        private readonly float _distanceToBeNear;
        private readonly Collider[] _results;

        public CharacterSearcher(Transform transform, float distanceToBeNear)
        {
            _transform = transform ? transform : throw new ArgumentNullException(nameof(transform));
            _distanceToBeNear = distanceToBeNear;
            _results = new Collider[100];
        }

        public bool HasFoundCharacter => SearchedCharacter != null;

        public ICharacter SearchedCharacter { get; private set; }

        public void Search()
        {
            SearchedCharacter = null;
            int size = Physics.OverlapSphereNonAlloc(_transform.position, _distanceToBeNear, _results);
        
            for (int i = 0; i < size; i++)
            {
                if (_results[i].gameObject.activeInHierarchy && _results[i].TryGetComponent(out ICharacter character))
                    SearchedCharacter = character;
            }
        }
    }
}