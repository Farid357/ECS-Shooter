using UnityEngine;

namespace Shooter.Gameplay
{
    public class BulletFactory : MonoBehaviour, IBulletFactory
    {
        [SerializeField] private Bullet _prefab;
        
        public IBullet Create(int damage, Vector3 position)
        {
            Bullet bullet = Instantiate(_prefab, position, _prefab.transform.rotation);
            bullet.Initialize(damage);
            return bullet;
        }
    }
}