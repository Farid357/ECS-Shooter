using Scellecs.Morpeh;
using UniRx;
using UnityEngine;

namespace Shooter.Gameplay
{
    public interface ICharacter
    {
        Entity Entity { get; }
        
        Vector3 Position { get; }
       
        IReadOnlyReactiveProperty<bool> IsAlive { get; }
    }
}