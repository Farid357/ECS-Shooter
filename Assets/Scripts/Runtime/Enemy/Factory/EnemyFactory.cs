using UnityEngine;
using Random = UnityEngine.Random;

namespace Shooter.Gameplay
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Transform[] _spawnPoints;
        
        public IEnemy Create()
        {
            Vector3 position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
            IEnemy enemy = Instantiate(_enemy, position, Quaternion.identity);
            return enemy;
        }
    }
}