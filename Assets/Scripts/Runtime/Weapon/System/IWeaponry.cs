namespace Shooter.Gameplay
{
    public interface IWeaponry
    {
        int GetBullets(GeneralWeaponType weaponType);
        
        void Add(int bullets, GeneralWeaponType to);

        void Remove(int bullets, GeneralWeaponType from);
    }
}