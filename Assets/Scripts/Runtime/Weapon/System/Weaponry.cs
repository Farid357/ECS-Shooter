using System;
using System.Collections.Generic;
using System.Linq;

namespace Shooter.Gameplay
{
    public sealed class Weaponry : IWeaponry
    {
        private readonly Dictionary<GeneralWeaponType, int> _bullets;

        public Weaponry()
        {
            var weaponTypes = Enum.GetValues(typeof(GeneralWeaponType)).Cast<GeneralWeaponType>().ToList();
            _bullets = weaponTypes.ToDictionary(weaponType => weaponType, _ => 0);
        }

        public int GetBullets(GeneralWeaponType weaponType)
        {
            return _bullets[weaponType];
        }

        public void Add(int bullets, GeneralWeaponType to)
        {
            if (_bullets.ContainsKey(to) == false)
                throw new InvalidOperationException($"Dictionary doesn't contain type: {to.ToString()}");

            _bullets[to] += bullets;
        }

        public void Remove(int bullets, GeneralWeaponType from)
        {
            if (_bullets.ContainsKey(from) == false)
                throw new InvalidOperationException($"Dictionary doesn't contain type: {from.ToString()}");

            _bullets[from] -= bullets;
        }
    }
}