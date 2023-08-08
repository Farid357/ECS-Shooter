namespace Shooter.Gameplay
{
    public interface ICharacterSearcher
    {
        bool HasFoundCharacter { get; }
        
        ICharacter SearchedCharacter { get; }
        
        void Search();
    }
}