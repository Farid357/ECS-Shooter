using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace Shooter.Gameplay
{
    [RequireComponent(typeof(HealthProvider))]
    public class Character : MonoProvider<CharacterComponent>, ICharacter
    {
        public Vector3 Position => transform.position;
    }
}