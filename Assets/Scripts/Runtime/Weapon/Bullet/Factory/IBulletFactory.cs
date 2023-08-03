namespace Shooter.Gameplay
{
    public interface IBulletFactory
    {
        IBullet Create(int damage);
    }
}