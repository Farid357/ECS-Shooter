using UnityEngine;

namespace Shooter.Tools
{
    public class ObjectLifetime : MonoBehaviour
    {
        [SerializeField] private float _secondsToDestroy = 5f;

        private void OnEnable()
        {
            Destroy(gameObject, _secondsToDestroy);
        }
    }
}
