using IceFebruary.Space;

public interface IShootingCalculator
{
    Vector2 GetBulletForce(Vector2 direction);
    Vector2 GetRecoilForce(Vector2 direction);
}
