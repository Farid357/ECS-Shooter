using Scellecs.Morpeh.Providers;
using Shooter.Tools;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Shooter.Gameplay
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [RequireComponent(typeof(WeaponTypeProvider), typeof(ClipProvider), typeof(DamageProvider))]
    [RequireComponent(typeof(AnimatorProvider))]
    public sealed class WeaponProvider : MonoProvider<WeaponComponent>
    {
    }
}