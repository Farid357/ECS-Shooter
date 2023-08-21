using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class DestroyGameObjectOnLowHealth : EntityProvider
    {
        [SerializeField, Tooltip("If false just deactivates")]
        private bool _destroy = true;

        private void Update()
        {
            ref HealthComponent healthComponent = ref Entity.GetComponent<HealthComponent>();

            if (healthComponent.Health <= 0)
            {
                if (_destroy)
                {
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}