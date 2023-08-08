using Scellecs.Morpeh;
using UnityEngine;

namespace Shooter.Gameplay
{
    public interface ICharacter
    {
        Entity Entity { get; }
        
        Vector3 Position { get; }
    }
}