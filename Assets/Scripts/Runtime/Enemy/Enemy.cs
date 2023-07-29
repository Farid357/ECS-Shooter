using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;

namespace Shooter.Gameplay
{
    public class Enemy : MonoProvider<EnemyComponent>, IEnemy
    {
        public void TakeDamage(int damage)
        {
           ref HealthComponent healthComponent = ref Entity.GetComponent<HealthComponent>();
           healthComponent.Health -= damage;
           
           if(healthComponent.Health <= 0)
               Destroy(gameObject);
        }
    }
}