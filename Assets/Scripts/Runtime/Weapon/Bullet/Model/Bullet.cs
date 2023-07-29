using UnityEngine;

namespace Shooter.Gameplay
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _throwForce;
        
        private int _damage;

        public void Initialize(int damage)
        {
            _damage = damage;
        }
        
        public void Throw(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _throwForce);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEnemy enemy))
            {
                enemy.TakeDamage(_damage);
            }
            
            Destroy(gameObject);
        }
    }
}