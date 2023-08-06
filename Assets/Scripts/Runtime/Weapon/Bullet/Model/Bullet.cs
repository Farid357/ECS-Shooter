using Scellecs.Morpeh;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _throwForce;

        private int _damage;
        private Vector3 _direction;

        public void Initialize(int damage, Vector3 direction)
        {
            _direction = direction;
            _damage = damage;
        }

        public void Throw()
        {
            _rigidbody.AddForce(_direction * _throwForce, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HealthProvider healthProvider))
            {
               ref HealthComponent healthComponent = ref healthProvider.Entity.GetComponent<HealthComponent>();
               healthComponent.Health -= _damage;
            }

            Destroy(gameObject);
        }
    }
}