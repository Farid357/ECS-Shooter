namespace Shooter.Gameplay
{
    public interface ICharacterShootingInput
    {
        bool IsShootingBurst { get; }
        
        bool IsShooting { get; }
    }
}