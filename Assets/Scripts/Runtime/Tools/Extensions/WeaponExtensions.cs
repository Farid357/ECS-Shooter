using Shooter.Gameplay;

namespace Shooter.Tools
{
    public static class WeaponExtensions
    {
        public static bool IsStandard(this GeneralWeaponType weaponType)
        {
            return weaponType is GeneralWeaponType.Rifle or GeneralWeaponType.Pistol or GeneralWeaponType.Shotgun
                or GeneralWeaponType.SG or GeneralWeaponType.SniperRifle or GeneralWeaponType.Explosive;
        }
    }
}