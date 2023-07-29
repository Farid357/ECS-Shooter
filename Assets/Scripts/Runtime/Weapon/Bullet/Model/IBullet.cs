using UnityEngine;

namespace Shooter.Gameplay
{
    public interface IBullet
    {
        void Throw(Vector3 direction);
    }
}