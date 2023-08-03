using UnityEngine;

namespace Shooter.Gameplay
{
    public class BulletFactory : MonoBehaviour, IBulletFactory
    {
        [SerializeField] private Bullet _prefab;
        [SerializeField] private Transform _spawnPoint;
        
        public IBullet Create(int damage)
        {
            Bullet bullet = Instantiate(_prefab, _spawnPoint.position, _prefab.transform.rotation);
            Vector3 throwDirection = _spawnPoint.forward;
            
            bullet.Initialize(damage, throwDirection);
            return bullet;
        }
    }
}