using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Shooter.Gameplay
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyProvider _enemyPrefab;
        [SerializeField] private Transform[] _spawnPoints;
        
        public void Create(int count)
        {
            List<Transform> spawnPoints = _spawnPoints.ToList();
            
            for (int i = 0; i < count; i++)
            {
                Transform randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
                EnemyProvider enemy = Instantiate(_enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
                spawnPoints.Remove(randomSpawnPoint);
            }
        }
    }
}