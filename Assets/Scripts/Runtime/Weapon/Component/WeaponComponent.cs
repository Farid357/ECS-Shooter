using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Shooter.Gameplay
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct WeaponComponent : IComponent
    {
        public GeneralWeaponType GeneralType;
        public ConcreteWeaponType ConcreteType;
        public Transform BulletSpawnPoint;
        public bool IsSelected;
    }
}