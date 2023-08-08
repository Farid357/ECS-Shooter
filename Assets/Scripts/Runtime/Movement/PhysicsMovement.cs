using UnityEngine;

namespace Shooter.Gameplay
{
    public class PhysicsMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed = 2.4f;

        public Vector3 Position => _rigidbody.position;

        public void Move(Vector3 direction)
        {
            _rigidbody.MovePosition(Position + direction * _speed * Time.fixedDeltaTime);
        }
    }
}