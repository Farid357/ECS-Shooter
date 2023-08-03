namespace Shooter.Gameplay
{
    public interface IWeaponry : IReadOnlyWeaponry
    {
        void Add(int bullets, GeneralWeaponType to);

        void Remove(int bullets, GeneralWeaponType from);
    }
}