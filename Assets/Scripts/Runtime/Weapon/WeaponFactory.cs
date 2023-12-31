using Scellecs.Morpeh;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class WeaponFactory : MonoBehaviour
    {
        [SerializeField] private WeaponProvider _weaponPrefab;
        [SerializeField] private Transform _spawnPoint;

        public Entity Create()
        {
            WeaponProvider weapon = Instantiate(_weaponPrefab, _spawnPoint.position, Quaternion.identity, _spawnPoint.transform);
            return weapon.Entity;
        }
    }
}