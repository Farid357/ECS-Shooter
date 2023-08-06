using Scellecs.Morpeh.Providers;
using Unity.IL2CPP.CompilerServices;

namespace Shooter.Gameplay
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class EnemyProvider : MonoProvider<EnemyComponent>
    {
    }
}