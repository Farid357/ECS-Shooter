using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;

namespace Shooter.Gameplay
{
    public class DestroyGameObjectOnLowHealth : EntityProvider
    {
        private void Update()
        {
            ref HealthComponent healthComponent = ref Entity.GetComponent<HealthComponent>();
           
            if(healthComponent.Health <= 0)
                Destroy(gameObject);
        }
    }
}