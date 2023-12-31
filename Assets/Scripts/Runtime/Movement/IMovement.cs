using UnityEngine;

namespace Shooter.Gameplay
{
    public interface IMovement
    {
        Vector3 Position { get; }
        
        void Move(Vector3 direction);
    }
}