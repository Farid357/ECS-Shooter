using Sirenix.OdinInspector;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class MovementWithAnimation : SerializedMonoBehaviour, IMovement
    {
        [SerializeField] private IMovement _movement;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _walkingBool = "IsWalking";
        
        public Vector3 Position => _movement.Position;

        public void Move(Vector3 direction)
        {
            _animator.SetBool(_walkingBool, direction != Vector3.zero);
            _movement.Move(direction);
        }
    }
}