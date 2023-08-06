using Scellecs.Morpeh;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Shooter.Gameplay
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyProvider _enemy;
        [SerializeField] private Transform[] _spawnPoints;
        
        public Entity Create()
        {
            Vector3 position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
            EnemyProvider enemy = Instantiate(_enemy, position, Quaternion.identity);
            return enemy.Entity;
        }
    }
}