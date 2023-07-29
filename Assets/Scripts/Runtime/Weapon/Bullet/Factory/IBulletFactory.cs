using UnityEngine;

namespace Shooter.Gameplay
{
    public interface IBulletFactory
    {
        IBullet Create(int damage, Vector3 position);
    }
}